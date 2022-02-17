namespace CommandPattern.Models;

public class Product
{
    public decimal Price { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Price:#.##$}";
    }
}
