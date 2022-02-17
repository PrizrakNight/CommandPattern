namespace CommandPattern.Models;

public class Basket
{
    public decimal Cost
    {
        get
        {
            if (Products == null || Products.Count == 0)
                return 0;

            return Products.Sum(x => x.Price);
        }
    }

    public List<Product> Products { get; } = new();
}
