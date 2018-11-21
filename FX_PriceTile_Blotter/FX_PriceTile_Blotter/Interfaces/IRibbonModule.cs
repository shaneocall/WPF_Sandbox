using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;

namespace FX_PriceTile_Blotter.Interfaces
{
    public interface IRibbonModule : IModule
    {
        string Label { get; }
        
        int Priority { get; }

        string Glyph { get; }

    }
}
