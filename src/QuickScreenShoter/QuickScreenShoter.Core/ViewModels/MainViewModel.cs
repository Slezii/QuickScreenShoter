using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuickScreenShoter.Core.Base;
using QuickScreenShoter.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickScreenShoter.Core.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IScreenshotService _screenshotService;
        private readonly ISettingsService _settingsService;

        [ObservableProperty]
        private string statusMessage = "Ready to capture";

        [ObservableProperty]
        private bool runInBackground;

        public MainViewModel(
            IScreenshotService screenshotService,
            ISettingsService settingsService)
        {
            _screenshotService = screenshotService;
            _settingsService = settingsService;
            LoadSettings();
        }

        private void LoadSettings()
        {
            //RunInBackground = _settingsService.GetSetting<bool>("RunInBackground");
        }

        [RelayCommand]
        private async Task StartCapture()
        {
            try
            {
                StatusMessage = "Selecting region...";
                var region = await _screenshotService.SelectRegionAsync();

                if (region != null)
                {
                    StatusMessage = "Capturing...";
                    var screenshot = await _screenshotService.CaptureAsync(region.Value);
                    var path = await _screenshotService.SaveAsync(screenshot);
                    StatusMessage = $"Saved to: {path}";
                }
                else
                {
                    StatusMessage = "Capture cancelled";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        [RelayCommand]
        private async Task OpenSettings()
        {
        }

        partial void OnRunInBackgroundChanged(bool value)
        {
        }
    }

}
