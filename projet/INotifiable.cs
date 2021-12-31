namespace projet
{
    internal interface INotifiable
    {
        void Notify(Element sender, NotificationArgs arguments);
    }

    public class NotificationArgs
    {
        public CycleDeVie CycleDeVie { get; set; }
        public IElement Element { get; set; }
    }
}