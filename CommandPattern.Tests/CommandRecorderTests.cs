using CommandPattern.Commands;
using CommandPattern.Models;
using CommandPattern.Tests.Utilities;
using FluentAssertions;
using System;
using Xunit;

namespace CommandPattern.Tests;

public class CommandRecorderTests
{
    [Fact]
    public void RecordCommand_Null_ThrowArgumentNullException()
    {
        // Arrange
        var commandRecorder = new CommandRecorder();

        // Act
        commandRecorder
            .Invoking(x => x.RecordCommand(null!))
            .Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void RecordCommand_AddProduct_ShouldExecuteAndRecord()
    {
        // Arrange
        var commandRecorder = new CommandRecorder();
        var basket = new Basket();
        var product = new Product { Name = "Product" };
        var command = new AddProductToBasketCommand(basket, product);

        // Act
        commandRecorder.RecordCommand(command);

        // Assert
        basket.Products.Should().HaveCount(1);
        
        CommandUtility.CountRecordedCommands(commandRecorder).Should().Be(1);
    }

    [Fact]
    public void RecordCommandAndUndoCommand_RecorderShouldBeEmpty()
    {
        // Arrange
        var commandRecorder = new CommandRecorder();
        var basket = new Basket();
        var product = new Product { Name = "Product" };
        var command = new AddProductToBasketCommand(basket, product);

        // Act
        commandRecorder.RecordCommand(command);

        var undoCommand = commandRecorder.UndoCommand();
        var referenceEqual = ReferenceEquals(command, undoCommand);

        // Assert
        basket.Products.Should().BeEmpty();
        referenceEqual.Should().BeTrue();

        CommandUtility.CountRecordedCommands(commandRecorder).Should().Be(0);
    }
}
