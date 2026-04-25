using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestorArt.Dominio;

namespace GestorArt
{
    public partial class frmAgregar : Form
    {
        private Dominio.Articulo articulo = null;

        public frmAgregar()
        {
            InitializeComponent();
        }

        public frmAgregar(Dominio.Articulo articulo, bool modoDetalle = false)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = modoDetalle ? "Detalle del Artículo" : "Modificar Artículo";
            
            if (modoDetalle)
            {
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
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            Negocio.MarcaNegocio marcaNegocio = new Negocio.MarcaNegocio();
            Negocio.CategoriaNegocio categoriaNegocio = new Negocio.CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();

                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;

                    foreach (Imagen img in articulo.Imagenes)
                    {
                        lbxImagenes.Items.Add(img.ImagenUrl);
                    }

                    if (lbxImagenes.Items.Count > 0)
                    {
                        lbxImagenes.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Negocio.ArticuloNegocio negocio = new Negocio.ArticuloNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Dominio.Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Dominio.Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Dominio.Categoria)cboCategoria.SelectedItem;
                
                decimal precio = 0;
                if (decimal.TryParse(txtPrecio.Text, out precio))
                {
                    articulo.Precio = precio;
                }
                else
                {
                    MessageBox.Show("El precio debe ser un número válido.");
                    return;
                }

                articulo.Imagenes.Clear();
                foreach (string url in lbxImagenes.Items)
                {
                    Imagen img = new Imagen();
                    img.ImagenUrl = url;
                    articulo.Imagenes.Add(img);
                }

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtImagenUrl.Text))
            {
                lbxImagenes.Items.Add(txtImagenUrl.Text);
                txtImagenUrl.Text = "";
                lbxImagenes.SelectedIndex = lbxImagenes.Items.Count - 1;
            }
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            if (lbxImagenes.SelectedIndex != -1)
            {
                lbxImagenes.Items.RemoveAt(lbxImagenes.SelectedIndex);
                if (lbxImagenes.Items.Count > 0)
                {
                    lbxImagenes.SelectedIndex = 0;
                }
                else
                {
                    pbxImagen.Image = null;
                }
            }
        }

        private void lbxImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxImagenes.SelectedIndex != -1)
            {
                string url = lbxImagenes.SelectedItem.ToString();
                cargarImagen(url);
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
                pbxImagen.Image = System.Drawing.Image.FromStream(stream);
                stream.Close();
            }
            catch (Exception)
            {
                try {
                    System.Net.WebClient cliente = new System.Net.WebClient();
                    cliente.Headers.Add("User-Agent", "Mozilla/5.0");
                    System.IO.Stream stream = cliente.OpenRead("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
                    pbxImagen.Image = System.Drawing.Image.FromStream(stream);
                    stream.Close();
                } catch {
                    pbxImagen.Image = null;
                }
            }
        }
    }
}
