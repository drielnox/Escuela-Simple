using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EscuelaSimple.InterfazDeUsuario.Personal;
using EscuelaSimple.Negocio;

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
