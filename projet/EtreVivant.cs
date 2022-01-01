using System;
using System.Timers;

namespace projet
{
    public abstract class EtreVivant : Element
    {
        public bool IsVivant = true;
        public double PointVie { get; set; }
        public int ReserveEnergie { get; set; }
        protected abstract double PointVieBebe { get; }
        protected abstract double MasseBebe { get; }

        protected abstract int ReserveEnergieBebe { get; }
        internal Timer PerteVieTimer;

        protected abstract double TempsPerteDeVie { get; }

        public EtreVivant(double age, double masse, double PointVie, int ReserveEnergie, ILocalisation position) : base(age, masse, position)
        {
            this.PointVie = PointVie;
            this.ReserveEnergie = ReserveEnergie;
        }
        protected void PerdreVie(object sender, EventArgs args)
        {
            PointVie -= 0.5;
            Ecosysteme.Notify(this, new NotificationArgs { CycleDeVie = CycleDeVie.PerdreVie });
        }
        protected abstract void SeNourir();
        protected abstract void SeReproduire();
        protected void Mourir()
        {

            if (PointVie <= 0)
            {
                Ecosysteme.Notify(this, new NotificationArgs { CycleDeVie = CycleDeVie.Mourir });
            }


        }


        protected void ProduireVie()
        {
            if (PointVie <= 1 && ReserveEnergie > 0)
            {
                ReserveEnergie -= 10;
                PointVie += 2;
                Ecosysteme.Notify(this, new NotificationArgs { CycleDeVie = CycleDeVie.ProduireVie });
            }
        }

        public override void Simuler()
        {
            Age += 0.1;

            SeNourir();

            ProduireVie();
            Mourir();
            SeReproduire();
            if (PerteVieTimer is null)
            {
                PerteVieTimer = new Timer(TempsPerteDeVie);
                PerteVieTimer.Elapsed += PerdreVie;
            }

            if (IsVivant && !PerteVieTimer.Enabled)
                PerteVieTimer.Start();

        }

        protected abstract void Manger(Type t);

        protected void Manger(Type type, Predicate<IElement> predicate)
        {
            var aliment = Ecosysteme.ChercheUn(type, predicate);
            if (aliment is null)
                return;

            Ecosysteme.Notify(this, notification: new NotificationArgs { CycleDeVie = CycleDeVie.SeNourir, Element = aliment });
        }

    }



}