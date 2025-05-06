using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZXing.Windows.Compatibility;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace QLThuQuan.Winforms.Helpers
{
    public class CodeImageScanner
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private PictureBox previewBox;
        private TextBox outputBox;

        public CodeImageScanner(PictureBox pictureBox, TextBox textBox)
        {
            previewBox = pictureBox;
            outputBox = textBox;
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
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            previewBox.Image = (Bitmap)bitmap.Clone(); // Hiển thị lên PictureBox
            previewBox.SizeMode = PictureBoxSizeMode.StretchImage;

            var reader = new BarcodeReader();
            Result result = reader.Decode(bitmap);
            if (result != null)
            {
                previewBox.Invoke(new MethodInvoker(delegate
                {
                    outputBox.Text = result.Text;
                    //MessageBox.Show($"Đã quét mã: {result.Text}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
                //videoSource.SignalToStop(); // Dừng camera sau khi quét thành công
            }

            bitmap.Dispose();
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

                    var reader = new BarcodeReader();
                    reader.AutoRotate = true;
                    reader.Options = new ZXing.Common.DecodingOptions
                    {
                        PossibleFormats = new[] { BarcodeFormat.QR_CODE, BarcodeFormat.EAN_13, BarcodeFormat.CODE_128 }
                    };

                    // Duyệt qua từng khung hình
                    for (int i = 0; i < frameCount; i++)
                    {
                        gifImage.SelectActiveFrame(dimension, i);
                        using (Bitmap bitmap = new Bitmap(gifImage))
                        {
                            var result = reader.Decode(bitmap);
                            if (result != null)
                            {
                                outputBox.Invoke(new MethodInvoker(delegate
                                {
                                    outputBox.Text = result.Text;
                                    previewBox.Image = (Bitmap)bitmap.Clone(); // Hiển thị khung hình chứa mã
                                }));
                                MessageBox.Show($"Đã quét mã: {result.Text}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static string parseDeviceId(string code)
        {
            string[] parts = code.Split("-");
            if (parts.Length == 2 && parts[0].Equals("device"))
            {
                return parts[1];
            }

            return string.Empty;
        }

        public static string parseUserEmail(string code)
        {
            string[] parts = code.Split("-");
            if (parts.Length == 2 && parts[0].Equals("user"))
            {
                return parts[1];
            }
            return string.Empty;
        }
    }
}