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
    // La idea de éste form es usarlo tanto en el form de Categoria como en el de Marca ya que comparten los mismos campos.
    public partial class frmSecundario : Form
    {
        private string accion;
        private Categoria categoria = null;
        private Marca marca = null;
        public frmSecundario()
        {
            InitializeComponent();
        }

        public frmSecundario(Categoria categoria, string accion) { 

            InitializeComponent();
            this.categoria = categoria;
            this.accion = accion;
        }

        public frmSecundario(Marca marca, string accion)
        {
            InitializeComponent();
            this.marca = marca;
            this.accion = accion;
        }

        private void frmSecundario_Load(object sender, EventArgs e)
        {
            if (accion == "modificar") txtDescripcion.Text = marca.Descripcion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (categoria != null)
            {
                CategoriaConexion conexion = new CategoriaConexion();
                if (accion == "agregar")
                {
                    conexion.agregar(txtDescripcion.Text);
                    MessageBox.Show("Categoria agregada a la base de datos.");

                }
                else if (accion == "modificar")
                {
                    Categoria modificado = new Categoria(categoria.Id, txtDescripcion.Text);

                    conexion.modificar(modificado);
                    MessageBox.Show("Categoria modificada de la base de datos.");
                }
            }
            else if (marca != null)
            {
                MarcaConexion conexion = new MarcaConexion();
                if (accion == "agregar")
                {
                    conexion.agregar(txtDescripcion.Text);
                    MessageBox.Show("Marca agregada a la base de datos.");

                }
                else if (accion == "modificar")
                {
                    Marca modificado = new Marca(marca.Id, txtDescripcion.Text);
                    conexion.modificar(modificado);
                    MessageBox.Show("Marca modificada de la base de datos.");
                }
            }
            Close();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
