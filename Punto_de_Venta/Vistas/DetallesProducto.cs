using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_Venta.Vistas
{
    public partial class detallesProducto : Form
    {
        public detallesProducto()
        {
            InitializeComponent();
        }

        public void recuperarValores(string uno, string dos, string tres, string cuatro, string cinco, string seis, string siete,string ocho)
        {
            textBox1.Text = dos;
            textBox2.Text = tres;
            textBox3.Text = cuatro;
            textBox4.Text = cinco;
            textBox5.Text = seis;
            textBox6.Text = siete;
            textBox7.Text = ocho;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();    
            listarProducto listarProducto = new listarProducto();
            listarProducto.Show();
        }
    }
}
