using System;
namespace projet
{
    public abstract class Element : IElement
    {

        protected Element(double age, double masse, Position position)
        {
          
            Position = position;
            Age = age;
            Masse = masse;

        }

        protected bool IsWithinDistance(double limit, Position position)
            => limit >= GetDistance(Position, position);

        internal double GetDistance(Position a, Position b)
        {
            return Math.Sqrt(Power(b.X - a.X) + Power(b.Y - a.Y));

            #region local function
            static double Power(double x) => Math.Pow(x, 2);
            #endregion
        }

        public readonly Guid Name = Guid.NewGuid() ;
        public Position Position { get; set; }
        public double Masse { get; set; }
        public double Age { get; set; }

        public abstract void Simuler();

        public Ecosysteme Ecosysteme { get; set; }

        public override bool Equals(object obj)
        {
            return ((Element)obj).Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
