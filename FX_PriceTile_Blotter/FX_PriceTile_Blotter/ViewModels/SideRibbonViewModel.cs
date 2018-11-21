using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FX_PriceTile_Blotter.Interfaces;
using FX_PriceTile_Blotter.Modules;
using FX_PriceTile_Blotter.Services;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace FX_PriceTile_Blotter.ViewModels
{
    public class SideRibbonViewModel : ViewModelBase
    {
        private ObservableCollection<IRibbonModule> _ribbonItems;
        private IUnityContainer _unityContainer;

        public SideRibbonViewModel(IUnityContainer container)
        {

            _ribbonItems = new ObservableCollection<IRibbonModule>{container.Resolve<SettingsModule>()};
        }


        public string Title => "SideRibbon";

        public string Item1 => "Item 1";

        public string Item2 => "Item 2";

        public string Item3 => "Item 3";

        public ObservableCollection<IRibbonModule> RibbonItems
        {
            get { return _ribbonItems; }
        }

    }
}
