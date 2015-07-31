using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Modelos
{
    public class SituacionRevista : IEntidad<int>
    {
        public virtual int Identificador { get; set; }
        public virtual string Abreviacion { get; set; }
        public virtual string Descripcion { get; set; }

        public SituacionRevista()
        {

        }

        // override object.Equals
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

            return this.Identificador.Equals(situacion.Identificador) &&
                this.Abreviacion.Equals(situacion.Abreviacion) &&
                this.Descripcion.Equals(situacion.Descripcion);
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
