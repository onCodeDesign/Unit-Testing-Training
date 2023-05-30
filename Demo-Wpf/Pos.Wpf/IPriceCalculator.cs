using System.Linq;
using Pos.Wpf.DAL;

namespace Pos.Wpf
{
	public interface IPriceCalculator
	{
		decimal GetPrice(Product product);
	}

	class PriceCalculator : IPriceCalculator
	{
		public decimal GetPrice(Product product)
		{
			if (product.Taxes.Contains(TaxationType.Vat))
				return product.Price * 1.19m;

			return product.Price;
		}
	}
}