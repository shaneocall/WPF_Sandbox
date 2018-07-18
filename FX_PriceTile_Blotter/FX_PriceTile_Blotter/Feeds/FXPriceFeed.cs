using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FX_PriceTile_Blotter.Feeds
{
    public  class FXPriceFeed
    {
        private Subject<double> _priceSubject = new Subject<double>();

        public  FXPriceFeed()
        {
            //Console.WriteLine("Shows use of Start to start on a background thread:");

            _priceSubject.OnNext(1.33);

            var task = new Task(() =>
            {
                var randPrice = new Random();
                while (true)
                {
                    _priceSubject.OnNext(randPrice.Next(0, 2) + randPrice.NextDouble());
                    Thread.Sleep(1000);
                }
            });

            task.Start();
     
    }


        public IObservable<double> PriceFeed
        {
            get { return _priceSubject.AsObservable(); }
        }

    }


}
