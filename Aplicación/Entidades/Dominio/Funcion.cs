using EscuelaSimple.Aplicacion.Entidades.Contratos;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Funcion : Entidad<int, Funcion>
    {
        public Tarea Tarea { get; set; }
        public DateTime TomaDePosesion { get; set; }
        public DateTime? CeseDePosesion { get; set; }
        public SituacionRevista SituacionDeRevista { get; set; }
        public string Observacion { get; set; }

        public Funcion()
        {

        }

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
                this.Tarea.Equals(funcion.Tarea) &&
                this.TomaDePosesion.Equals(funcion.TomaDePosesion) &&
                this.CeseDePosesion.Equals(funcion.CeseDePosesion) &&
                this.SituacionDeRevista.Equals(funcion.SituacionDeRevista) &&
                this.Observacion.Equals(funcion.Observacion);
        }

        public override bool Equals(Funcion other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                this.Tarea.Equals(other.Tarea) &&
                this.TomaDePosesion.Equals(other.TomaDePosesion) &&
                this.CeseDePosesion.Equals(other.CeseDePosesion) &&
                this.SituacionDeRevista.Equals(other.SituacionDeRevista) &&
                this.Observacion.Equals(other.Observacion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                this.Tarea.GetHashCode() ^
                this.TomaDePosesion.GetHashCode() ^
                this.CeseDePosesion.GetHashCode() ^
                this.SituacionDeRevista.GetHashCode() ^
                this.Observacion.GetHashCode();
        }
    }
}