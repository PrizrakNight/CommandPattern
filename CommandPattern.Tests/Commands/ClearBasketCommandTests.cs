using CommandPattern.Commands;
using CommandPattern.Models;
using CommandPattern.Tests.Utilities;
using FluentAssertions;
using Xunit;

namespace CommandPattern.Tests.Commands
{
    public class ClearBasketCommandTests
    {
        [Fact]
        public void Execute_ShouldClearBasket()
        {
            // Arrange
            var basket = new Basket();
            var command = new ClearBasketCommand(basket);

            var products = new[]
            {
                new Product { Name = "Product 1", Price = 100 },
                new Product { Name = "Product 2", Price = 200 },
                new Product { Name = "Product 3", Price = 300 },
            };

            basket.Products.AddRange(products);

            // Act
            command.Execute();

            // Assert
            basket.Products.Should().BeEmpty();
        }

        [Fact]
        public void Undo_ShouldRestoreBasket()
        {
            // Arrange
            var basket = new Basket();
            var command = new ClearBasketCommand(basket);
            var products = new[]
            {
                new Product { Name = "Product 1", Price = 100 },
                new Product { Name = "Product 2", Price = 200 },
                new Product { Name = "Product 3", Price = 300 },
            };

            CommandUtility.SetExecutedPropertyValue(command, true);
            CommandUtility.SetProductsValue(command, products);

            // Act
            command.Undo();

            // Assert
            basket.Products.Should().HaveCount(3);
        }
    }
}
