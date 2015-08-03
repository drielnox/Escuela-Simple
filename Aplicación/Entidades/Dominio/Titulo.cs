using EscuelaSimple.Aplicacion.Entidades.Contratos;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Titulo : Entidad<int, Titulo>
    {
        public virtual int Identificador { get; set; }
        public virtual string Descripcion { get; set; }

        public Titulo()
        {

        }

        public override bool Equals(Titulo obj)
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

        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" +
                this.Descripcion;
            return hashCode.GetHashCode();
        }

        public override int CompareTo(Titulo other)
        {
            throw new NotImplementedException();
        }
    }
}
