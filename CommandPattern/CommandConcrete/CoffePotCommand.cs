using CommandPattern.Interface;
using CommandPattern.Model;

namespace CommandPattern.CommandConcrete;

public class CoffePotCommand : ICommand
{
    private readonly Coffe coffe;

    public CoffePotCommand(Coffe coffe)
    {
        this.coffe = coffe;
    }
    public void Execute()
    {
        coffe.SetOnOrOffCoffe(true);
        Console.WriteLine($"Coffe Id: { coffe.Id} status : {coffe.GetOnOrOfCoffe()} and start type Coffe: {coffe.TypeCoffe}");
    }

    public void Undo()
    {
        coffe.SetOnOrOffCoffe(false);
        Console.WriteLine($"Coffe Id: {coffe.Id} status : {coffe.GetOnOrOfCoffe()}");
    }
}
