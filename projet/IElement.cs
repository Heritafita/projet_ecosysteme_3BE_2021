namespace projet
{
    public interface IElement : ILocalizable, ISimulable
    {
        Ecosysteme Ecosysteme { get; set; }
    }
}
