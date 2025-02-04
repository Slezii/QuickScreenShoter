using Microsoft.Extensions.DependencyInjection;
using QuickScreenShoter.Core.Services;
using QuickScreenShoter.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickScreenShoter.Core.Startup
{
    public class ContainerBuilder
    {
        public static IServiceProvider ConfigureContainer()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainViewModel>();

            services.AddSingleton<IScreenshotService, ScreenshotService>();
            services.AddSingleton<ISettingsService, SettingsService>();

            return services.BuildServiceProvider();
        }
    }
}
