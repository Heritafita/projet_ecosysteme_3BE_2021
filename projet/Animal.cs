using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;


namespace projet
{
    public abstract class Animal : EtreVivant
    {

        public bool IsEngestation;
        public bool IsImmobile;
        public bool IsEnfant;
        public bool IsFatigue;

        protected double TempsEnceinte;
        protected int TempsRecup = 60;
        protected int TempsRepos;

        protected Timer DefecationTimer;

        protected abstract double ZoneVision { get; }
        protected abstract double ZoneContact { get; }
        protected abstract double AgeAdulte { get; }
        protected abstract int TempsDeGestation { get; }
        protected abstract double QuantiteDefecation { get; }
        protected abstract int PeriodeDefecation { get; }

        public readonly Genre genre;
        public Animal(double age, double masse, double PointVie, int ReserveEnergie, Genre genre, Position position) :
        base(age, masse, PointVie, ReserveEnergie, position)
        {
            this.genre = genre;
        }

        protected bool IsInZoneVision(Position position) => IsWithinDistance(ZoneVision, position);

        protected bool IsInZoneContact(Position position) => IsWithinDistance(ZoneContact, position);

        internal void Defequer(object sender, EventArgs args)
        {
            Ecosysteme.Notify(this, new NotificationArgs { CycleDeVie = CycleDeVie.Defequer });
        }

        internal void DevenirViande(object sender, EventArgs args)
        {
            Ecosysteme.Notify(this, new NotificationArgs { CycleDeVie = CycleDeVie.DevenirViande });
        }

        protected override void SeReproduire()
        {
            if (genre == Genre.Femelle)
                return;

            var animals = Ecosysteme.Chercher(GetType(), element => genre != ((Animal)element).genre && IsInZoneContact(element.Position) && !IsEnfant && !IsFatigue && !((Animal)element).IsEngestation);
            if (animals.Any())
            {
                IsImmobile = true;
                Ecosysteme.Notify(this, new NotificationArgs { CycleDeVie = CycleDeVie.SeReproduire, Element = animals.First() });
                IsFatigue = true;
                IsImmobile = false;
            }
        }

        protected void SeDeplacer()
        {
            if (!IsImmobile)
            {

                var rand = new Random();
                double min = -3;
                double max = 3;
                double random_move = rand.NextDouble() * (max - min);
                Position.X += random_move;
                Position.Y -= random_move;
                if (Position.X >= 500 || Position.X <= -500) { Position.X = 0; }
                if (Position.Y >= 500 || Position.Y <= -500) { Position.Y = 0; }

            }
        }

        internal void CommenceGestation()
        {
            IsEngestation = true;
            TempsEnceinte = 0;
        }

        protected Genre GenreEnfant()
        {
            Random rd = new Random();
            var genre = new List<Genre> { Genre.Male, Genre.Femelle };
            int index = rd.Next(genre.Count);
            return (Genre) index;
        }
        public override void Simuler()
        {
            DonnerNaissance();
            SeDeplacer();
            base.Simuler();

            if (IsVivant && DefecationTimer is null)
            {
                DefecationTimer = new Timer(PeriodeDefecation);
                DefecationTimer.Elapsed += Defequer;
            }

            if (IsVivant && !DefecationTimer.Enabled)
                DefecationTimer.Start();


            if (Age > AgeAdulte) { IsEnfant = false; }



            if (IsEngestation) { TempsEnceinte += 0.5; }

            if (IsFatigue) { TempsRepos += 1; }



            if (TempsRepos == TempsRecup) { IsFatigue = false; }

        }

        protected abstract Animal Enfanter();

        protected void DonnerNaissance()
        {
            if (!IsEngestation) { return; }


            if (TempsEnceinte == TempsDeGestation)
            {

                IsImmobile = true;
                var enfant = Enfanter();
                Ecosysteme.Notify(this, new NotificationArgs { CycleDeVie = CycleDeVie.DonnerNaissance, Element = enfant });
                IsEngestation = false;
                IsImmobile = false;
            }
        }

        public void FinirCycle()
        {
            if (DefecationTimer != null)
            {
                DefecationTimer.Stop();
                //DefecationTimer.Elapsed -= Defequer;
                DefecationTimer.Dispose();
            }

            if (PerteVieTimer != null)
            {
                PerteVieTimer.Stop();
                //PerteVieTimer.Elapsed -= PerdreVie;
                PerteVieTimer.Dispose();
            }
        }

        protected override void Manger(Type type) => Manger(type, (element) => IsInZoneVision(element.Position));
            
    }
}