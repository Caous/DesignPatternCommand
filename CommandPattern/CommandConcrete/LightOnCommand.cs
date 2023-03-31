using CommandPattern.Interface;
using CommandPattern.Model;

namespace CommandPattern.CommandConcrete;

public class LightOnCommand : ICommand
{
    private readonly Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }
    public void Execute()
    {
        light.SetOnOrOffLight(true);
        Console.WriteLine($"Id: {light.Id} light of Enviroment: {light.Enviroments} this {light.GetOnOrOfLight()}");
    }

    public void Undo()
    {
        light.SetOnOrOffLight(false);
        Console.WriteLine($"Id: {light.Id} light of Enviroment: {light.Enviroments} this {light.GetOnOrOfLight()}");
    }
}
