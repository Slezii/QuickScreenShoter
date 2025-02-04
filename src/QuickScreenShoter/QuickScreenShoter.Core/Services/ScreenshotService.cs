using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickScreenShoter.Core.Services
{
    public class ScreenshotService : IScreenshotService
    {
        private readonly ISettingsService _settingsService;

        public ScreenshotService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task<Rectangle?> SelectRegionAsync()
        {
            //var selectionWindow = new SelectionWindow();
            //var result = await selectionWindow.ShowAsync();
            return null;
        }

        public async Task<Bitmap> CaptureAsync(Rectangle region)
        {
            // Implementation for capturing screen region
            var bitmap = new Bitmap(region.Width, region.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(region.X, region.Y, 0, 0, region.Size);
            }
            return bitmap;
        }

        public async Task<string> SaveAsync(Bitmap screenshot)
        {
            var fileName = $"Screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var savePath = Path.Combine(
                //_settingsService.GetSetting<string>("SavePath") ??
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                fileName
            );

            await Task.Run(() => screenshot.Save(savePath, ImageFormat.Png));
            return savePath;
        }
    }
}
