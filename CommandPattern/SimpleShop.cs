namespace CommandPattern;

public static class SimpleShop
{
    public static Basket UserBasket { get; } = new();

    public static Product[] RandomMusics
    {
        get
        {
            if (_musics == null || _musics.Length == 0)
                _musics = GenFu.GenFu.ListOf<Product>(6).ToArray();

            return _musics;
        }
    }

    private static Product[] _musics = null!;

    public static void RefreshMusics() => _musics = GenFu.GenFu.ListOf<Product>(6).ToArray();
}
