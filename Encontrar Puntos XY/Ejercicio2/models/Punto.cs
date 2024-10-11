using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.models
{
    public class Punto
    {
        //Coordenadas
        public double X { get; set; } 
        public double Y { get; set; }

        public Punto(double x, double y) //Constructor que inicializa un punto X y Y
        {
            X = x;
            Y = y;
        }

        //Calcula la distancia entr un punto y otro
        public double Distancia(Punto otro)
        {
            return Math.Sqrt(Math.Pow(X - otro.X, 2)) + Math.Pow(Y - otro.Y, 2);
        }
    }
}
