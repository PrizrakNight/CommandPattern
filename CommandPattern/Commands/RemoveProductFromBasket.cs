using CommandPattern.Models;

namespace CommandPattern.Commands;

public class RemoveProductFromBasket : CommandBase
{
    private readonly Basket _basket;
    private readonly Product _product;

    public RemoveProductFromBasket(Basket basket, Product product)
    {
        _basket = basket;
        _product = product;
    }

    protected override void OnExecute()
    {
        _basket.Products.Remove(_product);
    }

    protected override void OnUndo()
    {
        _basket.Products.Add(_product);
    }
}
