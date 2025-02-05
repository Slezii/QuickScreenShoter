using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickScreenShoter.Ui.Extensions
{
    internal static class WindowsFoundationExtensions
    {
        public static System.Drawing.Point ToSystemDrawingPoint(this Windows.Foundation.Point point) => 
            new System.Drawing.Point(
                (int)point.X, 
                (int)point.Y);
    }
}
