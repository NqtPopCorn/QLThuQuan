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
using QLThuQuan.Winforms.Helpers;

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
                DeviceItem deviceItem = new DeviceItem(device, _deviceService);
                deviceItem.OnSave += (updatedDevice) =>
                {
                    loadTableDevice();
                };
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
            //tu dong dispose dialog
            using (var dialog = new Component.ThietBi.AddDeviceDialog(_deviceService))
            {
                dialog.ShowDialog();
                loadTableDevice();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadTableDevice();
        }

        private async void btnImportExcel_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx";
                openFileDialog.Title = "Export Devices to Excel";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    // Call your export method here
                    List<Device> devices= ExcelService.ImportDevicesFromExcel(filePath);
                    if(devices != null && devices.Count > 0)
                    {
                        foreach (var device in devices)
                        {
                            //check not exist by id then add, otherwise skip
                            Device existingDevice = await _deviceService.GetByIdAsync(device.Id);
                            if (existingDevice == null)
                            {
                                // Add new device
                                await _deviceService.AddAsync(device);
                            }
                        }
                        loadTableDevice();
                    }
                    else
                    {
                        MessageBox.Show("No devices found in the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
