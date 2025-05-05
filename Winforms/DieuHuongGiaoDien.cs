using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuQuan.Winforms
{
    public partial class DieuHuongGiaoDien : Form
    {
        private readonly Dashboard _dashBoard;

        private readonly CheckInForm _checkInForm;

        public DieuHuongGiaoDien(Dashboard dashBoard, CheckInForm checkInForm)
        {
            InitializeComponent();
            _dashBoard = dashBoard;
            _checkInForm = checkInForm;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            _dashBoard.FormClosed += (s, args) => RestartApplication(); // Gọi khi đóng form
            _dashBoard.Visible = true;
        }

        private void btnCheckIns_Click(object sender, EventArgs e)
        {
            _checkInForm.FormClosed += (s, args) => RestartApplication(); // Gọi khi đóng form
            _checkInForm.Visible = true;
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            return;
        }

        private void RestartApplication()
        {
            Application.Restart(); // Khởi động lại ứng dụng
            Environment.Exit(0);  // Đóng tiến trình hiện tại
        }
    }
}
