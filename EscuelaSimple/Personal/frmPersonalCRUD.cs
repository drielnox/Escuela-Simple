using EscuelaSimple.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.Personal
{
    public partial class frmPersonalCRUD : Form
    {
        #region Delegados y Eventos
        private event RealizarPersistenciaMetodo PersistirEvento;
        private delegate void RealizarPersistenciaMetodo(Modelos.Personal persona);

        #endregion

        #region Atributos

        private ModoFormulario _modo;
        private Modelos.Personal _personal;
        private PersonalNegocio _negocioPersonal;

        #endregion

        #region Constructores

        public frmPersonalCRUD(ModoFormulario modo)
        {
            InitializeComponent();
            this._modo = modo;
            this._negocioPersonal = new PersonalNegocio();
        }

        public frmPersonalCRUD(ModoFormulario modo, Modelos.Personal personal)
            : this(modo)
        {
            this._personal = personal;
            this.CargarPersonal();
        }

        #endregion

        #region Eventos del formulario

        private void frmPersonalCRUD_Load(object sender, EventArgs e)
        {
            this.EstablecerModoFormulario();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool valido = this.ValidateChildren();
            if (valido)
            {
                Modelos.Personal personalAGuardar = this.ObtenerPersonal();
                if (this.PersistirEvento != null)
                {
                    this.PersistirEvento(personalAGuardar);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Validate(false);
            this.DialogResult = DialogResult.Cancel;
        }

        private void tsbAltaTelefono_Click(object sender, EventArgs e)
        {
            frmPersonalTelefonoCRUD frm = new frmPersonalTelefonoCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Modelos.Telefono telefonoNuevo = frm.Tag as Modelos.Telefono;
                this.CargarGrillaConTelefono(telefonoNuevo);
            }
        }

        private void tsbModificacionTelefono_Click(object sender, EventArgs e)
        {
            Modelos.Telefono telefonoSelecionado = this.lvTelefonos.SelectedItems[0].Tag as Modelos.Telefono;
            frmPersonalTelefonoCRUD frm = new frmPersonalTelefonoCRUD(telefonoSelecionado);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Modelos.Telefono telefonoModificado = frm.Tag as Modelos.Telefono;
                this.CargarGrillaConTelefono(telefonoModificado);
            }
        }

        private void tsbBajaTelefono_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este telefono?", "Borrar telefono", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                ListViewItem itemSeleccionado = this.lvTelefonos.SelectedItems[0];
                this.lvTelefonos.Items.Remove(itemSeleccionado);
            }
        }

        private void tsbAltaInasistencia_Click(object sender, EventArgs e)
        {
            frmPersonalInasistenciaCRUD frm = new frmPersonalInasistenciaCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Modelos.Inasistencia inasistenciaNueva = frm.Tag as Modelos.Inasistencia;
                this.CargarGrillaConInasistencia(inasistenciaNueva);
            }
        }

        private void tsbModificacionInasistencia_Click(object sender, EventArgs e)
        {
            Modelos.Inasistencia inasistenciaSeleccionada = this.lvInasistencia.SelectedItems[0].Tag as Modelos.Inasistencia;
            frmPersonalInasistenciaCRUD frm = new frmPersonalInasistenciaCRUD(inasistenciaSeleccionada);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Modelos.Inasistencia inasistenciaModificada = frm.Tag as Modelos.Inasistencia;
                this.CargarGrillaConInasistencia(inasistenciaModificada);
            }
        }

        private void tsbBajaInasistencia_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar esta inasistencia?", "Borrar inasistencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                ListViewItem itemSeleccionado = this.lvInasistencia.SelectedItems[0];
                this.lvInasistencia.Items.Remove(itemSeleccionado);
            }
        }

        #region Validaciones

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.txtNombre, "El contenido no es valido.");
            }
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            this.errorProvider.SetError(this.txtNombre, string.Empty);
        }

        private void txtApellido_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtApellido.Text))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.txtApellido, "El contenido no es valido.");
            }
        }

        private void txtApellido_Validated(object sender, EventArgs e)
        {
            this.errorProvider.SetError(this.txtApellido, string.Empty);
        }

        private void dtpIngresoDocencia_Validating(object sender, CancelEventArgs e)
        {
            if (this.dtpIngresoDocencia.Value <= this.dtpFechaNacimiento.Value)
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.dtpIngresoDocencia, "La fecha de ingreso a la docencia no puede ser menor o igual a fecha de nacimiento.");
            }
        }

        private void dtpIngresoDocencia_Validated(object sender, EventArgs e)
        {
            this.errorProvider.SetError(this.dtpIngresoDocencia, string.Empty);
        }

        private void dtpIngresoEstablecimiento_Validating(object sender, CancelEventArgs e)
        {
            if (this.dtpIngresoEstablecimiento.Value <= this.dtpFechaNacimiento.Value || this.dtpIngresoEstablecimiento.Value < this.dtpIngresoDocencia.Value)
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.dtpIngresoEstablecimiento, "La fecha de ingreso al establecimiento no puede ser menor a la fecha de nacimiento o la fecha de ingreso a la docencia.");
            }
        }

        private void dtpIngresoEstablecimiento_Validated(object sender, EventArgs e)
        {
            this.errorProvider.SetError(this.dtpIngresoEstablecimiento, string.Empty);
        }

        #endregion

        private void lvTelefonos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.tsbModificacionTelefono.Enabled = e.IsSelected;
            this.tsbBajaTelefono.Enabled = e.IsSelected;
        }

        private void lvInasistencia_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.tsbModificacionInasistencia.Enabled = e.IsSelected;
            this.tsbBajaInasistencia.Enabled = e.IsSelected;
        }

        #endregion

        #region Metodos Privados

        private void EstablecerModoFormulario()
        {
            switch (this._modo)
            {
                case ModoFormulario.Ver:
                    this.EstadoControl(this, false);
                    break;
                case ModoFormulario.Crear:
                    this.EstadoControl(this, true);
                    this.PersistirEvento += this._negocioPersonal.GuardarPersonal;
                    break;
                case ModoFormulario.Modificar:
                    this.EstadoControl(this, true);
                    this.PersistirEvento += this._negocioPersonal.ActualizarPersonal;
                    break;
            }
        }

        private void EstadoControl(Control control, bool estado)
        {
            if (control.HasChildren)
            {
                foreach (Control item in control.Controls)
                {
                    this.EstadoControl(item, estado);
                }
            }

            if (control is Form)
            {
                return;
            }

            if (control is Button)
            {
                return;
            }

            if (control is TabControl)
            {
                return;
            }

            if (control is TabPage)
            {
                return;
            }

            control.Enabled = estado;
        }

        private void CargarPersonal()
        {
            this.txtNombre.Text = this._personal.Nombre;
            this.txtApellido.Text = this._personal.Apellido;
            this.mskDNI.Text = this._personal.DNI.ToString();
            this.dtpFechaNacimiento.Value = this._personal.FechaNacimiento;
            this.txtDomicilio.Text = this._personal.Domicilio;
            this.txtLocalidad.Text = this._personal.Localidad;
            this.CargarGrillaConTelefonos(this._personal.Telefonos);

            //this.txtTitulo.Text = this._personal.Titulo;
            //this.txtCargo.Text = this._personal.Cargo;
            //this.txtSituacionRevista.Text = this._personal.SituacionRevista;
            this.dtpIngresoDocencia.Value = this._personal.IngresoDocencia.GetValueOrDefault(DateTime.Now);
            this.dtpIngresoEstablecimiento.Value = this._personal.IngresoEstablecimiento.GetValueOrDefault(DateTime.Now);
            this.rtbObservacion.Text = this._personal.Observacion;

            this.CargarGrillaConInasistencias(this._personal.Inasistencias);
        }

        private void BorrarTelefonoEnGrilla(Modelos.Telefono telefono)
        {
            ListViewItem item = this.lvTelefonos.Items.Cast<ListViewItem>().Where(x =>
            {
                var unTelefono = x.Tag as Modelos.Telefono;
                return unTelefono.Equals(telefono);
            }).SingleOrDefault();
            this.lvTelefonos.Items.Remove(item);
        }

        private void CargarGrillaConTelefono(Modelos.Telefono telefono)
        {
            BorrarTelefonoEnGrilla(telefono);

            ListViewItem fila = new ListViewItem(new string[] { telefono.Tipo.Descripcion, telefono.Numero.ToString() });
            fila.Tag = telefono;
            this.lvTelefonos.Items.Add(fila);
        }

        private void BorrarInasistenciaEnGrilla(Modelos.Inasistencia inasistencia)
        {
            ListViewItem item = this.lvInasistencia.Items.Cast<ListViewItem>().Where(x =>
            {
                var unaInasistencia = x.Tag as Modelos.Inasistencia;
                return unaInasistencia.Equals(inasistencia);
            }).SingleOrDefault();
            this.lvInasistencia.Items.Remove(item);
        }

        private void CargarGrillaConInasistencia(Modelos.Inasistencia inasistencia)
        {
            BorrarInasistenciaEnGrilla(inasistencia);

            int cantDias = inasistencia.Hasta.Subtract(inasistencia.Desde).Days;
            ListViewItem fila = new ListViewItem(new string[] { inasistencia.Motivo, inasistencia.Desde.ToShortDateString(), inasistencia.Hasta.ToShortDateString(), cantDias.ToString() });
            fila.Tag = inasistencia;
            this.lvInasistencia.Items.Add(fila);
        }

        private void CargarGrillaConTelefonos(IEnumerable<Modelos.Telefono> telefonos)
        {
            this.lvTelefonos.Items.Clear();
            foreach (Modelos.Telefono item in telefonos)
            {
                this.CargarGrillaConTelefono(item);
            }
            this.lvTelefonos.Refresh();
        }

        private void CargarGrillaConInasistencias(IEnumerable<Modelos.Inasistencia> inasistencias)
        {
            this.lvInasistencia.Items.Clear();
            foreach (Modelos.Inasistencia item in inasistencias)
            {
                this.CargarGrillaConInasistencia(item);
            }
            this.lvInasistencia.Refresh();
        }

        private IEnumerable<Modelos.Telefono> ObtenerTelefonosDelPersonal()
        {
            List<Modelos.Telefono> telefonosRegistrados = new List<Modelos.Telefono>();
            foreach (ListViewItem fila in this.lvTelefonos.Items)
            {
                Modelos.Telefono telefono = fila.Tag as Modelos.Telefono;
                telefonosRegistrados.Add(telefono);
            }
            return telefonosRegistrados;
        }

        private IEnumerable<Modelos.Inasistencia> ObtenerInasistenciasDelPersonal()
        {
            List<Modelos.Inasistencia> inasistenciasRegistradas = new List<Modelos.Inasistencia>();
            foreach (ListViewItem fila in this.lvInasistencia.Items)
            {
                Modelos.Inasistencia inasistencia = fila.Tag as Modelos.Inasistencia;
                inasistenciasRegistradas.Add(inasistencia);
            }
            return inasistenciasRegistradas;
        }

        private Modelos.Personal ObtenerPersonal()
        {
            Modelos.Personal nuevoPersonal = this._personal ?? new Modelos.Personal();
            nuevoPersonal.Apellido = this.txtApellido.Text.Trim();
            //nuevoPersonal.Cargo = this.txtCargo.Text.Trim();
            nuevoPersonal.DNI = Convert.ToInt32(this.mskDNI.Text.Trim());
            nuevoPersonal.Domicilio = this.txtDomicilio.Text.Trim();
            nuevoPersonal.FechaNacimiento = this.dtpFechaNacimiento.Value;
            ((List<Modelos.Inasistencia>)this.ObtenerInasistenciasDelPersonal()).ForEach(x => nuevoPersonal.AgregarInasistencia(x));
            nuevoPersonal.IngresoDocencia = this.dtpIngresoDocencia.Value;
            nuevoPersonal.IngresoEstablecimiento = this.dtpIngresoEstablecimiento.Value;
            nuevoPersonal.Localidad = this.txtLocalidad.Text.Trim();
            nuevoPersonal.Nombre = this.txtNombre.Text.Trim();
            nuevoPersonal.Observacion = this.rtbObservacion.Text.Trim();
            //nuevoPersonal.SituacionRevista = this.txtSituacionRevista.Text.Trim();
            ((List<Modelos.Telefono>)this.ObtenerTelefonosDelPersonal()).ForEach(x => nuevoPersonal.AgregarTelefono(x));
            //nuevoPersonal.Titulo = this.txtTitulo.Text.Trim();

            return nuevoPersonal;
        }

        #endregion
    }
}
