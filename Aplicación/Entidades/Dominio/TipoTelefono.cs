
using EscuelaSimple.Aplicacion.Entidades.Contratos;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Xml.Serialization;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class TipoTelefono : Entidad<int, TipoTelefono>
    {
        public string Descripcion { get; set; }

        public override bool Equals(TipoTelefono other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                this.Descripcion.Equals(other.Descripcion);
        }

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

            return base.Equals(obj) &&
                this.Descripcion.Equals(tipo.Descripcion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                this.Descripcion.GetHashCode();
        }
    }
}
