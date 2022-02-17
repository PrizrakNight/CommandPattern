using CommandPattern.Commands;

namespace CommandPattern;

public static class ConsoleShop
{
    private static CommandRecorder _recorder = new();

    public static void PrintHelpMenu()
    {
        Console.WriteLine("Commands: ");
        Console.WriteLine("Add|A {index} - Add product with index {index} to basket.");
        Console.WriteLine("Remove|R {index} - Remove product with index {index} from basket.");
        Console.WriteLine("Clear|C - Clear the basket.");
        Console.WriteLine("Refresh|RF - Update the assortment of goods in the store.");
        Console.WriteLine("Products|P - Display available products in the store.");
        Console.WriteLine("Basket|B - Display products in basket.");
        Console.WriteLine("Undo|U - Cancels the previous operation.");
        Console.WriteLine("Exit|E - Close program.");
    }

    public static void PrintShopProducts()
    {
        Console.WriteLine("Store's current musics: ");

        for (int i = 0; i < SimpleShop.RandomMusics.Length; i++)
        {
            Console.WriteLine($" [{i}] - " + SimpleShop.RandomMusics[i]);
        }
    }

    public static void PrintBasket()
    {
        if (SimpleShop.UserBasket.Products.Count == 0)
        {
            Console.WriteLine("Basket is empty.");

            return;
        }

        Console.WriteLine($"Your basket cost: {SimpleShop.UserBasket.Cost:#.##$}");
        Console.WriteLine("Basket contents:");

        for (int i = 0; i < SimpleShop.UserBasket.Products.Count; i++)
        {
            Console.WriteLine($" [{i}] - " + SimpleShop.UserBasket.Products[i]);
        }
    }

    public static bool TryReadIndex(out int index)
    {
        Console.WriteLine("Enter the index of the item you are interested in: ");

        var indexString = Console.ReadLine();

        if (int.TryParse(indexString, out index))
            return true;

        Console.WriteLine("You entered incorrect data.");

        return false;
    }

    public static void AddToBasket(int index)
    {
        var product = GetProductByIndex(SimpleShop.RandomMusics, index);

        if (product != null)
        {
            if (SimpleShop.UserBasket.Products.Contains(product))
            {
                Console.WriteLine("The product is already in the basket.");

                return;
            }

            var command = new AddProductToBasketCommand(SimpleShop.UserBasket, product);

            _recorder.RecordCommand(command);

            Console.WriteLine("OK.");
        }
    }

    public static void RefreshShopProducts()
    {
        SimpleShop.RefreshMusics();

        Console.WriteLine("OK.");
    }

    public static void RemoveFromBasket(int index)
    {
        var product = GetProductByIndex(SimpleShop.UserBasket.Products, index);

        if (product != null)
        {
            var command = new RemoveProductFromBasket(SimpleShop.UserBasket, product);

            _recorder.RecordCommand(command);

            Console.WriteLine("OK.");
        }
    }

    public static void ClearBasket()
    {
        if (SimpleShop.UserBasket.Products.Count == 0)
        {
            Console.WriteLine("Basket already empty.");

            return;
        }

        var command = new ClearBasketCommand(SimpleShop.UserBasket);

        _recorder.RecordCommand(command);

        Console.WriteLine("OK.");
    }

    public static void UndoLastCommand()
    {
        var command = _recorder.UndoCommand();

        if (command == null)
        {
            Console.WriteLine("There are no more commands to rollback.");

            return;
        }

        Console.WriteLine($"'{command.GetType().Name}' command canceled successfully.");
    }

    private static Product? GetProductByIndex(this IEnumerable<Product> products, int index)
    {
        ArgumentNullException.ThrowIfNull(products, nameof(products));

        try
        {
            return products.ElementAt(index);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("You have entered a non-existent product index.");

            return null;
        }
    }

    private static void ToMainMenu()
    {
        Console.WriteLine("Press any key to go to the main menu...");
        Console.ReadKey(true);

        PrintShopProducts();
    }
}
