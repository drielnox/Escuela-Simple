using EscuelaSimple.Aplicacion.Entidades.Contratos;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Tarea : Entidad<int, Tarea>
    {
        public virtual int Identificador { get; set; }
        public virtual string Abreviacion { get; set; }
        public virtual string Descripcion { get; set; }

        public Tarea()
        {

        }

        // override object.Equals
        public override bool Equals(Tarea obj)
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

            return this.Identificador.Equals(tarea.Identificador) &&
                this.Abreviacion.Equals(tarea.Abreviacion) &&
                this.Descripcion.Equals(tarea.Descripcion);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" +
                this.Abreviacion + "|" +
                this.Descripcion;
            return hashCode.GetHashCode();
        }
    }
}
