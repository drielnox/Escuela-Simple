using EscuelaSimple.Aplicacion.Componentes.Negocio;
using EscuelaSimple.InterfazDeUsuario.WinForms.Personal.Inasistencias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.WinForms.Personal.Datos
{
    public partial class frmPersonalCRUD : Form
    {
        #region Delegados y Eventos

        private event RealizarPersistenciaMetodo PersistirEvento;
        private delegate void RealizarPersistenciaMetodo(Aplicacion.Entidades.Personal persona);

        #endregion

        #region Atributos

        private ModoFormulario _modo;
        private Aplicacion.Entidades.Personal _personal;
        private PersonalNegocio _negocioPersonal;

        #endregion

        #region Constructores

        public frmPersonalCRUD(ModoFormulario modo)
        {
            InitializeComponent();
            _modo = modo;
            _negocioPersonal = new PersonalNegocio();
        }

        public frmPersonalCRUD(ModoFormulario modo, Aplicacion.Entidades.Personal personal)
            : this(modo)
        {
            _personal = personal;
            CargarPersonal();
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
                EscuelaSimple.Aplicacion.Entidades.Personal personalAGuardar = this.ObtenerPersonal();
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
                EscuelaSimple.Aplicacion.Entidades.Telefono telefonoNuevo = frm.Tag as EscuelaSimple.Aplicacion.Entidades.Telefono;
                this.CargarGrillaConTelefono(telefonoNuevo);
            }
        }

        private void tsbModificacionTelefono_Click(object sender, EventArgs e)
        {
            EscuelaSimple.Aplicacion.Entidades.Telefono telefonoSelecionado = this.lvTelefonos.SelectedItems[0].Tag as EscuelaSimple.Aplicacion.Entidades.Telefono;
            frmPersonalTelefonoCRUD frm = new frmPersonalTelefonoCRUD(telefonoSelecionado);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                EscuelaSimple.Aplicacion.Entidades.Telefono telefonoModificado = frm.Tag as EscuelaSimple.Aplicacion.Entidades.Telefono;
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
                Aplicacion.Entidades.Inasistencia inasistenciaNueva = frm.Tag as Aplicacion.Entidades.Inasistencia;
                CargarGrillaConInasistencia(inasistenciaNueva);
            }
        }

        private void tsbModificacionInasistencia_Click(object sender, EventArgs e)
        {
            Aplicacion.Entidades.Inasistencia inasistenciaSeleccionada = lvInasistencia.SelectedItems[0].Tag as Aplicacion.Entidades.Inasistencia;
            frmPersonalInasistenciaCRUD frm = new frmPersonalInasistenciaCRUD(inasistenciaSeleccionada);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Aplicacion.Entidades.Inasistencia inasistenciaModificada = frm.Tag as Aplicacion.Entidades.Inasistencia;
                CargarGrillaConInasistencia(inasistenciaModificada);
            }
        }

        private void tsbBajaInasistencia_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar esta inasistencia?", "Borrar inasistencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                ListViewItem itemSeleccionado = this.lvInasistencia.SelectedItems[0];
                lvInasistencia.Items.Remove(itemSeleccionado);
            }
        }

        private void tsbAltaTitulo_Click(object sender, EventArgs e)
        {
            frmPersonalTituloCRUD frm = new frmPersonalTituloCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                EscuelaSimple.Aplicacion.Entidades.Titulo tituloNuevo = frm.Tag as EscuelaSimple.Aplicacion.Entidades.Titulo;
                this.CargarGrillaConTitulo(tituloNuevo);
            }
        }

        private void tsbModificacionTitulo_Click(object sender, EventArgs e)
        {
            EscuelaSimple.Aplicacion.Entidades.Titulo tituloSeleccionado = this.lvTitulos.SelectedItems[0].Tag as EscuelaSimple.Aplicacion.Entidades.Titulo;
            frmPersonalTituloCRUD frm = new frmPersonalTituloCRUD(tituloSeleccionado);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                EscuelaSimple.Aplicacion.Entidades.Titulo tituloModificado = frm.Tag as EscuelaSimple.Aplicacion.Entidades.Titulo;
                this.CargarGrillaConTitulo(tituloModificado);
            }
        }

        private void tsbBajaTitulo_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este titulo?", "Borrar titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                ListViewItem itemSeleccionado = this.lvTitulos.SelectedItems[0];
                this.lvTitulos.Items.Remove(itemSeleccionado);
            }
        }

        private void btnAltaCargo_Click(object sender, EventArgs e)
        {
            EscuelaSimple.Aplicacion.Entidades.Cargo cargoNuevo = new EscuelaSimple.Aplicacion.Entidades.Cargo();
            this.CargarComboConCargo(cargoNuevo);
        }

        private void btnBajaCargo_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este cargo?", "Borrar cargo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                EscuelaSimple.Aplicacion.Entidades.Cargo cargoSeleccionado = this.cboCargo.SelectedItem as EscuelaSimple.Aplicacion.Entidades.Cargo;
                this.cboCargo.Items.Remove(cargoSeleccionado);
            }
        }

        private void tsbAltaFuncion_Click(object sender, EventArgs e)
        {
            frmPersonalFuncionCRUD frm = new frmPersonalFuncionCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                EscuelaSimple.Aplicacion.Entidades.Funcion funcionNueva = frm.Tag as EscuelaSimple.Aplicacion.Entidades.Funcion;
                this.CargarGrillaConFuncion(funcionNueva);
            }
        }

        private void tsbModificacionFuncion_Click(object sender, EventArgs e)
        {
            EscuelaSimple.Aplicacion.Entidades.Funcion funcionSeleccionada = this.lvFunciones.SelectedItems[0].Tag as EscuelaSimple.Aplicacion.Entidades.Funcion;
            frmPersonalFuncionCRUD frm = new frmPersonalFuncionCRUD(funcionSeleccionada);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                EscuelaSimple.Aplicacion.Entidades.Funcion funcionModificada = frm.Tag as EscuelaSimple.Aplicacion.Entidades.Funcion;
                this.CargarGrillaConFuncion(funcionModificada);
            }
        }

        private void tsbBajaFuncion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar esta funcion?", "Borrar funcion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                ListViewItem itemSeleccionado = this.lvFunciones.SelectedItems[0];
                this.lvFunciones.Items.Remove(itemSeleccionado);
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
            tsbModificacionInasistencia.Enabled = e.IsSelected;
            tsbBajaInasistencia.Enabled = e.IsSelected;
        }

        private void lvTitulos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.tsbModificacionTitulo.Enabled = e.IsSelected;
            this.tsbBajaTitulo.Enabled = e.IsSelected;
        }

        private void cboCargo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EscuelaSimple.Aplicacion.Entidades.Cargo cargoSeleccionado = this.cboCargo.SelectedItem as EscuelaSimple.Aplicacion.Entidades.Cargo;
            this.CargarGrillaConFunciones(cargoSeleccionado.Funciones);
        }

        private void lvFunciones_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.tsbModificacionFuncion.Enabled = e.IsSelected;
            this.tsbBajaFuncion.Enabled = e.IsSelected;
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
            txtNombre.Text = _personal.Nombre;
            txtApellido.Text = _personal.Apellido;
            mskDNI.Text = _personal.DNI.ToString();
            dtpFechaNacimiento.Value = _personal.FechaNacimiento;
            txtDomicilio.Text = _personal.Domicilio;
            txtLocalidad.Text = _personal.Localidad;
            CargarGrillaConTelefonos(_personal.Telefonos);
            CargarGrillaConTitulos(_personal.Titulos);
            CargarComboConCargos(_personal.Cargos);
            dtpIngresoDocencia.Value = _personal.IngresoDocencia.GetValueOrDefault(DateTime.Now);
            dtpIngresoEstablecimiento.Value = _personal.IngresoEstablecimiento.GetValueOrDefault(DateTime.Now);
            rtbObservacion.Text = _personal.Observacion;
            CargarGrillaConInasistencias(_personal.Inasistencias);
        }

        private void BorrarTelefonoEnGrilla(Aplicacion.Entidades.Telefono telefono)
        {
            ListViewItem item = this.lvTelefonos.Items.Cast<ListViewItem>().Where(x =>
            {
                var unTelefono = x.Tag as EscuelaSimple.Aplicacion.Entidades.Telefono;
                return unTelefono.Equals(telefono);
            }).SingleOrDefault();
            this.lvTelefonos.Items.Remove(item);
        }

        private void CargarGrillaConTelefono(Aplicacion.Entidades.Telefono telefono)
        {
            BorrarTelefonoEnGrilla(telefono);

            ListViewItem fila = new ListViewItem(new string[] { telefono.Tipo.Descripcion, telefono.Numero.ToString() });
            fila.Tag = telefono;
            this.lvTelefonos.Items.Add(fila);
        }

        private void BorrarInasistenciaEnGrilla(EscuelaSimple.Aplicacion.Entidades.Inasistencia inasistencia)
        {
            ListViewItem item = this.lvInasistencia.Items.Cast<ListViewItem>().Where(x =>
            {
                var unaInasistencia = x.Tag as EscuelaSimple.Aplicacion.Entidades.Inasistencia;
                return unaInasistencia.Equals(inasistencia);
            }).SingleOrDefault();
            this.lvInasistencia.Items.Remove(item);
        }

        private void CargarGrillaConInasistencia(EscuelaSimple.Aplicacion.Entidades.Inasistencia inasistencia)
        {
            BorrarInasistenciaEnGrilla(inasistencia);

            int cantDias = inasistencia.Hasta.Subtract(inasistencia.Desde).Days;
            ListViewItem fila = new ListViewItem(new string[] { inasistencia.Motivo, inasistencia.Desde.ToShortDateString(), inasistencia.Hasta.ToShortDateString(), cantDias.ToString() });
            fila.Tag = inasistencia;
            this.lvInasistencia.Items.Add(fila);
        }

        private void BorrarTituloEnGrilla(EscuelaSimple.Aplicacion.Entidades.Titulo titulo)
        {
            ListViewItem item = this.lvTitulos.Items.Cast<ListViewItem>().Where(x =>
            {
                var unTitulo = x.Tag as EscuelaSimple.Aplicacion.Entidades.Titulo;
                return unTitulo.Equals(titulo);
            }).SingleOrDefault();
            this.lvTitulos.Items.Remove(item);
        }

        private void CargarGrillaConTitulo(EscuelaSimple.Aplicacion.Entidades.Titulo titulo)
        {
            BorrarTituloEnGrilla(titulo);

            ListViewItem fila = new ListViewItem(new string[] { titulo.Descripcion });
            fila.Tag = titulo;
            this.lvTitulos.Items.Add(fila);
        }

        private void BorrarCargoEnCombo(EscuelaSimple.Aplicacion.Entidades.Cargo cargo)
        {
            EscuelaSimple.Aplicacion.Entidades.Cargo item = this.cboCargo.Items.Cast<EscuelaSimple.Aplicacion.Entidades.Cargo>().Where(x =>
            {
                return x.Equals(cargo);
            }).SingleOrDefault();
            this.cboCargo.Items.Remove(item);
        }

        private void CargarComboConCargo(EscuelaSimple.Aplicacion.Entidades.Cargo cargo)
        {
            BorrarCargoEnCombo(cargo);

            this.cboCargo.Items.Add(cargo);
        }

        private void BorrarFuncionEnGrilla(EscuelaSimple.Aplicacion.Entidades.Funcion funcion)
        {
            ListViewItem item = this.lvFunciones.Items.Cast<ListViewItem>().Where(x =>
            {
                var unaFuncion = x.Tag as EscuelaSimple.Aplicacion.Entidades.Funcion;
                return unaFuncion.Equals(funcion);
            }).SingleOrDefault();
            this.lvFunciones.Items.Remove(item);
        }

        private void CargarGrillaConFuncion(EscuelaSimple.Aplicacion.Entidades.Funcion funcion)
        {
            BorrarFuncionEnGrilla(funcion);

            ListViewItem fila = new ListViewItem(new string[] { funcion.Tarea.Descripcion, funcion.TomaDePosesion.ToShortDateString(), funcion.CeseDePosesion.HasValue ? funcion.CeseDePosesion.Value.ToShortDateString() : null, funcion.SituacionDeRevista.Descripcion, funcion.Observacion });
            fila.Tag = funcion;
            this.lvFunciones.Items.Add(fila);
        }

        private void CargarGrillaConTelefonos(IEnumerable<EscuelaSimple.Aplicacion.Entidades.Telefono> telefonos)
        {
            this.lvTelefonos.Items.Clear();
            foreach (EscuelaSimple.Aplicacion.Entidades.Telefono item in telefonos)
            {
                this.CargarGrillaConTelefono(item);
            }
            this.lvTelefonos.Refresh();
        }

        private void CargarGrillaConInasistencias(IEnumerable<EscuelaSimple.Aplicacion.Entidades.Inasistencia> inasistencias)
        {
            this.lvInasistencia.Items.Clear();
            foreach (EscuelaSimple.Aplicacion.Entidades.Inasistencia item in inasistencias)
            {
                this.CargarGrillaConInasistencia(item);
            }
            this.lvInasistencia.Refresh();
        }

        private void CargarGrillaConTitulos(IEnumerable<EscuelaSimple.Aplicacion.Entidades.Titulo> titulos)
        {
            this.lvTitulos.Items.Clear();
            foreach (EscuelaSimple.Aplicacion.Entidades.Titulo item in titulos)
            {
                this.CargarGrillaConTitulo(item);
            }
            this.lvTitulos.Refresh();
        }

        private void CargarComboConCargos(IEnumerable<EscuelaSimple.Aplicacion.Entidades.Cargo> cargos)
        {
            this.cboCargo.Items.Clear();
            foreach (EscuelaSimple.Aplicacion.Entidades.Cargo item in cargos)
            {
                this.CargarComboConCargo(item);
            }
            this.cboCargo.Refresh();
        }

        private void CargarGrillaConFunciones(IEnumerable<EscuelaSimple.Aplicacion.Entidades.Funcion> funciones)
        {
            this.lvFunciones.Items.Clear();
            foreach (EscuelaSimple.Aplicacion.Entidades.Funcion item in funciones)
            {
                this.CargarGrillaConFuncion(item);
            }
            this.lvFunciones.Refresh();
        }

        private IEnumerable<EscuelaSimple.Aplicacion.Entidades.Telefono> ObtenerTelefonosDelPersonal()
        {
            List<EscuelaSimple.Aplicacion.Entidades.Telefono> telefonosRegistrados = new List<EscuelaSimple.Aplicacion.Entidades.Telefono>();
            foreach (ListViewItem fila in this.lvTelefonos.Items)
            {
                EscuelaSimple.Aplicacion.Entidades.Telefono telefono = fila.Tag as EscuelaSimple.Aplicacion.Entidades.Telefono;
                telefonosRegistrados.Add(telefono);
            }
            return telefonosRegistrados;
        }

        private IEnumerable<EscuelaSimple.Aplicacion.Entidades.Inasistencia> ObtenerInasistenciasDelPersonal()
        {
            List<EscuelaSimple.Aplicacion.Entidades.Inasistencia> inasistenciasRegistradas = new List<EscuelaSimple.Aplicacion.Entidades.Inasistencia>();
            foreach (ListViewItem fila in this.lvInasistencia.Items)
            {
                EscuelaSimple.Aplicacion.Entidades.Inasistencia inasistencia = fila.Tag as EscuelaSimple.Aplicacion.Entidades.Inasistencia;
                inasistenciasRegistradas.Add(inasistencia);
            }
            return inasistenciasRegistradas;
        }

        private IEnumerable<EscuelaSimple.Aplicacion.Entidades.Titulo> ObtenerTitulosDelPersonal()
        {
            List<EscuelaSimple.Aplicacion.Entidades.Titulo> titulosRegistrados = new List<EscuelaSimple.Aplicacion.Entidades.Titulo>();
            foreach (ListViewItem fila in this.lvTitulos.Items)
            {
                EscuelaSimple.Aplicacion.Entidades.Titulo titulo = fila.Tag as EscuelaSimple.Aplicacion.Entidades.Titulo;
                titulosRegistrados.Add(titulo);
            }
            return titulosRegistrados;
        }

        private IEnumerable<EscuelaSimple.Aplicacion.Entidades.Cargo> ObtenerCargosDelPersonal()
        {
            List<EscuelaSimple.Aplicacion.Entidades.Cargo> cargosRegistrados = new List<EscuelaSimple.Aplicacion.Entidades.Cargo>();
            foreach (EscuelaSimple.Aplicacion.Entidades.Cargo item in this.cboCargo.Items)
            {
                cargosRegistrados.Add(item);
            }
            return cargosRegistrados;
        }

        private IEnumerable<EscuelaSimple.Aplicacion.Entidades.Funcion> ObtenerFuncionesDelPersonal()
        {
            List<EscuelaSimple.Aplicacion.Entidades.Funcion> funcionesRegistradas = new List<EscuelaSimple.Aplicacion.Entidades.Funcion>();
            foreach (ListViewItem fila in this.lvFunciones.Items)
            {
                EscuelaSimple.Aplicacion.Entidades.Funcion funcion = fila.Tag as EscuelaSimple.Aplicacion.Entidades.Funcion;
                funcionesRegistradas.Add(funcion);
            }
            return funcionesRegistradas;
        }

        private EscuelaSimple.Aplicacion.Entidades.Personal ObtenerPersonal()
        {
            EscuelaSimple.Aplicacion.Entidades.Personal nuevoPersonal = this._personal ?? new EscuelaSimple.Aplicacion.Entidades.Personal();
            nuevoPersonal.Apellido = this.txtApellido.Text.Trim();
            ((List<EscuelaSimple.Aplicacion.Entidades.Cargo>)this.ObtenerCargosDelPersonal()).ForEach(x => nuevoPersonal.AgregarCargo(x));
            nuevoPersonal.DNI = Convert.ToInt32(this.mskDNI.Text.Trim());
            nuevoPersonal.Domicilio = this.txtDomicilio.Text.Trim();
            nuevoPersonal.FechaNacimiento = this.dtpFechaNacimiento.Value;
            ((List<EscuelaSimple.Aplicacion.Entidades.Inasistencia>)this.ObtenerInasistenciasDelPersonal()).ForEach(x => nuevoPersonal.AgregarInasistencia(x));
            nuevoPersonal.IngresoDocencia = this.dtpIngresoDocencia.Value;
            nuevoPersonal.IngresoEstablecimiento = this.dtpIngresoEstablecimiento.Value;
            nuevoPersonal.Localidad = this.txtLocalidad.Text.Trim();
            nuevoPersonal.Nombre = this.txtNombre.Text.Trim();
            nuevoPersonal.Observacion = this.rtbObservacion.Text.Trim();
            ((List<EscuelaSimple.Aplicacion.Entidades.Telefono>)this.ObtenerTelefonosDelPersonal()).ForEach(x => nuevoPersonal.AgregarTelefono(x));
            ((List<EscuelaSimple.Aplicacion.Entidades.Titulo>)this.ObtenerTitulosDelPersonal()).ForEach(x => nuevoPersonal.AgregarTitulo(x));

            return nuevoPersonal;
        }

        #endregion
    }
}
