using CommunityToolkit.Mvvm.ComponentModel;
using QuickScreenShoter.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickScreenShoter.Core.Base
{
    public class BaseViewModel(INavigationService NavigationService) : ObservableObject
    {
    }
}
