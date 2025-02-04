using System.Drawing;

namespace QuickScreenShoter.Core.Services;


public interface IScreenshotService
{
    Task<Rectangle?> SelectRegionAsync();
    Task<Bitmap> CaptureAsync(Rectangle region);
    Task<string> SaveAsync(Bitmap screenshot);
}