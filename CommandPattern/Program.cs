using CommandPattern.CommandConcrete;
using CommandPattern.Invoker;
using CommandPattern.Model;

Alexa invoke = new Alexa();

Guid guid = Guid.NewGuid();

invoke.SetStarCommand(new CoffePotCommand(new Coffe(guid, ETypeCoffe.Express)));

invoke.ExecuteCommand();

invoke.UndoCommand();

guid = Guid.NewGuid();

invoke.SetStarCommand(new TvCommand(new Tv(guid, "bedroom")));

invoke.ExecuteCommand();

invoke.UndoCommand();

guid = Guid.NewGuid();

invoke.SetStarCommand(new LightOnCommand(new Light(guid, "bathroom")));

invoke.ExecuteCommand();

invoke.UndoCommand();

