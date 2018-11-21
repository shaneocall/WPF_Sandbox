using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using FX_PriceTile_Blotter.Extensions;
using FX_PriceTile_Blotter.Interfaces;
using FX_PriceTile_Blotter.Models;

namespace FX_PriceTile_Blotter.ViewModels
{
    public class PriceTileViewModel : ViewModelBase
    {
        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        public PriceTileViewModel(IFxPriceFeed priceFeed)
        {

            priceFeed.PriceFeed.Subscribe(price => BuyPrice = Math.Round(price, 2)).AddTo(_disposables);
            priceFeed.PriceFeed.Subscribe(price => SellPrice = 2 - Math.Round(price, 2)).AddTo(_disposables);

            //_buyPrice = 1.42;
            //_sellPrice = 1.33;

            BuyCommand = new DelegateCommand(o => ExecuteTrade(TradeDirection.Buy, BuyPrice), o => true);
            SellCommand = new DelegateCommand(o => ExecuteTrade(TradeDirection.Sell, SellPrice), o => true);

            BlotterViewModel = new BlotterViewModel();
        }

        private void ExecuteTrade(TradeDirection direction, double price)
        {
            var quantity = new Random();

            BlotterViewModel.TradeList.Add(new TradeViewModel(DateTime.Now, Environment.UserName, direction, "CADUSD",
                quantity.Next(100, 1000), price));
        }

        public ICommand SellCommand { get; }
        public ICommand BuyCommand { get; }

        private double _buyPrice;
        private double _sellPrice;
        private Colour _sellColour = Colour.Black;
        private Colour _buyColour = Colour.Black;

        public double BuyPrice
        {
            get => _buyPrice;
            set => OnPropertyChanged(ref _buyPrice, value, nameof(BuyPrice),
                () => BuyColour = value > _buyPrice ? Colour.Green : Colour.Red);
        }


        public double SellPrice
        {
            get => _sellPrice;
            set => OnPropertyChanged(ref _sellPrice, value, nameof(SellPrice),
                () => { SellColour = value > _sellPrice ? Colour.Green : Colour.Red; });
        }


        public Colour SellColour
        {
            get => _sellColour;
            set => OnPropertyChanged(ref _sellColour, value, nameof(SellColour));
        }

        public Colour BuyColour
        {
            get => _buyColour;
            set => OnPropertyChanged(ref _buyColour, value, nameof(BuyColour));
        }


        public BlotterViewModel BlotterViewModel { get; set; }

        public enum Colour
        {
            Black = 0,
            Red = 1,
            Green = 2
        }


        protected override void Dispose(bool disposing)
        {
            foreach (var disposable in _disposables.Where(x => x != null))
            {
                disposable.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
