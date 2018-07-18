using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FX_PriceTile_Blotter.ViewModels
{
    public class PriceTileVM : ViewModelBase
    {
        public PriceTileVM()
        {

            _buyText = "Buy";
            _sellText = "Sell";

            SellButton = new DelegateCommand(o => SellText = "You Sold!", o => true);



        }

        private string _buyText;
        private string _sellText;
        private ICommand _buyCommand;


        public string BuyText
        {
            get => _buyText;
            set
            {
                OnPropertyChanged(ref _buyText, value, nameof(BuyText));
                            }
        }

        public string SellText
        {
            get => _sellText;
            set
            {
                //if(value == _sellText) return;
                //_sellText = value;
                //OnPropertyChanged(nameof(SellText));

                OnPropertyChanged( ref _sellText, value, nameof(SellText), () => BuyText = "Pre Set Text", () => BuyText = "Post Set Text");
            }
        }



        public ICommand SellButton { get; }
    }
}
