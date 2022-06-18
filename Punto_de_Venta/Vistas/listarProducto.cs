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
using Punto_de_Venta.Vistas;

namespace Punto_de_Venta
{
    public partial class listarProducto : Form
    {
        public listarProducto()
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
            agregarProducto agregarProducto = new agregarProducto();
            agregarProducto.Show();
        }

        private void dgv_control_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listarProducto_Load(object sender, EventArgs e)
        {
            Daos daos = new Daos();
            List<Producto> modeloLista = daos.consultar();
            if (modeloLista != null)
            {
                dgv_control.DataSource = modeloLista;
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            int i = dgv_control.CurrentRow.Index;
            MessageBox.Show("el numero es" + i);
            Daos daos = new Daos();
            daos.eliminar(i);
        }
    }
}
