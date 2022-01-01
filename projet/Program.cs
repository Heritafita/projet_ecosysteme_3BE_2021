using projet.Implementation.Animaux.Carnivores;
using projet.Implementation.Animaux.Herbivores;
using projet.Implementation.Organiques;
using projet.Implementation.Plantes;
using System;

namespace projet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SIMULATEUR ECOSYSTEM");
            var ecosysteme = new Ecosysteme(new Note());

            ecosysteme.AjouterElement(new Loup(3, 30, 5, 10, Genre.Male, new PositionAlternative(15, 16)));
            ecosysteme.AjouterElement(new Loup(3, 30, 5, 10, Genre.Male, new Position(14, 15)));

            ecosysteme.AjouterElement(new Loup(4, 45, 3, 5, Genre.Femelle, new Position(15, 21)));
            ecosysteme.AjouterElement(new Mouton(4, 35, 2, 20, Genre.Femelle, new Position(15, 19)));

            ecosysteme.AjouterElement(new Mouton(4, 20, 2, 10, Genre.Male, new Position(60, 21)));
            ecosysteme.AjouterElement(new Mouton(2, 20, 2, 15, Genre.Femelle, new Position(61, 21)));

            ecosysteme.AjouterElement(new Mouton(2, 20, 2, 15, Genre.Femelle, new Position(3, 5)));
            ecosysteme.AjouterElement(new Herbe(5, 2, 34, 4, 0.5, 30, new Position(3, 4)));

            ecosysteme.AjouterElement(new Herbe(1, 2, 1, 4, 0.5, 2, new Position(20, 12)));
            ecosysteme.AjouterElement(new DechetOrganique(1, 10, new Position(20, 12)));

            ecosysteme.AjouterElement(new Viande(1, 10, new Position(20, 12)));



            ecosysteme.Simuler();
        }
    }
}