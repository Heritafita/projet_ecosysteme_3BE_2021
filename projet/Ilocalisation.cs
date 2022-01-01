namespace projet
{
    public interface ILocalisation
    {
        double X { get; set; }
        double Y { get; set; }
        bool IsWithinDistance(double limit, ILocalisation position);
    }
}
