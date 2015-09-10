using EscuelaSimple.Aplicacion.Entidades;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.WinForms.Personal.Inasistencias
{
    public partial class frmPersonalInasistenciaCRUD : Form
    {
        #region Atributos

        private Inasistencia _inasistencia;

        #endregion

        #region Costructores

        public frmPersonalInasistenciaCRUD()
        {
            InitializeComponent();
            _inasistencia = new Inasistencia();
        }

        public frmPersonalInasistenciaCRUD(Inasistencia inasistencia)
            : this()
        {
            _inasistencia = inasistencia;
            CargarInasistencia();
        }

        #endregion

        #region Eventos del formulario

        private void txtArticulo_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidarMotivo(this.txtArticulo.Text, out errorMsg))
            {
                e.Cancel = true;
                txtArticulo.Select(0, this.txtArticulo.Text.Length);
                epMotivo.SetIconPadding(this.txtArticulo, 5);
                epMotivo.SetError(this.txtArticulo, errorMsg);
            }
        }

        private void txtArticulo_Validated(object sender, EventArgs e)
        {
            epMotivo.SetError(txtArticulo, string.Empty);
        }

        private void dtpDesde_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidarRangoDeFechas(dtpDesde.Value, dtpHasta.Value, out errorMsg))
            {
                e.Cancel = true;
                dtpDesde.Select();
                epFecha.SetIconPadding(dtpDesde, 5);
                epFecha.SetError(dtpDesde, errorMsg);
            }
        }

        private void dtpDesde_Validated(object sender, EventArgs e)
        {
            epFecha.SetError(dtpDesde, string.Empty);
        }

        private void dtpHasta_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidarRangoDeFechas(dtpDesde.Value, dtpHasta.Value, out errorMsg))
            {
                e.Cancel = true;
                dtpHasta.Select();
                epFecha.SetIconPadding(dtpHasta, 5);
                epFecha.SetError(dtpHasta, errorMsg);
            }
        }

        private void dtpHasta_Validated(object sender, EventArgs e)
        {
            epFecha.SetError(dtpHasta, string.Empty);
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            dtpDesde.Format = DateTimePickerFormat.Short;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            dtpHasta.Format = DateTimePickerFormat.Short;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool valido = ValidateChildren();
            if (valido)
            {
                _inasistencia.Motivo = txtArticulo.Text.Trim();
                _inasistencia.Desde = dtpDesde.Value;
                _inasistencia.Hasta = dtpHasta.Value;
                Tag = _inasistencia;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Metodos privados

        private void CargarInasistencia()
        {
            txtArticulo.Text = _inasistencia.Motivo;
            dtpDesde.Value = _inasistencia.Desde;
            dtpHasta.Value = _inasistencia.Hasta;
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
