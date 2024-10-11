using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DivideyVenceras1
{
    public partial class Form1 : Form
    {
        // Definir arreglo para 8 elementos
        private int[] numeros = new int[8];
        private int i = 0; 

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(tbNum.Text);

                if (i < numeros.Length)
                {
                    numeros[i] = numero;
                    i++;
                    lbNum.Items.Add(numero);
                    tbNum.Clear();
                }
                else
                {
                    MessageBox.Show("Ha alcanzado el límite de elementos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, ingresa un número válido.");
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                int[] numerosIngresados = new int[i];
                Array.Copy(numeros, numerosIngresados, i);

                int maxVal = CalcularMaximo(numerosIngresados);
                int minVal = CalcularMinimo(numerosIngresados);

                // Mostrar resultados
                lblMax.Text = $"Máximo: {maxVal}";
                lblMin.Text = $"Mínimo: {minVal}";
            }
            else
            {
                MessageBox.Show("Por favor, agrega números antes de calcular.");
            }
        }

        private int CalcularMaximo(int[] arr)
        {
            return max(arr, 0, arr.Length - 1);
        }

        private int CalcularMinimo(int[] arr)
        {
            return min(arr, 0, arr.Length - 1);
        }

        // Divide y vencerás max
        private int max(int[] arr, int inicio, int fin)
        {
            if (inicio == fin)
                return arr[inicio];

            int medio = (inicio + fin) / 2;

            int maxIzq = max(arr, inicio, medio);
            int maxDer = max(arr, medio + 1, fin);

            return Math.Max(maxIzq, maxDer);
        }

        // Divide y vencerás min
        private int min(int[] arr, int inicio, int fin)
        {
            if (inicio == fin)
                return arr[inicio];

            int medio = (inicio + fin) / 2;

            int minIzq = min(arr, inicio, medio);
            int minDer = min(arr, medio + 1, fin);

            return Math.Min(minIzq, minDer);
        }
    }
}
