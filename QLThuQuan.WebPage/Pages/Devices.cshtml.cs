using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuQuan.Data.Services;
using QLThuQuan.Data.Models;

namespace QLThuQuan.WebPage.Pages
{
    public class DevicesModel : PageModel
    {
        private IDeviceService _deviceService;
        public List<Device> _devices;

        [BindProperty]
        public Device Device { get; set; } = new Device();

        public DevicesModel(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        public async Task OnGetAsync()
        {
            _devices = await _deviceService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _deviceService.AddAsync(Device);
            return RedirectToPage("Devices");
        }
    }
}
