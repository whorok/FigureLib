using System;

namespace FigureLib
{
    public abstract class Figure
    {
        public double Square { get; protected set; }

        protected void CheckValue(string valueName, double value)
        {
            if (value <= 0)
                throw new ArgumentException($"{valueName} can't be less than or equal to 0.");
        }

        protected abstract double CalcSquare();
    }

    public sealed class Circle : Figure
    {
        private double _radius;

        public double Radius
        {
            get => _radius;
            private set
            {
                CheckValue("Radius", value);
                _radius = value;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
            Square = CalcSquare();
        }

        protected override double CalcSquare()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    public sealed class Triangle : Figure
    {
        public double SizeAB { get; private set; }
        public double SizeBC { get; private set; }
        public double SizeCA { get; private set; }

        public Triangle(double sizeAB, double sizeBC, double sizeCA)
        {
            if (sizeAB + sizeBC <= sizeCA || sizeBC + sizeCA <= sizeAB || sizeCA + sizeAB <= sizeBC)
                throw new ArgumentException("Triangle doesn't exist.");
            SizeAB = sizeAB;
            SizeBC = sizeBC;
            SizeCA = sizeCA;
            Square = CalcSquare();
        }

        protected override double CalcSquare()
        {
            var p = (SizeAB + SizeBC + SizeCA) / 2;
            var square = Math.Sqrt(p * (p - SizeAB) * (p - SizeBC) * (p - SizeCA));
            return square;
        }

        public bool IsRight()
        {
            var check = Math.Abs(SizeAB - Math.Sqrt(Math.Pow(SizeBC, 2) + Math.Pow(SizeCA, 2))) < 0.01
                         || Math.Abs(SizeBC - Math.Sqrt(Math.Pow(SizeAB, 2) + Math.Pow(SizeCA, 2))) < 0.01
                         || Math.Abs(SizeCA - Math.Sqrt(Math.Pow(SizeAB, 2) + Math.Pow(SizeBC, 2))) < 0.01;
            return check;
        }
    }
}