namespace EscuelaSimple.InterfazDeUsuario.Personal
{
    partial class frmPersonalFuncionCRUD
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
            this.components = new System.ComponentModel.Container();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cboTarea = new System.Windows.Forms.ComboBox();
            this.dtpTomaPosesion = new System.Windows.Forms.DateTimePicker();
            this.dtpCesePosesion = new System.Windows.Forms.DateTimePicker();
            this.cboSituacionRevista = new System.Windows.Forms.ComboBox();
            this.lblTarea = new System.Windows.Forms.Label();
            this.lblTomaPosesion = new System.Windows.Forms.Label();
            this.lblCesePosesion = new System.Windows.Forms.Label();
            this.lblSituacionRevista = new System.Windows.Forms.Label();
            this.rtbObservaciones = new System.Windows.Forms.RichTextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(325, 195);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(406, 195);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboTarea
            // 
            this.cboTarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarea.Location = new System.Drawing.Point(12, 25);
            this.cboTarea.Name = "cboTarea";
            this.cboTarea.Size = new System.Drawing.Size(121, 21);
            this.cboTarea.TabIndex = 2;
            // 
            // dtpTomaPosesion
            // 
            this.dtpTomaPosesion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpTomaPosesion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTomaPosesion.Location = new System.Drawing.Point(139, 26);
            this.dtpTomaPosesion.Name = "dtpTomaPosesion";
            this.dtpTomaPosesion.Size = new System.Drawing.Size(95, 20);
            this.dtpTomaPosesion.TabIndex = 3;
            this.dtpTomaPosesion.Validating += new System.ComponentModel.CancelEventHandler(this.dtpTomaPosesion_Validating);
            this.dtpTomaPosesion.Validated += new System.EventHandler(this.dtpTomaPosesion_Validated);
            // 
            // dtpCesePosesion
            // 
            this.dtpCesePosesion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpCesePosesion.Checked = false;
            this.dtpCesePosesion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCesePosesion.Location = new System.Drawing.Point(240, 26);
            this.dtpCesePosesion.Name = "dtpCesePosesion";
            this.dtpCesePosesion.ShowCheckBox = true;
            this.dtpCesePosesion.Size = new System.Drawing.Size(112, 20);
            this.dtpCesePosesion.TabIndex = 4;
            this.dtpCesePosesion.Validating += new System.ComponentModel.CancelEventHandler(this.dtpCesePosesion_Validating);
            this.dtpCesePosesion.Validated += new System.EventHandler(this.dtpCesePosesion_Validated);
            // 
            // cboSituacionRevista
            // 
            this.cboSituacionRevista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSituacionRevista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSituacionRevista.Location = new System.Drawing.Point(358, 25);
            this.cboSituacionRevista.Name = "cboSituacionRevista";
            this.cboSituacionRevista.Size = new System.Drawing.Size(123, 21);
            this.cboSituacionRevista.TabIndex = 5;
            // 
            // lblTarea
            // 
            this.lblTarea.AutoSize = true;
            this.lblTarea.CausesValidation = false;
            this.lblTarea.Location = new System.Drawing.Point(12, 9);
            this.lblTarea.Name = "lblTarea";
            this.lblTarea.Size = new System.Drawing.Size(45, 13);
            this.lblTarea.TabIndex = 6;
            this.lblTarea.Text = "Funcion";
            // 
            // lblTomaPosesion
            // 
            this.lblTomaPosesion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTomaPosesion.AutoSize = true;
            this.lblTomaPosesion.CausesValidation = false;
            this.lblTomaPosesion.Location = new System.Drawing.Point(136, 9);
            this.lblTomaPosesion.Name = "lblTomaPosesion";
            this.lblTomaPosesion.Size = new System.Drawing.Size(34, 13);
            this.lblTomaPosesion.TabIndex = 7;
            this.lblTomaPosesion.Text = "Toma";
            // 
            // lblCesePosesion
            // 
            this.lblCesePosesion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCesePosesion.AutoSize = true;
            this.lblCesePosesion.CausesValidation = false;
            this.lblCesePosesion.Location = new System.Drawing.Point(237, 9);
            this.lblCesePosesion.Name = "lblCesePosesion";
            this.lblCesePosesion.Size = new System.Drawing.Size(31, 13);
            this.lblCesePosesion.TabIndex = 8;
            this.lblCesePosesion.Text = "Cese";
            // 
            // lblSituacionRevista
            // 
            this.lblSituacionRevista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSituacionRevista.AutoSize = true;
            this.lblSituacionRevista.CausesValidation = false;
            this.lblSituacionRevista.Location = new System.Drawing.Point(355, 9);
            this.lblSituacionRevista.Name = "lblSituacionRevista";
            this.lblSituacionRevista.Size = new System.Drawing.Size(105, 13);
            this.lblSituacionRevista.TabIndex = 9;
            this.lblSituacionRevista.Text = "Situacion de Revista";
            // 
            // rtbObservaciones
            // 
            this.rtbObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbObservaciones.Location = new System.Drawing.Point(12, 65);
            this.rtbObservaciones.Name = "rtbObservaciones";
            this.rtbObservaciones.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbObservaciones.Size = new System.Drawing.Size(469, 124);
            this.rtbObservaciones.TabIndex = 10;
            this.rtbObservaciones.Text = "";
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.CausesValidation = false;
            this.lblObservaciones.Location = new System.Drawing.Point(12, 49);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(78, 13);
            this.lblObservaciones.TabIndex = 11;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmPersonalFuncionCRUD
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(493, 230);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.rtbObservaciones);
            this.Controls.Add(this.lblSituacionRevista);
            this.Controls.Add(this.lblCesePosesion);
            this.Controls.Add(this.lblTomaPosesion);
            this.Controls.Add(this.lblTarea);
            this.Controls.Add(this.cboSituacionRevista);
            this.Controls.Add(this.dtpCesePosesion);
            this.Controls.Add(this.dtpTomaPosesion);
            this.Controls.Add(this.cboTarea);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonalFuncionCRUD";
            this.Text = "frmPersonalFuncionCRUD";
            this.Load += new System.EventHandler(this.frmPersonalFuncionCRUD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cboTarea;
        private System.Windows.Forms.DateTimePicker dtpTomaPosesion;
        private System.Windows.Forms.DateTimePicker dtpCesePosesion;
        private System.Windows.Forms.ComboBox cboSituacionRevista;
        private System.Windows.Forms.Label lblTarea;
        private System.Windows.Forms.Label lblTomaPosesion;
        private System.Windows.Forms.Label lblCesePosesion;
        private System.Windows.Forms.Label lblSituacionRevista;
        private System.Windows.Forms.RichTextBox rtbObservaciones;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}