using EscuelaSimple.Aplicacion.Componentes.Negocio;
using EscuelaSimple.Aplicacion.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EscuelaSimple.InterfazDeUsuario.WinForms.Personal.Inasistencias
{
    public partial class frmPersonalInasistenciaListado : Form
    {
        #region Atributos

        private InasistenciaNegocio _personalNegocio;
        private ICollection<Inasistencia> _inasistencias;

        #endregion

        #region Propiedades

        #endregion

        #region Constructores

        public frmPersonalInasistenciaListado()
        {
            InitializeComponent();
            _personalNegocio = new InasistenciaNegocio();
        }

        public frmPersonalInasistenciaListado(ICollection<Inasistencia> inasistencias)
            : this()
        {
            _inasistencias = inasistencias;
            CargarInasistencias();
        }

        #endregion

        #region Eventos

        #region Formulario

        private void frmPersonalInasistenciaListado_Load(object sender, System.EventArgs e)
        {

        }

        #endregion

        #region Menu

        private void tsbAltaInasistencia_Click(object sender, System.EventArgs e)
        {
            frmPersonalInasistenciaCRUD frm = new frmPersonalInasistenciaCRUD();
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Inasistencia inasistenciaNueva = frm.Tag as Inasistencia;
                CargarGrillaConInasistencia(inasistenciaNueva);
            }
        }

        private void tsbModificacionInasistencia_Click(object sender, System.EventArgs e)
        {
            Inasistencia inasistenciaSeleccionada = lvInasistencia.SelectedItems[0].Tag as Inasistencia;
            frmPersonalInasistenciaCRUD frm = new frmPersonalInasistenciaCRUD(inasistenciaSeleccionada);
            DialogResult resultado = frm.ShowDialog(this);
            if (resultado == DialogResult.OK)
            {
                Inasistencia inasistenciaModificada = frm.Tag as Inasistencia;
                CargarGrillaConInasistencia(inasistenciaModificada);
            }
        }

        private void tsbBajaInasistencia_Click(object sender, System.EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(this, "¿Esta seguro que desea borrar esta inasistencia?", "Borrar inasistencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resultado == DialogResult.OK)
            {
                Inasistencia inasistenciaSeleccionada = lvInasistencia.SelectedItems[0].Tag as Inasistencia;
                BorrarInasistenciaEnGrilla(inasistenciaSeleccionada);
            }
        }

        #endregion

        #region Lista

        private void lvInasistencia_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tsbModificacionInasistencia.Enabled = e.IsSelected;
            tsbBajaInasistencia.Enabled = e.IsSelected;
        }

        #endregion

        #endregion

        #region Metodos privados

        private void CargarInasistencias()
        {
            foreach (Inasistencia inasistencia in _inasistencias)
            {
                CargarInasistencia(inasistencia);
            }
        }

        private void CargarInasistencia(Inasistencia inasistencia)
        {
            CargarGrillaConInasistencia(inasistencia);
        }

        private void BorrarInasistenciaEnGrilla(Inasistencia inasistencia)
        {
            ListViewItem item = lvInasistencia.Items
                .Cast<ListViewItem>()
                .Where(x =>
                {
                    Inasistencia unaInasistencia = x.Tag as Inasistencia;
                    return unaInasistencia.Equals(inasistencia);
                }).SingleOrDefault();

            lvInasistencia.Items.Remove(item);
        }

        private void CargarGrillaConInasistencia(Inasistencia inasistencia)
        {
            BorrarInasistenciaEnGrilla(inasistencia);

            int cantDias = inasistencia.Hasta.Subtract(inasistencia.Desde).Days;
            ListViewItem fila = new ListViewItem(new string[]
            {
                inasistencia.Motivo,
                inasistencia.Desde.ToShortDateString(),
                inasistencia.Hasta.ToShortDateString(),
                cantDias.ToString()
            });
            fila.Tag = inasistencia;

            lvInasistencia.Items.Add(fila);
        }

        private IEnumerable<Inasistencia> ObtenerInasistenciasDelPersonal()
        {
            List<Inasistencia> inasistenciasRegistradas = new List<Inasistencia>();
            foreach (ListViewItem fila in lvInasistencia.Items)
            {
                Inasistencia inasistencia = fila.Tag as Inasistencia;
                inasistenciasRegistradas.Add(inasistencia);
            }
            return inasistenciasRegistradas;
        }

        #endregion
    }
}
