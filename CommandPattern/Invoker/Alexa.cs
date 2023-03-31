using CommandPattern.Interface;

namespace CommandPattern.Invoker;

public class Alexa
{
    private ICommand _command;

    public void SetStarCommand(ICommand starCommand) => _command = starCommand;
    public void ExecuteCommand() => _command.Execute();
    public void UndoCommand() => _command.Undo();

}
