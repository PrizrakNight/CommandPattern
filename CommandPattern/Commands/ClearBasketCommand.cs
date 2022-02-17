namespace CommandPattern.Commands;

public class ClearBasketCommand : CommandBase
{
    private readonly Basket _basket;

    private Product[] _products = Array.Empty<Product>();

    public ClearBasketCommand(Basket basket)
    {
        _basket = basket;
    }

    protected override void OnExecute()
    {
        _products = _basket.Products.ToArray();

        _basket.Products.Clear();
    }

    protected override void OnUndo()
    {
        _basket.Products.AddRange(_products);

        _products = Array.Empty<Product>();
    }
}
