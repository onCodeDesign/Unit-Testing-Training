using System.Collections.Generic;
using Pos.Wpf.DAL;

namespace Pos.Wpf.Services.Taxes
{
    interface ITaxesFactory
    {
        IEnumerable<ITax> GetTaxesFor(Product product);
    }
}