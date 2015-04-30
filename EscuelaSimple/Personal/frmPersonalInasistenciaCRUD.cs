using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.Personal
{
    public partial class frmPersonalInasistenciaCRUD : Form
    {
        #region Atributos

        private Modelos.Inasistencia _inasistencia;

        #endregion

        #region Costructores

        public frmPersonalInasistenciaCRUD()
        {
            InitializeComponent();
            this._inasistencia = new Modelos.Inasistencia();
        }

        public frmPersonalInasistenciaCRUD(Modelos.Inasistencia inasistencia)
            : this()
        {
            this._inasistencia = inasistencia;
            this.CargarInasistencia();
        }

        #endregion

        #region Eventos del formulario

        private void txtArticulo_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!this.ValidarMotivo(this.txtArticulo.Text, out errorMsg))
            {
                e.Cancel = true;
                this.txtArticulo.Select(0, this.txtArticulo.Text.Length);
                this.epMotivo.SetIconPadding(this.txtArticulo, 5);
                this.epMotivo.SetError(this.txtArticulo, errorMsg);
            }
        }

        private void txtArticulo_Validated(object sender, EventArgs e)
        {
            this.epMotivo.SetError(this.txtArticulo, string.Empty);
        }

        private void dtpDesde_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!this.ValidarRangoDeFechas(this.dtpDesde.Value, this.dtpHasta.Value, out errorMsg))
            {
                e.Cancel = true;
                this.dtpDesde.Select();
                this.epFecha.SetIconPadding(this.dtpDesde, 5);
                this.epFecha.SetError(this.dtpDesde, errorMsg);
            }
        }

        private void dtpDesde_Validated(object sender, EventArgs e)
        {
            this.epFecha.SetError(this.dtpDesde, string.Empty);
        }

        private void dtpHasta_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!this.ValidarRangoDeFechas(this.dtpDesde.Value, this.dtpHasta.Value, out errorMsg))
            {
                e.Cancel = true;
                this.dtpHasta.Select();
                this.epFecha.SetIconPadding(this.dtpHasta, 5);
                this.epFecha.SetError(this.dtpHasta, errorMsg);
            }
        }

        private void dtpHasta_Validated(object sender, EventArgs e)
        {
            this.epFecha.SetError(this.dtpHasta, string.Empty);
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            this.dtpDesde.Format = DateTimePickerFormat.Short;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            this.dtpHasta.Format = DateTimePickerFormat.Short;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool valido = this.ValidateChildren();
            if (valido)
            {
                this._inasistencia.Motivo = this.txtArticulo.Text.Trim();
                this._inasistencia.Desde = this.dtpDesde.Value;
                this._inasistencia.Hasta = this.dtpHasta.Value;
                this.Tag = this._inasistencia;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Metodos privados

        private void CargarInasistencia()
        {
            this.txtArticulo.Text = this._inasistencia.Motivo;
            this.dtpDesde.Value = this._inasistencia.Desde;
            this.dtpHasta.Value = this._inasistencia.Hasta;
        }

        private bool ValidarRangoDeFechas(DateTime desde, DateTime hasta, out string errorMessage)
        {
            if (desde > hasta)
            {
                errorMessage = "La fecha de inicio no puede ser mayor a la fecha de fin.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        private bool ValidarMotivo(string motivo, out string errorMsg)
        {
            if (string.IsNullOrWhiteSpace(motivo))
            {
                errorMsg = "El motivo no puede ser vacio.";
                return false;
            }

            errorMsg = string.Empty;
            return true;
        }

        #endregion
    }
}
