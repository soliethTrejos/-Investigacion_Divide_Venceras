using Ordenamiento_Rápido.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordenamiento_Rápido
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            try
            {
                // Tomar los números del TextBox, separados por comas.
                string input = tbtNums.Text;

                // Convertir el input a un arreglo de enteros.
                int[] arreglo = input.Split(',').Select(int.Parse).ToArray();

                // Instanciar la clase OrdenamientoRapido y ordenar el arreglo.
                OrdenamientoRapido ordenamiento = new OrdenamientoRapido();
                ordenamiento.QuickSort(arreglo, 0, arreglo.Length - 1);

                // Limpiar el ListBox y agregar los números ordenados.
                lbShow.Items.Clear();
                foreach (int num in arreglo)
                {
                    lbShow.Items.Add(num);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, ingresa una lista de números válidos separados por comas.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
