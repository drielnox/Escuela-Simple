using EscuelaSimple.Aplicacion.Entidades.Contratos;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Xml.Serialization;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Inasistencia : Entidad<int, Inasistencia>
    {
        public string Motivo { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Inasistencia inasistencia = obj as Inasistencia;
            if (inasistencia == null)
            {
                return false;
            }

            return base.Equals(obj) &&
                this.Motivo.Equals(inasistencia.Motivo) &&
                this.Desde.Equals(inasistencia.Desde) &&
                this.Hasta.Equals(inasistencia.Hasta);
        }

        public override bool Equals(Inasistencia other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                this.Motivo.Equals(other.Motivo) &&
                this.Desde.Equals(other.Desde) &&
                this.Hasta.Equals(other.Hasta);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                this.Motivo.GetHashCode() ^
                this.Desde.GetHashCode() ^
                this.Hasta.GetHashCode();
        }
    }
}
