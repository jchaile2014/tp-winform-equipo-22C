using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestorArt
{
    public partial class frmListado : Form
    {
        private List<Articulo> listaArticulos;
        private int indiceImagenActual;

        public frmListado()
        {
            InitializeComponent();
        }

        private void frmListado_Load(object sender, EventArgs e)
        {
            armarColumnas();
            cargar();
        }

        private void armarColumnas()
        {
            dgvArticulos.AutoGenerateColumns = false;

            agregarColumna("Codigo", "Código");
            agregarColumna("Nombre", "Nombre");
            agregarColumna("Descripcion", "Descripción");
            agregarColumna("Marca", "Marca");
            agregarColumna("Categoria", "Categoría");

            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.Name = "Precio";
            colPrecio.HeaderText = "Precio";
            colPrecio.DataPropertyName = "Precio";
            colPrecio.DefaultCellStyle.Format = "0.00";
            dgvArticulos.Columns.Add(colPrecio);
        }

        private void agregarColumna(string propiedad, string titulo)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = propiedad;
            col.HeaderText = titulo;
            col.DataPropertyName = propiedad;
            dgvArticulos.Columns.Add(col);
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
                dgvArticulos.DataSource = listaArticulos;

                if (listaArticulos.Count > 0)
                {
                    indiceImagenActual = 0;
                    cargarImagenActual();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                indiceImagenActual = 0;
                cargarImagenActual();
            }
        }

        private void cargarImagenActual()
        {
            if (dgvArticulos.CurrentRow == null)
                return;

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            if (seleccionado.Imagenes.Count == 0)
            {
                cargarImagen("");
                return;
            }

            if (indiceImagenActual < 0)
                indiceImagenActual = seleccionado.Imagenes.Count - 1;
            if (indiceImagenActual >= seleccionado.Imagenes.Count)
                indiceImagenActual = 0;

            cargarImagen(seleccionado.Imagenes[indiceImagenActual].ImagenUrl);
        }

        private void cargarImagen(string url)
        {
            try
            {
                pbxArticulo.Load(url);
            }
            catch
            {
                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQeJQeJyzgAzTEVqXiGe90RGBFhfp_4RcJJMQ&s");
            }
        }

        private void btnAnteriorImagen_Click(object sender, EventArgs e)
        {
            indiceImagenActual--;
            cargarImagenActual();
        }

        private void btnSiguienteImagen_Click(object sender, EventArgs e)
        {
            indiceImagenActual++;
            cargarImagenActual();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar alta = new frmAgregar();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para modificar.");
                return;
            }

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAgregar modificar = new frmAgregar(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Seguro querés eliminar el artículo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminar(seleccionado.Id);
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
