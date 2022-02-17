using CommandPattern.Commands;

namespace CommandPattern;

public class CommandRecorder
{
    private readonly Stack<CommandBase> _commands = new();

    public void RecordCommand(CommandBase command)
    {
        ArgumentNullException.ThrowIfNull(command, nameof(command));

        command.Execute();

        _commands.Push(command);
    }

    public CommandBase? UndoCommand()
    {
        if (_commands.Count == 0)
            return null;

        var command = _commands.Pop();

        command.Undo();

        return command;
    }
}
