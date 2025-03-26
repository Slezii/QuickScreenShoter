using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickScreenShoter.Core.ViewModels.Interfaces
{
    internal interface IPageViewModel : INotifyPropertyChanged
    {
        public bool IsActive { get; set; }
    }
}
