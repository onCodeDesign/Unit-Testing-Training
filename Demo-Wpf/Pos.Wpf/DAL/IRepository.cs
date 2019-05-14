namespace Pos.Wpf.DAL
{
    public interface IRepository
    {
        Product GetProduct(string eBarcode);
    }
}