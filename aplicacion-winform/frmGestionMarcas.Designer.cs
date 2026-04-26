namespace GestorArt
{
    partial class frmGestionMarcas
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

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNuevaMarca = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblNuevaMarca = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvMarcas);
            this.pnlMain.Controls.Add(this.btnModificar);
            this.pnlMain.Controls.Add(this.btnAgregar);
            this.pnlMain.Controls.Add(this.txtNuevaMarca);
            this.pnlMain.Controls.Add(this.lblNuevaMarca);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(500, 310);
            this.pnlMain.TabIndex = 0;
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMarcas.Location = new System.Drawing.Point(12, 12);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMarcas.Size = new System.Drawing.Size(300, 250);
            this.dgvMarcas.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(333, 57);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNuevaMarca
            // 
            this.txtNuevaMarca.Location = new System.Drawing.Point(333, 31);
            this.txtNuevaMarca.Name = "txtNuevaMarca";
            this.txtNuevaMarca.Size = new System.Drawing.Size(150, 20);
            this.txtNuevaMarca.TabIndex = 2;
            // 
            // btnModificar  — movido a la izquierda
            // 
            this.btnModificar.Location = new System.Drawing.Point(12, 268);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 23);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblNuevaMarca
            // 
            this.lblNuevaMarca.AutoSize = true;
            this.lblNuevaMarca.Location = new System.Drawing.Point(330, 15);
            this.lblNuevaMarca.Name = "lblNuevaMarca";
            this.lblNuevaMarca.Size = new System.Drawing.Size(75, 13);
            this.lblNuevaMarca.TabIndex = 1;
            this.lblNuevaMarca.Text = "Nueva Marca:";
            // 
            // frmGestionMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 310);
            this.Controls.Add(this.pnlMain);
            this.MinimumSize = new System.Drawing.Size(520, 350);
            this.Name = "frmGestionMarcas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Marcas";
            this.Load += new System.EventHandler(this.frmGestionMarcas_Load);
            this.Resize += new System.EventHandler(this.frmGestionMarcas_Resize);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNuevaMarca;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblNuevaMarca;
    }
}
