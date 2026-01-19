using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_PretizeniOperatoru
{
    // Sealed class = třída, od které nelze dědit
    public sealed class Vector2D
    {
        // Souřadnice vektoru
        public double X { get; }
        public double Y { get; }

        // Konstruktor
        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }       

        // součet dvou vektorů
        public static Vector2D operator +(Vector2D left, Vector2D right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Argument je null");
            }

            return new Vector2D(left.X + right.X, left.Y + right.Y);
        }

        // rozdíl dvou vektorů
        public static Vector2D operator -(Vector2D left, Vector2D right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Argument je null");
            }

            return new Vector2D(left.X - right.X, left.Y - right.Y);
        }

        // násobení vektoru skalárem
        public static Vector2D operator *(Vector2D vector, double scalar)
        {
            if (vector == null)
            {
                throw new ArgumentNullException(nameof(vector));
            }

            return new Vector2D(vector.X * scalar, vector.Y * scalar);
        }

        // Výpis
        public override string ToString()
        {
            return $"({X}, {Y})";
        }       
    }
}
