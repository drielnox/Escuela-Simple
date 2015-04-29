
using System;
using System.Xml.Serialization;

namespace EscuelaSimple.Entidad
{
    [Serializable()]
    public class Telefono : IEntidad<uint>
    {
        public virtual uint Identificador { get; set; }
        [XmlElementAttribute(IsNullable = false)]
        public virtual TipoTelefono Tipo { get; set; }
        public virtual uint Numero { get; set; }

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
