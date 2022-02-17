using CommandPattern.Commands;
using CommandPattern.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Tests.Utilities;

public static class CommandUtility
{
    public static void SetExecutedPropertyValue(CommandBase command, bool value)
    {
        var propertyInfo = typeof(CommandBase).GetProperty(nameof(CommandBase.Executed));

        propertyInfo!.SetValue(command, value);
    }

    public static void SetProductsValue(ClearBasketCommand command, IEnumerable<Product> products)
    {
        var fieldInfo = typeof(ClearBasketCommand).GetField("_products", BindingFlags.NonPublic | BindingFlags.Instance);

        fieldInfo!.SetValue(command, products.ToArray());
    }

    public static int CountRecordedCommands(CommandRecorder recorder)
    {
        var propertyInfo = typeof(Stack<CommandBase>).GetProperty(nameof(Stack<CommandBase>.Count));
        var fieldInfo = typeof(CommandRecorder).GetField("_commands", BindingFlags.Instance | BindingFlags.NonPublic);

        var result = propertyInfo!.GetValue(fieldInfo!.GetValue(recorder));

        return (int)result!;
    }
}
