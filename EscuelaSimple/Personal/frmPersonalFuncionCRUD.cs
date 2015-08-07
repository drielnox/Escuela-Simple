using EscuelaSimple.Aplicacion.Componentes.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.WinForms.Personal
{
    public partial class frmPersonalFuncionCRUD : Form
    {
        #region Atributos

        private EscuelaSimple.Aplicacion.Entidades.Funcion _funcion;
        private TareaNegocio _negocioTarea;
        private SituacionRevistaNegocio _negocioSituacionRevista;

        #endregion

        #region Constructores

        public frmPersonalFuncionCRUD()
        {
            InitializeComponent();
            this._funcion = new EscuelaSimple.Aplicacion.Entidades.Funcion();
            this._negocioTarea = new TareaNegocio();
            this._negocioSituacionRevista = new SituacionRevistaNegocio();
        }

        public frmPersonalFuncionCRUD(EscuelaSimple.Aplicacion.Entidades.Funcion funcion)
            : this()
        {
            this._funcion = funcion;
            this.CargarFuncion();
        }

        #endregion

        #region Eventos del formulario

        private void frmPersonalFuncionCRUD_Load(object sender, EventArgs e)
        {
            this.CargarComboTarea();
            this.CargarComboSituacionRevista();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool valido = this.ValidateChildren();
            if (valido)
            {
                this._funcion.Tarea = this.cboTarea.SelectedItem as EscuelaSimple.Aplicacion.Entidades.Tarea;
                this._funcion.TomaDePosesion = this.dtpTomaPosesion.Value;
                if (this.dtpCesePosesion.Checked)
                {
                    this._funcion.CeseDePosesion = this.dtpCesePosesion.Value;
                }
                this._funcion.SituacionDeRevista = this.cboSituacionRevista.SelectedItem as EscuelaSimple.Aplicacion.Entidades.SituacionRevista;
                this._funcion.Observacion = this.rtbObservaciones.Text;
                this.Tag = this._funcion;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Validate(false);
            this.Close();
        }

        #region Validaciones

        private void dtpTomaPosesion_Validating(object sender, CancelEventArgs e)
        {
            string errorMensaje;
            if (!this.ValidarFechas(this.dtpTomaPosesion.Value, this.dtpCesePosesion.Value, out errorMensaje))
            {
                e.Cancel = true;
                this.dtpTomaPosesion.Select();
                this.errorProvider.SetError(this.dtpTomaPosesion, errorMensaje);
            }
        }

        private void dtpTomaPosesion_Validated(object sender, EventArgs e)
        {
            this.errorProvider.SetError(this.dtpTomaPosesion, string.Empty);
        }

        private void dtpCesePosesion_Validating(object sender, CancelEventArgs e)
        {
            string errorMensaje;
            if (!this.ValidarFechas(this.dtpTomaPosesion.Value, this.dtpCesePosesion.Value, out errorMensaje))
            {
                e.Cancel = true;
                this.dtpCesePosesion.Select();
                this.errorProvider.SetError(this.dtpCesePosesion, errorMensaje);
            }
        }

        private void dtpCesePosesion_Validated(object sender, EventArgs e)
        {
            this.errorProvider.SetError(this.dtpCesePosesion, string.Empty);
        }

        #endregion

        #endregion

        #region Metodos Privados

        private void CargarComboTarea()
        {
            IEnumerable<EscuelaSimple.Aplicacion.Entidades.Tarea> tareas = this._negocioTarea.ObtenerTareas();
            this.cboTarea.DataSource = tareas;
            this.cboTarea.ValueMember = "Identificador";
            this.cboTarea.DisplayMember = "Descripcion";
        }

        private void CargarComboSituacionRevista()
        {
            IEnumerable<EscuelaSimple.Aplicacion.Entidades.SituacionRevista> sitRevista = this._negocioSituacionRevista.ObtenerSituacionesRevista();
            this.cboSituacionRevista.DataSource = sitRevista;
            this.cboSituacionRevista.ValueMember = "Identificador";
            this.cboSituacionRevista.DisplayMember = "Descripcion";
        }

        private void CargarFuncion()
        {
            this.cboTarea.SelectedItem = this._funcion.Tarea.Identificador;
            this.dtpTomaPosesion.Value = this._funcion.TomaDePosesion;
            if (this._funcion.CeseDePosesion.HasValue)
            {
                this.dtpCesePosesion.Checked = true;
                this.dtpCesePosesion.Value = this._funcion.CeseDePosesion.Value;
            }
            this.cboSituacionRevista.SelectedItem = this._funcion.SituacionDeRevista.Identificador;
            this.rtbObservaciones.Text = this._funcion.Observacion;
        }

        private bool ValidarFechas(DateTime toma, DateTime cese, out string errorMensaje)
        {
            if (toma >= cese)
            {
                errorMensaje = "La fecha de cese no peude ser mayor que la fecha de toma.";
                return false;
            }

            errorMensaje = string.Empty;
            return true;
        }

        #endregion
    }
}
