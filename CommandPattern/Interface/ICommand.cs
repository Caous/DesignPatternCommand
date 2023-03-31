namespace CommandPattern.Interface;

public interface ICommand
{
    void Execute();
    void Undo();
}
