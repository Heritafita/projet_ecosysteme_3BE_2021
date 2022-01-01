using System;

namespace projet.Implementation.Plantes
{
    public class Herbe : Plante
    {


        protected new double ZoneRacine = 1;
        protected new double ZoneSemis = 2;


        protected override double PointVieBebe => 1;

        protected override double MasseBebe => 0.01;

        protected override int ReserveEnergieBebe => 10;

        protected override double TempsPerteDeVie => 4000;

        protected override double ZoneRacineBebe => 0.2;

       

        protected override double AgeMur => 5;



        public Herbe(double age, double masse, double PointVie, int ReserveEnergie, double zoneRacine, double zoneSemis, ILocalisation position) :
            base( age, masse, PointVie, ReserveEnergie, zoneRacine, zoneSemis, position)
        {
        }



        protected override void SeReproduire()
        {

            var positionEnfant =new PositionPlante (Position).PositionEnfant();

            if (IsInZoneSemis(positionEnfant) && Age >= AgeMur)
            {
                
                var enfant = new Herbe( 0, MasseBebe, PointVieBebe, ReserveEnergieBebe, ZoneRacineBebe, ZoneSemis, positionEnfant);
                Ecosysteme.Notify(this, new NotificationArgs { CycleDeVie = CycleDeVie.DonnerNaissance, Element = enfant });
            }

        }

        public override void Simuler()
        {
            base.Simuler();
            ZoneRacine += 0.001;
        }
    }
}