namespace CommandPattern.Model;

public class Light
{
    public Light(Guid id, string enviroments)
    {
        this.Id = id;
        this.Enviroments = enviroments;
    }
    public Guid Id { get; private set; }
    public string Enviroments { get; private set; }
    private bool OnOrOff { get; set; }
    public void SetOnOrOffLight(bool on) => OnOrOff = on;
    public bool GetOnOrOfLight() => this.OnOrOff;
}
