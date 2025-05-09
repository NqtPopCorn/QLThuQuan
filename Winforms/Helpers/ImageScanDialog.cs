using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using ZXing;
using ZXing.Windows.Compatibility;

namespace QLThuQuan.Winforms.Helpers
{
    public partial class ImageScanDialog : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public string DecodedValue => txtDecodedValue.Text;

        public ImageScanDialog()
        {
            InitializeComponent();
        }

        private void DemoCodeScanner_Load(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void DemoCodeScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            txtDecodedValue.Clear();
            StartCamera();
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            StopCamera();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            StopCamera();
            OpenFileAndScan();
        }

        private void txtDecodedValue_TextChanged(object sender, EventArgs e)
        {
        }

        public void StartCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("Không tìm thấy camera nào!");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
            videoSource.Start();
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (eventArgs.Frame == null)
            {
                return; // Bỏ qua nếu Frame là null
            }

            Bitmap bitmap = null;
            try
            {
                bitmap = (Bitmap)eventArgs.Frame.Clone();
                if (bitmap == null || bitmap.Width == 0 || bitmap.Height == 0)
                {
                    return; // Bỏ qua nếu bitmap không hợp lệ
                }

                if (picturePreview != null)
                {
                    picturePreview.Image = (Bitmap)bitmap.Clone();
                    picturePreview.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                var result = ScanBarcode(bitmap);
                if (result != null && txtDecodedValue != null)
                {
                    txtDecodedValue.Invoke(new MethodInvoker(delegate
                    {
                        txtDecodedValue.Text = result.Text;
                    }));
                    // Quét xong thì đóng camera
                    Cloce(DialogResult.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý khung hình: {ex.Message}");
            }
            finally
            {
                bitmap?.Dispose(); // Đảm bảo bitmap được giải phóng
            }
        }

        private Result ScanBarcode(Bitmap bitmap)
        {
            try
            {
                var reader = new BarcodeReader
                {
                    AutoRotate = true,
                    Options = new ZXing.Common.DecodingOptions
                    {
                        PossibleFormats = new[] { BarcodeFormat.QR_CODE, BarcodeFormat.EAN_13, BarcodeFormat.CODE_128 }
                    }
                };

                return reader.Decode(bitmap);
            }
            catch (Exception decodeEx)
            {
                MessageBox.Show($"Lỗi khi giải mã barcode: {decodeEx.Message}");
                return null;
            }
        }

        private void Cloce(DialogResult result = DialogResult.OK)
        {
            StopCamera();
            this.DialogResult = result;
            MessageBox.Show("Mã quét được là: " + DecodedValue);
            this.Close(); // Đóng form thay vì Dispose()
        }

        public void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }

        public void ScanGifFromFile(string filePath)
        {
            try
            {
                using (Image gifImage = Image.FromFile(filePath))
                {
                    if (gifImage == null)
                    {
                        MessageBox.Show("Không thể tải file GIF!");
                        return;
                    }

                    // Lấy thông tin khung hình của GIF
                    FrameDimension dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
                    int frameCount = gifImage.GetFrameCount(dimension);

                    // Duyệt qua từng khung hình
                    for (int i = 0; i < frameCount; i++)
                    {
                        gifImage.SelectActiveFrame(dimension, i);
                        using (Bitmap bitmap = new Bitmap(gifImage))
                        {
                            var result = ScanBarcode(bitmap);
                            if (result != null)
                            {
                                txtDecodedValue.Invoke(new MethodInvoker(delegate
                                {
                                    txtDecodedValue.Text = result.Text;
                                    picturePreview.Image = (Bitmap)bitmap.Clone(); // Hiển thị khung hình chứa mã
                                }));
                                Cloce(DialogResult.OK); // Đóng form sau khi tìm thấy mã
                                return; // Thoát sau khi tìm thấy mã đầu tiên
                            }
                        }
                    }

                    MessageBox.Show("Không tìm thấy mã vạch hoặc mã QR trong file GIF!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi quét file GIF: {ex.Message}");
            }
        }

        public void OpenFileAndScan()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "GIF Files|*.gif|All Files|*.*";
                openFileDialog.Title = "Chọn file GIF để quét mã vạch/QR";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ScanGifFromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cloce(DialogResult.Cancel);
        }
    }
}