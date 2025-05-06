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
                if (_violationService == null || _ruleService == null || _userService == null)
                {
                    MessageBox.Show("Không thể kết nối đến các dịch vụ cần thiết!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ShowLoadingUI();
                await LoadViolationsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo giao diện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoadingUI()
        {
            dgvViolations.Rows.Clear();
            dgvViolations.Columns[0].HeaderText = "Đang tải dữ liệu...";

            for (int i = 1; i < dgvViolations.Columns.Count; i++)
            {
                dgvViolations.Columns[i].HeaderText = "";
            }
        }

        private async Task LoadViolationsAsync()
        {
            try
            {
                ShowLoadingUI();

                if (_violationService == null)
                {
                    MessageBox.Show("Không thể kết nối đến dịch vụ vi phạm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var violations = await _violationService.GetAllAsync();
                DisplayViolations(violations);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("tracked") || ex.Message.Contains("MySqlConnection"))
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisplayViolations(new List<Violation>());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisplayViolations(new List<Violation>());
            }
        }

        private void DisplayViolations(List<Violation> violations)
        {
            dgvViolations.Columns[0].HeaderText = "ID";
            dgvViolations.Columns[1].HeaderText = "Người dùng";
            dgvViolations.Columns[2].HeaderText = "Quy tắc";
            dgvViolations.Columns[3].HeaderText = "Mô tả";
            dgvViolations.Columns[4].HeaderText = "Ngày vi phạm";
            dgvViolations.Columns[5].HeaderText = "Trạng thái";
            dgvViolations.Columns[6].HeaderText = "Thao tác";

            dgvViolations.Rows.Clear();

            if (violations == null)
            {
                MessageBox.Show("Không có dữ liệu vi phạm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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

                dgvViolations.Rows[rowIndex].Tag = violation;
            }

            dgvViolations.CellPainting += DgvViolations_CellPainting;
            dgvViolations.CellClick += DgvViolations_CellClick;
        }

        private void DgvViolations_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvViolations.Columns["colActions"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

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

                using (SolidBrush editBrush = new SolidBrush(Color.FromArgb(0, 149, 255)))
                {
                    e.Graphics.FillRectangle(editBrush, editButtonRect);
                }

                using (SolidBrush deleteBrush = new SolidBrush(Color.FromArgb(220, 53, 69)))
                {
                    e.Graphics.FillRectangle(deleteBrush, deleteButtonRect);
                }

                using (Font buttonFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        "Sửa",
                        buttonFont,
                        editButtonRect,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

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
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvViolations.Columns["colActions"].Index)
            {
                if (dgvViolations.Rows[e.RowIndex].Tag == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin vi phạm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var violation = (Violation)dgvViolations.Rows[e.RowIndex].Tag;
                Rectangle cellBounds = dgvViolations.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point clickPoint = dgvViolations.PointToClient(Cursor.Position);
                if (clickPoint.X < cellBounds.X + cellBounds.Width / 2)
                {
                    await EditViolation(violation);
                }
                else
                {
                    await DeleteViolation(violation);
                }
            }
        }

        private async Task EditViolation(Violation violation)
        {
            var form = new Form();
            form.Text = "Sửa vi phạm";
            form.Size = new Size(500, 400);
            form.StartPosition = FormStartPosition.CenterParent;

            var lblUser = new Label { Text = "Người dùng:", Location = new Point(20, 20) };
            var cboUser = new ComboBox { Location = new Point(120, 20), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

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
            //moi them 
            var lblUnban = new Label { Text = "Ngày unban:", Location = new Point(20, 260) };
            var dtpUnban = new DateTimePicker
            {
                Location = new Point(120, 260),
                Width = 250,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy HH:mm",
                ShowUpDown = true // Để dễ chọn giờ phút
            };


            var btnSave = new Button { Text = "Lưu", Location = new Point(200, 300), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Hủy", Location = new Point(300, 300), DialogResult = DialogResult.Cancel };

            form.Controls.AddRange(new Control[] { lblUser, cboUser, lblRule, cboRule, lblDesc, txtDesc, lblStatus, cboStatus, lblUnban, dtpUnban, btnSave, btnCancel });
            form.AcceptButton = btnSave;
            form.CancelButton = btnCancel;

            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (cboUser.SelectedValue == null || cboRule.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng và quy tắc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    var updatedViolation = new Violation
                    {
                        UserId = Convert.ToInt32(cboUser.SelectedValue),
                        RuleId = Convert.ToInt32(cboRule.SelectedValue),
                        Description = txtDesc.Text,
                        Status = cboStatus.SelectedItem?.ToString() ?? "pending",
                        ViolationDate = DateTime.Now,
                        UnbanAt = dtpUnban.Value
                    };
                    await _violationService.UpdateAsync(updatedViolation);
                    await LoadViolationsAsync();
                    MessageBox.Show("Cập nhật vi phạm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DbUpdateConcurrencyException)
                {
                    MessageBox.Show("Không thể cập nhật vi phạm. Dữ liệu có thể đã bị thay đổi hoặc xóa.", "Lỗi đồng thời", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadViolationsAsync();
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("tracked") || ex.Message.Contains("MySqlConnection"))
                {
                    MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadViolationsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật vi phạm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    int violationId = violation.Id;

                    bool success = await _violationService.DeleteAsync(violationId);

                    if (success)
                    {
                        await LoadViolationsAsync();
                        MessageBox.Show("Xóa vi phạm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa vi phạm. Vi phạm có thể đã bị xóa hoặc không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await LoadViolationsAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    MessageBox.Show("Không thể xóa vi phạm. Dữ liệu có thể đã bị thay đổi hoặc xóa.", "Lỗi đồng thời", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadViolationsAsync();
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("tracked") || ex.Message.Contains("MySqlConnection"))
                {
                    MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadViolationsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa vi phạm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadViolationsAsync();
                }
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var form = new Form();
            form.Text = "Thêm vi phạm mới";
            form.Size = new Size(500, 400);
            form.StartPosition = FormStartPosition.CenterParent;

            var lblUser = new Label { Text = "Người dùng:", Location = new Point(20, 20) };
            var cboUser = new ComboBox { Location = new Point(120, 20), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

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
            //moi them 
            var lblUnban = new Label { Text = "Ngày unban:", Location = new Point(20, 260) };
            var dtpUnban = new DateTimePicker
            {
                Location = new Point(120, 260),
                Width = 250,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy HH:mm",
                ShowUpDown = true // Để dễ chọn giờ phút
            };

            var btnSave = new Button { Text = "Lưu", Location = new Point(200, 300), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Hủy", Location = new Point(300, 300), DialogResult = DialogResult.Cancel };

            form.Controls.AddRange(new Control[] { lblUser, cboUser, lblRule, cboRule, lblDesc, txtDesc, lblStatus, cboStatus, lblUnban, dtpUnban, btnSave, btnCancel });
            form.AcceptButton = btnSave;
            form.CancelButton = btnCancel;

            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {

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

                    await _violationService.AddAsync(violation);
                    await LoadViolationsAsync();
                    MessageBox.Show("Thêm vi phạm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("tracked") || ex.Message.Contains("MySqlConnection"))
                {
                    MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadViolationsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm vi phạm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadViolationsAsync();
                }
            }
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                ShowLoadingUI();

                if (string.IsNullOrEmpty(keyword))
                {
                    await LoadViolationsAsync();
                    return;
                }
                if (_violationService == null)
                {
                    MessageBox.Show("Không thể kết nối đến dịch vụ vi phạm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var violations = await _violationService.FindByKeywordAsync(keyword);
                DisplayViolations(violations);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("tracked") || ex.Message.Contains("MySqlConnection"))
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                await LoadViolationsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                await LoadViolationsAsync();
            }
        }
    }
}
