using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FX_PriceTile_Blotter.Models;

namespace FX_PriceTile_Blotter.ViewModels
{
    public class PriceTileViewModel : ViewModelBase
    {
        public PriceTileViewModel(IObservable<double> PriceFeed)
        {

            PriceFeed.Subscribe(price => BuyPrice = Math.Round(price, 2));
            PriceFeed.Subscribe(price => SellPrice = 2 - Math.Round(price, 2));

            //_buyPrice = 1.42;
            //_sellPrice = 1.33;

            BuyButton = new DelegateCommand(o => ExecuteTrade(TradeDirection.Buy, BuyPrice), o => true);
            SellButton = new DelegateCommand(o => ExecuteTrade(TradeDirection.Sell, SellPrice), o => true);

            BlotterViewModel = new BlotterViewModel();
        }

        private void ExecuteTrade(TradeDirection direction, double price)
        {
            var quantity = new Random();

          BlotterViewModel.TradeList.Add(new TradeViewModel(DateTime.Now, Environment.UserName, direction, "CADUSD", quantity.Next(100, 1000), price));
        }

        public ICommand SellButton { get; }
        public ICommand BuyButton { get; }

        private double _buyPrice;
        private double _sellPrice;

        public double BuyPrice
        {
            get => _buyPrice;
            set => OnPropertyChanged(ref _buyPrice, value, nameof(BuyPrice));
        }

        public double SellPrice
        {
            get => _sellPrice;
            set => OnPropertyChanged( ref _sellPrice, value, nameof(SellPrice));
        }

        public BlotterViewModel BlotterViewModel { get; set; }

    }
}
