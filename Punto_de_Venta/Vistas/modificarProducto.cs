using Npgsql;
using Punto_de_Venta.Conexion;
using Punto_de_Venta.Modelo;
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
    public partial class modificarProducto : Form
    {
        public modificarProducto()
        {
            InitializeComponent();
        }
        public void recuperarValores(string uno,string dos,string tres,string cuatro,string cinco,string seis,string siete,string ocho)
        {
            textBox1.Text = uno;
            textBox2.Text = dos;
            textBox4.Text = tres;
            textBox5.Text = cuatro;
            textBox6.Text = cinco;
            textBox7.Text = seis;   
            textBox8.Text = siete;
            textBox9.Text = ocho;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            listarProducto listarproducto = new listarProducto();
            listarproducto.Show();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Daos daos = new Daos();
            Producto producto = new Producto();
            int id = int.Parse(textBox1.Text);
            producto.Descripcion = textBox2.Text;
            producto.NumeroUnidades = int.Parse(textBox4.Text);
            producto.PrecioProveedor = int.Parse(textBox5.Text);
            producto.PrecioUnitario = int.Parse(textBox6.Text);
            producto.PrecioPublico = int.Parse(textBox7.Text);
            producto.CodigoBarra = textBox8.Text;
            producto.FechaEntrada = textBox9.Text;
            daos.modificarProducto(id,producto);
            this.Hide();
            listarProducto listarProducto = new listarProducto();
            listarProducto.Show();
        }
    }
}
