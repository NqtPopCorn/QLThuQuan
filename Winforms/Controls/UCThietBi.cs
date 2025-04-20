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
using QLThuQuan.Winforms.Components.ThietBi;

namespace QLThuQuan.Winforms.Controls
{
    public partial class UCThietBi : UserControl
    {

        private IDeviceService _deviceService;

        public UCThietBi(IDeviceService deviceService)
        {
            _deviceService = deviceService;
            InitializeComponent();
        }

        private async void loadTableDevice()
        {
            List<Device> devices = await _deviceService.GetAllAsync();
            loadTableDevice(devices);
        }

        private void loadTableDevice(List<Device> devices)
        {
            tableDevice.Controls.Clear();
            devices.ForEach(device =>
            {
                DeviceItem deviceItem = new DeviceItem(device);
                tableDevice.Controls.Add(deviceItem);
            });
        }

        private void UCThietBi_Load(object sender, EventArgs e)
        {
            loadTableDevice();

        }

        private async void btnTim_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            List<Device> devices = await _deviceService.FindByKeywordAsync(searchText);
            loadTableDevice(devices);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new Component.ThietBi.AddDeviceDialog(_deviceService).ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadTableDevice();
        }
    }
}
