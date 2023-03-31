namespace CommandPattern.Model;

public class Coffe
{
    public Coffe(Guid id, ETypeCoffe typeCoffe)
    {
        this.TypeCoffe = typeCoffe;
        this.Id = id;
    }

    public Guid Id { get; private set; }
    public ETypeCoffe TypeCoffe { get; private set; }
    private bool OnOrOff { get; set; }
    public void SetOnOrOffCoffe(bool on) => OnOrOff = on;
    public bool GetOnOrOfCoffe() => this.OnOrOff;

}

public enum ETypeCoffe
{
    Express,
    WithMilk
}