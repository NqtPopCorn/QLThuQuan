using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;

namespace QLThuQuan.WebPage.Pages
{
    public class DeviceListModel : PageModel
    {
        private readonly IDeviceService _deviceService;
        private const int PageSize = 12;

        public DeviceListModel(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [BindProperty(SupportsGet = true)]
        public string Keyword { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        public int CurrentPage => PageNumber;

        public string SelectedStatus => Status;

        public List<Device> PaginatedDevices { get; set; } = new List<Device>();

        public async Task<IActionResult> OnGetAsync()
        {
            var allDevices = await _deviceService.GetAllAsync();

            // Filter by keyword (nếu có)
            if (!string.IsNullOrEmpty(Keyword))
            {
                allDevices = allDevices
                    .Where(d => d.Name.Contains(Keyword, System.StringComparison.OrdinalIgnoreCase) ||
                                (!string.IsNullOrEmpty(d.Description) &&
                                 d.Description.Contains(Keyword, System.StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }

            // Filter by status (nếu có)
            if (!string.IsNullOrEmpty(Status))
            {
                allDevices = allDevices
                    .Where(d => d.Status.Equals(Status, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Phân trang
            int totalItems = allDevices.Count;
            TotalPages = (int)System.Math.Ceiling(totalItems / (double)PageSize);

            // Đảm bảo PageNumber hợp lệ
            PageNumber = Math.Max(1, Math.Min(PageNumber, TotalPages));

            PaginatedDevices = allDevices
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return Page();
        }
    }
}