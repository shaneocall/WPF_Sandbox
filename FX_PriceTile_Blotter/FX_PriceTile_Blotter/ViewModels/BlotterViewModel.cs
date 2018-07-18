using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_PriceTile_Blotter.ViewModels
{
    public class BlotterViewModel : ViewModelBase
    {
        private ObservableCollection<TradeViewModel> _tradeList;

        public BlotterViewModel()
        {
           _tradeList = new ObservableCollection<TradeViewModel>();

        }
        

        public ObservableCollection<TradeViewModel> TradeList
        {
            get => _tradeList;
            set => OnPropertyChanged(ref _tradeList, value, nameof(TradeList));
        }
    }
}
