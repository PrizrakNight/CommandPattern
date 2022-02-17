using CommandPattern.Models;

namespace CommandPattern.Commands;

public class AddProductToBasketCommand : CommandBase
{
    private readonly Basket _basket;
    private readonly Product _product;

    public AddProductToBasketCommand(Basket basket, Product product)
    {
        _basket = basket;
        _product = product;
    }

    protected override void OnExecute()
    {
        _basket.Products.Add(_product);
    }

    protected override void OnUndo()
    {
        _basket.Products.Remove(_product);
    }
}
