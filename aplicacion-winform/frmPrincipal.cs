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

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirVentana(new frmListado());
        }

        private void listadoDeArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirVentana(new frmBuscar());
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirVentana(new frmGestionMarcas());
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirVentana(new frmGestionCategorias());
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void abrirVentana(Form ventana)
        {
            foreach (Form abierta in MdiChildren)
            {
                if (abierta.GetType() == ventana.GetType())
                {
                    abierta.BringToFront();
                    return;
                }
            }
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
