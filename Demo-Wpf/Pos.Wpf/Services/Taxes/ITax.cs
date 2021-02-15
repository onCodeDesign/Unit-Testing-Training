using Pos.Wpf.DAL;

namespace Pos.Wpf.Services.Taxes
{
    interface ITax
    {
        decimal ApplyFor(Product product);
    }
}