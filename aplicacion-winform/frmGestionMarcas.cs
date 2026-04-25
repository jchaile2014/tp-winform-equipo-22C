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
        }

        private void cargar()
        {
            try
            {
                dgvMarcas.DataSource = negocio.listar();
                if (dgvMarcas.Columns.Contains("Activo"))
                {
                    dgvMarcas.Columns["Activo"].Visible = false;
                }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow != null)
            {
                try
                {
                    Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                    DialogResult respuesta = MessageBox.Show($"¿Seguro que desea eliminar la marca {seleccionada.Descripcion}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        negocio.eliminarLogica(seleccionada.Id);
                        MessageBox.Show("Marca eliminada lógicamente.");
                        cargar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Seleccione una marca para eliminar.");
            }
        }
    }
}
