using EscuelaSimple.Aplicacion.Componentes.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.WinForms.Personal.Datos
{
    public partial class frmPersonalTelefonoCRUD : Form
    {
        #region Atributos

        private EscuelaSimple.Aplicacion.Entidades.Telefono _telefono;
        private TipoTelefonoNegocio _tipoTelefonoNegocio;

        #endregion

        #region Constructores

        public frmPersonalTelefonoCRUD()
        {
            InitializeComponent();
            this._telefono = new EscuelaSimple.Aplicacion.Entidades.Telefono();
            this._tipoTelefonoNegocio = new TipoTelefonoNegocio();
        }

        public frmPersonalTelefonoCRUD(EscuelaSimple.Aplicacion.Entidades.Telefono telefonoSelecionado)
            : this()
        {
            this._telefono = telefonoSelecionado;
            this.CargarTelefono();
        }

        #endregion

        #region Eventos del formulario

        private void frmPersonalTelefonoCRUD_Load(object sender, EventArgs e)
        {
            IEnumerable<EscuelaSimple.Aplicacion.Entidades.TipoTelefono> tiposTelefonos = this._tipoTelefonoNegocio.ObtenerTelefonoTipos();
            this.cboTipoTelefono.DataSource = tiposTelefonos;
            this.cboTipoTelefono.ValueMember = "Id";
            this.cboTipoTelefono.DisplayMember = "Descripcion";
        }

        #region Validaciones

        private void mskNumero_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage;
            if (!this.ValidarTelefono(this.mskNumero.Text, out errorMessage))
            {
                e.Cancel = true;
                this.mskNumero.Select(0, this.mskNumero.Text.Length);
                this.epMaskTelefono.SetError(this.mskNumero, errorMessage);
            }
        }

        private void mskNumero_Validated(object sender, EventArgs e)
        {
            this.epMaskTelefono.SetError(this.mskNumero, string.Empty);
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool valido = this.ValidateChildren();
            if (valido)
            {
                this._telefono.Tipo = this.cboTipoTelefono.SelectedItem as EscuelaSimple.Aplicacion.Entidades.TipoTelefono;
                this._telefono.Numero = Convert.ToInt32(this.mskNumero.Text);
                this.Tag = this._telefono;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Validate(false);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Metodos privados

        private void CargarTelefono()
        {
            this.cboTipoTelefono.SelectedItem = this._telefono.Tipo.Identificador;
            this.mskNumero.Text = this._telefono.Numero.ToString();
        }

        private bool ValidarTelefono(string telefono, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(telefono))
            {
                errorMessage = "No se ingreso ningun telefono.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        #endregion
    }
}