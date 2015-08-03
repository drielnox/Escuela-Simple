
using EscuelaSimple.Aplicacion.Entidades.Contratos;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Xml.Serialization;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Telefono : Entidad<int, Telefono>
    {
        public virtual int Identificador { get; set; }
        public virtual TipoTelefono Tipo { get; set; }
        public virtual int Numero { get; set; }

        public override bool Equals(Telefono obj)
        {
            if (obj == null)
            {
                return false;
            }

            Telefono telefono = obj as Telefono;
            if (telefono == null)
            {
                return false;
            }

            return this.Identificador.Equals(telefono.Identificador) &&
                this.Tipo.Equals(telefono.Tipo) &&
                this.Numero.Equals(telefono.Numero);
        }

        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" + this.Tipo.GetHashCode() + "|" + this.Numero;
            return hashCode.GetHashCode();
        }

        public override int CompareTo(Telefono other)
        {
            throw new NotImplementedException();
        }
    }
}
