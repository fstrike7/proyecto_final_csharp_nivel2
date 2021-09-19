using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catalogo_form
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            bool existeVentana = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is Form1) existeVentana = true;
            }
            if (!existeVentana) { 
                Form1 articulos = new Form1();
                articulos.Show();
            }
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            bool existeVentana = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is frmCategorias) existeVentana = true;
            }
            if (!existeVentana) { 
                frmCategorias categorias = new frmCategorias();
                categorias.Show();
            }
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            bool existeVentana = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is frmMarcas) existeVentana = true;
            }
            if (!existeVentana) { 
                frmMarcas marcas = new frmMarcas();
                marcas.Show();
            }
        }
    }
}
