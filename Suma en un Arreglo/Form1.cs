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

        }
    }
}
