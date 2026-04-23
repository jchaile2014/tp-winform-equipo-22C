using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GestorArt
{
    public partial class frmListado : Form
    {
        private List<Dominio.Articulo> listaArticulos;

        public frmListado()
        {
            InitializeComponent();
        }

        private void frmListado_Load(object sender, EventArgs e)
        {
            dgvArticulos.DataError += delegate (object s, DataGridViewDataErrorEventArgs ev) {
                // Prevenir crasheos por columnas generadas automáticamente que intenten parsear formatos complejos
                ev.ThrowException = false;
            };
            cargar();
        }

        private void cargar()
        {
            Negocio.ArticuloNegocio negocio = new Negocio.ArticuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                ocultarColumnas();
                
                if (listaArticulos.Count > 0)
                {
                    cargarImagen(listaArticulos[0].Imagenes.Count > 0 ? listaArticulos[0].Imagenes[0].ImagenUrl : "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            if(dgvArticulos.Columns.Contains("Id"))
                dgvArticulos.Columns["Id"].Visible = false;
            if(dgvArticulos.Columns.Contains("Descripcion"))
                dgvArticulos.Columns["Descripcion"].Visible = false;
            if(dgvArticulos.Columns.Contains("Imagenes"))
                dgvArticulos.Columns["Imagenes"].Visible = false;
                
            if (dgvArticulos.Columns.Contains("Precio"))
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "0.00";
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Dominio.Articulo seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.Imagenes.Count > 0 ? seleccionado.Imagenes[0].ImagenUrl : "");
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                System.Net.WebClient cliente = new System.Net.WebClient();
                cliente.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.0.0 Safari/537.36");
                System.IO.Stream stream = cliente.OpenRead(imagen);
                pbxArticulo.Image = System.Drawing.Image.FromStream(stream);
                stream.Close();
            }
            catch (Exception)
            {
                try {
                    System.Net.WebClient cliente = new System.Net.WebClient();
                    cliente.Headers.Add("User-Agent", "Mozilla/5.0");
                    System.IO.Stream stream = cliente.OpenRead("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
                    pbxArticulo.Image = System.Drawing.Image.FromStream(stream);
                    stream.Close();
                } catch {
                    pbxArticulo.Image = null; // Falla total de red
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar alta = new frmAgregar();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Dominio.Articulo seleccionado;
            if (dgvArticulos.CurrentRow != null)
            {
                seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAgregar modificar = new frmAgregar(seleccionado);
                modificar.ShowDialog();
                cargar();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo para modificar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Negocio.ArticuloNegocio negocio = new Negocio.ArticuloNegocio();
            Dominio.Articulo seleccionado;
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    DialogResult respuesta = MessageBox.Show("¿Seguro querés eliminar el artículo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        seleccionado = (Dominio.Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                        negocio.eliminar(seleccionado.Id);
                        cargar();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un artículo para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}

