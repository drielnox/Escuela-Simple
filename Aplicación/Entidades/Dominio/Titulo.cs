using EscuelaSimple.Aplicacion.Entidades.TiposBase;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Titulo : Entidad<int, Titulo>
    {
        #region Propiedades

        public string Descripcion { get; set; }

        #region Propiedades de Navegacion

        public int IdPersonal { get; set; }
        public Personal PersonalAsociado { get; set; }

        #endregion

        #endregion
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Titulo titulo = obj as Titulo;
            if (titulo == null)
            {
                return false;
            }

            return base.Equals(obj) &&
                Descripcion.Equals(titulo.Descripcion);
        }

        public override bool Equals(Titulo other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                Descripcion.Equals(other.Descripcion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                Descripcion.GetHashCode();
        }
    }
}
