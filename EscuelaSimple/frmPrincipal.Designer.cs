namespace EscuelaSimple.InterfazDeUsuario
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
            this.tsmiPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInicializar = new System.Windows.Forms.ToolStripMenuItem();
            this.msPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // msPrincipal
            // 
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPersonal,
            this.tsmiConfiguracion,
            this.tsmiAyuda});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(624, 24);
            this.msPrincipal.TabIndex = 1;
            this.msPrincipal.Text = "menuStrip1";
            // 
            // tsmiPersonal
            // 
            this.tsmiPersonal.Name = "tsmiPersonal";
            this.tsmiPersonal.Size = new System.Drawing.Size(64, 20);
            this.tsmiPersonal.Text = "Personal";
            this.tsmiPersonal.Click += new System.EventHandler(this.tsmiPersonal_Click);
            // 
            // tsmiConfiguracion
            // 
            this.tsmiConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarToolStripMenuItem,
            this.exportarToolStripMenuItem});
            this.tsmiConfiguracion.Name = "tsmiConfiguracion";
            this.tsmiConfiguracion.Size = new System.Drawing.Size(95, 20);
            this.tsmiConfiguracion.Text = "Configuracion";
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.importarToolStripMenuItem.Text = "Importar";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exportarToolStripMenuItem.Text = "Exportar";
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
            this.tsmiInicializar.Size = new System.Drawing.Size(123, 22);
            this.tsmiInicializar.Text = "Inicializar";
            this.tsmiInicializar.Click += new System.EventHandler(this.tsmiInicializar_Click);
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
        private System.Windows.Forms.ToolStripMenuItem tsmiConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAyuda;
        private System.Windows.Forms.ToolStripMenuItem tsmiInicializar;
    }
}

