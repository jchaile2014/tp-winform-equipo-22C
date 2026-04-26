using System;
using System.Windows.Forms;
using GestorArt.Dominio;
using GestorArt.Negocio;

namespace GestorArt
{
    public partial class frmGestionMarcas : Form
    {
        private MarcaNegocio negocio;
        private Marca marcaSeleccionada = null;

        public frmGestionMarcas()
        {
            InitializeComponent();
            negocio = new MarcaNegocio();
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
                (this.ClientSize.Width - pnlMain.Width) / 2,
                (this.ClientSize.Height - pnlMain.Height) / 2
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNuevaMarca.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para la marca.");
                    return;
                }

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
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow != null)
            {
                marcaSeleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                txtNuevaMarca.Text = marcaSeleccionada.Descripcion;
                lblNuevaMarca.Text = "Modificando Marca:";
                btnAgregar.Text = "Guardar Cambios";
            }
            else
            {
                MessageBox.Show("Seleccione una marca para modificar.");
            }
        }


    }
}
