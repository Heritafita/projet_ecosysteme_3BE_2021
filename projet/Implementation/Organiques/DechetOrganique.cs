using System;

namespace projet.Implementation.Organiques
{
    public class DechetOrganique : Element
    {
        public DechetOrganique(double age, double masse, Position position) : base( age, masse, position)
        {
        }

        protected void Mourir()
        {
            if (Masse <= 0 || Age >= 50)
                Ecosysteme.Notify(this, new NotificationArgs { CycleDeVie = CycleDeVie.Mourir });
        }


        public override void Simuler()
        {
            Masse -= 0.005;
            Age += 0.002;

            Mourir();

        }
    }
}