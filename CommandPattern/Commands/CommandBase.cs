namespace CommandPattern.Commands;

public abstract class CommandBase
{
    public bool Executed { get; private set; }

    public void Execute()
    {
        if (Executed)
            return;

        OnExecute();

        Executed = true;
    }

    public void Undo()
    {
        if (Executed)
        {
            OnUndo();

            Executed = false;
        }
    }

    protected abstract void OnExecute();
    protected abstract void OnUndo();
}
