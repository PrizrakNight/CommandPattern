namespace CommandPattern;

public static class GenFuExtensions
{
    public static void UseDefaultProducts(this GenFuConfigurator<Product> configurator)
    {
        configurator
            .Fill(x => x.Name)
            .AsMusicGenreName();

        configurator
            .Fill(x => x.Description)
            .AsMusicGenreDescription();

        configurator
            .Fill(x => x.Price)
            .WithinRange(1, 25);
    }
}
