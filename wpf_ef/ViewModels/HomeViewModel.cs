using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_ef.ViewModels;

namespace SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public MajorIndexListingViewModel MajorIndexListingViewModel { get; set; }

        public HomeViewModel(MajorIndexListingViewModel majorIndexListingViewModel)
        {
            MajorIndexListingViewModel = majorIndexListingViewModel;
        }
    }
}
