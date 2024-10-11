using Ejercicio2.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();

            string[] input = txtPuntos.Text.Split(';'); //Separa los puntos por ;
            List<Punto> puntos = new List<Punto>();

            try
            {
                foreach(var item in input)
                {
                    string[] coords = item.Split(',');
                    double x = double.Parse(coords[0]);
                    double y = double.Parse(coords[1]);
                    puntos.Add(new Punto(x, y));


                    //Mensaje de depuracion
                    MessageBox.Show($"Agregando punto: ({x}, {y})");
                }

                //Aqui declaro la variable del resultado

                Tuple<Punto, Punto, double> resultado = PuntosMasCercanos.EncontrarPuntoMasCercanos(puntos.ToArray());

                if (resultado.Item1 != null && resultado.Item2 != null)
                {
                    lbResultados.Items.Add($"Punto 1: ({resultado.Item1.X}, {resultado.Item1.Y})");
                    lbResultados.Items.Add($"Punto 2: ({resultado.Item2.X}, {resultado.Item2.Y})");
                    lbResultados.Items.Add($"Distancia: {resultado.Item3:F2}");
                }
                else
                {
                    lbResultados.Items.Add("No se encontraron puntos cercanos.");
                }

            }
            catch (Exception ex)
            {
                lbResultados.Items.Add("Error en la entrada. Asegúrate de usar el formato correcto (ejemplo: 1,2;3,4).");

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
        }
    }
    
}
