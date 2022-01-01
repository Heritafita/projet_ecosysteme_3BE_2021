using System;
using System.Linq;

namespace projet.Implementation.Animaux.Herbivores
{
    internal class Mouton : Herbivore
    {
        protected override int TempsDeGestation => 25;

        protected override double QuantiteDefecation => 1.5;

        protected override int PeriodeDefecation => 3000;

        protected override double TempsPerteDeVie => 4000;

        protected override double ZoneVision => 1.5;

        protected override double ZoneContact => 1;

        protected override double MasseBebe => 0.2;

        protected override double PointVieBebe => 2;

        protected override int ReserveEnergieBebe => 10;

        protected override double AgeAdulte => 1.5;



        public Mouton( double age, double masse, double PointVie, int ReserveEnergie, Genre Sexe, ILocalisation position) :
            base(age, masse, PointVie, ReserveEnergie, Sexe, position)
        {
        }

        protected override Animal Enfanter()
        {
            return new Mouton(0, MasseBebe, PointVieBebe, ReserveEnergieBebe, GenreEnfant(), Position);
        }
    }
}