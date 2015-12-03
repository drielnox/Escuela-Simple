using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Funcion : Entidad<int, Funcion>
    {
        #region Propiedades

        public virtual Tarea Tarea { get; set; }
        public DateTime TomaDePosesion { get; set; }
        public DateTime? CeseDePosesion { get; set; }
        public virtual SituacionRevista SituacionDeRevista { get; set; }
        public string Observacion { get; set; }

        #region Propiedades de Navegacion

        public int IdCargo { get; set; }
        public Cargo CargoAsociado { get; set; }

        #endregion

        #endregion
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Funcion funcion = obj as Funcion;
            if (funcion == null)
            {
                return false;
            }

            return base.Equals(obj) &&
                Tarea.Equals(funcion.Tarea) &&
                TomaDePosesion.Equals(funcion.TomaDePosesion) &&
                CeseDePosesion.Equals(funcion.CeseDePosesion) &&
                SituacionDeRevista.Equals(funcion.SituacionDeRevista) &&
                Observacion.Equals(funcion.Observacion);
        }

        public override bool Equals(Funcion other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                Tarea.Equals(other.Tarea) &&
                TomaDePosesion.Equals(other.TomaDePosesion) &&
                CeseDePosesion.Equals(other.CeseDePosesion) &&
                SituacionDeRevista.Equals(other.SituacionDeRevista) &&
                Observacion.Equals(other.Observacion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                Tarea.GetHashCode() ^
                TomaDePosesion.GetHashCode() ^
                CeseDePosesion.GetHashCode() ^
                SituacionDeRevista.GetHashCode() ^
                Observacion.GetHashCode();
        }
    }
}