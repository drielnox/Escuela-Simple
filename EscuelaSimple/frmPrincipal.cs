using EscuelaSimple.InterfazDeUsuario.Personal;
using EscuelaSimple.Negocio;
using System;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void tsmiPersonal_Click(object sender, EventArgs e)
        {
            frmPersonalListado frm = new frmPersonalListado();
            frm.ShowDialog(this);
        }

        private void tsmiInicializar_Click(object sender, EventArgs e)
        {
            new SistemaNegocio().ValidarEsquema();
            new SistemaNegocio().CrearBaseDeDatos();
            new SistemaNegocio().InstarDatosEjemplo();
        }
    }
}
