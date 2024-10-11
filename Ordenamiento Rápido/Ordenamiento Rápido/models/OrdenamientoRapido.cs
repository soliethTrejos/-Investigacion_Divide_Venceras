using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenamiento_Rápido.models
{
    public class OrdenamientoRapido
    {
        public void QuickSort(int[] arreglo, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int indicePivote = Particionar(arreglo, izquierda, derecha);
                QuickSort(arreglo, izquierda, indicePivote - 1);
                QuickSort(arreglo, indicePivote + 1, derecha);
            }

        }
        private int Particionar(int[] arreglo, int izquierda, int derecha)
        {
            int pivote = arreglo[derecha];
            int i = izquierda - 1;

            for (int j = izquierda; j < derecha; j++)
            {
                if (arreglo[j] <= pivote)
                {
                    i++;
                    Intercambiar(arreglo, i, j);
                }
            }

            Intercambiar(arreglo, i + 1, derecha);
            return i + 1;
        }

        private void Intercambiar(int[] arreglo, int i, int j)
        {
            int temp = arreglo[i];
            arreglo[i] = arreglo[j];
            arreglo[j] = temp;
        }
    }
}
