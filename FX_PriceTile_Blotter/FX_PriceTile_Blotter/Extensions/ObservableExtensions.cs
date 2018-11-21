using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_PriceTile_Blotter.Extensions
{
    public static class ObservableExtensions
    {
        public static IDisposable AddTo(this IDisposable disposable, List<IDisposable> disposableList)
        {
            disposableList.Add(disposable);

            return disposable;
        }
    }
}
