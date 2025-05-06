using ClosedXML.Excel;
using QLThuQuan.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuQuan.Winforms.Helpers
{
    public class ExcelService
    {
        /// <summary>
        /// Exports a list of devices to an Excel file.
        /// </summary>
        /// <param name="devices">List of devices to export.</param>
        /// <param name="filePath">Path to save the Excel file.</param>
        /// <returns>True if export is successful to Sheet 'Devices', false otherwise.</returns>
        public static bool ExportDevicesToExcel(List<Device> devices, string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Devices");

                    // Add header row
                    worksheet.Cell(1, 1).Value = "ID";
                    worksheet.Cell(1, 2).Value = "Name";
                    worksheet.Cell(1, 3).Value = "Description";
                    worksheet.Cell(1, 4).Value = "Status";
                    worksheet.Cell(1, 5).Value = "Image Path";

                    // Add data rows
                    for (int i = 0; i < devices.Count; i++)
                    {
                        var device = devices[i];
                        worksheet.Cell(i + 2, 1).Value = device.Id;
                        worksheet.Cell(i + 2, 2).Value = device.Name;
                        worksheet.Cell(i + 2, 3).Value = device.Description;
                        worksheet.Cell(i + 2, 4).Value = device.Status;
                        worksheet.Cell(i + 2, 5).Value = device.ImagePath ?? string.Empty;
                    }

                    // Auto-fit columns for better readability
                    worksheet.Columns().AdjustToContents();

                    // Save the file
                    workbook.SaveAs(filePath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting devices to Excel: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Imports a list of devices from an Excel file.
        /// </summary>
        /// <param name="filePath">Path to the Excel file.</param>
        /// <returns>List of devices read from the file (first sheet).</returns>
        public static List<Device> ImportDevicesFromExcel(string filePath)
        {
            var devices = new List<Device>();

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Excel file not found.");
                }

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RowsUsed().Skip(1);

                    foreach (var row in rows)
                    {
                        var device = new Device
                        {
                            Id = row.Cell(1).GetValue<int>(),
                            Name = row.Cell(2).GetValue<string>(),
                            Description = row.Cell(3).GetValue<string>(),
                            Status = row.Cell(4).GetValue<string>(),
                            ImagePath = row.Cell(5).GetValue<string>()
                        };

                        if (!string.IsNullOrEmpty(device.Name) && !string.IsNullOrEmpty(device.Status))
                        {
                            devices.Add(device);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importing devices from Excel: {ex.Message}");
            }

            return devices;
        }

        /// <summary>
        /// Exports a list of users to an Excel file.
        /// </summary>
        /// <param name="users">List of users to export.</param>
        /// <param name="filePath">Path to save the Excel file.</param>
        /// <returns>True if export is successful to sheet 'Users', false otherwise.</returns>
        public static bool ExportUsersToExcel(List<User> users, string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var wrinkle = workbook.Worksheets.Add("Users");

                    // Add header row
                    wrinkle.Cell(1, 1).Value = "ID";
                    wrinkle.Cell(1, 2).Value = "First Name";
                    wrinkle.Cell(1, 3).Value = "Last Name";
                    wrinkle.Cell(1, 4).Value = "Email";
                    wrinkle.Cell(1, 5).Value = "Password";
                    wrinkle.Cell(1, 6).Value = "Is Admin";
                    wrinkle.Cell(1, 7).Value = "Created At";

                    // Add data rows
                    for (int i = 0; i < users.Count; i++)
                    {
                        var user = users[i];
                        wrinkle.Cell(i + 2, 1).Value = user.Id;
                        wrinkle.Cell(i + 2, 2).Value = user.FirstName;
                        wrinkle.Cell(i + 2, 3).Value = user.LastName;
                        wrinkle.Cell(i + 2, 4).Value = user.Email;
                        wrinkle.Cell(i + 2, 5).Value = user.Password;
                        wrinkle.Cell(i + 2, 6).Value = user.IsAdmin;
                        wrinkle.Cell(i + 2, 7).Value = user.CreateAt.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    // Auto-fit columns for better readability
                    wrinkle.Columns().AdjustToContents();

                    // Save the file
                    workbook.SaveAs(filePath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting users to Excel: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Imports a list of users from an Excel file.
        /// </summary>
        /// <param name="filePath">Path to the Excel file.</param>
        /// <returns>List of users read from the file (first sheet).</returns>
        public static List<User> ImportUsersFromExcel(string filePath)
        {
            var users = new List<User>();

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Excel file not found.");
                }

                using (var workbook = new XLWorkbook(filePath))
                {
                    var wrinkle = workbook.Worksheet(1);
                    var rows = wrinkle.RowsUsed().Skip(1);

                    foreach (var row in rows)
                    {
                        var user = new User
                        {
                            Id = row.Cell(1).GetValue<int>(),
                            FirstName = row.Cell(2).GetValue<string>(),
                            LastName = row.Cell(3).GetValue<string>(),
                            Email = row.Cell(4).GetValue<string>(),
                            Password = row.Cell(5).GetValue<string>(),
                            IsAdmin = row.Cell(6).GetValue<bool>(),
                            CreateAt = row.Cell(7).GetValue<DateTime>()
                        };

                        // Validate required fields
                        if (!string.IsNullOrEmpty(user.FirstName) &&
                            !string.IsNullOrEmpty(user.LastName) &&
                            !string.IsNullOrEmpty(user.Email) &&
                            !string.IsNullOrEmpty(user.Password))
                        {
                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importing users from Excel: {ex.Message}");
            }

            return users;
        }
    }
}