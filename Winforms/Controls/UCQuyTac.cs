using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;

namespace QLThuQuan.Winforms.Controls
{
    public partial class UCQuyTac : UserControl
    {
        private readonly IRuleService _ruleService;

        public UCQuyTac(IRuleService ruleService)
        {
            InitializeComponent();
            _ruleService = ruleService;
            this.Load += UCQuyTac_Load;

            // Wire up event handlers
            btnSearch.Click += btnSearch_Click;
            btnAddRule.Click += btnAddRule_Click;
            dgvRules.CellClick += dgvRules_CellClick;
            dgvRules.CellPainting += dgvRules_CellPainting;
        }

        private void dgvRules_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Only paint custom buttons for the actions column and not the header
            if (e.RowIndex >= 0 && e.ColumnIndex == colActions.Index)
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

        private async void UCQuyTac_Load(object sender, EventArgs e)
        {
            // Show loading state
            ShowLoadingUI();

            // Load data
            await LoadRulesAsync();
        }

        private void ShowLoadingUI()
        {
            // Clear existing rows
            dgvRules.Rows.Clear();

            // Add a loading row
            dgvRules.Rows.Add("", "Đang tải dữ liệu...", "", "");
        }

        private async Task LoadRulesAsync()
        {
            try
            {
                var rules = await _ruleService.GetAllAsync();
                DisplayRules(rules);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayRules(List<QLThuQuan.Data.Models.Rule> rules)
        {
            // Clear existing rows
            dgvRules.Rows.Clear();

            // Add data rows
            foreach (var rule in rules)
            {
                dgvRules.Rows.Add(
                    rule.Id,
                    rule.Name,
                    rule.Description,
                    rule.CreatedAt.ToString("dd/MM/yyyy HH:mm")
                );
            }

            // If no rules found
            if (rules.Count == 0)
            {
                dgvRules.Rows.Add("", "Không tìm thấy kết quả trùng khớp", "", "");
            }
        }

        private void dgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if it's the actions column and not the header row
            if (e.RowIndex >= 0 && e.ColumnIndex == colActions.Index)
            {
                // Get the rule ID from the selected row
                if (dgvRules.Rows[e.RowIndex].Cells[colId.Index].Value != null)
                {
                    int ruleId = Convert.ToInt32(dgvRules.Rows[e.RowIndex].Cells[colId.Index].Value);

                    // Get the cell bounds
                    Rectangle cellBounds = dgvRules.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                    // Determine which half of the cell was clicked
                    Point clickPoint = dgvRules.PointToClient(Cursor.Position);

                    // If click is in the left half (Edit button)
                    if (clickPoint.X < cellBounds.X + cellBounds.Width / 2)
                    {
                        _ = EditRuleById(ruleId);
                    }
                    // If click is in the right half (Delete button)
                    else
                    {
                        _ = DeleteRuleById(ruleId);
                    }
                }
            }
        }

        private async Task EditRuleById(int ruleId)
        {
            try
            {
                var rule = await _ruleService.GetByIdAsync(ruleId);
                if (rule != null)
                {
                    await EditRule(rule);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin quy tắc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteRuleById(int ruleId)
        {
            try
            {
                var rule = await _ruleService.GetByIdAsync(ruleId);
                if (rule != null)
                {
                    await DeleteRule(rule);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin quy tắc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EditRule(QLThuQuan.Data.Models.Rule rule)
        {
            // Create form to edit rule
            var form = new Form();
            form.Text = "Sửa quy tắc";
            form.Size = new Size(500, 350);
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            // Create a table layout for better organization
            TableLayoutPanel panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                RowCount = 3,
                ColumnCount = 2
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            // Create controls
            var lblName = new Label { Text = "Tên quy tắc:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            var txtName = new TextBox { Text = rule.Name, Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10F) };

            var lblDesc = new Label { Text = "Mô tả:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            var txtDesc = new TextBox { Text = rule.Description, Dock = DockStyle.Fill, Multiline = true, Font = new Font("Segoe UI", 10F) };

            // Create button panel
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft
            };

            var btnSave = new Button
            {
                Text = "Lưu",
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button
            {
                Text = "Hủy",
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                DialogResult = DialogResult.Cancel
            };

            // Add controls to panel
            panel.Controls.Add(lblName, 0, 0);
            panel.Controls.Add(txtName, 1, 0);
            panel.Controls.Add(lblDesc, 0, 1);
            panel.Controls.Add(txtDesc, 1, 1);

            buttonPanel.Controls.Add(btnCancel);
            buttonPanel.Controls.Add(btnSave);
            panel.Controls.Add(buttonPanel, 1, 2);
            panel.SetColumnSpan(buttonPanel, 2);

            form.Controls.Add(panel);
            form.AcceptButton = btnSave;
            form.CancelButton = btnCancel;

            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                rule.Name = txtName.Text;
                rule.Description = txtDesc.Text;
                rule.UpdatedAt = DateTime.Now;

                await _ruleService.UpdateAsync(rule);
                await LoadRulesAsync();
                MessageBox.Show("Cập nhật quy tắc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task DeleteRule(QLThuQuan.Data.Models.Rule rule)
        {
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa quy tắc '{rule.Name}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await _ruleService.DeleteAsync(rule.Id);
                await LoadRulesAsync();
                MessageBox.Show("Xóa quy tắc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnAddRule_Click(object sender, EventArgs e)
        {
            // Create form to add new rule
            var form = new Form();
            form.Text = "Thêm quy tắc mới";
            form.Size = new Size(500, 350);
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            // Create a table layout for better organization
            TableLayoutPanel panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                RowCount = 3,
                ColumnCount = 2
            };

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            // Create controls
            var lblName = new Label { Text = "Tên quy tắc:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            var txtName = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10F) };

            var lblDesc = new Label { Text = "Mô tả:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            var txtDesc = new TextBox { Dock = DockStyle.Fill, Multiline = true, Font = new Font("Segoe UI", 10F) };

            // Create button panel
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft
            };

            var btnSave = new Button
            {
                Text = "Lưu",
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button
            {
                Text = "Hủy",
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                DialogResult = DialogResult.Cancel
            };

            // Add controls to panel
            panel.Controls.Add(lblName, 0, 0);
            panel.Controls.Add(txtName, 1, 0);
            panel.Controls.Add(lblDesc, 0, 1);
            panel.Controls.Add(txtDesc, 1, 1);

            buttonPanel.Controls.Add(btnCancel);
            buttonPanel.Controls.Add(btnSave);
            panel.Controls.Add(buttonPanel, 1, 2);
            panel.SetColumnSpan(buttonPanel, 2);

            form.Controls.Add(panel);
            form.AcceptButton = btnSave;
            form.CancelButton = btnCancel;

            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                var rule = new QLThuQuan.Data.Models.Rule
                {
                    Name = txtName.Text,
                    Description = txtDesc.Text,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                await _ruleService.AddAsync(rule);
                await LoadRulesAsync();
                MessageBox.Show("Thêm quy tắc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                ShowLoadingUI();
                await LoadRulesAsync();
                return;
            }

            // Show loading UI
            ShowLoadingUI();

            try
            {
                var rules = await _ruleService.FindByKeywordAsync(keyword);
                DisplayRules(rules);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}