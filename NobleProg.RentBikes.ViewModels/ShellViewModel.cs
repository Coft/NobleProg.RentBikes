using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleProg.RentBikes.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        public BaseViewModel ViewModel { get; set; }
        public ShellViewModel()
        {
            ViewModel = new BikesViewModel();
            // don't work because of WINDOW-Type - one needs a UserControl
            //ViewModel = new StationsViewModel();
        }
    }
}
