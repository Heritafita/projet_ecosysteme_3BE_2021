using System;

namespace projet
{
    public class PositionAlternative : ILocalisation
    {
        public double X { get; set; }
        public double Y { get; set; }


        public PositionAlternative(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool IsWithinDistance(double limit, ILocalisation position) => limit >= GetDistance(position);

        private double GetDistance(ILocalisation position)
        {
            return Math.Sqrt(Power(position.X - X) + Power(position.Y - Y));

            #region local function
            static double Power(double x) => Math.Pow(x, 2);
            #endregion
        }
        public override string ToString() => $"({X} , {Y})";
    }
}
