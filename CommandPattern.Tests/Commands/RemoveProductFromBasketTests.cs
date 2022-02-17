using CommandPattern.Commands;
using CommandPattern.Models;
using CommandPattern.Tests.Utilities;
using FluentAssertions;
using Xunit;

namespace CommandPattern.Tests.Commands;

public class RemoveProductFromBasketTests
{
    [Fact]
    public void Execute_ShouldRemoveProduct()
    {
        // Arrange
        var basket = new Basket();
        var product = new Product { Name = "Product", Price = 100 };
        var command = new RemoveProductFromBasket(basket, product);

        basket.Products.Add(product);

        // Act
        command.Execute();

        // Assert
        basket.Products.Should().BeEmpty();
    }

    [Fact]
    public void Undo_ShouldRestoreProduct()
    {
        // Arrange
        var basket = new Basket();
        var product = new Product { Name = "Product", Price = 100 };
        var command = new RemoveProductFromBasket(basket, product);

        CommandUtility.SetExecutedPropertyValue(command, true);

        // Act
        command.Undo();

        // Assert
        basket.Products.Should().HaveCount(1);
    }
}
