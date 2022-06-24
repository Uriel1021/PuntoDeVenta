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
    public partial class detallesProveedor : Form
    {
        public detallesProveedor()
        {
            InitializeComponent();
        }
        public void recuperarValoresProveedor(string uno, string dos, string tres, string cuatro, string cinco, string seis, string siete, string ocho)
        {
            textBox1.Text = dos;
            textBox2.Text = tres;
            textBox4.Text = cuatro;
            textBox5.Text = cinco;
            textBox6.Text = seis;
            textBox7.Text = siete;
            textBox8.Text = ocho;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            listarProveedores listarProveedores = new listarProveedores();
            listarProveedores.Show();
            this.Hide();
        }
    }
}
