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
using QLThuQuan.Data.Models;

namespace QLThuQuan.Winforms.Component.User
{
    public partial class UpdateUser : Form
    {
        public QLThuQuan.Data.Models.User UpdatedUser { get; private set; }

        public UpdateUser()
        {
            InitializeComponent();
        }

        public void SetUser(QLThuQuan.Data.Models.User user)
        {
            // Sao chép để tránh ảnh hưởng dữ liệu gốc nếu người dùng hủy
            UpdatedUser = new QLThuQuan.Data.Models.User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Password = user.Password,
                CreateAt = user.CreateAt
            };

            // Hiển thị lên các textbox, checkbox...
            txtFirstName.Text = UpdatedUser.FirstName;
            txtLastName.Text = UpdatedUser.LastName;
            txtEmail.Text = UpdatedUser.Email;
            chkIsAdmin.Checked = UpdatedUser.IsAdmin;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Cập nhật thông tin từ form vào UpdatedUser
            UpdatedUser.FirstName = txtFirstName.Text.Trim();
            UpdatedUser.LastName = txtLastName.Text.Trim();
            UpdatedUser.Email = txtEmail.Text.Trim();
            UpdatedUser.IsAdmin = chkIsAdmin.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
