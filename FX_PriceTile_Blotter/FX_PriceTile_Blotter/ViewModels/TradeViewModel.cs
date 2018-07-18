using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FX_PriceTile_Blotter.Models;

namespace FX_PriceTile_Blotter.ViewModels
{
    public class TradeViewModel : ViewModelBase
    {
        private DateTime _timeStamp;
        private string _trader;
        private TradeDirection _direction;
        private string _ccyPair;
        private double _quantity;
        private double _price;


        public TradeViewModel(DateTime timeStamp, string trader, TradeDirection direction, string ccyPair,
            double quantity, double price)
        {
            _timeStamp = timeStamp;
            _trader = trader;
            _direction = direction;
            _ccyPair = ccyPair;
            _quantity = quantity;
            _price = price;
        }

        public DateTime TimeStamp
        {
            get => _timeStamp;
            private set => OnPropertyChanged(ref _timeStamp, value, nameof(TimeStamp));
        }

        public string Trader
        {
            get => _trader;
            private set => OnPropertyChanged(ref _trader, value, nameof(Trader));
        }

        public TradeDirection Direction
        {
            get => _direction;
            private set => OnPropertyChanged(ref _direction, value, nameof(Direction));
        }

        public string CcyPair
        {
            get => _ccyPair;
            private set => OnPropertyChanged(ref _ccyPair, value, nameof(CcyPair));
        }

        public double Quantity
        {
            get => _quantity;
            private set => OnPropertyChanged(ref _quantity, value, nameof(Quantity));
        }

        public double Price
        {
            get => _price;
            private set => OnPropertyChanged(ref _price, value, nameof(Price));
        }




    }
}
