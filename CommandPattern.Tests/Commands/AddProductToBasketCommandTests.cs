using CommandPattern.Commands;
using CommandPattern.Models;
using CommandPattern.Tests.Utilities;
using FluentAssertions;
using Xunit;

namespace CommandPattern.Tests.Commands;

public class AddProductToBasketCommandTests
{
    [Fact]
    public void Execute_ShouldAddProduct()
    {
        // Arrange
        var basket = new Basket();
        var product = new Product { Name = "Some product", Price = 100 };
        var command = new AddProductToBasketCommand(basket, product);

        // Act
        command.Execute();

        // Assert
        basket.Products.Should().HaveCount(1);
    }

    [Fact]
    public void Undo_ShouldRemoveProduct()
    {
        // Arrange
        var basket = new Basket();
        var product = new Product { Name = "Some product", Price = 100 };
        var command = new AddProductToBasketCommand(basket, product);

        CommandUtility.SetExecutedPropertyValue(command, true);

        basket.Products.Add(product);

        // Act
        command.Undo();

        // Assert
        basket.Products.Should().BeEmpty();
    }
}
