using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Modelos
{
    public class Titulo : IEntidad<int>
    {
        public virtual int Identificador { get; set; }
        public virtual string Descripcion { get; set; }

        public Titulo()
        {

        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Titulo titulo = obj as Titulo;
            if (titulo == null)
            {
                return false;
            }

            return this.Identificador.Equals(titulo.Identificador) &&
                this.Descripcion.Equals(titulo.Descripcion);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" +
                this.Descripcion;
            return hashCode.GetHashCode();
        }
    }
}
