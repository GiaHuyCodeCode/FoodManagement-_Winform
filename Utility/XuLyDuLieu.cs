using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Utility
{
    internal class XuLyDuLieu
    {
        public string value { get; set; }
        public string FormatWithCommas(int value)
        {
            // Định dạng số có dấu phân cách
            string formattedValue = value.ToString("#,##0");

            return formattedValue;
        }
    }
}
