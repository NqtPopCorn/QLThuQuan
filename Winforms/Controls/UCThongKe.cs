using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.WinForms;
using ScottPlot.Colormaps;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QLThuQuan.Data.Services;
using System.Diagnostics;

namespace QLThuQuan.Winforms.Controls
{
    public partial class UCThongKe : UserControl
    {
        private FormsPlot plt; // Khai báo biến FormsPlot ở cấp class

        private readonly ICheckInsService _checkInsService;

        private readonly IUserService _userService;

        private readonly IBorrowService _borrowService;

        // Sửa constructor để nhận dependencies
        public UCThongKe(ICheckInsService checkInsService, IUserService userService, IBorrowService borrowService)
        {
            InitializeComponent();
            _checkInsService = checkInsService ?? throw new ArgumentNullException(nameof(checkInsService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _borrowService = borrowService ?? throw new ArgumentNullException(nameof(borrowService));

            // 1. Khởi tạo FormsPlot
            plt = new FormsPlot();

            // 2. Load dữ liệu cho combobox (chỉ khởi tạo, không kích hoạt sự kiện)
            LoadLuaChon();

            // Vô hiệu hóa các control lọc ban đầu
            cbLuaChon.Enabled = false;
            cbLuaChon.DropDownStyle = ComboBoxStyle.DropDownList;
            mcStartDate.Enabled = false;
            mcEndDate.Enabled = false;
        }

        //private async void UCThongKe_Load(object sender, EventArgs e)
        //{
        //    LoadLuaChon();

        //    // Gán sự kiện cho các thành phần
        //    cbLuaChon.SelectedIndexChanged += Control_Changed;
        //    mcStartDate.DateChanged += Control_Changed;
        //    mcEndDate.DateChanged += Control_Changed;

        //    // Thiết lập giá trị mặc định nếu chưa chọn
        //    if (mcStartDate.SelectionStart == DateTime.MinValue)
        //        mcStartDate.SetDate(DateTime.Today.AddMonths(-6)); // Mặc định 6 tháng trước
        //    if (mcEndDate.SelectionStart == DateTime.MinValue)
        //        mcEndDate.SetDate(DateTime.Today); // Mặc định hôm nay

        //    // Gọi lại hàm tạo thống kê
        //    await LoadAndDisplayChartData();
        //}

        private async Task LoadAndDisplayChartData()
        {
            string selectedOption = cbLuaChon.SelectedItem?.ToString() ?? "Tổng số lần check-in";
            DateTime startDate = mcStartDate.SelectionStart;
            DateTime endDate = mcEndDate.SelectionStart;

            // Kiểm tra hợp lệ ngày
            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gọi service để lấy dữ liệu (DbContext được tạo mới bên trong service)
            var data = await TaoDuLieuThongKe(selectedOption, startDate, endDate);
            HienThiBieuDoTheoThang(data);
        }

        private async void Control_Changed(object sender, EventArgs e)
        {
            await LoadAndDisplayChartData();
        }

        private void LoadLuaChon()
        {
            List<string> luaChon = new List<string>
            {
                "Tổng số người dùng",
                "Tổng số lần check-in",
                "Tổng số các thiết bị mượn",
                "Thống kê vi phạm",
            };

            cbLuaChon.DataSource = luaChon;
        }

        public async Task<Dictionary<string, double>> TaoDuLieuThongKe(string option, DateTime startDate, DateTime endDate)
        {
            var data = new Dictionary<string, double>();

            try
            {
                if (option == "Tổng số người dùng")
                {
                    var userStats = await _userService.GetMonthlyUserRegisterStats(startDate, endDate)
                                  ?? new Dictionary<string, double>();
                    foreach (var stat in userStats.Where(stat => stat.Key != null))
                    {
                        data[stat.Key] = stat.Value;
                    }

                    // Điền các tháng thiếu
                    FillMissingMonths(data, startDate, endDate);
                    data = data.OrderBy(d => new DateTime(int.Parse(d.Key.Split('/')[1]), int.Parse(d.Key.Split('/')[0]), 1))
                     .ToDictionary(d => d.Key, d => d.Value);
                }
                else if (option == "Tổng số lần check-in")
                {
                    var checkInStats = await _checkInsService.GetMonthlyCheckInStats(startDate, endDate)
                                     ?? new Dictionary<string, double>();
                    foreach (var stat in checkInStats.Where(stat => stat.Key != null))
                    {
                        data[stat.Key] = stat.Value;
                    }

                    // Điền các tháng thiếu
                    FillMissingMonths(data, startDate, endDate);
                    data = data.OrderBy(d => new DateTime(int.Parse(d.Key.Split('/')[1]), int.Parse(d.Key.Split('/')[0]), 1))
                     .ToDictionary(d => d.Key, d => d.Value);
                }
                else if (option == "Tổng số các thiết bị mượn")
                {
                    var borrowStats = await _borrowService.GetDeviceBorrowStatsByDateRangeAsync(startDate, endDate)
                                     ?? new Dictionary<string, double>();
                    foreach (var stat in borrowStats.Where(stat => stat.Key != null))
                    {
                        data[stat.Key] = stat.Value;
                    }
                }
                else if (option == "Thống kê vi phạm")
                {
                    var viPhamStats = await _checkInsService.GetViPhamStats(startDate, endDate)
                                     ?? new Dictionary<string, double>();
                    foreach (var stat in viPhamStats.Where(stat => stat.Key != null))
                    {
                        data[stat.Key] = stat.Value;
                        Debug.WriteLine($"data[stat.Key] '{stat.Key}'");
                        Debug.WriteLine($"stat.Value'{stat.Value}'");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thống kê: {ex.Message}");
                throw;
            }

            return data;
        }

        private void FillMissingMonths(Dictionary<string, double> data, DateTime startDate, DateTime endDate)
        {
            var current = new DateTime(startDate.Year, startDate.Month, 1);
            var end = new DateTime(endDate.Year, endDate.Month, 1);

            while (current <= end)
            {
                string key = current.ToString("MM/yyyy");
                if (!data.ContainsKey(key)) data[key] = 0;
                current = current.AddMonths(1);
            }
        }

        public void HienThiBieuDoTheoThang(Dictionary<string, double> duLieuTheoThang)
        {
            // Xóa các control cũ trong TableLayoutPanel
            tbLayoutChartTK.Controls.Clear();
            tbLayoutChartTK.RowStyles.Clear();
            tbLayoutChartTK.ColumnStyles.Clear();

            // Cấu hình TableLayoutPanel
            tbLayoutChartTK.RowCount = 1;
            tbLayoutChartTK.ColumnCount = 1;
            tbLayoutChartTK.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutChartTK.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            // Khởi tạo hoặc reset FormsPlot
            var plt = new FormsPlot();
            plt.Dock = DockStyle.Fill;

            // Chuyển đổi dữ liệu
            double[] values = duLieuTheoThang.Values.ToArray();
            string[] labels = duLieuTheoThang.Keys.ToArray();
            double[] positions = Enumerable.Range(0, values.Length).Select(x => (double)x).ToArray();

            // Vẽ biểu đồ
            plt.Plot.Clear();

            // Tạo biểu đồ cột
            var bar = plt.Plot.Add.Bars(positions, values);
            plt.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(
                positions,
                labels
            );

            // Tùy chỉnh giao diện
            plt.Plot.Title("Thống kê theo tháng");
            plt.Plot.Axes.Left.Label.Text = "Giá trị";
            plt.Plot.Axes.Bottom.Label.Text = "Thuộc tính";

            // Cấu hình lưới
            plt.Plot.Grid.MajorLineWidth = 1;
            plt.Plot.Grid.MajorLineColor = Colors.LightGray;

            // Hiển thị giá trị trên từng cột
            for (int i = 0; i < values.Length; i++)
            {
                string labelText = values[i].ToString("N0");
                double x = positions[i];
                double y = values[i] + (values.Max() * 0.02); // đẩy text lên trên cột

                var txt = plt.Plot.Add.Text(labelText, x, y);
                txt.Alignment = Alignment.MiddleCenter;
                txt.FontSize = 12;
                txt.Color = Colors.Black;
            }


            // Thêm vào TableLayoutPanel
            tbLayoutChartTK.Controls.Add(plt, 0, 0);

            // Render lại biểu đồ
            plt.Refresh();
        }

        // Các hàm sự kiện không sử dụng
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) { }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }

        private async void btnTaoThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Vô hiệu hóa nút và hiển thị trạng thái loading
                btnTaoThongKe.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Bước 2: Gọi hàm tạo dữ liệu
                await LoadAndDisplayChartData();

                // Bước 3: Kích hoạt các control sau khi hoàn thành
                cbLuaChon.Enabled = true;
                mcStartDate.Enabled = true;
                mcEndDate.Enabled = true;

                // Gán sự kiện sau khi kích hoạt control
                cbLuaChon.SelectedIndexChanged += Control_Changed;
                mcStartDate.DateChanged += Control_Changed;
                mcEndDate.DateChanged += Control_Changed;

                // Lần đầu tiên load dữ liệu
                await LoadAndDisplayChartData();

                // Hiệu ứng thành công
                btnTaoThongKe.Text = "Đã tạo thành công!";
                btnTaoThongKe.BackColor = System.Drawing.Color.LimeGreen;
                await Task.Delay(2000); // Giữ trạng thái 2 giây
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bước 4: Đảm bảo luôn khôi phục trạng thái ban đầu
                btnTaoThongKe.Enabled = true;
                btnTaoThongKe.Text = "Tạo lại thống kê";
                btnTaoThongKe.ForeColor = System.Drawing.Color.White;
                btnTaoThongKe.BackColor = System.Drawing.Color.BlueViolet;
                Cursor = Cursors.Default;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}