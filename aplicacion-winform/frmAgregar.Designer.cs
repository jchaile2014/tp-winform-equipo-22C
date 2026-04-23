namespace GestorArt
{
    partial class frmAgregar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblImagenUrl = new System.Windows.Forms.Label();
            this.txtImagenUrl = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            this.SuspendLayout();
            //
            // Etiquetas
            //
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(30, 33);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.Text = "Código:";
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(30, 63);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.Text = "Nombre:";
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(30, 93);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.Text = "Descripción:";
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(30, 123);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.Text = "Marca:";
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(30, 153);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(55, 13);
            this.lblCategoria.Text = "Categoría:";
            this.lblImagenUrl.AutoSize = true;
            this.lblImagenUrl.Location = new System.Drawing.Point(30, 183);
            this.lblImagenUrl.Name = "lblImagenUrl";
            this.lblImagenUrl.Size = new System.Drawing.Size(61, 13);
            this.lblImagenUrl.Text = "Url Imagen:";
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(30, 213);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.Text = "Precio:";
            //
            // Controles
            //
            this.txtCodigo.Location = new System.Drawing.Point(120, 30);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.Location = new System.Drawing.Point(120, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtDescripcion.Location = new System.Drawing.Point(120, 90);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(150, 20);
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.Location = new System.Drawing.Point(120, 120);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(150, 21);
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Location = new System.Drawing.Point(120, 150);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(150, 21);
            this.txtImagenUrl.Location = new System.Drawing.Point(120, 180);
            this.txtImagenUrl.Name = "txtImagenUrl";
            this.txtImagenUrl.Size = new System.Drawing.Size(150, 20);
            this.txtImagenUrl.Leave += new System.EventHandler(this.txtImagenUrl_Leave);
            this.txtPrecio.Location = new System.Drawing.Point(120, 210);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(150, 20);
            //
            // PictureBox
            //
            this.pbxImagen.Location = new System.Drawing.Point(300, 30);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(250, 250);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagen.TabStop = false;
            //
            // Botones
            //
            this.btnAceptar.Location = new System.Drawing.Point(60, 260);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnCancelar.Location = new System.Drawing.Point(170, 260);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // frmAgregar
            //
            this.ClientSize = new System.Drawing.Size(580, 320);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.lblImagenUrl);
            this.Controls.Add(this.txtImagenUrl);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.pbxImagen);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmAgregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Artículo";
            this.Load += new System.EventHandler(this.frmAgregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblImagenUrl;
        private System.Windows.Forms.TextBox txtImagenUrl;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

