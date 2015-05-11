using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.Personal
{
    public partial class frmPersonalTituloCRUD : Form
    {
        #region Atributos

        private Modelos.Titulo _titulo;

        #endregion

        #region Constructores

        public frmPersonalTituloCRUD()
        {
            InitializeComponent();
            this._titulo = new Modelos.Titulo();
        }

        public frmPersonalTituloCRUD(Modelos.Titulo tituloSeleccionado)
            : this()
        {
            this._titulo = tituloSeleccionado;
            this.CargarTitulo();
        }

        #endregion

        #region Eventos del formulario

        private void frmPersonalTituloCRUD_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool valido = this.ValidateChildren();
            if (valido)
            {
                this._titulo.Descripcion = this.txtTitulo.Text;
                this.Tag = this._titulo;
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

        #region Validaciones

        private void txtTitulo_Validating(object sender, CancelEventArgs e)
        {
            string mensajeError;
            if (!this.ValidarTitulo(this.txtTitulo.Text, out mensajeError))
            {
                e.Cancel = true;
                this.txtTitulo.Select(0, this.txtTitulo.Text.Length);
                this.errorProvider.SetError(this.txtTitulo, mensajeError);
            }
        }

        private void txtTitulo_Validated(object sender, EventArgs e)
        {
            this.errorProvider.SetError(this.txtTitulo, string.Empty);
        }

        #endregion

        #endregion

        #region Meotods privados

        private void CargarTitulo()
        {
            this.txtTitulo.Text = this._titulo.Descripcion;
        }

        private bool ValidarTitulo(string titulo, out string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                mensajeError = "El titulo no puede estar vacio.";
                return false;
            }

            mensajeError = string.Empty;
            return true;
        }

        #endregion
    }
}
