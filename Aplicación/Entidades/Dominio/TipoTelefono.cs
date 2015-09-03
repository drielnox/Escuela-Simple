using EscuelaSimple.Aplicacion.Entidades.TiposBase;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class TipoTelefono : Entidad<int, TipoTelefono>
    {
        #region Propiedades

        public string Descripcion { get; set; }

        #region Propiedades de Navegacion

        public Telefono TelefonoAsociado { get; set; }

        #endregion

        #endregion

        public override bool Equals(TipoTelefono other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                Descripcion.Equals(other.Descripcion);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            TipoTelefono tipo = obj as TipoTelefono;
            if (tipo == null)
            {
                return false;
            }

            return base.Equals(obj) &&
                Descripcion.Equals(tipo.Descripcion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                Descripcion.GetHashCode();
        }
    }
}
