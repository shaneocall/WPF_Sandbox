using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FX_PriceTile_Blotter.Feeds;
using FX_PriceTile_Blotter.Interfaces;
using FX_PriceTile_Blotter.Services;
using FX_PriceTile_Blotter.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace FX_PriceTile_Blotter
{
     class Bootstrapper : UnityBootstrapper, IDisposable
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<AppShell>();
        }

        protected override void InitializeModules()
        {
            RegisterServices();
           base.InitializeModules();
            App.Current.MainWindow = (AppShell)this.Shell;
            App.Current.MainWindow.Show();

            
        }

        public delegate void MytestDelegate();



        private void RegisterServices()
        {
            Container.RegisterInstance<IRibbonMenuService>(new RibbonMenuService());
            Container.RegisterType<IFxPriceFeed, FXPriceFeed>();
           

            var myDelegate = new MytestDelegate(MyTestFunction);

           

            ThresholdReached += (sender, args) => myDelegate() ;

            ThresholdReached.Invoke(this, new EventArgs());
        }




        public event EventHandler ThresholdReached;

        protected virtual void OnThresholdReached(object sender, EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }

            int c = 6;

            c = null;
        }


        public void MyTestFunction()
        {

            return;
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();


            //var type = typeof(IModule);
            //var types = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => type.IsAssignableFrom(p));

           var modulesToLoad = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x).ToList();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            // Seems like as soon as you add a new module, internally seletor module
            // adopter (since blotter region is on tab control), automatically adds a tab item)

            foreach (var module in modulesToLoad)
            {
                moduleCatalog.AddModule(module);
            }

        }

        private void LoadModules()
        {
            
        }

        public void Dispose()
        {
           
        }
    }
}
