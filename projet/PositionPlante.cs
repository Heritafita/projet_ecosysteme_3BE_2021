using System;

namespace projet
{
    public class PositionPlante : IRacineLocalisation
    {
        private ILocalisation _position;
        public PositionPlante(ILocalisation position)
        {
            _position = position;

        }


        public ILocalisation PositionEnfant()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 10000);
            int y = rnd.Next(1, 10000);
            var position = new Position(x, y);
            return position;
        }
    }
}
