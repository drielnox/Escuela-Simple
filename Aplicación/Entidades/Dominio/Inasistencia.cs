using EscuelaSimple.Aplicacion.Entidades.Contratos;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Xml.Serialization;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Inasistencia : Entidad<int, Inasistencia>
    {
        public virtual int Identificador { get; set; }
        public virtual string Motivo { get; set; }
        public virtual DateTime Desde { get; set; }
        public virtual DateTime Hasta { get; set; }

        public override bool Equals(Inasistencia obj)
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

            return this.Identificador.Equals(inasistencia.Identificador) &&
                this.Motivo.Equals(inasistencia.Motivo) &&
                this.Desde.Equals(inasistencia.Desde) &&
                this.Hasta.Equals(inasistencia.Hasta);
        }

        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" + this.Motivo + "|" + this.Desde + "|" + this.Hasta;
            return hashCode.GetHashCode();
        }

        public override int CompareTo(Inasistencia other)
        {
            throw new NotImplementedException();
        }
    }
}
