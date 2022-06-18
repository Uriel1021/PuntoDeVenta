using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_Venta.Conexion;
using Punto_de_Venta.Modelo;

namespace Punto_de_Venta.Vistas
{
    public partial class agregarCategoria : Form
    {
        public agregarCategoria()
        {
            InitializeComponent();
        }
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            inicio inicio = new inicio();
            inicio.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Daos daos = new Daos();
            Categoria categoria = new Categoria();
            categoria.CategoriaName = textBox1.Text;
            daos.insertarCategoria(categoria);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
