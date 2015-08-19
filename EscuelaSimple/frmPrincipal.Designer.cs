namespace EscuelaSimple.InterfazDeUsuario.WinForms
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.msPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInicializar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDatosPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInasistenciasPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.msPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // msPrincipal
            // 
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiArchivo,
            this.tsmiPersonal,
            this.tsmiAyuda});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(624, 24);
            this.msPrincipal.TabIndex = 1;
            this.msPrincipal.Text = "menuStrip1";
            // 
            // tsmiArchivo
            // 
            this.tsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImportar,
            this.tsmiExportar});
            this.tsmiArchivo.Name = "tsmiArchivo";
            this.tsmiArchivo.Size = new System.Drawing.Size(60, 20);
            this.tsmiArchivo.Text = "Archivo";
            // 
            // tsmiImportar
            // 
            this.tsmiImportar.Image = global::EscuelaSimple.InterfazDeUsuario.WinForms.Properties.Resources.import;
            this.tsmiImportar.Name = "tsmiImportar";
            this.tsmiImportar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmiImportar.Size = new System.Drawing.Size(157, 22);
            this.tsmiImportar.Text = "Importar";
            this.tsmiImportar.Click += new System.EventHandler(this.tsmiImportar_Click);
            // 
            // tsmiExportar
            // 
            this.tsmiExportar.Image = global::EscuelaSimple.InterfazDeUsuario.WinForms.Properties.Resources.export_16x16;
            this.tsmiExportar.Name = "tsmiExportar";
            this.tsmiExportar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiExportar.Size = new System.Drawing.Size(157, 22);
            this.tsmiExportar.Text = "Exportar";
            this.tsmiExportar.Click += new System.EventHandler(this.tsmiExportar_Click);
            // 
            // tsmiPersonal
            // 
            this.tsmiPersonal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDatosPersonal,
            this.tsmiInasistenciasPersonal});
            this.tsmiPersonal.Name = "tsmiPersonal";
            this.tsmiPersonal.Size = new System.Drawing.Size(64, 20);
            this.tsmiPersonal.Text = "Personal";
            // 
            // tsmiAyuda
            // 
            this.tsmiAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInicializar});
            this.tsmiAyuda.Name = "tsmiAyuda";
            this.tsmiAyuda.Size = new System.Drawing.Size(53, 20);
            this.tsmiAyuda.Text = "Ayuda";
            // 
            // tsmiInicializar
            // 
            this.tsmiInicializar.Name = "tsmiInicializar";
            this.tsmiInicializar.Size = new System.Drawing.Size(152, 22);
            this.tsmiInicializar.Text = "Inicializar";
            // 
            // tsmiDatosPersonal
            // 
            this.tsmiDatosPersonal.Name = "tsmiDatosPersonal";
            this.tsmiDatosPersonal.Size = new System.Drawing.Size(152, 22);
            this.tsmiDatosPersonal.Text = "Datos";
            this.tsmiDatosPersonal.Click += new System.EventHandler(this.tsmiDatosPersonal_Click);
            // 
            // tsmiInasistenciasPersonal
            // 
            this.tsmiInasistenciasPersonal.Name = "tsmiInasistenciasPersonal";
            this.tsmiInasistenciasPersonal.Size = new System.Drawing.Size(152, 22);
            this.tsmiInasistenciasPersonal.Text = "Inasistencias";
            this.tsmiInasistenciasPersonal.Click += new System.EventHandler(this.tsmiInasistenciasPersonal_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.msPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Escuela Simple";
            this.msPrincipal.ResumeLayout(false);
            this.msPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonal;
        private System.Windows.Forms.ToolStripMenuItem tsmiArchivo;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportar;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportar;
        private System.Windows.Forms.ToolStripMenuItem tsmiAyuda;
        private System.Windows.Forms.ToolStripMenuItem tsmiInicializar;
        private System.Windows.Forms.ToolStripMenuItem tsmiDatosPersonal;
        private System.Windows.Forms.ToolStripMenuItem tsmiInasistenciasPersonal;
    }
}

