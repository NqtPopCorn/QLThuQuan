using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZXing.Windows.Compatibility;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace QLThuQuan.Winforms.Helpers
{
    public class ParseCodeHelper
    {
        
        public static int ParseDeviceId(string code)
        {
            string[] parts = code.Split("-");
            if (parts.Length == 2 && parts[0].Equals("device"))
            {
                return int.Parse(parts[1]);
            }

            return -1;
        }

        public static string ParseUserEmail(string code)
        {
            return code;
            //string[] parts = code.Split("-");
            //if (parts.Length == 2 && parts[0].Equals("user"))
            //{
            //    return parts[1];
            //}
            //return string.Empty;
        }
    }
}