using EscuelaSimple.InterfazDeUsuario.WinForms.Personal;
using EscuelaSimple.Aplicacion.Componentes.Negocio;
using System;
using System.Windows.Forms;
using EscuelaSimple.InterfazDeUsuario.WinForms.Personal.Datos;

namespace EscuelaSimple.InterfazDeUsuario.WinForms
{
    public partial class frmPrincipal : Form
    {
        #region Atributos

        private Lazy<PersonalNegocio> _personalNegocio;

        #endregion

        #region Constructores

        public frmPrincipal()
        {
            InitializeComponent();
            this._personalNegocio = new Lazy<PersonalNegocio>(() => new PersonalNegocio());
        }

        #endregion
        
        #region Eventos

        #region Formulario

        #endregion

        #region Menu

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
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //saveFileDialog.Filter = "Archivo XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = saveFileDialog.FileName;

            //    List<Entidades.PersonalSerializable> listaPersonal = this._personalNegocio.Value.ObtenerTodoPersonalSerializable();
            //    XmlSerializer serializer = new XmlSerializer(typeof(List<Entidades.PersonalSerializable>));
            //    using (StreamWriter myWriter = new StreamWriter(FileName))
            //    {
            //        serializer.Serialize(myWriter, listaPersonal);
            //    }
            //}
        }

        private void tsmiDatosPersonal_Click(object sender, EventArgs e)
        {
            frmPersonalListado frm = new frmPersonalListado(typeof(frmPersonalCRUD));
            frm.ShowDialog(this);
        }

        private void tsmiInasistenciasPersonal_Click(object sender, EventArgs e)
        {
            frmPersonalListado frm = new frmPersonalListado();
            frm.ShowDialog(this);
        }

        #endregion
        
        #endregion
    }
}
