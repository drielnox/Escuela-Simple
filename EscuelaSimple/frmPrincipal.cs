using EscuelaSimple.InterfazDeUsuario.Personal;
using EscuelaSimple.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EscuelaSimple.InterfazDeUsuario
{
    public partial class frmPrincipal : Form
    {
        private Lazy<SistemaNegocio> _sistemaNegocio;
        private Lazy<PersonalNegocio> _personalNegocio;

        public frmPrincipal()
        {
            InitializeComponent();
            this._sistemaNegocio = new Lazy<SistemaNegocio>(() => new SistemaNegocio());
            this._personalNegocio = new Lazy<PersonalNegocio>(() => new PersonalNegocio());
        }

        private void tsmiPersonal_Click(object sender, EventArgs e)
        {
            frmPersonalListado frm = new frmPersonalListado();
            frm.ShowDialog(this);
        }

        private void tsmiInicializar_Click(object sender, EventArgs e)
        {
            this._sistemaNegocio.Value.ValidarEsquema();
            this._sistemaNegocio.Value.CrearBaseDeDatos();
            this._sistemaNegocio.Value.InstarDatosEjemplo();
        }

        private void tsmiImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivo XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void tsmiExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivo XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;

                List<Modelos.Personal> listaPersonal = this._personalNegocio.Value.ObtenerTodoPersonal();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Modelos.Personal>));
                using (StreamWriter myWriter = new StreamWriter(FileName))
                {
                    serializer.Serialize(myWriter, listaPersonal);
                }
            }
        }
    }
}
