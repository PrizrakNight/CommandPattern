using CommandPattern.Commands;
using FluentAssertions;
using Xunit;

namespace CommandPattern.Tests.Commands;

public class CommandBaseTests
{
    private sealed class MockCommand : CommandBase
    {
        public int NumberOfExecutions { get; private set; }

        protected override void OnExecute()
        {
            NumberOfExecutions++;
        }

        protected override void OnUndo()
        {
            NumberOfExecutions--;
        }
    }

    [Fact]
    public void CommandMustBeExecutedOnce()
    {
        // Arrange
        var command = new MockCommand();

        // Act
        command.Execute();
        command.Execute();

        // Assert
        command.NumberOfExecutions.Should().Be(1);
    }

    [Fact]
    public void CommandMustBeUndoOnce()
    {
        // Arrange
        var command = new MockCommand();

        command.Execute();

        // Act
        command.Undo();
        command.Undo();

        // Assert
        command.NumberOfExecutions.Should().Be(0);
    }
}
