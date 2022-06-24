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
    public partial class modificarProveedor : Form
    {
        public modificarProveedor()
        {
            InitializeComponent();
        }
        public void recuperarValoresProveedor(string uno, string dos, string tres, string cuatro, string cinco, string seis, string siete, string ocho, string nueve)
        {
            textBox10.Text = uno;
            textBox1.Text = dos;
            textBox2.Text = tres;
            textBox4.Text = cuatro;
            textBox5.Text = cinco;
            textBox6.Text = seis;
            textBox7.Text = siete;
            textBox8.Text = ocho;
            textBox9.Text = nueve;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Daos daos = new Daos();
            Proveedor proveedor = new Proveedor();
            int valor = int.Parse(textBox10.Text);
            proveedor.Nombre = textBox1.Text;
            proveedor.Direccion = textBox2.Text;
            proveedor.Telefono = textBox4.Text;
            proveedor.FechaPedido = textBox5.Text;
            proveedor.DiaSurtido = textBox6.Text;
            proveedor.Cantidad = int.Parse(textBox7.Text);
            proveedor.FormaPago = textBox8.Text;
            proveedor.Plazo = int.Parse(textBox9.Text);

            daos.modificarProveedor(valor, proveedor);

        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            listarProveedores listarProveedores = new listarProveedores();
            listarProveedores.Show();
        }
    }
}
