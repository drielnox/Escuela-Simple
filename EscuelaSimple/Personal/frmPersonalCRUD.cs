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

        private void tsbAltaTitulo_Click(object sender, EventArgs e)
        {
            frmPersonalTituloCRUD frm = new frmPersonalTituloCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Modelos.Titulo tituloNuevo = frm.Tag as Modelos.Titulo;
                this.CargarGrillaConTitulo(tituloNuevo);
            }
        }

        private void tsbModificacionTitulo_Click(object sender, EventArgs e)
        {
            Modelos.Titulo tituloSeleccionado = this.lvTitulos.SelectedItems[0].Tag as Modelos.Titulo;
            frmPersonalTituloCRUD frm = new frmPersonalTituloCRUD(tituloSeleccionado);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Modelos.Titulo tituloModificado = frm.Tag as Modelos.Titulo;
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
            Modelos.Cargo cargoNuevo = new Modelos.Cargo();
            this.CargarComboConCargo(cargoNuevo);
        }

        private void btnBajaCargo_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este cargo?", "Borrar cargo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                Modelos.Cargo cargoSeleccionado = this.cboCargo.SelectedItem as Modelos.Cargo;
                this.cboCargo.Items.Remove(cargoSeleccionado);
            }
        }

        private void tsbAltaFuncion_Click(object sender, EventArgs e)
        {
            frmPersonalFuncionCRUD frm = new frmPersonalFuncionCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Modelos.Funcion funcionNueva = frm.Tag as Modelos.Funcion;
                this.CargarGrillaConFuncion(funcionNueva);
            }
        }

        private void tsbModificacionFuncion_Click(object sender, EventArgs e)
        {
            Modelos.Funcion funcionSeleccionada = this.lvFunciones.SelectedItems[0].Tag as Modelos.Funcion;
            frmPersonalFuncionCRUD frm = new frmPersonalFuncionCRUD(funcionSeleccionada);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Modelos.Funcion funcionModificada = frm.Tag as Modelos.Funcion;
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
            this.tsbModificacionInasistencia.Enabled = e.IsSelected;
            this.tsbBajaInasistencia.Enabled = e.IsSelected;
        }

        private void lvTitulos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.tsbModificacionTitulo.Enabled = e.IsSelected;
            this.tsbBajaTitulo.Enabled = e.IsSelected;
        }

        private void cboCargo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Modelos.Cargo cargoSeleccionado = this.cboCargo.SelectedItem as Modelos.Cargo;
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
            this.txtNombre.Text = this._personal.Nombre;
            this.txtApellido.Text = this._personal.Apellido;
            this.mskDNI.Text = this._personal.DNI.ToString();
            this.dtpFechaNacimiento.Value = this._personal.FechaNacimiento;
            this.txtDomicilio.Text = this._personal.Domicilio;
            this.txtLocalidad.Text = this._personal.Localidad;
            this.CargarGrillaConTelefonos(this._personal.Telefonos);
            this.CargarGrillaConTitulos(this._personal.Titulos);
            this.CargarComboConCargos(this._personal.Cargos);
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

        private void BorrarTituloEnGrilla(Modelos.Titulo titulo)
        {
            ListViewItem item = this.lvTitulos.Items.Cast<ListViewItem>().Where(x =>
            {
                var unTitulo = x.Tag as Modelos.Titulo;
                return unTitulo.Equals(titulo);
            }).SingleOrDefault();
            this.lvTitulos.Items.Remove(item);
        }

        private void CargarGrillaConTitulo(Modelos.Titulo titulo)
        {
            BorrarTituloEnGrilla(titulo);

            ListViewItem fila = new ListViewItem(new string[] { titulo.Descripcion });
            fila.Tag = titulo;
            this.lvTitulos.Items.Add(fila);
        }

        private void BorrarCargoEnCombo(Modelos.Cargo cargo)
        {
            Modelos.Cargo item = this.cboCargo.Items.Cast<Modelos.Cargo>().Where(x =>
            {
                return x.Equals(cargo);
            }).SingleOrDefault();
            this.cboCargo.Items.Remove(item);
        }

        private void CargarComboConCargo(Modelos.Cargo cargo)
        {
            BorrarCargoEnCombo(cargo);

            this.cboCargo.Items.Add(cargo);
        }

        private void BorrarFuncionEnGrilla(Modelos.Funcion funcion)
        {
            ListViewItem item = this.lvFunciones.Items.Cast<ListViewItem>().Where(x =>
            {
                var unaFuncion = x.Tag as Modelos.Funcion;
                return unaFuncion.Equals(funcion);
            }).SingleOrDefault();
            this.lvFunciones.Items.Remove(item);
        }

        private void CargarGrillaConFuncion(Modelos.Funcion funcion)
        {
            BorrarFuncionEnGrilla(funcion);

            ListViewItem fila = new ListViewItem(new string[] { funcion.Tarea.Descripcion, funcion.TomaDePosesion.ToShortDateString(), funcion.CeseDePosesion.HasValue ? funcion.CeseDePosesion.Value.ToShortDateString() : null, funcion.SituacionDeRevista.Descripcion, funcion.Observacion });
            fila.Tag = funcion;
            this.lvFunciones.Items.Add(fila);
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

        private void CargarGrillaConTitulos(IEnumerable<Modelos.Titulo> titulos)
        {
            this.lvTitulos.Items.Clear();
            foreach (Modelos.Titulo item in titulos)
            {
                this.CargarGrillaConTitulo(item);
            }
            this.lvTitulos.Refresh();
        }

        private void CargarComboConCargos(IEnumerable<Modelos.Cargo> cargos)
        {
            this.cboCargo.Items.Clear();
            foreach (Modelos.Cargo item in cargos)
            {
                this.CargarComboConCargo(item);
            }
            this.cboCargo.Refresh();
        }

        private void CargarGrillaConFunciones(IEnumerable<Modelos.Funcion> funciones)
        {
            this.lvFunciones.Items.Clear();
            foreach (Modelos.Funcion item in funciones)
            {
                this.CargarGrillaConFuncion(item);
            }
            this.lvFunciones.Refresh();
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

        private IEnumerable<Modelos.Titulo> ObtenerTitulosDelPersonal()
        {
            List<Modelos.Titulo> titulosRegistrados = new List<Modelos.Titulo>();
            foreach (ListViewItem fila in this.lvTitulos.Items)
            {
                Modelos.Titulo titulo = fila.Tag as Modelos.Titulo;
                titulosRegistrados.Add(titulo);
            }
            return titulosRegistrados;
        }

        private IEnumerable<Modelos.Cargo> ObtenerCargosDelPersonal()
        {
            List<Modelos.Cargo> cargosRegistrados = new List<Modelos.Cargo>();
            foreach (Modelos.Cargo item in this.cboCargo.Items)
            {
                cargosRegistrados.Add(item);
            }
            return cargosRegistrados;
        }

        private IEnumerable<Modelos.Funcion> ObtenerFuncionesDelPersonal()
        {
            List<Modelos.Funcion> funcionesRegistradas = new List<Modelos.Funcion>();
            foreach (ListViewItem fila in this.lvFunciones.Items)
            {
                Modelos.Funcion funcion = fila.Tag as Modelos.Funcion;
                funcionesRegistradas.Add(funcion);
            }
            return funcionesRegistradas;
        }

        private Modelos.Personal ObtenerPersonal()
        {
            Modelos.Personal nuevoPersonal = this._personal ?? new Modelos.Personal();
            nuevoPersonal.Apellido = this.txtApellido.Text.Trim();
            ((List<Modelos.Cargo>)this.ObtenerCargosDelPersonal()).ForEach(x => nuevoPersonal.AgregarCargo(x));
            nuevoPersonal.DNI = Convert.ToInt32(this.mskDNI.Text.Trim());
            nuevoPersonal.Domicilio = this.txtDomicilio.Text.Trim();
            nuevoPersonal.FechaNacimiento = this.dtpFechaNacimiento.Value;
            ((List<Modelos.Inasistencia>)this.ObtenerInasistenciasDelPersonal()).ForEach(x => nuevoPersonal.AgregarInasistencia(x));
            nuevoPersonal.IngresoDocencia = this.dtpIngresoDocencia.Value;
            nuevoPersonal.IngresoEstablecimiento = this.dtpIngresoEstablecimiento.Value;
            nuevoPersonal.Localidad = this.txtLocalidad.Text.Trim();
            nuevoPersonal.Nombre = this.txtNombre.Text.Trim();
            nuevoPersonal.Observacion = this.rtbObservacion.Text.Trim();
            ((List<Modelos.Telefono>)this.ObtenerTelefonosDelPersonal()).ForEach(x => nuevoPersonal.AgregarTelefono(x));
            ((List<Modelos.Titulo>)this.ObtenerTitulosDelPersonal()).ForEach(x => nuevoPersonal.AgregarTitulo(x));

            return nuevoPersonal;
        }

        #endregion
    }
}
