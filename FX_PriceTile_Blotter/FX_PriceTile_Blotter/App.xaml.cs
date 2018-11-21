using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using FX_PriceTile_Blotter.Feeds;
using FX_PriceTile_Blotter.ViewModels;

namespace FX_PriceTile_Blotter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App(string[] args)
        {
            var priceFeed = new FXPriceFeed();
            var blotterVm = new BlotterViewModel();

            var numOfWindows = 1;

            if (args.Any() )
            {
                if(!int.TryParse(args.FirstOrDefault(), out numOfWindows)) numOfWindows = 1;
            }

            var windowList = new List<Window>();

            for (var i = 0; i < numOfWindows; i++)
            {
                windowList.Add(CreateWindow(priceFeed, blotterVm, "Blotter " +i));
            }

           windowList.ForEach(x => x.Show());
        }

        private Window CreateWindow(FXPriceFeed priceFeed, BlotterViewModel blotterVm, string title)
        {
            var vm = new PriceTileViewModel(blotterVm, priceFeed.PriceFeed);
            var window = new FXWindow() { DataContext = vm, Title = title };
            return window;
        }
    }
}
