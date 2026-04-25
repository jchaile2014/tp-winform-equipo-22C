using System;
using System.Windows.Forms;
using GestorArt.Dominio;
using GestorArt.Negocio;

namespace GestorArt
{
    public partial class frmGestionCategorias : Form
    {
        private CategoriaNegocio negocio;
        private Categoria categoriaSeleccionada = null;

        public frmGestionCategorias()
        {
            InitializeComponent();
            negocio = new CategoriaNegocio();
        }

        private void frmGestionCategorias_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            try
            {
                dgvCategorias.DataSource = negocio.listar();
                if (dgvCategorias.Columns.Contains("Activo"))
                {
                    dgvCategorias.Columns["Activo"].Visible = false;
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
                if (string.IsNullOrWhiteSpace(txtNuevaCategoria.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para la categoría.");
                    return;
                }

                if (categoriaSeleccionada == null)
                {
                    Categoria nueva = new Categoria();
                    nueva.Descripcion = txtNuevaCategoria.Text;
                    negocio.agregar(nueva);
                    MessageBox.Show("Categoría agregada exitosamente.");
                }
                else
                {
                    categoriaSeleccionada.Descripcion = txtNuevaCategoria.Text;
                    negocio.modificar(categoriaSeleccionada);
                    MessageBox.Show("Categoría modificada exitosamente.");
                    
                    categoriaSeleccionada = null;
                    btnAgregar.Text = "Agregar";
                    lblNuevaCategoria.Text = "Nueva Categoría:";
                }

                txtNuevaCategoria.Text = "";
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                categoriaSeleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                txtNuevaCategoria.Text = categoriaSeleccionada.Descripcion;
                lblNuevaCategoria.Text = "Modificando Categoría:";
                btnAgregar.Text = "Guardar Cambios";
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para modificar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                try
                {
                    Categoria seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    DialogResult respuesta = MessageBox.Show($"¿Seguro que desea eliminar la categoría {seleccionada.Descripcion}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        negocio.eliminarLogica(seleccionada.Id);
                        MessageBox.Show("Categoría eliminada lógicamente.");
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
                MessageBox.Show("Seleccione una categoría para eliminar.");
            }
        }
    }
}
