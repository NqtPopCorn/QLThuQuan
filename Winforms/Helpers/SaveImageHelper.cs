using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuQuan.Winforms.Helpers
{
    public class SaveImageHelper
    {
        public static string CopyImage(string filePath, string relativePath)
        {
            //bo dau / dau va cuoi cua relativePath
            relativePath = relativePath.TrimStart('/').TrimEnd('/');

            //copy image to imageRoot
            string destinationPath = Path.Combine(Program.wwwRoot, relativePath);
            if (!Directory.Exists(Program.wwwRoot))
            {
                Directory.CreateDirectory(Program.wwwRoot);
            }
            //create directory if not exists
            if (!File.Exists(destinationPath))
            {
                File.Copy(filePath, destinationPath);
            }
            return relativePath;
        }

        public static string GetImageAbsolutePath(string relativePath)
        {
            //bo dau / dau va cuoi cua relativePath
            relativePath = relativePath.TrimStart('/').TrimEnd('/');

            string filePath = Path.Combine(Program.wwwRoot, relativePath);
            if (File.Exists(filePath))
            {
                return filePath;
            }
            return null;
        }
    }
}
