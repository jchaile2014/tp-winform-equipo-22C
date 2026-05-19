using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace GestorArt
{
    public partial class frmBuscar : Form
    {
        private List<Articulo> listaArticulos;

        public frmBuscar()
        {
            InitializeComponent();
        }

        private void frmBuscar_Load(object sender, EventArgs e)
        {
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
            if (cboCampo.SelectedItem == null || cboCriterio.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un campo y un criterio.");
                return;
            }

            string campo = cboCampo.SelectedItem.ToString();
            string criterio = cboCriterio.SelectedItem.ToString();
            string filtro = txtFiltro.Text;

            if (campo == "Precio" && !string.IsNullOrWhiteSpace(filtro) && !SoloNumeros(filtro))
            {
                MessageBox.Show("Para buscar por precio escriba solo números (admite coma o punto).");
                return;
            }

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                if (string.IsNullOrWhiteSpace(filtro))
                    listaArticulos = negocio.listar();
                else
                    listaArticulos = negocio.filtrar(campo, criterio, filtro);

                armarColumnas(campo);
                dgvArticulos.DataSource = listaArticulos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool SoloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!char.IsNumber(caracter) && caracter != ',' && caracter != '.')
                    return false;
            }
            return true;
        }

        private void armarColumnas(string campoSeleccionado)
        {
            dgvArticulos.AutoGenerateColumns = false;
            dgvArticulos.DataSource = null;
            dgvArticulos.Columns.Clear();

            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.Name = "Codigo";
            colCodigo.HeaderText = "Código";
            colCodigo.DataPropertyName = "Codigo";
            dgvArticulos.Columns.Add(colCodigo);

            DataGridViewTextBoxColumn colExtra = new DataGridViewTextBoxColumn();
            if (campoSeleccionado == "Precio")
            {
                colExtra.Name = "Precio";
                colExtra.HeaderText = "Precio";
                colExtra.DataPropertyName = "Precio";
                colExtra.DefaultCellStyle.Format = "0.00";
            }
            else if (campoSeleccionado == "Nombre")
            {
                colExtra.Name = "Nombre";
                colExtra.HeaderText = "Nombre";
                colExtra.DataPropertyName = "Nombre";
            }
            else if (campoSeleccionado == "Marca")
            {
                colExtra.Name = "Marca";
                colExtra.HeaderText = "Marca";
                colExtra.DataPropertyName = "Marca";
            }
            else
            {
                colExtra.Name = "Categoria";
                colExtra.HeaderText = "Categoría";
                colExtra.DataPropertyName = "Categoria";
            }
            dgvArticulos.Columns.Add(colExtra);
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para ver el detalle.");
                return;
            }

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAgregar detalle = new frmAgregar(seleccionado, true);
            detalle.ShowDialog();
        }
    }
}
