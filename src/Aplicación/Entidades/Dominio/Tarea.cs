using EscuelaSimple.Aplicacion.Entidades.TiposBase;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Tarea : Entidad<int, Tarea>
    {
        #region Propiedades

        public string Abreviacion { get; set; }
        public string Descripcion { get; set; }

        #region Propiedades de Navegacion

        public Funcion FuncionAsociada { get; set; }

        #endregion

        #endregion
        
        public override bool Equals(Tarea other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                Abreviacion.Equals(other.Abreviacion) &&
                Descripcion.Equals(other.Descripcion);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Tarea tarea = obj as Tarea;
            if (tarea == null)
            {
                return false;
            }

            return base.Equals(obj) &&
                Abreviacion.Equals(tarea.Abreviacion) &&
                Descripcion.Equals(tarea.Descripcion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                Abreviacion.GetHashCode() ^
                Descripcion.GetHashCode();
        }
    }
}
