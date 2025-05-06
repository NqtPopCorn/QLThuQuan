using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;

namespace QLThuQuan.Winforms.Controls
{
    public partial class UCViPham : UserControl
    {
        private readonly IViolationService _violationService;
        private readonly IRuleService _ruleService;
        private readonly IUserService _userService;

        public UCViPham(IViolationService violationService, IRuleService ruleService, IUserService userService)
        {
            InitializeComponent();
            _violationService = violationService;
            _ruleService = ruleService;
            _userService = userService;
            this.Load += UCViPham_Load;
        }

        private async void UCViPham_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các service
                if (_violationService == null || _ruleService == null || _userService == null)
                {
                    MessageBox.Show("Không thể kết nối đến các dịch vụ cần thiết!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị giao diện loading trước
                ShowLoadingUI();

                // Sau đó load dữ liệu
                await LoadViolationsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo giao diện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoadingUI()
        {
            // Clear existing data
            dgvViolations.Rows.Clear();

            // Add a loading message
            dgvViolations.Columns[0].HeaderText = "Đang tải dữ liệu...";

            // Hide other column headers temporarily
            for (int i = 1; i < dgvViolations.Columns.Count; i++)
            {
                dgvViolations.Columns[i].HeaderText = "";
            }
        }

        private async Task LoadViolationsAsync()
        {
            try
            {
                // Hiển thị UI loading trước
                ShowLoadingUI();

                // Kiểm tra service
                if (_violationService == null)
                {
                    MessageBox.Show("Không thể kết nối đến dịch vụ vi phạm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy danh sách vi phạm trực tiếp, không sử dụng Task.Run để tránh vấn đề với context
                var violations = await _violationService.GetAllAsync();
                DisplayViolations(violations);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("tracked") || ex.Message.Contains("MySqlConnection"))
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Hiển thị danh sách trống
                DisplayViolations(new List<Violation>());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Hiển thị danh sách trống
                DisplayViolations(new List<Violation>());
            }
        }

        private void DisplayViolations(List<Violation> violations)
        {
            // Restore column headers
            dgvViolations.Columns[0].HeaderText = "ID";
            dgvViolations.Columns[1].HeaderText = "Người dùng";
            dgvViolations.Columns[2].HeaderText = "Quy tắc";
            dgvViolations.Columns[3].HeaderText = "Mô tả";
            dgvViolations.Columns[4].HeaderText = "Ngày vi phạm";
            dgvViolations.Columns[5].HeaderText = "Trạng thái";
            dgvViolations.Columns[6].HeaderText = "Thao tác";

            // Clear existing data
            dgvViolations.Rows.Clear();

            // Check if violations list is null
            if (violations == null)
            {
                MessageBox.Show("Không có dữ liệu vi phạm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Add data rows
            foreach (var violation in violations)
            {
                if (violation == null) continue;

                int rowIndex = dgvViolations.Rows.Add(
                    violation.Id.ToString(),
                    violation.User?.FirstName + " " + violation.User?.LastName,
                    violation.Rule?.Name,
                    violation.Description ?? "",
                    violation.ViolationDate.ToString("dd/MM/yyyy"),
                    violation.Status ?? "pending",
                    "Thao tác"
                );

                // Store the violation object in the row's Tag property for later use
                dgvViolations.Rows[rowIndex].Tag = violation;
            }

            // Set up the action buttons column
            dgvViolations.CellPainting += DgvViolations_CellPainting;
            dgvViolations.CellClick += DgvViolations_CellClick;
        }

        private void DgvViolations_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Only paint custom buttons for the actions column and not the header
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvViolations.Columns["colActions"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Calculate button rectangles (divide cell in half)
                Rectangle editButtonRect = new Rectangle(
                    e.CellBounds.X,
                    e.CellBounds.Y,
                    e.CellBounds.Width / 2,
                    e.CellBounds.Height);

                Rectangle deleteButtonRect = new Rectangle(
                    e.CellBounds.X + e.CellBounds.Width / 2,
                    e.CellBounds.Y,
                    e.CellBounds.Width / 2,
                    e.CellBounds.Height);

                // Draw edit button (brighter blue)
                using (SolidBrush editBrush = new SolidBrush(Color.FromArgb(0, 149, 255)))
                {
                    e.Graphics.FillRectangle(editBrush, editButtonRect);
                }

                // Draw delete button (red)
                using (SolidBrush deleteBrush = new SolidBrush(Color.FromArgb(220, 53, 69)))
                {
                    e.Graphics.FillRectangle(deleteBrush, deleteButtonRect);
                }

                // Draw button text
                using (Font buttonFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                {
                    // Draw "Sửa" text
                    TextRenderer.DrawText(
                        e.Graphics,
                        "Sửa",
                        buttonFont,
                        editButtonRect,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    // Draw "Xóa" text
                    TextRenderer.DrawText(
                        e.Graphics,
                        "Xóa",
                        buttonFont,
                        deleteButtonRect,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                e.Handled = true;
            }
        }

        private async void DgvViolations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if it's the actions column and not the header row
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvViolations.Columns["colActions"].Index)
            {
                // Get the violation object from the row's Tag property
                if (dgvViolations.Rows[e.RowIndex].Tag == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin vi phạm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var violation = (Violation)dgvViolations.Rows[e.RowIndex].Tag;

                // Get the cell bounds
                Rectangle cellBounds = dgvViolations.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                // Determine which half of the cell was clicked
                Point clickPoint = dgvViolations.PointToClient(Cursor.Position);

                // If click is in the left half (Edit button)
                if (clickPoint.X < cellBounds.X + cellBounds.Width / 2)
                {
                    await EditViolation(violation);
                }
                // If click is in the right half (Delete button)
                else
                {
                    await DeleteViolation(violation);
                }
            }
        }

        private async Task EditViolation(Violation violation)
        {
            // Tạo form để sửa vi phạm
            var form = new Form();
            form.Text = "Sửa vi phạm";
            form.Size = new Size(500, 400);
            form.StartPosition = FormStartPosition.CenterParent;

            var lblUser = new Label { Text = "Người dùng:", Location = new Point(20, 20) };
            var cboUser = new ComboBox { Location = new Point(120, 20), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            // Lấy danh sách người dùng
            try
            {
                var users = (await _userService.GetAllUsersAsync()).ToList();
                cboUser.DataSource = users;
                cboUser.DisplayMember = "FirstName";
                cboUser.ValueMember = "Id";
                cboUser.SelectedValue = violation.UserId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lblRule = new Label { Text = "Quy tắc:", Location = new Point(20, 60) };
            var cboRule = new ComboBox { Location = new Point(120, 60), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            // Lấy danh sách quy tắc
            try
            {
                var rules = await _ruleService.GetAllAsync();
                cboRule.DataSource = rules;
                cboRule.DisplayMember = "Name";
                cboRule.ValueMember = "Id";
                cboRule.SelectedValue = violation.RuleId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách quy tắc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lblDesc = new Label { Text = "Mô tả:", Location = new Point(20, 100) };
            var txtDesc = new TextBox { Text = violation.Description, Location = new Point(120, 100), Width = 250, Multiline = true, Height = 100 };

            var lblStatus = new Label { Text = "Trạng thái:", Location = new Point(20, 220) };
            var cboStatus = new ComboBox { Location = new Point(120, 220), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cboStatus.Items.AddRange(new object[] { "pending", "resolved" });
            cboStatus.SelectedItem = violation.Status;

            var btnSave = new Button { Text = "Lưu", Location = new Point(200, 300), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Hủy", Location = new Point(300, 300), DialogResult = DialogResult.Cancel };

            form.Controls.AddRange(new Control[] { lblUser, cboUser, lblRule, cboRule, lblDesc, txtDesc, lblStatus, cboStatus, btnSave, btnCancel });
            form.AcceptButton = btnSave;
            form.CancelButton = btnCancel;

            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Kiểm tra giá trị được chọn trước khi chuyển đổi
                if (cboUser.SelectedValue == null || cboRule.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng và quy tắc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Tạo một đối tượng mới chỉ chứa dữ liệu cần thiết để cập nhật
                    var updatedViolation = new Violation
                    {
                        Id = violation.Id,
                        UserId = Convert.ToInt32(cboUser.SelectedValue),
                        RuleId = Convert.ToInt32(cboRule.SelectedValue),
                        Description = txtDesc.Text,
                        Status = cboStatus.SelectedItem?.ToString() ?? "pending",
                        // Không cần thiết lập ViolationDate vì service sẽ giữ nguyên giá trị cũ
                    };

                    // Cập nhật vi phạm trực tiếp, không sử dụng Task.Run để tránh vấn đề với context
                    await _violationService.UpdateAsync(updatedViolation);

                    // Tải lại dữ liệu sau khi cập nhật thành công
                    await LoadViolationsAsync();
                    MessageBox.Show("Cập nhật vi phạm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DbUpdateConcurrencyException)
                {
                    MessageBox.Show("Không thể cập nhật vi phạm. Dữ liệu có thể đã bị thay đổi hoặc xóa.", "Lỗi đồng thời", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                    await LoadViolationsAsync();
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("tracked") || ex.Message.Contains("MySqlConnection"))
                {
                    MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                    await LoadViolationsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật vi phạm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                    await LoadViolationsAsync();
                }
            }
        }

        private async Task DeleteViolation(Violation violation)
        {
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa vi phạm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Lưu ID để xóa
                    int violationId = violation.Id;

                    // Xóa vi phạm trực tiếp, không sử dụng Task.Run để tránh vấn đề với context
                    bool success = await _violationService.DeleteAsync(violationId);

                    if (success)
                    {
                        // Tải lại dữ liệu sau khi xóa thành công
                        await LoadViolationsAsync();
                        MessageBox.Show("Xóa vi phạm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa vi phạm. Vi phạm có thể đã bị xóa hoặc không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                        await LoadViolationsAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    MessageBox.Show("Không thể xóa vi phạm. Dữ liệu có thể đã bị thay đổi hoặc xóa.", "Lỗi đồng thời", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                    await LoadViolationsAsync();
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("tracked") || ex.Message.Contains("MySqlConnection"))
                {
                    MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                    await LoadViolationsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa vi phạm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                    await LoadViolationsAsync();
                }
            }
        }

        // No unused event handlers needed

        private async void button1_Click(object sender, EventArgs e) // This is now btnAddViolation.Click
        {
            // Tạo form để thêm vi phạm mới
            var form = new Form();
            form.Text = "Thêm vi phạm mới";
            form.Size = new Size(500, 400);
            form.StartPosition = FormStartPosition.CenterParent;

            var lblUser = new Label { Text = "Người dùng:", Location = new Point(20, 20) };
            var cboUser = new ComboBox { Location = new Point(120, 20), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            // Lấy danh sách người dùng
            try
            {
                var users = (await _userService.GetAllUsersAsync()).ToList();
                cboUser.DataSource = users;
                cboUser.DisplayMember = "FirstName";
                cboUser.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lblRule = new Label { Text = "Quy tắc:", Location = new Point(20, 60) };
            var cboRule = new ComboBox { Location = new Point(120, 60), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            // Lấy danh sách quy tắc
            try
            {
                var rules = await _ruleService.GetAllAsync();
                cboRule.DataSource = rules;
                cboRule.DisplayMember = "Name";
                cboRule.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách quy tắc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lblDesc = new Label { Text = "Mô tả:", Location = new Point(20, 100) };
            var txtDesc = new TextBox { Location = new Point(120, 100), Width = 250, Multiline = true, Height = 100 };

            var lblStatus = new Label { Text = "Trạng thái:", Location = new Point(20, 220) };
            var cboStatus = new ComboBox { Location = new Point(120, 220), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cboStatus.Items.AddRange(new object[] { "pending", "resolved" });
            cboStatus.SelectedIndex = 0;

            var btnSave = new Button { Text = "Lưu", Location = new Point(200, 300), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Hủy", Location = new Point(300, 300), DialogResult = DialogResult.Cancel };

            form.Controls.AddRange(new Control[] { lblUser, cboUser, lblRule, cboRule, lblDesc, txtDesc, lblStatus, cboStatus, btnSave, btnCancel });
            form.AcceptButton = btnSave;
            form.CancelButton = btnCancel;

            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Kiểm tra giá trị được chọn trước khi chuyển đổi
                if (cboUser.SelectedValue == null || cboRule.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng và quy tắc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    var violation = new Violation
                    {
                        UserId = Convert.ToInt32(cboUser.SelectedValue),
                        RuleId = Convert.ToInt32(cboRule.SelectedValue),
                        Description = txtDesc.Text,
                        Status = cboStatus.SelectedItem?.ToString() ?? "pending",
                        ViolationDate = DateTime.Now
                    };

                    // Thêm vi phạm mới trực tiếp, không sử dụng Task.Run để tránh vấn đề với context
                    await _violationService.AddAsync(violation);

                    // Tải lại dữ liệu sau khi thêm thành công
                    await LoadViolationsAsync();
                    MessageBox.Show("Thêm vi phạm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("tracked") || ex.Message.Contains("MySqlConnection"))
                {
                    MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                    await LoadViolationsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm vi phạm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                    await LoadViolationsAsync();
                }
            }
        }

        private async void button11_Click(object sender, EventArgs e) // This is now btnSearch.Click
        {
            try
            {
                string keyword = txtSearch.Text.Trim();

                // Hiển thị UI loading
                ShowLoadingUI();

                if (string.IsNullOrEmpty(keyword))
                {
                    await LoadViolationsAsync();
                    return;
                }

                // Kiểm tra service
                if (_violationService == null)
                {
                    MessageBox.Show("Không thể kết nối đến dịch vụ vi phạm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tìm kiếm vi phạm trực tiếp, không sử dụng Task.Run để tránh vấn đề với context
                var violations = await _violationService.FindByKeywordAsync(keyword);
                DisplayViolations(violations);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("tracked") || ex.Message.Contains("MySqlConnection"))
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                await LoadViolationsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Tải lại dữ liệu để đồng bộ với cơ sở dữ liệu
                await LoadViolationsAsync();
            }
        }
    }
}
