using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_PriceTile_Blotter.Interfaces
{
    public interface IRibbonMenuService
    {

        ObservableCollection<IRibbonModule> RibbonItems { get; }

        void RegisterRibbonItem(IRibbonModule ribbonItem);

        void RemoveRibbonItem(IRibbonModule ribbonItem);

      

    }
}
