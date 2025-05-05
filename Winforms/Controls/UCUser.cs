using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;
using QLThuQuan.Winforms.Component.User;

namespace QLThuQuan.Winforms.Controls
{
    public partial class UCUser : UserControl
    {
        private readonly IUserService _userService;

        private readonly CreateUser _createUserForm;

        private readonly UpdateUser _updateUserForm;

        public UCUser(IUserService userService, CreateUser createUserFrom, UpdateUser updateUserForm)
        {
            InitializeComponent();
            _userService = userService;
            _createUserForm = createUserFrom;
            _updateUserForm = updateUserForm;
            this.Load += UCUser_Load;
        }

        private async void UCUser_Load(object sender, EventArgs e)
        {
            await FetchAndShowUsersAsync();
        }

        private async Task FetchAndShowUsersAsync()
        {
            var users = (await _userService.GetAllUsersAsync()).ToList();
            ShowUsers(users);

        }

        private void ShowUsers(List<User> users)
        {
            dtgView.AutoGenerateColumns = true;
            dtgView.DataSource = null;
            dtgView.Columns.Clear(); // Xóa toàn bộ cột cũ trước khi gán lại source
            dtgView.DataSource = users;
            dtgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đặt lại headerText và ẩn cột không cần
            if (dtgView.Columns.Contains("Id"))
                dtgView.Columns["Id"].HeaderText = "Mã người dùng";

            if (dtgView.Columns.Contains("FirstName"))
                dtgView.Columns["FirstName"].HeaderText = "Tên";

            if (dtgView.Columns.Contains("LastName"))
                dtgView.Columns["LastName"].HeaderText = "Họ";

            if (dtgView.Columns.Contains("Email"))
                dtgView.Columns["Email"].HeaderText = "Email";

            if (dtgView.Columns.Contains("Password"))
                dtgView.Columns["Password"].Visible = false;

            if (dtgView.Columns.Contains("IsAdmin"))
            {
                dtgView.Columns["IsAdmin"].HeaderText = "Admin";
                dtgView.Columns["IsAdmin"].ReadOnly = true; // Ngăn người dùng chỉnh sửa
            }

            if (dtgView.Columns.Contains("CreateAt"))
                dtgView.Columns["CreateAt"].HeaderText = "Ngày tạo";

            // Thêm cột thao tác
            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Thao tác",
                Text = "Sửa | Xóa",
                UseColumnTextForButtonValue = true,
                Width = 120
            };
            dtgView.Columns.Add(actionCol);

            // Tránh đăng ký nhiều lần
            dtgView.CellClick -= DtgView_CellClick;
            dtgView.CellClick += DtgView_CellClick;
        }

        private async void DtgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var clickedColumn = dtgView.Columns[e.ColumnIndex];
            if (clickedColumn.Name == "Actions")
            {
                var selectedUser = dtgView.Rows[e.RowIndex].DataBoundItem as User;
                if (selectedUser == null) return;

                // Xác định nửa trái/phải trong ô button
                var cellRect = dtgView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPoint = dtgView.PointToClient(Cursor.Position);
                int clickX = clickPoint.X - cellRect.X;

                if (clickX < cellRect.Width / 2)
                {
                    // Nửa trái: cập nhật
                    await UpdateUserAsync(selectedUser);
                }
                else
                {
                    // Nửa phải: xóa
                    await DeleteUserAsync(selectedUser);
                }
            }
        }

        private async Task UpdateUserAsync(User user)
        {
            _updateUserForm.SetUser(user); // Truyền dữ liệu người dùng vào form

            var result = _updateUserForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                var updatedUser = _updateUserForm.UpdatedUser;

                await _userService.UpdateUserAsync(updatedUser);
                MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await FetchAndShowUsersAsync();
            }
        }

        private async Task DeleteUserAsync(User user)
        {
            var confirm = MessageBox.Show($"Xác nhận xóa người dùng {user.FirstName} {user.LastName}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                await _userService.DeleteUserAsync(user.Id);
                await FetchAndShowUsersAsync();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Có thể bỏ qua hoặc xử lý nếu cần
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this._createUserForm.ShowDialog();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            await FetchAndShowUsersAsync();
        }

        private async void btnEnter_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                await FetchAndShowUsersAsync();
                return;
            }

            var allUsers = await _userService.GetAllUsersAsync();
            var filteredUsers = allUsers.Where(u =>
                (u.FirstName != null && u.FirstName.ToLower().Contains(searchText)) ||
                (u.LastName != null && u.LastName.ToLower().Contains(searchText)) ||
                (u.Email != null && u.Email.ToLower().Contains(searchText)) ||
                (u.Id.ToString().Contains(searchText))
            ).ToList();

            if (filteredUsers.Any())
            {
                ShowUsers(filteredUsers);
                MessageBox.Show("Tìm kiếm thành công!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Truyền danh sách rỗng
                ShowUsers(new List<User>());
                // Hoặc có thể hiển thị thông báo cho người dùng
                MessageBox.Show("Không tìm thấy người dùng phù hợp.", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
