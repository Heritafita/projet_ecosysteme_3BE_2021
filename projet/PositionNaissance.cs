using System;

namespace projet
{
    public class PositionNaissance
    {
        private ILocalisation _position;
        public PositionNaissance(ILocalisation position)
        {
            _position = position;

        }


        public ILocalisation PositionEnfant()
        {
            Random rnd = new Random();
            int x = rnd.Next(-1, 1);
            int y = rnd.Next(-1, 1);

            return new Position(_position.X + x, _position.Y + y);
        }
    }
}