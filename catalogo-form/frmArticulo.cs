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
    public partial class frmArticulo : Form
    {
        private Articulo articulo = null;
        private Boolean detalle = false;
        public frmArticulo()
        {
            InitializeComponent();
        }

        public frmArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        public frmArticulo(Articulo articulo, Boolean detalle) //Constructor con boolean para determinar si solo se quiere ver el detalle.
        {
            InitializeComponent();
            this.articulo = articulo;
            this.detalle = detalle;
        }


        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void lblMarca_Click(object sender, EventArgs e)
        {

        }

        private void lblCategoria_Click(object sender, EventArgs e)
        {

        }

        private void lblImagen_Click(object sender, EventArgs e)
        {

        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            MarcaConexion marcaConexion = new MarcaConexion();
            CategoriaConexion categoriaConexion = new CategoriaConexion();
            try
            {
                comboMarca.DataSource = marcaConexion.listar();
                comboMarca.ValueMember = "Id";
                comboMarca.DisplayMember = "Descripcion";
                comboCategoria.DataSource = categoriaConexion.listar();
                comboCategoria.ValueMember = "Id";
                comboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtNombre.Text = articulo.Nombre;
                    txtPrecio.Text = Convert.ToString(articulo.Precio);
                    txtUrlImagen.Text = articulo.UrlImagen;
                    comboMarca.SelectedValue = articulo.Marca.Id;
                    comboCategoria.SelectedValue = articulo.Categoria.Id;
                }

                if (detalle) // Si se llama desde el constructor para ver detalle, se deshabilitan los campos.
                {
                    txtCodigo.ReadOnly = true;
                    txtDescripcion.ReadOnly = true;
                    txtNombre.ReadOnly = true;
                    txtPrecio.ReadOnly = true;
                    txtUrlImagen.ReadOnly = true;
                    comboMarca.Enabled = false;
                    comboCategoria.Enabled = false;
                    btnCancelar.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (detalle)
            {
                Close();
                return;
            }
            ArticuloConexion conexion = new ArticuloConexion();
            try
            {
                if (articulo == null) articulo = new Articulo();
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.UrlImagen = txtUrlImagen.Text;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
                // Aca va marca y categoria
                articulo.Marca = (Marca)comboMarca.SelectedItem;
                articulo.Categoria = (Categoria)comboCategoria.SelectedItem;

                if (articulo.Id == 0) { 
                    conexion.agregar(articulo);
                    MessageBox.Show("Artículo agregado a la base de datos.");
                }
                else { 
                    conexion.modificar(articulo);
                    MessageBox.Show("Artículo modificado a la base de datos.");
                }

                Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter = e.KeyChar;
            if (caracter == 46 && txtPrecio.Text.IndexOf(".") != -1) // Si se ingresa más de un punto.
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(caracter) && caracter != 8 && caracter != 46) // 8 corresponde al caracter de borrar. 46 el de punto.
            {
                e.Handled = true; // El caracter no es escrito en el textbox
            }
        }
    }
}
