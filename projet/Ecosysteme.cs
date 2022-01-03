using projet;
using projet.Implementation.Organiques;
using System;
using System.Collections.Generic;
using System.Linq;


namespace projet
{
    public class Ecosysteme : ISimulateur, IFouillable, INotifiable
    {
        private readonly IAfficheur _afficheur;

        public Ecosysteme(IAfficheur afficheur)
        {
            _afficheur = afficheur;
        }
        private IList<IElement> Elements { get; } = new List<IElement>();

        public void AjouterElement(IElement element)
        {
            element.Ecosysteme = this;
            Elements.Add(element);
            _afficheur.Afficher($"Rajout ({element.GetType().Name}), Nombre d'éléments dans écosystème = {Elements.Count}", ConsoleColor.DarkGreen);
        }
        private void SupprimerElement(IElement element)
        {
            if (element is EtreVivant etreVivant)
                etreVivant.IsVivant = false;

            if (element is Animal animal)
                animal.FinirCycle();

            Elements.Remove(element);
            _afficheur.Afficher($"Suppression ({element.GetType().Name}), Nombre d'éléments restant dans l'écosystème = {Elements.Count}", ConsoleColor.DarkRed);
        }

        public void Simuler()
        {
            while (Elements.Any())
            {
                var things = new List<IElement>(Elements);
                foreach (var element in things)
                {
                    element.Simuler();
                }
            }

            _afficheur.Afficher("AUCUN ELEMENT DANS L'ECOSYSTEME, FIN", ConsoleColor.Green);
        }

        public IEnumerable<IElement> Chercher(Type type, Predicate<IElement> predicate = null)
        {
            if (predicate != null)
                return Elements.Where(element => defaultPredicate(type, element) && predicate(element));

            return Elements.Where(element => defaultPredicate(type, element));

            static bool defaultPredicate(Type a, IElement b) => a.IsAssignableFrom(b.GetType());
        }


        public void Notify(Element sender, NotificationArgs notification)
        {

<<<<<<< HEAD

=======
           
>>>>>>> b629eb3491dcf0d418bf2e58b1fb84d7d1fd54d8
            if (notification.CycleDeVie == CycleDeVie.PerdreVie)
            {
                if (sender is EtreVivant etreVivant)
                {
                    _afficheur.Afficher($"{etreVivant.Name} ({etreVivant.GetType().Name}) a perdu une vie, Point de vie actuelle = {etreVivant.PointVie} {etreVivant.Position}", ConsoleColor.DarkYellow);

                }

            }

            if (notification.CycleDeVie == CycleDeVie.ProduireVie)
            {

                if (sender is EtreVivant etrevivant)
                {
                    _afficheur.Afficher($"({etrevivant.GetType().Name}) {etrevivant.Name} a genere PointVie, PointVie = {etrevivant.PointVie}, Energie restant= {etrevivant.ReserveEnergie}  { etrevivant.Position}", ConsoleColor.Gray);
                }


            }

            if (notification.CycleDeVie == CycleDeVie.Mourir)
            {


                if (sender is Plante || sender is Viande)
                {

                    DechetOrganique dechetOrganique = new DechetOrganique(0, sender.Masse, sender.Position);

                    _afficheur.Afficher($"({sender.GetType().Name}) {sender.Name} s'est tranformé en dechet organique {sender.Position}", ConsoleColor.DarkYellow);
                    _afficheur.Afficher($"Dechet organique {dechetOrganique.Name} a ete cree, position : {dechetOrganique.Position}", ConsoleColor.DarkYellow);
                    AjouterElement(dechetOrganique);
                }



                if (sender is DechetOrganique dechetOrganique1)
                {
                    _afficheur.Afficher($"Dechet organique {dechetOrganique1.Name} a disparu {dechetOrganique1.Position}", ConsoleColor.DarkYellow);
                }

                if (sender is Animal animal)
                {
                    Viande viande = new Viande(0, animal.Masse, animal.Position);
                    _afficheur.Afficher($"({animal.GetType().Name}) {animal.Name} n'est plus en vie et transformé en {viande.GetType().Name} {viande.Name} {viande.Position} ", ConsoleColor.DarkYellow);
                    AjouterElement(viande);
                }

                SupprimerElement(sender);

            }



            if (notification.CycleDeVie == CycleDeVie.SeNourir)
            {
                if (sender is EtreVivant mangeur && notification.Element is EtreVivant aliment)
                {
                    _afficheur.Afficher($"({aliment.GetType().Name}){aliment.Name} a ete mangé par {mangeur.GetType().Name} {mangeur.Name} {mangeur.Position}", ConsoleColor.DarkMagenta);
                    SupprimerElement(aliment);
                    mangeur.PointVie += 2;

                }

                if (sender is Plante PlanteMangeur && notification.Element is DechetOrganique dechetAliment)
                {
                    _afficheur.Afficher($"({dechetAliment.GetType().Name}) {dechetAliment.Name} a ete mangé par {PlanteMangeur.GetType().Name} {PlanteMangeur.Name} {PlanteMangeur.Position}", ConsoleColor.DarkMagenta);
                    SupprimerElement(dechetAliment);
                    PlanteMangeur.PointVie += 1;
                }


            }

            if (notification.CycleDeVie == CycleDeVie.Defequer)
            {
                if (sender is Animal animal)
                {
                    _afficheur.Afficher($"{animal.Name} ({animal.GetType().Name}) a lache du dechet organique, position : {animal.Position}", ConsoleColor.DarkCyan);

<<<<<<< HEAD
                    if (notification.CycleDeVie == CycleDeVie.Defequer)
                    {
                        if (sender is Animal animal)
                        {
                            _afficheur.Afficher($"{animal.Name} ({animal.GetType().Name}) a lache du dechet organique, position : {animal.Position}", ConsoleColor.DarkCyan);
                            DechetOrganique defec = new DechetOrganique(0, animal.MasseDefecation, animal.Position);
                            //AjouterElement(defec);

                        }

                    }

                }
=======
                }
>>>>>>> b629eb3491dcf0d418bf2e58b1fb84d7d1fd54d8

            }
            if (notification.CycleDeVie == CycleDeVie.SeReproduire)
            {
                if (sender is Animal animalMale && notification.Element is Animal animalfemelle)
                {

                    _afficheur.Afficher($"({animalMale.GetType().Name}) male {animalMale.Name} et femelle {animalfemelle.Name} en contact pour repoduction", ConsoleColor.DarkCyan);

                    animalfemelle.CommenceGestation();
                    _afficheur.Afficher($"({animalfemelle.GetType().Name}) femelle {animalfemelle.Name} est en gestation {animalfemelle.Position}", ConsoleColor.DarkGray);

                }
            }

            if (notification.CycleDeVie == CycleDeVie.DonnerNaissance)
            {
                if (sender is Animal mere && notification.Element is Animal enfant)

                {
                    enfant.IsEnfant = true;
                    _afficheur.Afficher($"La mere ({mere.GetType().Name}) {mere.genre} {enfant.Name} a donne naissance\n Le bebe {enfant.GetType().Name} {enfant.genre} {enfant.Name} est ne ", ConsoleColor.DarkYellow);
                }

                if (sender is Plante MerePlante && notification.Element is Plante enfantPlante)

                {
                    _afficheur.Afficher($"({MerePlante.GetType().Name}) {MerePlante.Name} s'est repandu {MerePlante.Position} \n ({enfantPlante.GetType().Name})  {enfantPlante.Name} a pousse {enfantPlante.Position}", ConsoleColor.DarkYellow);
                }
                AjouterElement(notification.Element);
            }
        }

        public IElement ChercheUn(Type type, Predicate<IElement> predicate)
            => Chercher(type, predicate).FirstOrDefault();


    }
}

public interface ISimulateur
{
    void AjouterElement(IElement simulable);
    void Simuler();
}

public interface IFouillable
{
    IEnumerable<IElement> Chercher(Type type, Predicate<IElement> predicate);
    IElement ChercheUn(Type type, Predicate<IElement> predicate);
}

public class Note : IAfficheur
{
    public void Afficher(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

public interface IAfficheur
{
    public void Afficher(string message, ConsoleColor color = ConsoleColor.White);

}
