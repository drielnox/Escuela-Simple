
using EscuelaSimple.Aplicacion.Entidades.Contratos;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Xml.Serialization;

namespace EscuelaSimple.Aplicacion.Entidades
{
    [Serializable()]
    public class TipoTelefono : Entidad<int, TipoTelefono>
    {
        [XmlAttribute]
        public virtual int Identificador { get; set; }
        public virtual string Descripcion { get; set; }

        public override bool Equals(TipoTelefono obj)
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
