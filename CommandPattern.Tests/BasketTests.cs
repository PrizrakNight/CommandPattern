using CommandPattern.Models;
using FluentAssertions;
using Xunit;

namespace CommandPattern.Tests;

public class BasketTests
{
    [Fact]
    public void Cost_ShouldBe500()
    {
        // Arrange
        var basket = new Basket();
        var products = new[]
        {
            new Product { Name = "Product", Price = 250 },
            new Product { Name = "Product", Price = 250 }
        };

        // Act
        basket.Products.AddRange(products);

        // Assert
        basket.Cost.Should().Be(500);
    }

    [Fact]
    public void Cost_ShouldBeZero()
    {
        // Arrange
        var basket = new Basket();

        // Assert
        basket.Cost.Should().Be(0);
    }
}
