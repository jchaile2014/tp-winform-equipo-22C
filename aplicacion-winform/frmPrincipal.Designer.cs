namespace GestorArt
{
    partial class frmPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.menuStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.listadoDeArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripPrincipal
            // 
            this.menuStripPrincipal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menuStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDeArtToolStripMenuItem,
            this.articulosToolStripMenuItem,
            this.opcionesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuStripPrincipal.Name = "menuStripPrincipal";
            this.menuStripPrincipal.Size = new System.Drawing.Size(894, 24);
            this.menuStripPrincipal.TabIndex = 1;
            this.menuStripPrincipal.Text = "menuStrip1";
            // 
            // listadoDeArtToolStripMenuItem
            // 
            this.listadoDeArtToolStripMenuItem.Name = "listadoDeArtToolStripMenuItem";
            this.listadoDeArtToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.listadoDeArtToolStripMenuItem.Text = "Buscar Art";
            this.listadoDeArtToolStripMenuItem.Click += new System.EventHandler(this.listadoDeArtToolStripMenuItem_Click);
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.articulosToolStripMenuItem.Text = "Listado de Art";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click);
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarArtToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // agregarArtToolStripMenuItem
            // 
            this.agregarArtToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.agregarArtToolStripMenuItem.Name = "agregarArtToolStripMenuItem";
            this.agregarArtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarArtToolStripMenuItem.Text = "Agregar Art";
            this.agregarArtToolStripMenuItem.Click += new System.EventHandler(this.agregarArtToolStripMenuItem_Click);

            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.Controls.Add(this.menuStripPrincipal);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripPrincipal;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de Art";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.menuStripPrincipal.ResumeLayout(false);
            this.menuStripPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem listadoDeArtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarArtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;

    }
}


