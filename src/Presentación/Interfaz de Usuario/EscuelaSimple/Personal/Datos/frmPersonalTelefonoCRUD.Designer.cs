﻿namespace EscuelaSimple.InterfazDeUsuario.WinForms.Personal.Datos
{
    partial class frmPersonalTelefonoCRUD
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
            this.cboTipoTelefono = new System.Windows.Forms.ComboBox();
            this.mskNumero = new System.Windows.Forms.MaskedTextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.epMaskTelefono = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epMaskTelefono)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoTelefono
            // 
            this.cboTipoTelefono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTelefono.FormattingEnabled = true;
            this.cboTipoTelefono.Location = new System.Drawing.Point(12, 12);
            this.cboTipoTelefono.Name = "cboTipoTelefono";
            this.cboTipoTelefono.Size = new System.Drawing.Size(121, 21);
            this.cboTipoTelefono.TabIndex = 0;
            // 
            // mskNumero
            // 
            this.mskNumero.Location = new System.Drawing.Point(139, 13);
            this.mskNumero.Mask = "9999999999";
            this.mskNumero.Name = "mskNumero";
            this.mskNumero.Size = new System.Drawing.Size(145, 20);
            this.mskNumero.TabIndex = 1;
            this.mskNumero.Validating += new System.ComponentModel.CancelEventHandler(this.mskNumero_Validating);
            this.mskNumero.Validated += new System.EventHandler(this.mskNumero_Validated);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(144, 39);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(225, 39);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // epMaskTelefono
            // 
            this.epMaskTelefono.ContainerControl = this;
            // 
            // frmPersonalTelefonoCRUD
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(312, 74);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.mskNumero);
            this.Controls.Add(this.cboTipoTelefono);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonalTelefonoCRUD";
            this.Text = "frmPersonalTelefonoCRUD";
            this.Load += new System.EventHandler(this.frmPersonalTelefonoCRUD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epMaskTelefono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTipoTelefono;
        private System.Windows.Forms.MaskedTextBox mskNumero;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider epMaskTelefono;
    }
}