using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;
using ZXing;
using ZXing.Common;

namespace QLThuQuan.Winforms
{
    public partial class CheckInForm : Form
    {
        private readonly IUserService _userService;
        private readonly ICheckInsService _checkInsService;

        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoSource;
        private BarcodeReaderGeneric _barcodeReader;
        private bool _isScanning;
        private DateTime _lastScanTime = DateTime.MinValue;

        public CheckInForm(IUserService userService, ICheckInsService checkInsService)
        {
            InitializeComponent();
            _userService = userService;
            _checkInsService = checkInsService;

            // Khởi tạo BarcodeReader với cấu hình tối ưu cho QR code
            _barcodeReader = new BarcodeReaderGeneric()
            {
                AutoRotate = true,
                Options = new DecodingOptions
                {
                    PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE },
                    TryHarder = true
                }
            };

            // Kiểm tra camera khi khởi tạo
            CheckCameraAvailable();
        }

        private bool CheckCameraAvailable()
        {
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            btnStartCamera.Enabled = _videoDevices.Count > 0;
            return btnStartCamera.Enabled;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userService.GetUserByEmailAsync(email);
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void StartCamera()
        {
            if (_videoDevices.Count == 0)
            {
                MessageBox.Show("Không tìm thấy camera nào!");
                return;
            }
            _videoSource = new VideoCaptureDevice(_videoDevices[0].MonikerString);
            _videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            _videoSource.Start();
            _isScanning = true;
            btnStartCamera.Enabled = false;
            btnStopCamera.Enabled = true;
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (!_isScanning || pbCamera.IsDisposed)
                return;

            //// Kiểm tra tần suất quét (1 giây/lần)
            if ((DateTime.Now - _lastScanTime).TotalMilliseconds < 1000)
                return;

            //// Cập nhật thời gian quét cuối
            _lastScanTime = DateTime.Now;

            try
            {
                using (var frame = (Bitmap)eventArgs.Frame.Clone())
                {
                    Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                    pbCamera.Image = (Bitmap)bitmap.Clone(); // Hiển thị lên PictureBox
                    pbCamera.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Quét QR code
                    var result = DecodeQrCode(frame);
                    if (result != null)
                    {
                        _lastScanTime = DateTime.Now;
                        this.Invoke(new Action(() => ProcessQRCodeResult(result)));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi xử lý frame: {ex.Message}");
            }
        }

        private string DecodeQrCode(Bitmap frame)
        {
            try
            {
                var luminanceSource = new RGBLuminanceSource(ConvertToBytes(frame), frame.Width, frame.Height);
                var result = _barcodeReader.Decode(luminanceSource);
                return result?.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi quét QR: {ex.Message}");
                return null;
            }
        }

        // Hàm hỗ trợ chuyển Bitmap sang byte[]
        private byte[] ConvertToBytes(Bitmap bitmap)
        {
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
            try
            {
                var length = bitmapData.Stride * bitmapData.Height;
                var bytes = new byte[length];
                Marshal.Copy(bitmapData.Scan0, bytes, 0, length);
                return bytes;
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }

        private async void ProcessQRCodeResult(string qrText)
        {
            try
            {
                if (string.IsNullOrEmpty(qrText))
                    return;

                var userChecked = await _userService.GetUserByEmailAsync(qrText);
                if (userChecked != null)
                {
                    txtEmail.Text = userChecked.Email;
                    txtFirstName.Text = userChecked.FirstName;
                    txtLastName.Text = userChecked.LastName;

                    // Check violation of user have ?
                    bool violationOfUser = await _checkInsService.checkViolationOfUserIsActive(userChecked.Email);

                    if (violationOfUser)
                    {
                        MessageBox.Show("Người dùng hiện đang bị cấm!");
                        return;
                    }

                    CheckIns checkUserInThuQuan = await _checkInsService.CheckOut(qrText);

                    if (checkUserInThuQuan != null)
                    {
                        MessageBox.Show("Check-out thành công từ QR code!");
                    }
                    else
                    {
                        var checkIns = new CheckIns
                        {
                            User = userChecked,
                            CheckIn = DateTime.Now,
                        };

                        await _checkInsService.AddCheckInAsync(checkIns);
                        MessageBox.Show("Check-in thành công từ QR code!");
                    }
                    //StopCamera();
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy người dùng với email: {qrText}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xử lý QR code: {ex.Message}");
            }
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            StopCamera();
        }

        private void StopCamera()
        {
            //_isScanning = false;

            //if (_videoSource != null)
            //{
            //    if (_videoSource.IsRunning)
            //    {
            //        _videoSource.SignalToStop();
            //        _videoSource.WaitForStop();
            //    }
            //    _videoSource.NewFrame -= VideoSource_NewFrame;
            //    _videoSource = null;
            //}

            //pbCamera.Image = null;
            //btnStartCamera.Enabled = true;
            //btnStopCamera.Enabled = false;
            if (_videoSource != null && _videoSource.IsRunning)
            {
                _videoSource.SignalToStop();
                _videoSource.WaitForStop();
            }
            btnStartCamera.Enabled = true;
            btnStopCamera.Enabled = false;
        }

        private async void btnEnter_Click(object sender, EventArgs e)
        {
            var emailEnter = txtNhapEmail.Text.Trim();
            if (string.IsNullOrEmpty(emailEnter))
            {
                MessageBox.Show("Vui lòng nhập email");
                return;
            }

            try
            {
                var userChecked = await _userService.GetUserByEmailAsync(emailEnter);
                // Check violation of user have ?
                bool violationOfUser = await _checkInsService.checkViolationOfUserIsActive(userChecked.Email);

                if (violationOfUser)
                {
                    MessageBox.Show("Người dùng hiện đang bị cấm!");
                    return;
                }
                if (userChecked != null)
                {
                    txtEmail.Text = userChecked.Email;
                    txtFirstName.Text = userChecked.FirstName;
                    txtLastName.Text = userChecked.LastName;

                    CheckIns checkUserInThuQuan = await _checkInsService.CheckOut(emailEnter);

                    if (checkUserInThuQuan != null)
                    {
                        MessageBox.Show("Check-out thành công!");
                    }
                    else
                    {
                        var checkIns = new CheckIns
                        {
                            User = userChecked,
                            CheckIn = DateTime.Now,
                        };



                        await _checkInsService.AddCheckInAsync(checkIns);
                        MessageBox.Show("Check-in thành công!");
                    }
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy người dùng với email: {emailEnter}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi check-in: {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            StopCamera();
        }

        private void CheckInForm_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}