using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FX_PriceTile_Blotter.Feeds;
using FX_PriceTile_Blotter.ViewModels;


namespace FX_PriceTile_Blotter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Bootstrapper _bootstrapper;
        //private void App_OnStartup(object sender, StartupEventArgs e)
        //{
        //    var priceFeed = new FXPriceFeed();
        //    var vm = new PriceTileViewModel(priceFeed.PriceFeed);
        //    var window = new FXWindow() {DataContext = vm};



        //    window?.Show();

        //}

        protected override void OnStartup(StartupEventArgs e)
        {
       

            base.OnStartup(e);
            _bootstrapper = new Bootstrapper();
            _bootstrapper.Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {

            _bootstrapper.Dispose();
            base.OnExit(e);
        }


    }
}
