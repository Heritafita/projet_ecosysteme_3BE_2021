using System;
using System.Linq;

namespace projet.Implementation.Animaux.Carnivores
{
    internal class Loup : Carnivore
    {


        protected override double ZoneVision => 2;
        protected override double ZoneContact => 0.4;

        protected override double MasseBebe => 0.3;

        protected override double PointVieBebe => 3;

        protected override int ReserveEnergieBebe => 10;
        protected override int TempsDeGestation => 10;
        protected override double QuantiteDefecation => 2;
        protected override int PeriodeDefecation => 2000;

        protected override double TempsPerteDeVie => 3000;



        protected override double AgeAdulte => 2;



        public Loup( double age, double masse, double PointVie, int ReserveEnergie, Genre genre, Position position) : base(age, masse, PointVie, ReserveEnergie, genre, position)
        {
        }

        protected override Animal Enfanter()
        {
            return new Loup(0, MasseBebe, PointVieBebe, ReserveEnergieBebe, GenreEnfant(), Position);
        }
    }
}