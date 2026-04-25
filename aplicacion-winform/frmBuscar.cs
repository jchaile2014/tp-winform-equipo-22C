using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GestorArt
{
    public partial class frmBuscar : Form
    {
        private List<Dominio.Articulo> listaArticulos;

        public frmBuscar()
        {
            InitializeComponent();
        }

        private void frmBuscar_Load(object sender, EventArgs e)
        {
            dgvArticulos.DataError += delegate (object s, DataGridViewDataErrorEventArgs ev) {
                ev.ThrowException = false;
            };

            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoría");
            cboCampo.SelectedIndex = 0;
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            cboCriterio.Items.Clear();

            if (opcion == "Precio")
            {
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
            cboCriterio.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Negocio.ArticuloNegocio negocio = new Negocio.ArticuloNegocio();
            try
            {
                if (cboCampo.SelectedItem == null || cboCriterio.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un campo y un criterio de búsqueda.");
                    return;
                }

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    listaArticulos = negocio.listar();
                }
                else
                {
                    if (campo == "Precio" && !SoloNumeros(filtro))
                    {
                        MessageBox.Show("Para buscar por precio, escriba solamente números (y puede usar punto o coma).");
                        return;
                    }

                    listaArticulos = negocio.filtrar(campo, criterio, filtro);
                }
                
                dgvArticulos.DataSource = listaArticulos;
                ocultarColumnas(campo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool SoloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter) || caracter == ',' || caracter == '.'))
                    return false;
            }
            return true;
        }

        private void ocultarColumnas(string campoSeleccionado)
        {
            if (dgvArticulos.Columns.Contains("Id"))
                dgvArticulos.Columns["Id"].Visible = false;
            if (dgvArticulos.Columns.Contains("Descripcion"))
                dgvArticulos.Columns["Descripcion"].Visible = false;
            if(dgvArticulos.Columns.Contains("Imagenes"))
                dgvArticulos.Columns["Imagenes"].Visible = false;
            
            if(dgvArticulos.Columns.Contains("Nombre"))
                dgvArticulos.Columns["Nombre"].Visible = false;
            if(dgvArticulos.Columns.Contains("Marca"))
                dgvArticulos.Columns["Marca"].Visible = false;
            if(dgvArticulos.Columns.Contains("Categoria"))
                dgvArticulos.Columns["Categoria"].Visible = false;
            if(dgvArticulos.Columns.Contains("Precio"))
                dgvArticulos.Columns["Precio"].Visible = false;

            if(dgvArticulos.Columns.Contains("Codigo"))
                dgvArticulos.Columns["Codigo"].Visible = true;

            if (campoSeleccionado == "Precio" && dgvArticulos.Columns.Contains("Precio"))
            {
                dgvArticulos.Columns["Precio"].Visible = true;
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "0.00";
            }
            else if (campoSeleccionado == "Nombre" && dgvArticulos.Columns.Contains("Nombre"))
                dgvArticulos.Columns["Nombre"].Visible = true;
            else if (campoSeleccionado == "Marca" && dgvArticulos.Columns.Contains("Marca"))
                dgvArticulos.Columns["Marca"].Visible = true;
            else if (campoSeleccionado == "Categoría" && dgvArticulos.Columns.Contains("Categoria"))
                dgvArticulos.Columns["Categoria"].Visible = true;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Dominio.Articulo seleccionado;
            if (dgvArticulos.CurrentRow != null)
            {
                seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAgregar detalle = new frmAgregar(seleccionado, true);
                detalle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo para ver su detalle.");
            }
        }
    }
}
