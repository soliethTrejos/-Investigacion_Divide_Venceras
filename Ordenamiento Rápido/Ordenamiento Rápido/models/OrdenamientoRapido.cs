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
                // Verifica si el índice izquierdo es menor que el derecho
                if (izquierda < derecha)
                {
                    // Encuentra el índice del pivote después de la partición
                    int indicePivote = Particionar(arreglo, izquierda, derecha);

                    // Llama recursivamente a QuickSort para la mitad izquierda del pivote
                    QuickSort(arreglo, izquierda, indicePivote - 1);

                    // Llama recursivamente a QuickSort para la mitad derecha del pivote
                    QuickSort(arreglo, indicePivote + 1, derecha);
                }
            }

            private int Particionar(int[] arreglo, int izquierda, int derecha)
            {
                // Selecciona el último elemento como pivote
                int pivote = arreglo[derecha];

                // i será el índice de los elementos menores que el pivote
                int i = izquierda - 1;

                // Itera sobre el subarreglo desde la izquierda hasta el penúltimo elemento (antes del pivote)
                for (int j = izquierda; j < derecha; j++)
                {
                    // Si el elemento actual es menor o igual al pivote
                    if (arreglo[j] <= pivote)
                    {
                        // Incrementa el índice de los elementos menores
                        i++;

                        // Intercambia el elemento actual con el que está en la posición i
                        Intercambiar(arreglo, i, j);
                    }
                }

                // Coloca el pivote en su posición correcta intercambiándolo con el elemento en i+1
                Intercambiar(arreglo, i + 1, derecha);

                // Retorna el índice del pivote
                return i + 1;
            }

            private void Intercambiar(int[] arreglo, int i, int j)
            {
                // Intercambia dos elementos en el arreglo
                int temp = arreglo[i];
                arreglo[i] = arreglo[j];
                arreglo[j] = temp;
            }

        }
    }
