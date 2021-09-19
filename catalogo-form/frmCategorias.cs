using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Conexion;

namespace catalogo_form
{
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }
        private void cargar()
        {
            CategoriaConexion categoriaConexion = new CategoriaConexion();
            dgvCategorias.DataSource = categoriaConexion.listar();
        }
        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Categoria seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            frmSecundario form = new frmSecundario(seleccionado, "modificar");
            form.ShowDialog();
            cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            frmSecundario form = new frmSecundario(seleccionado, "agregar");
            form.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Categoria seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            CategoriaConexion conexion = new CategoriaConexion();
            try { 
                conexion.eliminar(seleccionado);
                MessageBox.Show("Eliminado correctamente de la base de datos.");
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
