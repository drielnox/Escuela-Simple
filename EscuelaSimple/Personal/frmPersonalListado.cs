using EscuelaSimple.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.Personal
{
    public partial class frmPersonalListado : Form
    {
        #region Atributos

        private PersonalNegocio _personalNegocio;

        #endregion

        #region Constructores

        public frmPersonalListado()
        {
            InitializeComponent();
            this._personalNegocio = new PersonalNegocio();
        }

        #endregion

        #region Eventos del formulario

        private void frmListadoPersonal_Load(object sender, EventArgs e)
        {
            List<Entidad.Personal> personal = this._personalNegocio.ObtenerTodoPersonal();
            this.CargarGrilla(personal);
        }

        private void lvPersonal_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.tsbVerPersonal.Enabled = e.IsSelected;
            this.tsbBajaPersonal.Enabled = e.IsSelected;
            this.tsbModificarPersonal.Enabled = e.IsSelected;
        }

        private void tsbFiltrarPersonal_Click(object sender, EventArgs e)
        {
            frmPersonalFiltrar frm = new frmPersonalFiltrar();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                List<Entidad.Personal> personal = frm.Tag as List<Entidad.Personal>;
                this.CargarGrilla(personal);
            }
        }

        private void tsbVerPersonal_Click(object sender, EventArgs e)
        {
            Entidad.Personal personalSeleccionado = this.lvPersonal.SelectedItems[0].Tag as Entidad.Personal;
            frmPersonalCRUD frm = new frmPersonalCRUD(ModoFormulario.Ver, personalSeleccionado);
            frm.ShowDialog(this);
        }

        private void tsbAltaPersonal_Click(object sender, EventArgs e)
        {
            frmPersonalCRUD frm = new frmPersonalCRUD(ModoFormulario.Crear);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                this.OnLoad(EventArgs.Empty);
            }
        }

        private void tsbModificarPersonal_Click(object sender, EventArgs e)
        {
            Entidad.Personal personalSeleccionado = this.lvPersonal.SelectedItems[0].Tag as Entidad.Personal;
            frmPersonalCRUD frm = new frmPersonalCRUD(ModoFormulario.Modificar, personalSeleccionado);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                this.OnLoad(EventArgs.Empty);
            }
        }

        private void tsbBajaPersonal_Click(object sender, EventArgs e)
        {
            Entidad.Personal personalSeleccionado = this.lvPersonal.SelectedItems[0].Tag as Entidad.Personal;
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este personal?", "Borrar personal", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                this._personalNegocio.BorrarPersonal(personalSeleccionado);
                this.OnLoad(EventArgs.Empty);
            }
        }

        #endregion

        #region Metodos Privados

        private void CargarGrilla(List<Entidad.Personal> personal)
        {
            this.lvPersonal.Items.Clear();
            foreach (Entidad.Personal item in personal)
            {
                ListViewItem fila = new ListViewItem(new string[] { item.Apellido, item.Nombre });
                fila.Tag = item;
                this.lvPersonal.Items.Add(fila);
            }
        }

        #endregion
    }
}
