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
            // Tạm thời gỡ bỏ sự kiện để tránh kích hoạt trong quá trình cập nhật dữ liệu
            dgvViolations.CellPainting -= DgvViolations_CellPainting;
            dgvViolations.CellClick -= DgvViolations_CellClick;

            dgvViolations.Columns[0].HeaderText = "ID";
            dgvViolations.Columns[1].HeaderText = "Người dùng";
            dgvViolations.Columns[2].HeaderText = "Quy tắc";
            dgvViolations.Columns[3].HeaderText = "Mô tả";
            dgvViolations.Columns[4].HeaderText = "Ngày vi phạm";
            dgvViolations.Columns[5].HeaderText = "Loại";
            dgvViolations.Columns[6].HeaderText = "Trạng thái";
            dgvViolations.Columns[7].HeaderText = "Thao tác";

            dgvViolations.Rows.Clear();

            if (violations == null)
            {
                MessageBox.Show("Không có dữ liệu vi phạm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Đăng ký lại sự kiện sau khi cập nhật
                dgvViolations.CellPainting += DgvViolations_CellPainting;
                dgvViolations.CellClick += DgvViolations_CellClick;
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
                    violation.Type ?? "warning",
                    violation.Status ?? "pending",
                    "Thao tác"
                );

                dgvViolations.Rows[rowIndex].Tag = violation;
            }

            // Đăng ký lại sự kiện sau khi cập nhật
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

        // Cờ để chặn việc kích hoạt nhiều lần
        private bool _isProcessingCellClick = false;

        private async void DgvViolations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu đang xử lý một sự kiện click, bỏ qua các click tiếp theo
            if (_isProcessingCellClick)
                return;

            try
            {
                // Đánh dấu đang xử lý
                _isProcessingCellClick = true;

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
            finally
            {
                // Đảm bảo luôn reset cờ khi hoàn thành
                _isProcessingCellClick = false;
            }
        }

        private async Task EditViolation(Violation violation)
        {
            if (violation == null || violation.Id <= 0)
            {
                MessageBox.Show("Không tìm thấy thông tin vi phạm hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo form chỉnh sửa vi phạm
            using (var editForm = new Form())
            {
                editForm.Text = $"Sửa vi phạm ID: {violation.Id}";
                editForm.Size = new Size(500, 500);
                editForm.StartPosition = FormStartPosition.CenterParent;

                // Người dùng (chỉ đọc)
                var lblUser = new Label { Text = "Người dùng:", Location = new Point(20, 20) };
                var txtUser = new TextBox
                {
                    Text = $"{violation.User?.FirstName} {violation.User?.LastName}",
                    Location = new Point(120, 20),
                    Width = 250,
                    ReadOnly = true
                };

                // Quy tắc (chỉ đọc)
                var lblRule = new Label { Text = "Quy tắc:", Location = new Point(20, 60) };
                var txtRule = new TextBox
                {
                    Text = violation.Rule?.Name,
                    Location = new Point(120, 60),
                    Width = 250,
                    ReadOnly = true
                };

                // Mô tả
                var lblDesc = new Label { Text = "Mô tả:", Location = new Point(20, 100) };
                var txtDesc = new TextBox
                {
                    Text = violation.Description,
                    Location = new Point(120, 100),
                    Width = 250,
                    Multiline = true,
                    Height = 100
                };

                // Loại vi phạm
                var lblType = new Label { Text = "Loại:", Location = new Point(20, 220) };
                var cboType = new ComboBox
                {
                    Location = new Point(120, 220),
                    Width = 250,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cboType.Items.AddRange(new object[] { "warning", "ban", "compensation" });
                cboType.SelectedItem = violation.Type;

                // Số tiền phạt (ẩn mặc định)
                var lblCompensation = new Label { Text = "Số tiền phạt:", Location = new Point(20, 260), Visible = violation.Type == "compensation" };
                var txtCompensationPaid = new TextBox
                {
                    Text = violation.CompensationPaid?.ToString("F2") ?? "",
                    Location = new Point(120, 260),
                    Width = 250,
                    Visible = violation.Type == "compensation"
                };

                // Trạng thái
                var lblStatus = new Label { Text = "Trạng thái:", Location = new Point(20, 300), Visible = true };
                var cboStatus = new ComboBox
                {
                    Location = new Point(120, 300),
                    Width = 250,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Visible = true
                };
                cboStatus.Items.AddRange(new object[] { "pending", "canceled", "active" });
                cboStatus.SelectedItem = violation.Status;

                // Ngày hết hạn
                var lblExpired = new Label { Text = "Ngày hết hạn:", Location = new Point(20, 340), Visible = true };
                var dtpExpired = new DateTimePicker
                {
                    Location = new Point(120, 340),
                    Width = 250,
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "dd/MM/yyyy HH:mm",
                    ShowUpDown = true,
                    Value = violation.ExpiredAt ?? DateTime.Now.AddDays(7),
                    Visible = true
                };

                // Sự kiện thay đổi Type để hiển thị/ẩn CompensationPaid
                cboType.SelectedIndexChanged += (s, e) =>
                {
                    bool isCompensation = cboType.SelectedItem?.ToString() == "compensation";
                    lblCompensation.Visible = isCompensation;
                    txtCompensationPaid.Visible = isCompensation;

                    // Điều chỉnh vị trí các control bên dưới
                    lblStatus.Location = new Point(20, isCompensation ? 300 : 260);
                    cboStatus.Location = new Point(120, isCompensation ? 300 : 260);
                    lblExpired.Location = new Point(20, isCompensation ? 340 : 300);
                    dtpExpired.Location = new Point(120, isCompensation ? 340 : 300);
                };

                // Nút lưu và hủy
                var btnSave = new Button { Text = "Lưu", Location = new Point(200, 380), DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "Hủy", Location = new Point(300, 380), DialogResult = DialogResult.Cancel };

                editForm.Controls.AddRange(new Control[] { lblUser, txtUser, lblRule, txtRule, lblDesc, txtDesc, lblType, cboType, lblCompensation, txtCompensationPaid, lblStatus, cboStatus, lblExpired, dtpExpired, btnSave, btnCancel });
                editForm.AcceptButton = btnSave;
                editForm.CancelButton = btnCancel;

                var result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        // Xác thực số tiền phạt
                        decimal? compensationPaid = null;
                        if (cboType.SelectedItem?.ToString() == "compensation")
                        {
                            if (!decimal.TryParse(txtCompensationPaid.Text, out decimal parsedValue) || parsedValue < 0)
                            {
                                MessageBox.Show("Số tiền phạt phải là số không âm hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            compensationPaid = parsedValue;
                        }

                        // Tạo đối tượng vi phạm mới để cập nhật
                        var updatedViolation = new Violation
                        {
                            Id = violation.Id,
                            UserId = violation.UserId,
                            RuleId = violation.RuleId,
                            Description = txtDesc.Text,
                            Type = cboType.SelectedItem?.ToString() ?? "warning",
                            Status = cboStatus.SelectedItem?.ToString() ?? "pending",
                            ViolationDate = violation.ViolationDate,
                            ExpiredAt = dtpExpired.Value,
                            CompensationPaid = compensationPaid
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

        //add vi pham 
        private async void button1_Click(object sender, EventArgs e)
        {
            var form = new Form();
            form.Text = "Thêm vi phạm mới";
            form.Size = new Size(500, 500);
            form.StartPosition = FormStartPosition.CenterParent;

            // Người dùng
            var lblUser = new Label { Text = "Người dùng:", Location = new Point(20, 20) };
            var cboUser = new ComboBox { Location = new Point(120, 20), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            try
            {
                var fetchedUsers = await _userService.GetAllUsersAsync();
                var users = fetchedUsers.Select(u => new User
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                }).ToList();

                cboUser.DataSource = users;
                cboUser.DisplayMember = "FirstName";
                cboUser.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Quy tắc
            var lblRule = new Label { Text = "Quy tắc:", Location = new Point(20, 60) };
            var cboRule = new ComboBox { Location = new Point(120, 60), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            try
            {
                var fetchedRules = await _ruleService.GetAllAsync();
                var rules = fetchedRules.Select(r => new QLThuQuan.Data.Models.Rule
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CompensationAmount = r.CompensationAmount
                }).ToList();

                cboRule.DataSource = rules;
                cboRule.DisplayMember = "Name";
                cboRule.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách quy tắc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mô tả
            var lblDesc = new Label { Text = "Mô tả:", Location = new Point(20, 100) };
            var txtDesc = new TextBox { Location = new Point(120, 100), Width = 250, Multiline = true, Height = 100 };

            // Loại vi phạm
            var lblType = new Label { Text = "Loại:", Location = new Point(20, 220) };
            var cboType = new ComboBox { Location = new Point(120, 220), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cboType.Items.AddRange(new object[] { "warning", "ban", "compensation" });
            cboType.SelectedIndex = 0;

            // Số tiền phạt (ẩn mặc định)
            var lblCompensation = new Label { Text = "Số tiền phạt:", Location = new Point(20, 260), Visible = false };
            var txtCompensationPaid = new TextBox { Location = new Point(120, 260), Width = 250, Visible = false };

            // Trạng thái
            var lblStatus = new Label { Text = "Trạng thái:", Location = new Point(20, 260) };
            var cboStatus = new ComboBox { Location = new Point(120, 260), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cboStatus.Items.AddRange(new object[] { "pending", "canceled", "active" });
            cboStatus.SelectedIndex = 0;

            // Ngày hết hạn
            var lblExpired = new Label { Text = "Ngày hết hạn:", Location = new Point(20, 300) };
            var dtpExpired = new DateTimePicker
            {
                Location = new Point(120, 300),
                Width = 250,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy HH:mm",
                ShowUpDown = true,
                Value = DateTime.Now.AddDays(7)
            };

            // Sự kiện thay đổi Type để hiển thị/ẩn CompensationPaid
            cboType.SelectedIndexChanged += (s, e) =>
            {
                bool isCompensation = cboType.SelectedItem?.ToString() == "compensation";
                lblCompensation.Visible = isCompensation;
                txtCompensationPaid.Visible = isCompensation;

                // Điều chỉnh vị trí các control bên dưới
                lblStatus.Location = new Point(20, isCompensation ? 300 : 260);
                cboStatus.Location = new Point(120, isCompensation ? 300 : 260);
                lblExpired.Location = new Point(20, isCompensation ? 340 : 300);
                dtpExpired.Location = new Point(120, isCompensation ? 340 : 300);
            };

            // Nút lưu và hủy
            var btnSave = new Button { Text = "Lưu", Location = new Point(200, 380), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Hủy", Location = new Point(300, 380), DialogResult = DialogResult.Cancel };

            form.Controls.AddRange(new Control[] { lblUser, cboUser, lblRule, cboRule, lblDesc, txtDesc, lblType, cboType, lblCompensation, txtCompensationPaid, lblStatus, cboStatus, lblExpired, dtpExpired, btnSave, btnCancel });
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
                    // Xác thực số tiền phạt
                    decimal? compensationPaid = null;
                    if (cboType.SelectedItem?.ToString() == "compensation")
                    {
                        if (!decimal.TryParse(txtCompensationPaid.Text, out decimal parsedValue) || parsedValue < 0)
                        {
                            MessageBox.Show("Số tiền phạt phải là số không âm hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        compensationPaid = parsedValue;
                    }

                    var violation = new Violation
                    {
                        UserId = Convert.ToInt32(cboUser.SelectedValue),
                        RuleId = Convert.ToInt32(cboRule.SelectedValue),
                        Description = txtDesc.Text,
                        Type = cboType.SelectedItem?.ToString() ?? "warning",
                        Status = cboStatus.SelectedItem?.ToString() ?? "pending",
                        ViolationDate = DateTime.Now,
                        ExpiredAt = dtpExpired.Value,
                        CompensationPaid = compensationPaid
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

        private async void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                ShowLoadingUI();
                txtSearch.Clear();
                await LoadViolationsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lại dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}