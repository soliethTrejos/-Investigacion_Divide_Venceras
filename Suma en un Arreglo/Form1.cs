using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suma_en_un_Arreglo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int Sum(int[] array, int left, int right)
        {
            if (left == right)
                return array[left];

            int mid = left + (right - left) / 2;

            int sumLeft = Sum(array, left, mid);
            int sumRight = Sum(array, mid + 1, right);

            return sumLeft + sumRight;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                string input = tbNums.Text;

                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Por favor, ingrese al menos un número.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int[] numbers = input.Split(',')
                                     .Select(s => int.Parse(s.Trim()))
                                     .ToArray();

                int totalSum = Sum(numbers, 0, numbers.Length - 1);

                lblResult.Text = $"La suma es: {totalSum}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese solo números separados por comas.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}