
using EscuelaSimple.Aplicacion.Entidades.Contratos;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Xml.Serialization;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Telefono : Entidad<int, Telefono>
    {
        public TipoTelefono Tipo { get; set; }
        public int Numero { get; set; }

        public override bool Equals(Telefono other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                this.Tipo.Equals(other.Tipo) &&
                this.Numero.Equals(other.Numero);
        }

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

            return base.Equals(obj) &&
                this.Tipo.Equals(telefono.Tipo) &&
                this.Numero.Equals(telefono.Numero);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                this.Tipo.GetHashCode() ^
                this.Numero.GetHashCode();
        }
    }
}
