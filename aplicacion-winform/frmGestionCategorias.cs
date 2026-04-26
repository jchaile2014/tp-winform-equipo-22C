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
            centrarPanel();
        }

        private void frmGestionCategorias_Resize(object sender, EventArgs e)
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
                dgvCategorias.DataSource = negocio.listar();
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


    }
}
