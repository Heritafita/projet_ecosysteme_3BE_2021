namespace projet.Implementation.Organiques
{
    internal class Viande : Element
    {

        const double TempsPourrir = 10;


        public Viande(double age, double masse, ILocalisation position) : base(age, masse, position)
        {

        }
        protected void DevenirDechetOrganique()
        {
            Ecosysteme.Notify(this, new NotificationArgs { CycleDeVie = CycleDeVie.Mourir });
        }

        public override void Simuler()
        {
            Age++;
            if (Age == TempsPourrir) { DevenirDechetOrganique(); }

        }
    }
}