using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FX_PriceTile_Blotter.Feeds;
using FX_PriceTile_Blotter.Interfaces;
using FX_PriceTile_Blotter.ViewModels;
using FX_PriceTile_Blotter.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace FX_PriceTile_Blotter.Modules
{
    public class BlotterModule : IModule
    {
        private readonly IRegionManager _regionManager = null;
        private IUnityContainer _container;
            

        public BlotterModule(IUnityContainer container, IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            this._container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<IView, FXWindow>();
            _container.RegisterType<IViewModel, PriceTileViewModel>();

            //this._regionManager.RegisterViewWithRegion("BlotterRegion", typeof(FXWindow));


            //var view = _container.Resolve<IView>();
            //_regionManager.Regions["BlotterRegion"].Add(view);



            //this._regionManager.RegisterViewWithRegion("TreeRegion", typeof(BlotterModule));
        }
    }
}
