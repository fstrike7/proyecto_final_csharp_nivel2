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
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            
        }

        private void cargar()
        {
            // Cargando la grilla de artículos.
            ArticuloConexion conexion = new ArticuloConexion();
            try
            {
                listaArticulos = conexion.listar();
                dgvArticulos.DataSource = listaArticulos;
                dgvArticulos.Columns[0].Visible = false; // ID de articulo

                pbxArticulo.Load(listaArticulos[0].UrlImagen);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            try
            {
                pbxArticulo.Load(seleccionado.UrlImagen);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://socialistmodernism.com/wp-content/uploads/2017/07/placeholder-image.png?w=640");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmArticulo ventanaNuevo = new frmArticulo();
            ventanaNuevo.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            frmArticulo ventanaNuevo = new frmArticulo(seleccionado);
            ventanaNuevo.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            ArticuloConexion conexion = new ArticuloConexion();
            try
            {
                DialogResult dialogResult = MessageBox.Show("Estás por eliminar el artículo de la base de datos.", "Eliminar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    conexion.eliminar(seleccionado);
                    MessageBox.Show("Artículo eliminado de la base de datos.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
            cargar();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmArticulo ventanaNuevo = new frmArticulo(seleccionado, true);
            ventanaNuevo.ShowDialog();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void filtro()
        {
            string filtro = txtFiltro.Text;
            filtro = filtro.ToUpper();
            if (filtro == "" || filtro.Length<=2)
            {
                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = listaArticulos;
            }
            else
            {
                List<Articulo> listaFiltrada = listaArticulos.FindAll(var => 
                    var.Codigo.ToUpper().Contains(filtro) ||
                    var.Descripcion.ToUpper().Contains(filtro) ||
                    var.Nombre.ToUpper().Contains(filtro) ||
                    var.Marca.Descripcion.ToUpper().Contains(filtro) ||
                    var.Categoria.Descripcion.ToUpper().Contains(filtro)
                    );
                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = listaFiltrada;
            }
        }
    }
}
