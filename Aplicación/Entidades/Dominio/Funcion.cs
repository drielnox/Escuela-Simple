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
        public virtual int Identificador { get; set; }
        public virtual Tarea Tarea { get; set; }
        public virtual DateTime TomaDePosesion { get; set; }
        public virtual DateTime? CeseDePosesion { get; set; }
        public virtual SituacionRevista SituacionDeRevista { get; set; }
        public virtual string Observacion { get; set; }

        public Funcion()
        {

        }

        // override object.Equals
        public override bool Equals(Funcion obj)
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

            return this.Identificador.Equals(funcion.Identificador) &&
                this.Tarea.Equals(funcion.Tarea) &&
                this.TomaDePosesion.Equals(funcion.TomaDePosesion) &&
                this.CeseDePosesion.Equals(funcion.CeseDePosesion) &&
                this.SituacionDeRevista.Equals(funcion.SituacionDeRevista) &&
                this.Observacion.Equals(funcion.Observacion);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" +
                this.Tarea + "|" +
                this.TomaDePosesion + "|" +
                this.CeseDePosesion + "|" +
                this.SituacionDeRevista + "|" +
                this.Observacion;
            return hashCode.GetHashCode();
        }
    }
}