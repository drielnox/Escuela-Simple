
using System;
using System.Xml.Serialization;

namespace EscuelaSimple.Modelos
{
    [Serializable()]
    public class TipoTelefono : IEntidad<int>
    {
        [XmlAttribute]
        public virtual int Identificador { get; set; }
        public virtual string Descripcion { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            TipoTelefono tipo = obj as TipoTelefono;
            if (tipo == null)
            {
                return false;
            }

            return this.Identificador.Equals(tipo.Identificador) &&
                this.Descripcion.Equals(tipo.Descripcion);
        }

        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" + this.Descripcion;
            return hashCode.GetHashCode();
        }
    }
}
