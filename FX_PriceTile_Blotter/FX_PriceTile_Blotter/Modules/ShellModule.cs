using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FX_PriceTile_Blotter.Feeds;
using FX_PriceTile_Blotter.Interfaces;
using FX_PriceTile_Blotter.Services;
using FX_PriceTile_Blotter.ViewModels;
using FX_PriceTile_Blotter.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace FX_PriceTile_Blotter.Modules
{
    public class ShellModule : IModule
    {
        private readonly IRegionManager _regionManager = null;
        private IUnityContainer _container;


        public ShellModule(IUnityContainer container, IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            this._container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<IViewModel, TitleBarViewModel>();
            _container.RegisterType<IViewModel, StatusBarViewModel>();
            _container.RegisterType<IViewModel, SideRibbonViewModel>();


            _container.RegisterType<IViewModel, AppShellViewModel>();
            _container.RegisterType<IView, FXWindow>();

           //var shell =  _container.Resolve<AppShell>();

           //var dataContext  = _container.Resolve<AppShellViewModel>();

           // shell.DataContext = dataContext;

            //_container.RegisterType<IFxPriceFeed, FXPriceFeed>();

            //this._regionManager.RegisterViewWithRegion("BlotterRegion", typeof(FXWindow));


            //var view = _container.Resolve<IView>();
            //_regionManager.Regions["BlotterRegion"].Add(view);



            //this._regionManager.RegisterViewWithRegion("TreeRegion", typeof(BlotterModule));
        }
    }
}
