﻿using System;
using System.Linq;

namespace projet
{
    abstract class Herbivore : Animal
    {
        public Herbivore(double age, double masse, double PointVie, int ReserveEnergie, Genre genre, Position position) :
           base(age, masse, PointVie, ReserveEnergie, genre, position)
        { }


        protected override void SeNourir() => Manger(typeof(Plante));
    }
}