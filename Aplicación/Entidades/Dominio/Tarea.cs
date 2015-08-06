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
        public string Abreviacion { get; set; }
        public string Descripcion { get; set; }

        public Tarea()
        {

        }

        public override bool Equals(Tarea other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                this.Abreviacion.Equals(other.Abreviacion) &&
                this.Descripcion.Equals(other.Descripcion);
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
                this.Abreviacion.Equals(tarea.Abreviacion) &&
                this.Descripcion.Equals(tarea.Descripcion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                this.Abreviacion.GetHashCode() ^
                this.Descripcion.GetHashCode();
        }
    }
}
