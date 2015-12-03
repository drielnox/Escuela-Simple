namespace EscuelaSimple.InterfazDeUsuario.WinForms.Personal.Inasistencias
{
    partial class frmPersonalInasistenciaListado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAltaInasistencia = new System.Windows.Forms.ToolStripButton();
            this.tsbModificacionInasistencia = new System.Windows.Forms.ToolStripButton();
            this.tsbBajaInasistencia = new System.Windows.Forms.ToolStripButton();
            this.lvInasistencia = new System.Windows.Forms.ListView();
            this.chArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDesde = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHasta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCantDias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAltaInasistencia,
            this.tsbModificacionInasistencia,
            this.tsbBajaInasistencia});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(411, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAltaInasistencia
            // 
            this.tsbAltaInasistencia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAltaInasistencia.Image = global::EscuelaSimple.InterfazDeUsuario.WinForms.Properties.Resources._077_AddFile_48x48_72;
            this.tsbAltaInasistencia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAltaInasistencia.Name = "tsbAltaInasistencia";
            this.tsbAltaInasistencia.Size = new System.Drawing.Size(23, 22);
            this.tsbAltaInasistencia.Text = "Agregar";
            this.tsbAltaInasistencia.Click += new System.EventHandler(this.tsbAltaInasistencia_Click);
            // 
            // tsbModificacionInasistencia
            // 
            this.tsbModificacionInasistencia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbModificacionInasistencia.Enabled = false;
            this.tsbModificacionInasistencia.Image = global::EscuelaSimple.InterfazDeUsuario.WinForms.Properties.Resources._126_Edit_48x48_72;
            this.tsbModificacionInasistencia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModificacionInasistencia.Name = "tsbModificacionInasistencia";
            this.tsbModificacionInasistencia.Size = new System.Drawing.Size(23, 22);
            this.tsbModificacionInasistencia.Text = "Modificar";
            this.tsbModificacionInasistencia.Click += new System.EventHandler(this.tsbModificacionInasistencia_Click);
            // 
            // tsbBajaInasistencia
            // 
            this.tsbBajaInasistencia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBajaInasistencia.Enabled = false;
            this.tsbBajaInasistencia.Image = global::EscuelaSimple.InterfazDeUsuario.WinForms.Properties.Resources.delete;
            this.tsbBajaInasistencia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBajaInasistencia.Name = "tsbBajaInasistencia";
            this.tsbBajaInasistencia.Size = new System.Drawing.Size(23, 22);
            this.tsbBajaInasistencia.Text = "Borrar";
            this.tsbBajaInasistencia.Click += new System.EventHandler(this.tsbBajaInasistencia_Click);
            // 
            // lvInasistencia
            // 
            this.lvInasistencia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chArticulo,
            this.chDesde,
            this.chHasta,
            this.chCantDias});
            this.lvInasistencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInasistencia.FullRowSelect = true;
            this.lvInasistencia.GridLines = true;
            this.lvInasistencia.Location = new System.Drawing.Point(0, 25);
            this.lvInasistencia.MultiSelect = false;
            this.lvInasistencia.Name = "lvInasistencia";
            this.lvInasistencia.ShowGroups = false;
            this.lvInasistencia.ShowItemToolTips = true;
            this.lvInasistencia.Size = new System.Drawing.Size(411, 309);
            this.lvInasistencia.TabIndex = 3;
            this.lvInasistencia.UseCompatibleStateImageBehavior = false;
            this.lvInasistencia.View = System.Windows.Forms.View.Details;
            this.lvInasistencia.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvInasistencia_ItemSelectionChanged);
            // 
            // chArticulo
            // 
            this.chArticulo.Text = "Articulo";
            // 
            // chDesde
            // 
            this.chDesde.Text = "Desde";
            // 
            // chHasta
            // 
            this.chHasta.Text = "Hasta";
            // 
            // chCantDias
            // 
            this.chCantDias.Text = "Dias";
            // 
            // frmPersonalInasistenciaListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 334);
            this.Controls.Add(this.lvInasistencia);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmPersonalInasistenciaListado";
            this.Text = "frmPersonalInasistenciaListado";
            this.Load += new System.EventHandler(this.frmPersonalInasistenciaListado_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAltaInasistencia;
        private System.Windows.Forms.ToolStripButton tsbModificacionInasistencia;
        private System.Windows.Forms.ToolStripButton tsbBajaInasistencia;
        private System.Windows.Forms.ListView lvInasistencia;
        private System.Windows.Forms.ColumnHeader chArticulo;
        private System.Windows.Forms.ColumnHeader chDesde;
        private System.Windows.Forms.ColumnHeader chHasta;
        private System.Windows.Forms.ColumnHeader chCantDias;
    }
}