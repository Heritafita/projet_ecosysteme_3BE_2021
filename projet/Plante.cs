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


        public Plante(double age, double masse, double PointVie, int ReserveEnergie, double zoneRacine, double zoneSemis, ILocalisation position) : base( age, masse, PointVie, ReserveEnergie, position)
        {
            ZoneRacine = zoneRacine;
            ZoneSemis = zoneSemis;
        }

        protected override void SeNourir()
            => Manger(typeof(DechetOrganique));
        protected override void Manger(Type t) => Manger(t, element => IsInZoneRacine(element.Position));


       
        protected bool IsInZoneRacine(ILocalisation position) => Position.IsWithinDistance(ZoneRacine, position);
        protected bool IsInZoneSemis(ILocalisation position) => Position.IsWithinDistance(ZoneSemis, position);
    }
}