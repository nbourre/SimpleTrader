using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_ef.ViewModels;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexListingViewModel : BaseViewModel
    {
        private IMajorIndexService _majorIndexService;
        private MajorIndex dowJones;
        private MajorIndex nasdaq;
        private MajorIndex sP500;

        public MajorIndex DowJones
        {
            get => dowJones;
            set
            {
                dowJones = value;
                OnPropertyChanged();
            }
        }

        public MajorIndex Nasdaq 
        { 
            get => nasdaq;
            set { 
                nasdaq = value;
                OnPropertyChanged();
            }
        }

        public MajorIndex SP500
        {
            get => sP500;
            set { 
                sP500 = value;
                OnPropertyChanged();
            }
        }

        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            var majorIndexViewModel = new MajorIndexListingViewModel(majorIndexService);
            majorIndexViewModel.LoadMajorIndexes();

            return majorIndexViewModel;
        }

        private void LoadMajorIndexes()
        {
            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task =>
           {
               if (task.Exception == null)
               {
                   DowJones = task.Result;
               }

           });

            _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Nasdaq = task.Result;
                }

            });

            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    SP500 = task.Result;
                }

            });
        }
    }
}
