using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.models
{
    public class PuntosMasCercanos
    {
        //Este metodo incializa el algoritmo
        public static Tuple<Punto, Punto, double> EncontrarPuntoMasCercano(Punto[] puntos)
        {
            //Ordena los puntos por su coord X

            Array.Sort(puntos, (p1, p2) => p1.X.CompareTo(p2.Y)); 
            return EncontrarPuntosMasCercanosRecursivo(puntos);
        }
        private static Tuple<Punto, Punto, double> EncontrarPuntosMasCercanosRecursivo(Punto[] puntos)
        {
            int n = puntos.Length;
            if (n == 3) //Aqui si hay 3 o menos puntos, usamos fuerza bruta
            {
                return EncontrarPorFuerzaBruta(puntos);
            }

            int mitad = n / 2;
            Punto[] izquierda = new Punto[mitad];
            Punto[] derecha = new Punto[n - mitad];

            //Divide los puntos en mitades

            Array.Copy(puntos, 0, izquierda, 0, mitad);
            Array.Copy(puntos, mitad, derecha, 0, mitad);

            //Aqui resolvemos recursivamente en cada mitad
            Tuple<Punto, Punto, double> distanciaIzquierda = EncontrarPuntosMasCercanosRecursivo(izquierda);
            Tuple<Punto, Punto, double> distanciaDerecha = EncontrarPuntosMasCercanosRecursivo(derecha);

            //Encontramos la distancia minima
            Tuple<Punto, Punto, double> minimaDistancia = distanciaIzquierda.Item3 < distanciaDerecha.Item3 ? distanciaIzquierda : distanciaDerecha;

            //Verifica los puntos cercanos a la frontera
            Tuple<Punto, Punto, double> frontera = EncontrarCercanosEnFrontera(puntos, minimaDistancia.Item3);

            //Y aqui devuelve el valor
            return frontera.Item3 < minimaDistancia.Item3 ? frontera : minimaDistancia;
        }
        private static Tuple<Punto, Punto, double> EncontrarCercanosEnFrontera(Punto[] puntos, double d)
        {
            //Selecciona esos puntos que estan cerca de la frontera

            List<Punto> enFrontera = new List<Punto>();
            double xMedio = puntos[puntos.Length / 2].X;

            foreach (Punto punto in puntos)
            {
                if (Math.Abs(punto.X - xMedio) < d)
                {
                    enFrontera.Add(punto);
                }
            }

            //Aqui ordenamos los puntos en la frontera pero en la coord Y

            enFrontera.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));
            double minimaDistancia = d;
            Punto punto1 = null, punto2 = null;

            //Comprobacion de que si este en la frontera

            for (int i = 0; i < puntos.Length; i++)
            {
                for (int j = i + 1; j < puntos.Length; j++)
                {
                    double distancia = puntos[i].Distancia(puntos[j]);
                    if (distancia < minimaDistancia)
                    {
                        minimaDistancia = distancia;
                        punto1 = puntos[i];
                        punto2 = puntos[j];
                    }
                }
            }

            return Tuple.Create(punto1, punto2, minimaDistancia);
        }


        //Aqui encontramos el punto mas cercano usando la Fuerza Bruta
        private static Tuple<Punto, Punto, double> EncontrarPorFuerzaBruta(Punto[] puntos)
        {
            double minimaDistancia = double.MaxValue;
            Punto punto1 = null, punto2 = null;

            for (int i = 0; i < puntos.Length; i++)
            {
                for (int j = i + 1; j < puntos.Length; j++)
                {
                    double distancia = puntos[i].Distancia(puntos[j]);
                    if (distancia < minimaDistancia)
                    {
                        minimaDistancia = distancia;
                        punto1 = puntos[i];
                        punto2 = puntos[j];
                    }
                }
            }

            return Tuple.Create(punto1, punto2, minimaDistancia);
        }
    }
    
}
