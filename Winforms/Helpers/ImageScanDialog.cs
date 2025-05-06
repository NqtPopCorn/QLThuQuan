using System;
using System.Windows.Forms;
using QLThuQuan.Winforms.Helpers;

namespace QLThuQuan.Winforms.Helpers
{
    public partial class ImageScanDialog : Form
    {
        private CodeImageScanner scanner;
        public string DecodedValue { get; private set; } // Thuộc tính để lưu giá trị đã giải mã

        public ImageScanDialog()
        {
            InitializeComponent();
            scanner = new CodeImageScanner(picturePreview, txtDecodedValue);
            DecodedValue = string.Empty; // Khởi tạo giá trị mặc định
        }

        private void DemoCodeScanner_Load(object sender, EventArgs e)
        {
            scanner.StartCamera();
        }

        private void DemoCodeScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            scanner.StopCamera();
            DecodedValue = txtDecodedValue.Text.Trim(); // Lưu giá trị trước khi đóng form
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            txtDecodedValue.Clear();
            scanner.StartCamera();
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            scanner.StopCamera();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            scanner.StopCamera();
            scanner.OpenFileAndScan();
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form thay vì Dispose()
        }

        public string GetDecodedValue()
        {
            return DecodedValue; // Trả về giá trị đã lưu
        }
    }
}