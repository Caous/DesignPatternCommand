using CommandPattern.Interface;
using CommandPattern.Model;

namespace CommandPattern.CommandConcrete;

public class TvCommand : ICommand
{
    private readonly Tv tv;

    public TvCommand(Tv tv)
    {
        this.tv = tv;
    }
    public void Execute()
    {
        tv.SetOnOrOffTv(true);
        Console.WriteLine($"Id: {tv.Id} TV of Enviroment: {tv.Enviroments} this {tv.GetOnOrOfTv()}");
    }

    public void Undo()
    {
        tv.SetOnOrOffTv(false);
        Console.WriteLine($"Id: {tv.Id} TV of Enviroment: {tv.Enviroments} this {tv.GetOnOrOfTv()}");
    }
}
