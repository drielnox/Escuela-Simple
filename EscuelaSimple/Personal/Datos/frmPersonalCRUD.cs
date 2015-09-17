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

        #region Formulario

        private void frmPersonalCRUD_Load(object sender, EventArgs e)
        {
            EstablecerModoFormulario();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool valido = ValidateChildren();
            if (valido)
            {
                Aplicacion.Entidades.Personal personalAGuardar = ObtenerPersonal();
                if (PersistirEvento != null)
                {
                    PersistirEvento(personalAGuardar);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Validate(false);
            DialogResult = DialogResult.Cancel;
        }

        #region Basico

        private void tsbAltaTelefono_Click(object sender, EventArgs e)
        {
            frmPersonalTelefonoCRUD frm = new frmPersonalTelefonoCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Aplicacion.Entidades.Telefono telefonoNuevo = frm.Tag as Aplicacion.Entidades.Telefono;
                CargarGrillaConTelefono(telefonoNuevo);
            }
        }

        private void tsbModificacionTelefono_Click(object sender, EventArgs e)
        {
            Aplicacion.Entidades.Telefono telefonoSelecionado = lvTelefonos.SelectedItems[0].Tag as Aplicacion.Entidades.Telefono;
            frmPersonalTelefonoCRUD frm = new frmPersonalTelefonoCRUD(telefonoSelecionado);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Aplicacion.Entidades.Telefono telefonoModificado = frm.Tag as Aplicacion.Entidades.Telefono;
                CargarGrillaConTelefono(telefonoModificado);
            }
        }

        private void tsbBajaTelefono_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este telefono?", "Borrar telefono", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                ListViewItem itemSeleccionado = lvTelefonos.SelectedItems[0];
                lvTelefonos.Items.Remove(itemSeleccionado);
            }
        }

        private void lvTelefonos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tsbModificacionTelefono.Enabled = e.IsSelected;
            tsbBajaTelefono.Enabled = e.IsSelected;
        }

        #region Validaciones

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNombre, "El contenido no es valido.");
            }
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(txtNombre, string.Empty);
        }

        private void txtApellido_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtApellido, "El contenido no es valido.");
            }
        }

        private void txtApellido_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(txtApellido, string.Empty);
        }

        private void mskDNI_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mskDNI.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(mskDNI, "El DNI es mandatorio.");
            }
        }

        private void mskDNI_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(mskDNI, string.Empty);
        }

        #endregion

        #endregion

        #region Titulos

        private void tsbAltaTitulo_Click(object sender, EventArgs e)
        {
            frmPersonalTituloCRUD frm = new frmPersonalTituloCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Aplicacion.Entidades.Titulo tituloNuevo = frm.Tag as Aplicacion.Entidades.Titulo;
                CargarGrillaConTitulo(tituloNuevo);
            }
        }

        private void tsbModificacionTitulo_Click(object sender, EventArgs e)
        {
            Aplicacion.Entidades.Titulo tituloSeleccionado = lvTitulos.SelectedItems[0].Tag as Aplicacion.Entidades.Titulo;
            frmPersonalTituloCRUD frm = new frmPersonalTituloCRUD(tituloSeleccionado);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Aplicacion.Entidades.Titulo tituloModificado = frm.Tag as Aplicacion.Entidades.Titulo;
                CargarGrillaConTitulo(tituloModificado);
            }
        }

        private void tsbBajaTitulo_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este titulo?", "Borrar titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                ListViewItem itemSeleccionado = lvTitulos.SelectedItems[0];
                lvTitulos.Items.Remove(itemSeleccionado);
            }
        }

        private void lvTitulos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tsbModificacionTitulo.Enabled = e.IsSelected;
            tsbBajaTitulo.Enabled = e.IsSelected;
        }

        #endregion

        #region Laboral

        private void btnAltaCargo_Click(object sender, EventArgs e)
        {
            Aplicacion.Entidades.Cargo cargoNuevo = new Aplicacion.Entidades.Cargo();
            CargarComboConCargo(cargoNuevo);
        }

        private void btnBajaCargo_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este cargo?", "Borrar cargo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                Aplicacion.Entidades.Cargo cargoSeleccionado = cboCargo.SelectedItem as Aplicacion.Entidades.Cargo;
                cboCargo.Items.Remove(cargoSeleccionado);
            }
        }

        private void tsbAltaFuncion_Click(object sender, EventArgs e)
        {
            frmPersonalFuncionCRUD frm = new frmPersonalFuncionCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Aplicacion.Entidades.Funcion funcionNueva = frm.Tag as Aplicacion.Entidades.Funcion;
                CargarGrillaConFuncion(funcionNueva);
            }
        }

        private void tsbModificacionFuncion_Click(object sender, EventArgs e)
        {
            Aplicacion.Entidades.Funcion funcionSeleccionada = lvFunciones.SelectedItems[0].Tag as Aplicacion.Entidades.Funcion;
            frmPersonalFuncionCRUD frm = new frmPersonalFuncionCRUD(funcionSeleccionada);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Aplicacion.Entidades.Funcion funcionModificada = frm.Tag as Aplicacion.Entidades.Funcion;
                CargarGrillaConFuncion(funcionModificada);
            }
        }

        private void tsbBajaFuncion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar esta funcion?", "Borrar funcion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                ListViewItem itemSeleccionado = lvFunciones.SelectedItems[0];
                lvFunciones.Items.Remove(itemSeleccionado);
            }
        }

        private void cboCargo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Aplicacion.Entidades.Cargo cargoSeleccionado = cboCargo.SelectedItem as Aplicacion.Entidades.Cargo;
            CargarGrillaConFunciones(cargoSeleccionado.Funciones);
        }

        private void lvFunciones_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tsbModificacionFuncion.Enabled = e.IsSelected;
            tsbBajaFuncion.Enabled = e.IsSelected;
        }

        #region Validaciones

        private void dtpIngresoDocencia_Validating(object sender, CancelEventArgs e)
        {
            if (dtpIngresoDocencia.Value <= dtpFechaNacimiento.Value)
            {
                e.Cancel = true;
                errorProvider.SetError(dtpIngresoDocencia, "La fecha de ingreso a la docencia no puede ser menor o igual a fecha de nacimiento.");
            }
        }

        private void dtpIngresoDocencia_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(dtpIngresoDocencia, string.Empty);
        }

        private void dtpIngresoEstablecimiento_Validating(object sender, CancelEventArgs e)
        {
            if (dtpIngresoEstablecimiento.Value <= dtpFechaNacimiento.Value || dtpIngresoEstablecimiento.Value < dtpIngresoDocencia.Value)
            {
                e.Cancel = true;
                errorProvider.SetError(dtpIngresoEstablecimiento, "La fecha de ingreso al establecimiento no puede ser menor a la fecha de nacimiento o la fecha de ingreso a la docencia.");
            }
        }

        private void dtpIngresoEstablecimiento_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(dtpIngresoEstablecimiento, string.Empty);
        }

        #endregion

        #endregion
        
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

        private void BorrarTituloEnGrilla(Aplicacion.Entidades.Titulo titulo)
        {
            ListViewItem item = this.lvTitulos.Items.Cast<ListViewItem>().Where(x =>
            {
                var unTitulo = x.Tag as EscuelaSimple.Aplicacion.Entidades.Titulo;
                return unTitulo.Equals(titulo);
            }).SingleOrDefault();
            this.lvTitulos.Items.Remove(item);
        }

        private void CargarGrillaConTitulo(Aplicacion.Entidades.Titulo titulo)
        {
            BorrarTituloEnGrilla(titulo);

            ListViewItem fila = new ListViewItem(new string[] { titulo.Descripcion });
            fila.Tag = titulo;
            this.lvTitulos.Items.Add(fila);
        }

        private void BorrarCargoEnCombo(Aplicacion.Entidades.Cargo cargo)
        {
            EscuelaSimple.Aplicacion.Entidades.Cargo item = this.cboCargo.Items.Cast<EscuelaSimple.Aplicacion.Entidades.Cargo>().Where(x =>
            {
                return x.Equals(cargo);
            }).SingleOrDefault();
            this.cboCargo.Items.Remove(item);
        }

        private void CargarComboConCargo(Aplicacion.Entidades.Cargo cargo)
        {
            BorrarCargoEnCombo(cargo);

            this.cboCargo.Items.Add(cargo);
        }

        private void BorrarFuncionEnGrilla(Aplicacion.Entidades.Funcion funcion)
        {
            ListViewItem item = this.lvFunciones.Items.Cast<ListViewItem>().Where(x =>
            {
                var unaFuncion = x.Tag as EscuelaSimple.Aplicacion.Entidades.Funcion;
                return unaFuncion.Equals(funcion);
            }).SingleOrDefault();
            this.lvFunciones.Items.Remove(item);
        }

        private void CargarGrillaConFuncion(Aplicacion.Entidades.Funcion funcion)
        {
            BorrarFuncionEnGrilla(funcion);

            ListViewItem fila = new ListViewItem(new string[] { funcion.Tarea.Descripcion, funcion.TomaDePosesion.ToShortDateString(), funcion.CeseDePosesion.HasValue ? funcion.CeseDePosesion.Value.ToShortDateString() : null, funcion.SituacionDeRevista.Descripcion, funcion.Observacion });
            fila.Tag = funcion;
            this.lvFunciones.Items.Add(fila);
        }

        private void CargarGrillaConTelefonos(IEnumerable<Aplicacion.Entidades.Telefono> telefonos)
        {
            this.lvTelefonos.Items.Clear();
            foreach (EscuelaSimple.Aplicacion.Entidades.Telefono item in telefonos)
            {
                this.CargarGrillaConTelefono(item);
            }
            this.lvTelefonos.Refresh();
        }

        private void CargarGrillaConTitulos(IEnumerable<Aplicacion.Entidades.Titulo> titulos)
        {
            this.lvTitulos.Items.Clear();
            foreach (EscuelaSimple.Aplicacion.Entidades.Titulo item in titulos)
            {
                this.CargarGrillaConTitulo(item);
            }
            this.lvTitulos.Refresh();
        }

        private void CargarComboConCargos(IEnumerable<Aplicacion.Entidades.Cargo> cargos)
        {
            this.cboCargo.Items.Clear();
            foreach (EscuelaSimple.Aplicacion.Entidades.Cargo item in cargos)
            {
                this.CargarComboConCargo(item);
            }
            this.cboCargo.Refresh();
        }

        private void CargarGrillaConFunciones(IEnumerable<Aplicacion.Entidades.Funcion> funciones)
        {
            this.lvFunciones.Items.Clear();
            foreach (EscuelaSimple.Aplicacion.Entidades.Funcion item in funciones)
            {
                this.CargarGrillaConFuncion(item);
            }
            this.lvFunciones.Refresh();
        }

        private IEnumerable<Aplicacion.Entidades.Telefono> ObtenerTelefonosDelPersonal()
        {
            List<EscuelaSimple.Aplicacion.Entidades.Telefono> telefonosRegistrados = new List<EscuelaSimple.Aplicacion.Entidades.Telefono>();
            foreach (ListViewItem fila in this.lvTelefonos.Items)
            {
                EscuelaSimple.Aplicacion.Entidades.Telefono telefono = fila.Tag as EscuelaSimple.Aplicacion.Entidades.Telefono;
                telefonosRegistrados.Add(telefono);
            }
            return telefonosRegistrados;
        }

        private IEnumerable<Aplicacion.Entidades.Titulo> ObtenerTitulosDelPersonal()
        {
            List<EscuelaSimple.Aplicacion.Entidades.Titulo> titulosRegistrados = new List<EscuelaSimple.Aplicacion.Entidades.Titulo>();
            foreach (ListViewItem fila in this.lvTitulos.Items)
            {
                EscuelaSimple.Aplicacion.Entidades.Titulo titulo = fila.Tag as EscuelaSimple.Aplicacion.Entidades.Titulo;
                titulosRegistrados.Add(titulo);
            }
            return titulosRegistrados;
        }

        private IEnumerable<Aplicacion.Entidades.Cargo> ObtenerCargosDelPersonal()
        {
            List<EscuelaSimple.Aplicacion.Entidades.Cargo> cargosRegistrados = new List<EscuelaSimple.Aplicacion.Entidades.Cargo>();
            foreach (EscuelaSimple.Aplicacion.Entidades.Cargo item in this.cboCargo.Items)
            {
                cargosRegistrados.Add(item);
            }
            return cargosRegistrados;
        }

        private IEnumerable<Aplicacion.Entidades.Funcion> ObtenerFuncionesDelPersonal()
        {
            List<EscuelaSimple.Aplicacion.Entidades.Funcion> funcionesRegistradas = new List<EscuelaSimple.Aplicacion.Entidades.Funcion>();
            foreach (ListViewItem fila in this.lvFunciones.Items)
            {
                EscuelaSimple.Aplicacion.Entidades.Funcion funcion = fila.Tag as EscuelaSimple.Aplicacion.Entidades.Funcion;
                funcionesRegistradas.Add(funcion);
            }
            return funcionesRegistradas;
        }

        private Aplicacion.Entidades.Personal ObtenerPersonal()
        {
            Aplicacion.Entidades.Personal nuevoPersonal = _personal ?? new Aplicacion.Entidades.Personal();
            nuevoPersonal.Apellido = txtApellido.Text.Trim();
            ((List<Aplicacion.Entidades.Cargo>)ObtenerCargosDelPersonal()).ForEach(x => nuevoPersonal.AgregarCargo(x));
            nuevoPersonal.DNI = Convert.ToInt32(mskDNI.Text.Trim());
            nuevoPersonal.Domicilio = txtDomicilio.Text.Trim();
            nuevoPersonal.FechaNacimiento = dtpFechaNacimiento.Value;
            nuevoPersonal.IngresoDocencia = dtpIngresoDocencia.Value;
            nuevoPersonal.IngresoEstablecimiento = dtpIngresoEstablecimiento.Value;
            nuevoPersonal.Localidad = txtLocalidad.Text.Trim();
            nuevoPersonal.Nombre = txtNombre.Text.Trim();
            nuevoPersonal.Observacion = rtbObservacion.Text.Trim();
            ((List<Aplicacion.Entidades.Telefono>)ObtenerTelefonosDelPersonal()).ForEach(x => nuevoPersonal.AgregarTelefono(x));
            ((List<Aplicacion.Entidades.Titulo>)ObtenerTitulosDelPersonal()).ForEach(x => nuevoPersonal.AgregarTitulo(x));

            return nuevoPersonal;
        }

        #endregion
    }
}
