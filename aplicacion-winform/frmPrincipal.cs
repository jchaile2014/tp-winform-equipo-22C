using System;
using System.Windows.Forms;

namespace GestorArt
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void listadoDeArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmBuscar))
                    return;
            }
            frmBuscar ventanaBuscar = new frmBuscar();
            ventanaBuscar.MdiParent = this;
            ventanaBuscar.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmListado))
                    return;
            }
            frmListado ventanaListado = new frmListado();
            ventanaListado.MdiParent = this;
            ventanaListado.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmGestionMarcas))
                    return;
            }
            frmGestionMarcas ventanaMarcas = new frmGestionMarcas();
            ventanaMarcas.MdiParent = this;
            ventanaMarcas.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmGestionCategorias))
                    return;
            }
            frmGestionCategorias ventanaCategorias = new frmGestionCategorias();
            ventanaCategorias.MdiParent = this;
            ventanaCategorias.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
