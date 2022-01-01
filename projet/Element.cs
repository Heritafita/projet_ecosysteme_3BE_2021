using System;
namespace projet
{
    public abstract class Element : IElement
    {

        protected Element(double age, double masse, ILocalisation position)
        {
          
            Position = position;
            Age = age;
            Masse = masse;

        }

      

        public readonly Guid Name = Guid.NewGuid() ;
        public ILocalisation Position { get; set; }
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
