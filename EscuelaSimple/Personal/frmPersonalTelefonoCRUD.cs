using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EscuelaSimple.Negocio;

namespace EscuelaSimple.InterfazDeUsuario.Personal
{
    public partial class frmPersonalTelefonoCRUD : Form
    {
        #region Atributos

        private Entidad.Telefono _telefono;
        private TipoTelefonoNegocio _tipoTelefonoNegocio;

        #endregion

        #region Constructores

        public frmPersonalTelefonoCRUD()
        {
            InitializeComponent();
            this._telefono = new Entidad.Telefono();
            this._tipoTelefonoNegocio = new TipoTelefonoNegocio();
        }

        public frmPersonalTelefonoCRUD(Entidad.Telefono telefonoSelecionado)
            : this()
        {
            this._telefono = telefonoSelecionado;
            this.CargarTelefono();
        }

        #endregion

        #region Eventos del formulario

        private void frmPersonalTelefonoCRUD_Load(object sender, EventArgs e)
        {
            IEnumerable<Entidad.TipoTelefono> tiposTelefonos = this._tipoTelefonoNegocio.ObtenerTelefonoTipos();
            this.cboTipoTelefono.DataSource = tiposTelefonos;
            this.cboTipoTelefono.ValueMember = "Id";
            this.cboTipoTelefono.DisplayMember = "Descripcion";
        }

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool valido = this.ValidateChildren();
            if (valido)
            {
                this._telefono.Tipo = this.cboTipoTelefono.SelectedItem as Entidad.TipoTelefono;
                this._telefono.Numero = Convert.ToUInt32(this.mskNumero.Text);
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
            this.cboTipoTelefono.SelectedItem = this._telefono.Tipo.Id;
            this.mskNumero.Text = this._telefono.Numero.ToString();
        }

        private bool ValidarTelefono(string telefono, out string errorMessage)
        {
            if (this.mskNumero.Text.Trim().Length == 0)
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
