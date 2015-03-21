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
    public partial class frmPersonalFiltrar : Form
    {
        private PersonalNegocio _negocio;

        public frmPersonalFiltrar()
        {
            InitializeComponent();
            this._negocio = new PersonalNegocio();
        }

        private void frmPersonalFiltrar_Load(object sender, EventArgs e)
        {
            this.cboTipoFiltro.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<Entidad.Personal> personal = new List<Entidad.Personal>();
            Entidad.Personal personalABuscar;

            switch ((string)this.cboTipoFiltro.SelectedItem)
            {
                case "Apellido":
                    personalABuscar = new Entidad.Personal() { Apellido = this.txtFiltro.Text.Trim() };
                    break;
                case "DNI":
                    personalABuscar = new Entidad.Personal() { DNI = Convert.ToUInt32(this.txtFiltro.Text.Trim()) };
                    break;
                default:
                    throw new Exception("Tipo de filtro no definido.");
            }

            this.Tag = this._negocio.ObtenerPersonal(personalABuscar);

            this.Close();
        }
    }
}
