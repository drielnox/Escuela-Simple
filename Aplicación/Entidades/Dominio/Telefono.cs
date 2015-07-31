
using System;
using System.Xml.Serialization;

namespace EscuelaSimple.Modelos
{
    public class Telefono : IEntidad<int>
    {
        public virtual int Identificador { get; set; }
        public virtual TipoTelefono Tipo { get; set; }
        public virtual int Numero { get; set; }

        public override bool Equals(object obj)
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
    }
}
