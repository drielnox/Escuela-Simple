using EscuelaSimple.Aplicacion.Componentes.Negocio;
using EscuelaSimple.InterfazDeUsuario.WinForms.Personal.Datos;
using EscuelaSimple.InterfazDeUsuario.WinForms.Personal.Inasistencias;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.WinForms.Personal
{
    public partial class frmPersonalListado : Form
    {
        #region Atributos

        private FormularioObjetivo _formularioObjetivo;
        private PersonalNegocio _personalNegocio;
        private Lazy<InasistenciaNegocio> _inasistenciaNegocio;

        #endregion

        #region Constructores

        public frmPersonalListado()
        {
            InitializeComponent();
            _personalNegocio = new PersonalNegocio();
            _inasistenciaNegocio = new Lazy<InasistenciaNegocio>();

        }

        public frmPersonalListado(FormularioObjetivo formularioObjetivo)
            : this()
        {
            _formularioObjetivo = formularioObjetivo;
        }

        #endregion

        #region Eventos del formulario

        #region Formulario

        private void frmListadoPersonal_Load(object sender, EventArgs e)
        {
            List<Aplicacion.Entidades.Personal> personal = _personalNegocio.ObtenerTodoPersonal();
            CargarGrilla(personal);
        }

        #endregion

        #region Menu

        private void tsbFiltrarPersonal_Click(object sender, EventArgs e)
        {
            frmPersonalFiltrar frm = new frmPersonalFiltrar();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                List<Aplicacion.Entidades.Personal> personal = frm.Tag as List<Aplicacion.Entidades.Personal>;
                CargarGrilla(personal);
            }
        }

        private void tsbVerPersonal_Click(object sender, EventArgs e)
        {
            Aplicacion.Entidades.Personal personalSeleccionado = lvPersonal.SelectedItems[0].Tag as Aplicacion.Entidades.Personal;
            Form frm = null;
            switch (_formularioObjetivo)
            {
                case FormularioObjetivo.PersonalCrud:
                    frm = new frmPersonalCRUD(ModoFormulario.Ver, personalSeleccionado);
                    break;
                case FormularioObjetivo.InasistenciaListado:
                    frm = new frmPersonalInasistenciaListado(personalSeleccionado.Inasistencias);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("_formularioObjetivo");
            }

            frm.ShowDialog(this);
        }

        private void tsbAltaPersonal_Click(object sender, EventArgs e)
        {
            frmPersonalCRUD frm = new frmPersonalCRUD(ModoFormulario.Crear);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                OnLoad(EventArgs.Empty);
            }
        }

        private void tsbModificarPersonal_Click(object sender, EventArgs e)
        {
            Aplicacion.Entidades.Personal personalSeleccionado = lvPersonal.SelectedItems[0].Tag as Aplicacion.Entidades.Personal;
            frmPersonalCRUD frm = new frmPersonalCRUD(ModoFormulario.Modificar, personalSeleccionado);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                OnLoad(EventArgs.Empty);
            }
        }

        private void tsbBajaPersonal_Click(object sender, EventArgs e)
        {
            Aplicacion.Entidades.Personal personalSeleccionado = lvPersonal.SelectedItems[0].Tag as Aplicacion.Entidades.Personal;
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este personal?", "Borrar personal", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                _personalNegocio.BorrarPersonal(personalSeleccionado);
                OnLoad(EventArgs.Empty);
            }
        }

        #endregion

        #region Lista

        private void lvPersonal_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tsbVerPersonal.Enabled = e.IsSelected;
            tsbBajaPersonal.Enabled = e.IsSelected;
            tsbModificarPersonal.Enabled = e.IsSelected;
        }

        private void lvPersonal_DoubleClick(object sender, EventArgs e)
        {
            if (lvPersonal.SelectedItems.Count > 0)
            {
                tsbVerPersonal.PerformClick();
            }
        }

        #endregion

        #endregion

        #region Metodos Privados

        private void CargarGrilla(List<Aplicacion.Entidades.Personal> personal)
        {
            lvPersonal.Items.Clear();
            foreach (Aplicacion.Entidades.Personal item in personal)
            {
                ListViewItem fila = new ListViewItem(new string[] { item.Apellido, item.Nombre });
                fila.Tag = item;
                lvPersonal.Items.Add(fila);
            }
        }

        #endregion
    }
}
