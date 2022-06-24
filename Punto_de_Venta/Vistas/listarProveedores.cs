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
    public partial class listarProveedores : Form
    {
        public listarProveedores()
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
            this.Hide();
            agregarProveedores agregarProveedores = new agregarProveedores();
            agregarProveedores.Show();
        }

        private void listarProveedores_Load(object sender, EventArgs e)
        {
            List<Proveedor> datos = new List<Proveedor>();
            Daos daos = new Daos();
            datos = daos.ConsultaProveedor();
            dgv_control.DataSource = datos;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bool click = bunifuFlatButton2.Enabled;
            if (click == true)
            {
                int i = dgv_control.CurrentRow.Index;

                string uno = dgv_control[0, i].Value.ToString();
                string dos = dgv_control[1, i].Value.ToString();
                string tres = dgv_control[2, i].Value.ToString();
                string cuatro = dgv_control[3, i].Value.ToString();
                string cinco = dgv_control[4, i].Value.ToString();
                string seis = dgv_control[5, i].Value.ToString();
                string siete = dgv_control[6, i].Value.ToString();
                string ocho = dgv_control[7, i].Value.ToString();
                string nueve = dgv_control[8, i].Value.ToString();

                modificarProveedor modificarproveedor = new modificarProveedor();
                modificarproveedor.Show();
                modificarproveedor.recuperarValoresProveedor(uno, dos, tres, cuatro, cinco, seis, siete, ocho,nueve);
                this.Hide();
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            int i = dgv_control.CurrentRow.Index;
            int valor = int.Parse(dgv_control[0, i].Value.ToString());
            Daos daos = new Daos();
            daos.eliminarProveedor(valor);
            listarProveedores listarProveedores = new listarProveedores();
            listarProveedores.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Daos daos = new Daos();
            string valor = bunifuTextbox1.text;
            List<Proveedor> lista = daos.BuscarProveedor(valor);  
            dgv_control.DataSource = lista;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bool click = bunifuFlatButton3.Enabled;
            if (click == true)
            {
                int i = dgv_control.CurrentRow.Index;

                string uno = dgv_control[0, i].Value.ToString();
                string dos = dgv_control[1, i].Value.ToString();
                string tres = dgv_control[2, i].Value.ToString();
                string cuatro = dgv_control[3, i].Value.ToString();
                string cinco = dgv_control[4, i].Value.ToString();
                string seis = dgv_control[5, i].Value.ToString();
                string siete = dgv_control[6, i].Value.ToString();
                string ocho = dgv_control[7, i].Value.ToString();

                detallesProveedor detallesProveedor = new detallesProveedor();
                detallesProveedor.Show();
                detallesProveedor.recuperarValoresProveedor(uno, dos, tres, cuatro, cinco, seis, siete, ocho);
                this.Hide();
            }
        }
    }
}
