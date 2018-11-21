using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FX_PriceTile_Blotter.Interfaces;
using Prism.Modularity;
using Prism.Regions;

namespace FX_PriceTile_Blotter.Modules
{
    public class SettingsModule :  IRibbonModule
    {
        private readonly IRegionViewRegistry regionViewRegistry = null;
        private IRibbonMenuService ribbonMenuService;

        public SettingsModule(IRegionViewRegistry regionViewRegistry)
        {
            this.regionViewRegistry = regionViewRegistry;
            this.ribbonMenuService = ribbonMenuService;
        }
        public void Initialize()
        {
        }


        public string Label
        {
            get { return "Settings"; }
        }
        public int Priority
        {
            get { return 3; }
        }
        public string Glyph
        {
            get { return "&#xE80F;"; }
        }
    }
}
