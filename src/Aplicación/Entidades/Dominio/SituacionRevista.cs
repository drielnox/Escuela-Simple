using EscuelaSimple.Aplicacion.Entidades.TiposBase;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class SituacionRevista : Entidad<int, SituacionRevista>
    {
        #region Propiedades

        public string Abreviacion { get; set; }
        public string Descripcion { get; set; }

        #region Propiedades de Navegacion

        public Funcion FuncionAsociada { get; set; }

        #endregion

        #endregion
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            SituacionRevista situacion = obj as SituacionRevista;
            if (situacion == null)
            {
                return false;
            }

            return base.Equals(obj) &&
                Abreviacion.Equals(situacion.Abreviacion) &&
                Descripcion.Equals(situacion.Descripcion);
        }

        public override bool Equals(SituacionRevista other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                Abreviacion.Equals(other.Abreviacion) &&
                Descripcion.Equals(other.Descripcion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                Abreviacion.GetHashCode() ^
                Descripcion.GetHashCode();
        }
    }
}
