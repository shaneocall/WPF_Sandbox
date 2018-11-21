using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Regions;

namespace FX_PriceTile_Blotter.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        private IRegionManager _regionManager;

        public AppShellViewModel(IRegionManager regionManager,
            TitleBarViewModel titleBarViewModel, 
            StatusBarViewModel statusBarViewModel,
            SideRibbonViewModel sideRibbonViewModel)
        {

            _regionManager = regionManager;
            TitleBarVm = titleBarViewModel;
            StatusBarVm = statusBarViewModel;
            SideRibbonVm = sideRibbonViewModel;

        }

        public string Title => "Shell";

        public TitleBarViewModel TitleBarVm { get; }

        public StatusBarViewModel StatusBarVm { get; }

        public SideRibbonViewModel SideRibbonVm { get; }
    }
}
