using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EscuelaSimple.Aplicacion.Entidades.TiposBase;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class SituacionRevista : Entidad<int, SituacionRevista>
    {
        public override int Identificador { get; set; }
        public string Abreviacion { get; set; }
        public string Descripcion { get; set; }

        public SituacionRevista()
        {

        }

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
                this.Abreviacion.Equals(situacion.Abreviacion) &&
                this.Descripcion.Equals(situacion.Descripcion);
        }

        public override bool Equals(SituacionRevista other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                this.Abreviacion.Equals(other.Abreviacion) &&
                this.Descripcion.Equals(other.Descripcion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                this.Abreviacion.GetHashCode() ^
                this.Descripcion.GetHashCode();
        }
    }
}
