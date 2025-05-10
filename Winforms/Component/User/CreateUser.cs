using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using QLThuQuan.Data.Services;

namespace QLThuQuan.Winforms.Component.User
{
    public partial class CreateUser : Form
    {
        private readonly IUserService _userService;

        public CreateUser(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
            this.Load += CreateUser_Load;
        }

        // Reset form khi mở lại
        private void CreateUser_Load(object sender, EventArgs e)
        {
            tbEmail.Text = "";
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbPassword.Text = "";
            cbIsAdmin.Checked = false;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();
            string firstName = tbFirstName.Text.Trim();
            string lastName = tbLastName.Text.Trim();
            string password = tbPassword.Text;
            bool isAdmin = cbIsAdmin.Checked;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email và mật khẩu là bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra email đã tồn tại chưa
                var existingUser = await _userService.GetUserByEmailAsync(email);
                if (existingUser != null)
                {
                    MessageBox.Show("Email đã tồn tại. Vui lòng chọn email khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newUser = new Data.Models.User
                {
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password, // Nên mã hóa nếu cần bảo mật
                    IsAdmin = isAdmin
                };

                await _userService.AddUserAsync(newUser);
                MessageBox.Show("Tạo người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
