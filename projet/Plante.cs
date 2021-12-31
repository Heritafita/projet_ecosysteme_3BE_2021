using projet.Implementation.Organiques;
using System;
using System.Linq;

namespace projet
{
    abstract public class Plante : EtreVivant
    {
        protected double ZoneRacine { get; }
        protected double ZoneSemis { get; }
        protected abstract double ZoneRacineBebe { get; }
        
        protected abstract double AgeMur { get; }


        public Plante(double age, double masse, double PointVie, int ReserveEnergie, double zoneRacine, double zoneSemis, Position position) : base( age, masse, PointVie, ReserveEnergie, position)
        {
            ZoneRacine = zoneRacine;
            ZoneSemis = zoneSemis;
        }

        protected override void SeNourir()
            => Manger(typeof(DechetOrganique));
        protected override void Manger(Type t) => Manger(t, element => IsInZoneRacine(element.Position));


        protected Position PositionEnfant()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 10000);
            int y = rnd.Next(1, 10000);
            return new Position(x, y);
        }
        protected bool IsInZoneRacine(Position position) => IsWithinDistance(ZoneRacine, position);
        protected bool IsInZoneSemis(Position position) => IsWithinDistance(ZoneSemis, position);
    }
}