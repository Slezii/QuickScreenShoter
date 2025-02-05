using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickScreenShoter.Core.Services
{
    public interface INavigationService
    {
        void Navigate<T>(object args = null);
        Y Navigate<T, Y>(object args = null);
    }
}
