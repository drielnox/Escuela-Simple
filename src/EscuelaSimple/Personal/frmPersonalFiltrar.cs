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
            _negocio = new PersonalNegocio();
        }

        private void frmPersonalFiltrar_Load(object sender, EventArgs e)
        {
            cboTipoFiltro.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<Aplicacion.Entidades.Personal> personal = new List<Aplicacion.Entidades.Personal>();
            Aplicacion.Entidades.Personal personalABuscar;

            switch ((string)cboTipoFiltro.SelectedItem)
            {
                case "Apellido":
                    personalABuscar = new Aplicacion.Entidades.Personal() { Apellido = txtFiltro.Text.Trim() };
                    break;
                case "DNI":
                    personalABuscar = new Aplicacion.Entidades.Personal() { DNI = Convert.ToInt32(txtFiltro.Text.Trim()) };
                    break;
                default:
                    throw new Exception("Tipo de filtro no definido.");
            }

            Tag = _negocio.ObtenerPersonal(personalABuscar);

            Close();
        }
    }
}
