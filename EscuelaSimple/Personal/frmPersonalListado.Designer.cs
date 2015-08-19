namespace EscuelaSimple.InterfazDeUsuario.WinForms.Personal
{
    partial class frmPersonalListado
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
            this.tsPersonal = new System.Windows.Forms.ToolStrip();
            this.tsbFiltrarPersonal = new System.Windows.Forms.ToolStripButton();
            this.tsbVerPersonal = new System.Windows.Forms.ToolStripButton();
            this.tsbAltaPersonal = new System.Windows.Forms.ToolStripButton();
            this.tsbModificarPersonal = new System.Windows.Forms.ToolStripButton();
            this.tsbBajaPersonal = new System.Windows.Forms.ToolStripButton();
            this.lvPersonal = new System.Windows.Forms.ListView();
            this.chApellido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsPersonal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsPersonal
            // 
            this.tsPersonal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFiltrarPersonal,
            this.tsbVerPersonal,
            this.tsbAltaPersonal,
            this.tsbModificarPersonal,
            this.tsbBajaPersonal});
            this.tsPersonal.Location = new System.Drawing.Point(0, 0);
            this.tsPersonal.Name = "tsPersonal";
            this.tsPersonal.Size = new System.Drawing.Size(484, 25);
            this.tsPersonal.TabIndex = 0;
            this.tsPersonal.Text = "toolStrip1";
            // 
            // tsbFiltrarPersonal
            // 
            this.tsbFiltrarPersonal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltrarPersonal.Image = global::EscuelaSimple.InterfazDeUsuario.WinForms.Properties.Resources.Filter;
            this.tsbFiltrarPersonal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltrarPersonal.Name = "tsbFiltrarPersonal";
            this.tsbFiltrarPersonal.Size = new System.Drawing.Size(23, 22);
            this.tsbFiltrarPersonal.Text = "Filtrar";
            this.tsbFiltrarPersonal.Click += new System.EventHandler(this.tsbFiltrarPersonal_Click);
            // 
            // tsbVerPersonal
            // 
            this.tsbVerPersonal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbVerPersonal.Enabled = false;
            this.tsbVerPersonal.Image = global::EscuelaSimple.InterfazDeUsuario.WinForms.Properties.Resources.Zoom_32x32;
            this.tsbVerPersonal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVerPersonal.Name = "tsbVerPersonal";
            this.tsbVerPersonal.Size = new System.Drawing.Size(23, 22);
            this.tsbVerPersonal.Text = "Ver";
            this.tsbVerPersonal.Click += new System.EventHandler(this.tsbVerPersonal_Click);
            // 
            // tsbAltaPersonal
            // 
            this.tsbAltaPersonal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAltaPersonal.Image = global::EscuelaSimple.InterfazDeUsuario.WinForms.Properties.Resources._077_AddFile_48x48_72;
            this.tsbAltaPersonal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAltaPersonal.Name = "tsbAltaPersonal";
            this.tsbAltaPersonal.Size = new System.Drawing.Size(23, 22);
            this.tsbAltaPersonal.Text = "Agregar";
            this.tsbAltaPersonal.Click += new System.EventHandler(this.tsbAltaPersonal_Click);
            // 
            // tsbModificarPersonal
            // 
            this.tsbModificarPersonal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbModificarPersonal.Enabled = false;
            this.tsbModificarPersonal.Image = global::EscuelaSimple.InterfazDeUsuario.WinForms.Properties.Resources._126_Edit_48x48_72;
            this.tsbModificarPersonal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModificarPersonal.Name = "tsbModificarPersonal";
            this.tsbModificarPersonal.Size = new System.Drawing.Size(23, 22);
            this.tsbModificarPersonal.Text = "Editar";
            this.tsbModificarPersonal.Click += new System.EventHandler(this.tsbModificarPersonal_Click);
            // 
            // tsbBajaPersonal
            // 
            this.tsbBajaPersonal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBajaPersonal.Enabled = false;
            this.tsbBajaPersonal.Image = global::EscuelaSimple.InterfazDeUsuario.WinForms.Properties.Resources.delete;
            this.tsbBajaPersonal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBajaPersonal.Name = "tsbBajaPersonal";
            this.tsbBajaPersonal.Size = new System.Drawing.Size(23, 22);
            this.tsbBajaPersonal.Text = "Borrar";
            this.tsbBajaPersonal.Click += new System.EventHandler(this.tsbBajaPersonal_Click);
            // 
            // lvPersonal
            // 
            this.lvPersonal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chApellido,
            this.chNombre});
            this.lvPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPersonal.FullRowSelect = true;
            this.lvPersonal.GridLines = true;
            this.lvPersonal.Location = new System.Drawing.Point(0, 25);
            this.lvPersonal.MultiSelect = false;
            this.lvPersonal.Name = "lvPersonal";
            this.lvPersonal.ShowGroups = false;
            this.lvPersonal.Size = new System.Drawing.Size(484, 287);
            this.lvPersonal.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvPersonal.TabIndex = 1;
            this.lvPersonal.UseCompatibleStateImageBehavior = false;
            this.lvPersonal.View = System.Windows.Forms.View.Details;
            this.lvPersonal.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvPersonal_ItemSelectionChanged);
            // 
            // chApellido
            // 
            this.chApellido.Text = "Apellido";
            this.chApellido.Width = 100;
            // 
            // chNombre
            // 
            this.chNombre.Text = "Nombre";
            this.chNombre.Width = 100;
            // 
            // frmPersonalListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 312);
            this.Controls.Add(this.lvPersonal);
            this.Controls.Add(this.tsPersonal);
            this.Name = "frmPersonalListado";
            this.Text = "frmListadoPersonal";
            this.Load += new System.EventHandler(this.frmListadoPersonal_Load);
            this.tsPersonal.ResumeLayout(false);
            this.tsPersonal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPersonal;
        private System.Windows.Forms.ToolStripButton tsbFiltrarPersonal;
        private System.Windows.Forms.ToolStripButton tsbVerPersonal;
        private System.Windows.Forms.ToolStripButton tsbAltaPersonal;
        private System.Windows.Forms.ToolStripButton tsbModificarPersonal;
        private System.Windows.Forms.ToolStripButton tsbBajaPersonal;
        private System.Windows.Forms.ListView lvPersonal;
        private System.Windows.Forms.ColumnHeader chApellido;
        private System.Windows.Forms.ColumnHeader chNombre;
    }
}