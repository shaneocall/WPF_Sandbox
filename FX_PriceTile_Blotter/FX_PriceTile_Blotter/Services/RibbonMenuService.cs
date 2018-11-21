using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FX_PriceTile_Blotter.Interfaces;

namespace FX_PriceTile_Blotter.Services
{
    public class RibbonMenuService : IRibbonMenuService
    {
        private ObservableCollection<IRibbonModule> _ribbonItems;

        public RibbonMenuService()
        {
            _ribbonItems = new ObservableCollection<IRibbonModule>();
        }

        public ObservableCollection<IRibbonModule> RibbonItems
        {
            get { return _ribbonItems; }
        }

        public void RegisterRibbonItem(IRibbonModule ribbonItem)
        {
            _ribbonItems.Add(ribbonItem);
        }

        public void RemoveRibbonItem(IRibbonModule ribbonItem)
        {
            _ribbonItems.Remove(ribbonItem);
        }
    }
}
