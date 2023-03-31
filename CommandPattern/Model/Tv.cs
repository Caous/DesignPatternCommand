namespace CommandPattern.Model;

public class Tv
{
    public Tv(Guid id, string enviroments)
    {
        this.Id = id;
        this.Enviroments = enviroments;
    }
    public Guid Id { get; private set; }
    public string Enviroments { get; private set; }
    private bool OnOrOff { get; set; }
    public void SetOnOrOffTv(bool on) => OnOrOff = on;
    public bool GetOnOrOfTv() => this.OnOrOff;
}
