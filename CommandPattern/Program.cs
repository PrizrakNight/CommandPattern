GenFu.GenFu.Configure<Product>().UseDefaultProducts();

Console.WriteLine("Welcome to Simple Store!");

ConsoleShop.PrintHelpMenu();

while (true)
{
    var command = Console.ReadLine()?.ToLower();

    if (string.IsNullOrWhiteSpace(command))
    {
        Console.WriteLine("You entered empty data.");

        continue;
    }

    switch (command)
    {
        case "add":
        case "a":

            if (ConsoleShop.TryReadIndex(out var indexToAdd))
                ConsoleShop.AddToBasket(indexToAdd);

            break;

        case "remove":
        case "r":

            if (ConsoleShop.TryReadIndex(out var indexToRemove))
                ConsoleShop.RemoveFromBasket(indexToRemove);

            break;

        case "clear":
        case "c":

            ConsoleShop.ClearBasket();

            break;

        case "products":
        case "p":

            ConsoleShop.PrintShopProducts();

            break;

        case "basket":
        case "b":

            ConsoleShop.PrintBasket();

            break;

        case "refresh":
        case "rf":

            ConsoleShop.RefreshShopProducts();

            break;

        case "exit":
        case "e":

            Environment.Exit(0);

            break;

        case "undo":
        case "u":

            ConsoleShop.UndoLastCommand();

            break;

        default:
            Console.WriteLine("Unknown command.");
            break;
    }
}