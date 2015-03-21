using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Olfrad.EscuelaSimple.Negocio;

namespace Olfrad.EscuelaSimple.InterfazDeUsuario.Personal
{
    public partial class frmPersonalCRUD : Form
    {
        #region Atributos

        private Entidad.Personal _personal;
        private PersonalNegocio _negocioPersonal;

        #endregion

        #region Constructores

        public frmPersonalCRUD()
        {
            InitializeComponent();
            this._negocioPersonal = new PersonalNegocio();
        }

        public frmPersonalCRUD(Entidad.Personal personal)
            : this()
        {
            this._personal = personal;
            this.CargarPersonal();
        }

        #endregion

        #region Eventos del formulario

        private void frmPersonalCRUD_Load(object sender, EventArgs e)
        {

        }

        private void tsbAltaTelefono_Click(object sender, EventArgs e)
        {
            frmPersonalTelefonoCRUD frm = new frmPersonalTelefonoCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                Entidad.Telefono telefonoNuevo = frm.Tag as Entidad.Telefono;
                this.CargarGrillaConTelefono(telefonoNuevo);
            }
        }

        private void tsbModificacionTelefono_Click(object sender, EventArgs e)
        {
            if (this.lvTelefonos.SelectedItems.Count <= 0)
            {
                return;
            }
            Entidad.Telefono telefonoSelecionado = this.lvTelefonos.SelectedItems[0].Tag as Entidad.Telefono;
            frmPersonalTelefonoCRUD frm = new frmPersonalTelefonoCRUD(telefonoSelecionado);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                Entidad.Telefono telefonoModificado = frm.Tag as Entidad.Telefono;
                this.CargarGrillaConTelefono(telefonoModificado);
            }
        }

        private void tsbBajaTelefono_Click(object sender, EventArgs e)
        {
            if (this.lvTelefonos.SelectedItems.Count <= 0)
            {
                return;
            }
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este telefono?", "Borrar telefono", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem itemSeleccionado = this.lvTelefonos.SelectedItems[0];
                this.lvTelefonos.Items.Remove(itemSeleccionado);
            }
        }

        private void tsbAltaInasistencia_Click(object sender, EventArgs e)
        {
            frmPersonalInasistenciaCRUD frm = new frmPersonalInasistenciaCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                Entidad.Inasistencia inasistenciaNueva = frm.Tag as Entidad.Inasistencia;
                this.CargarGrillaConInasistencia(inasistenciaNueva);
            }
        }

        private void tsbModificacionInasistencia_Click(object sender, EventArgs e)
        {
            if (this.lvInasistencia.SelectedItems.Count <= 0)
            {
                return;
            }
            Entidad.Inasistencia inasistenciaSeleccionada = this.lvInasistencia.SelectedItems[0].Tag as Entidad.Inasistencia;
            frmPersonalInasistenciaCRUD frm = new frmPersonalInasistenciaCRUD(inasistenciaSeleccionada);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                Entidad.Inasistencia inasistenciaModificada = frm.Tag as Entidad.Inasistencia;
                this.CargarGrillaConInasistencia(inasistenciaModificada);
            }
        }

        private void tsbBajaInasistencia_Click(object sender, EventArgs e)
        {
            if (this.lvInasistencia.SelectedItems.Count <= 0)
            {
                return;
            }
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar esta inasistencia?", "Borrar inasistencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem itemSeleccionado = this.lvInasistencia.SelectedItems[0];
                this.lvInasistencia.Items.Remove(itemSeleccionado);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Entidad.Personal personalAGuardar = this.ObtenerPersonal();
            this._negocioPersonal.GuardarPersonal(personalAGuardar);
        }

        #endregion

        #region Metodos Privados

        private void CargarPersonal()
        {
            this.txtNombre.Text = this._personal.Nombre;
            this.txtApellido.Text = this._personal.Apellido;
            this.mskDNI.Text = this._personal.DNI.ToString();
            this.dtpFechaNacimiento.Value = this._personal.FechaNacimiento;
            this.txtDomicilio.Text = this._personal.Domicilio;
            this.txtLocalidad.Text = this._personal.Localidad;
            this.CargarGrillaConTelefonos(this._personal.Telefonos);

            this.txtTitulo.Text = this._personal.Titulo;
            this.txtCargo.Text = this._personal.Cargo;
            this.txtSituacionRevista.Text = this._personal.SituacionRevista;
            this.dtpIngresoDocencia.Value = this._personal.IngresoDocencia.GetValueOrDefault(DateTime.Now);
            this.dtpIngresoEstablecimiento.Value = this._personal.IngresoEstablecimiento.GetValueOrDefault(DateTime.Now);
            this.rtbObservacion.Text = this._personal.Observacion;

            this.CargarGrillaConInasistencias(this._personal.Inasistencias);
        }

        private void BorrarTelefonoEnGrilla(Entidad.Telefono telefono)
        {
            ListViewItem item = this.lvTelefonos.Items.Cast<ListViewItem>().Where(x =>
            {
                var unTelefono = x.Tag as Entidad.Telefono;
                return unTelefono.Equals(telefono);
            }).SingleOrDefault();
            this.lvTelefonos.Items.Remove(item);
        }

        private void CargarGrillaConTelefono(Entidad.Telefono telefono)
        {
            BorrarTelefonoEnGrilla(telefono);

            ListViewItem fila = new ListViewItem(new string[] { telefono.Tipo.Descripcion, telefono.Numero.ToString() });
            fila.Tag = telefono;
            this.lvTelefonos.Items.Add(fila);
        }

        private void BorrarInasistenciaEnGrilla(Entidad.Inasistencia inasistencia)
        {
            ListViewItem item = this.lvInasistencia.Items.Cast<ListViewItem>().Where(x =>
            {
                var unaInasistencia = x.Tag as Entidad.Inasistencia;
                return unaInasistencia.Equals(inasistencia);
            }).SingleOrDefault();
            this.lvInasistencia.Items.Remove(item);
        }

        private void CargarGrillaConInasistencia(Entidad.Inasistencia inasistencia)
        {
            BorrarInasistenciaEnGrilla(inasistencia);

            int cantDias = inasistencia.Hasta.Subtract(inasistencia.Desde).Days;
            ListViewItem fila = new ListViewItem(new string[] { inasistencia.Motivo, inasistencia.Desde.ToShortDateString(), inasistencia.Hasta.ToShortDateString(), cantDias.ToString() });
            fila.Tag = inasistencia;
            this.lvInasistencia.Items.Add(fila);
        }

        private void CargarGrillaConTelefonos(IEnumerable<Entidad.Telefono> telefonos)
        {
            this.lvTelefonos.Items.Clear();
            foreach (Entidad.Telefono item in telefonos)
            {
                this.CargarGrillaConTelefono(item);
            }
            this.lvTelefonos.Refresh();
        }

        private void CargarGrillaConInasistencias(IEnumerable<Entidad.Inasistencia> inasistencias)
        {
            this.lvInasistencia.Items.Clear();
            foreach (Entidad.Inasistencia item in inasistencias)
            {
                this.CargarGrillaConInasistencia(item);
            }
            this.lvInasistencia.Refresh();
        }

        private IEnumerable<Entidad.Telefono> ObtenerTelefonosDelPersonal()
        {
            List<Entidad.Telefono> telefonosRegistrados = new List<Entidad.Telefono>();
            foreach (ListViewItem fila in this.lvTelefonos.Items)
            {
                Entidad.Telefono telefono = fila.Tag as Entidad.Telefono;
                telefonosRegistrados.Add(telefono);
            }
            return telefonosRegistrados;
        }

        private IEnumerable<Entidad.Inasistencia> ObtenerInasistenciasDelPersonal()
        {
            List<Entidad.Inasistencia> inasistenciasRegistradas = new List<Entidad.Inasistencia>();
            foreach (ListViewItem fila in this.lvInasistencia.Items)
            {
                Entidad.Inasistencia inasistencia = fila.Tag as Entidad.Inasistencia;
                inasistenciasRegistradas.Add(inasistencia);
            }
            return inasistenciasRegistradas;
        }

        private Entidad.Personal ObtenerPersonal()
        {
            Entidad.Personal nuevoPersonal = new Entidad.Personal();
            nuevoPersonal.Apellido = this.txtApellido.Text.Trim();
            nuevoPersonal.Cargo = this.txtCargo.Text.Trim();
            nuevoPersonal.DNI = Convert.ToUInt32(this.mskDNI.Text.Trim());
            nuevoPersonal.Domicilio = this.txtDomicilio.Text.Trim();
            nuevoPersonal.FechaNacimiento = this.dtpFechaNacimiento.Value;
            nuevoPersonal.Inasistencias = this.ObtenerInasistenciasDelPersonal();
            nuevoPersonal.IngresoDocencia = this.dtpIngresoDocencia.Value;
            nuevoPersonal.IngresoEstablecimiento = this.dtpIngresoEstablecimiento.Value;
            nuevoPersonal.Localidad = this.txtLocalidad.Text.Trim();
            nuevoPersonal.Nombre = this.txtNombre.Text.Trim();
            nuevoPersonal.Observacion = this.rtbObservacion.Text.Trim();
            nuevoPersonal.SituacionRevista = this.txtSituacionRevista.Text.Trim();
            nuevoPersonal.Telefonos = this.ObtenerTelefonosDelPersonal();
            nuevoPersonal.Titulo = this.txtTitulo.Text.Trim();

            return nuevoPersonal;
        }

        #endregion
    }
}
