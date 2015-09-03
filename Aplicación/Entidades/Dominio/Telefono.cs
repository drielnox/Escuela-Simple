using EscuelaSimple.Aplicacion.Entidades.TiposBase;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Telefono : Entidad<int, Telefono>
    {
        #region Propiedades

        public TipoTelefono Tipo { get; set; }
        public int Numero { get; set; }

        #region Propiedades de Navegacion

        public int IdPersonal { get; set; }
        public Personal PersonalAsociado { get; set; }

        #endregion

        #endregion
        
        public override bool Equals(Telefono other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                Tipo.Equals(other.Tipo) &&
                Numero.Equals(other.Numero);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Telefono telefono = obj as Telefono;
            if (telefono == null)
            {
                return false;
            }

            return base.Equals(obj) &&
                Tipo.Equals(telefono.Tipo) &&
                Numero.Equals(telefono.Numero);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                Tipo.GetHashCode() ^
                Numero.GetHashCode();
        }
    }
}
