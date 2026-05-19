using System;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace GestorArt
{
    public partial class frmGestionMarcas : Form
    {
        private MarcaNegocio negocio = new MarcaNegocio();
        private Marca marcaSeleccionada;

        public frmGestionMarcas()
        {
            InitializeComponent();
        }

        private void frmGestionMarcas_Load(object sender, EventArgs e)
        {
            cargar();
            centrarPanel();
        }

        private void frmGestionMarcas_Resize(object sender, EventArgs e)
        {
            centrarPanel();
        }

        private void centrarPanel()
        {
            pnlMain.Location = new System.Drawing.Point(
                (ClientSize.Width - pnlMain.Width) / 2,
                (ClientSize.Height - pnlMain.Height) / 2
            );
        }

        private void cargar()
        {
            try
            {
                dgvMarcas.DataSource = negocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNuevaMarca.Text))
            {
                MessageBox.Show("Ingrese un nombre para la marca.");
                return;
            }

            try
            {
                if (marcaSeleccionada == null)
                {
                    Marca nueva = new Marca();
                    nueva.Descripcion = txtNuevaMarca.Text;
                    negocio.agregar(nueva);
                    MessageBox.Show("Marca agregada exitosamente.");
                }
                else
                {
                    marcaSeleccionada.Descripcion = txtNuevaMarca.Text;
                    negocio.modificar(marcaSeleccionada);
                    MessageBox.Show("Marca modificada exitosamente.");
                    marcaSeleccionada = null;
                    btnAgregar.Text = "Agregar";
                    lblNuevaMarca.Text = "Nueva Marca:";
                }

                txtNuevaMarca.Text = "";
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una marca para modificar.");
                return;
            }

            marcaSeleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
            txtNuevaMarca.Text = marcaSeleccionada.Descripcion;
            lblNuevaMarca.Text = "Modificando Marca:";
            btnAgregar.Text = "Guardar Cambios";
        }
    }
}
