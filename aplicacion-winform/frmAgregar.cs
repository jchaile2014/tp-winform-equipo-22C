using System;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace GestorArt
{
    public partial class frmAgregar : Form
    {
        private Articulo articulo;

        public frmAgregar()
        {
            InitializeComponent();
            Text = "Nuevo Artículo";
        }

        public frmAgregar(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Artículo";
        }

        public frmAgregar(Articulo articulo, bool modoDetalle)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Detalle del Artículo";

            txtCodigo.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            cboMarca.Enabled = false;
            cboCategoria.Enabled = false;
            txtPrecio.ReadOnly = true;
            txtImagenUrl.ReadOnly = true;
            btnAgregarImagen.Visible = false;
            btnQuitarImagen.Visible = false;
            btnAceptar.Visible = false;
            btnCancelar.Text = "Cerrar";
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo == null)
                    return;

                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtPrecio.Text = articulo.Precio.ToString();
                cboMarca.SelectedValue = articulo.Marca.Id;
                cboCategoria.SelectedValue = articulo.Categoria.Id;

                foreach (Imagen img in articulo.Imagenes)
                    lbxImagenes.Items.Add(img.ImagenUrl);

                if (lbxImagenes.Items.Count > 0)
                    lbxImagenes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Precio = precio;

                articulo.Imagenes.Clear();
                foreach (string url in lbxImagenes.Items)
                {
                    Imagen img = new Imagen();
                    img.ImagenUrl = url;
                    articulo.Imagenes.Add(img);
                }

                ArticuloNegocio negocio = new ArticuloNegocio();
                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente.");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImagenUrl.Text))
                return;

            lbxImagenes.Items.Add(txtImagenUrl.Text);
            txtImagenUrl.Text = "";
            lbxImagenes.SelectedIndex = lbxImagenes.Items.Count - 1;
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            if (lbxImagenes.SelectedIndex == -1)
                return;

            lbxImagenes.Items.RemoveAt(lbxImagenes.SelectedIndex);
            if (lbxImagenes.Items.Count > 0)
                lbxImagenes.SelectedIndex = 0;
            else
                pbxImagen.Image = null;
        }

        private void lbxImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxImagenes.SelectedIndex == -1)
                return;

            cargarImagen(lbxImagenes.SelectedItem.ToString());
        }

        private void cargarImagen(string url)
        {
            try
            {
                pbxImagen.Load(url);
            }
            catch
            {
                pbxImagen.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQeJQeJyzgAzTEVqXiGe90RGBFhfp_4RcJJMQ&s");
            }
        }
    }
}
