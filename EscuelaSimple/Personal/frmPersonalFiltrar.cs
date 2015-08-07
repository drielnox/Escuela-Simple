using EscuelaSimple.Aplicacion.Componentes.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.WinForms.Personal
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
            List<Entidades.Personal> personal = new List<Entidades.Personal>();
            Entidades.Personal personalABuscar;

            switch ((string)this.cboTipoFiltro.SelectedItem)
            {
                case "Apellido":
                    personalABuscar = new Entidades.Personal() { Apellido = this.txtFiltro.Text.Trim() };
                    break;
                case "DNI":
                    personalABuscar = new Entidades.Personal() { DNI = Convert.ToInt32(this.txtFiltro.Text.Trim()) };
                    break;
                default:
                    throw new Exception("Tipo de filtro no definido.");
            }

            this.Tag = this._negocio.ObtenerPersonal(personalABuscar);

            this.Close();
        }
    }
}
