using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EscuelaSimple.Aplicacion.Entidades.TiposBase;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class SituacionRevista : Entidad<int, SituacionRevista>
    {
        public virtual int Identificador { get; set; }
        public virtual string Abreviacion { get; set; }
        public virtual string Descripcion { get; set; }

        public SituacionRevista()
        {

        }

        public override bool Equals(SituacionRevista obj)
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

        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" +
                this.Abreviacion + "|" +
                this.Descripcion;
            return hashCode.GetHashCode();
        }

        public override int CompareTo(SituacionRevista other)
        {
            throw new NotImplementedException();
        }
    }
}
