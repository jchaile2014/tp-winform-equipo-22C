using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void agregarArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmAgregar))
                    return;
            }
            frmAgregar ventanaAgregar = new frmAgregar();
            ventanaAgregar.MdiParent = this;
            ventanaAgregar.Show();
        }

        private void modificarArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmModificar))
                    return;
            }
            frmModificar ventanaModificar = new frmModificar();
            ventanaModificar.MdiParent = this;
            ventanaModificar.Show();
        }

        private void eliminarArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmEliminar))
                    return;
            }
            frmEliminar ventanaEliminar = new frmEliminar();
            ventanaEliminar.MdiParent = this;
            ventanaEliminar.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
