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

namespace QL_ThuQuan
{
    public partial class UCUser : Form
    {
        public UCUser()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadData();
            dgvUsers.CellClick += dgvUsers_CellClick;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void InitializeDataGridView()
        {
            dgvUsers.Columns.Clear();

            // Cấu hình các cột
            dgvUsers.Columns.Add("ID", "ID");
            dgvUsers.Columns.Add("Email", "Email");
            dgvUsers.Columns.Add("FirstName", "First Name");
            dgvUsers.Columns.Add("LastName", "Last Name");
            dgvUsers.Columns.Add("Password", "Password");
            dgvUsers.Columns.Add("IsAdmin", "Is Admin");
            dgvUsers.Columns.Add("Status", "Status");

            // Thêm cột Action với nút Khóa và Sửa
            DataGridViewButtonColumn btnLock = new DataGridViewButtonColumn();
            btnLock.Name = "btnLock";
            btnLock.HeaderText = "Khóa";
            btnLock.Text = "Khóa";
            btnLock.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "btnEdit";
            btnEdit.HeaderText = "Sửa";
            btnEdit.Text = "Sửa";
            btnEdit.UseColumnTextForButtonValue = true;

            dgvUsers.Columns.Add(btnLock);
            dgvUsers.Columns.Add(btnEdit);

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void LoadData()
        {
            var users = new List<User>
            {
                new User { ID = 1, Email = "user1@gmail.com", FirstName = "John", LastName = "Doe", Password = "1234", IsAdmin = true, Status = "Active" },
                new User { ID = 2, Email = "user2@gmail.com", FirstName = "Jane", LastName = "Smith", Password = "abcd", IsAdmin = false, Status = "Blocked" }
            };

            dgvUsers.Rows.Clear();

            foreach (var user in users)
            {
                int rowIndex = dgvUsers.Rows.Add(
                    user.ID,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.Password,
                    user.IsAdmin ? "Yes" : "No",
                    user.Status
                );

                // Thêm nút Khóa và Sửa vào từng hàng
                dgvUsers.Rows[rowIndex].Cells["btnLock"].Value = "Khóa";
                dgvUsers.Rows[rowIndex].Cells["btnEdit"].Value = "Sửa";
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // 👉 Bỏ qua nếu click vào tiêu đề cột hoặc hàng trống.

            try
            {
                string columnName = dgvUsers.Columns[e.ColumnIndex].HeaderText; // Sửa lại cách lấy tên cột

                // 👉 Kiểm tra xem cột "ID" có tồn tại trong bảng không
                if (!dgvUsers.Columns.Contains("ID"))
                {
                    MessageBox.Show("Cột 'ID' không tồn tại trong DataGridView.");
                    return;
                }

                // 👉 Lấy giá trị của ô "ID" và chuyển thành số nguyên
                var cellValue = dgvUsers.Rows[e.RowIndex].Cells["ID"].Value;

                if (cellValue == null || string.IsNullOrEmpty(cellValue.ToString()))
                {
                    MessageBox.Show("Ô 'ID' không có giá trị hợp lệ.");
                    return;
                }

                int userId = int.Parse(cellValue.ToString());

                if (columnName == "Khóa") // Tên cột được hiển thị trên giao diện là "Khóa"
                {
                    MessageBox.Show($"Bạn vừa nhấn nút Khóa cho User có ID: {userId}");
                    // Thêm code xử lý khóa người dùng ở đây
                }
                else if (columnName == "Sửa") // Tên cột được hiển thị trên giao diện là "Sửa"
                {
                    MessageBox.Show($"Bạn vừa nhấn nút Sửa cho User có ID: {userId}");
                    // Thêm code xử lý sửa người dùng ở đây
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }




        public class User
        {
            public int ID { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public bool IsAdmin { get; set; }
            public string Status { get; set; }
        }

    }
}
