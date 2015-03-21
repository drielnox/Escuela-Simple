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

        private void tsbFiltrarPersonal_Click(object sender, EventArgs e)
        {
            frmPersonalFiltrar frm = new frmPersonalFiltrar();
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                List<Entidad.Personal> personal = frm.Tag as List<Entidad.Personal>;
                this.CargarGrilla(personal);
            }
        }

        private void tsbVerPersonal_Click(object sender, EventArgs e)
        {
            Entidad.Personal personalSeleccionado = this.lvPersonal.SelectedItems[0].Tag as Entidad.Personal;
            frmPersonalCRUD frm = new frmPersonalCRUD(personalSeleccionado);
            frm.ShowDialog(this);
        }

        private void tsbAltaPersonal_Click(object sender, EventArgs e)
        {
            frmPersonalCRUD frm = new frmPersonalCRUD();
            frm.ShowDialog(this);
        }

        private void tsbModificarPersonal_Click(object sender, EventArgs e)
        {
            Entidad.Personal personalSeleccionado = this.lvPersonal.SelectedItems[0].Tag as Entidad.Personal;
            frmPersonalCRUD frm = new frmPersonalCRUD(personalSeleccionado);
            frm.ShowDialog(this);
        }

        private void tsbBajaPersonal_Click(object sender, EventArgs e)
        {
            if (this.lvPersonal.SelectedItems.Count <= 0)
            {
                return;
            }

            Entidad.Personal personalSeleccionado = this.lvPersonal.SelectedItems[0].Tag as Entidad.Personal;
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar este personal?", "Borrar personal", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                this._personalNegocio.BorrarPersonal(personalSeleccionado);
            }

            this.Refresh();
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
