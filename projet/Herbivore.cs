namespace projet
{
    abstract class Herbivore : Animal
    {
        public Herbivore(double age, double masse, double PointVie, int ReserveEnergie, Genre genre, ILocalisation position) :
           base(age, masse, PointVie, ReserveEnergie, genre, position)
        { }


        protected override void SeNourir() => Manger(typeof(Plante));
    }
}
