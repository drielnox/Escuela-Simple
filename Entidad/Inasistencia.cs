using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Entidad
{
    public class Inasistencia : IEntity<uint>
    {
        public virtual uint Id { get; set; }
        public virtual string Motivo { get; set; }
        public virtual DateTime Desde { get; set; }
        public virtual DateTime Hasta { get; set; }

        public Inasistencia()
        {

        }

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

            return this.Id.Equals(inasistencia.Id) &&
                this.Motivo.Equals(inasistencia.Motivo) &&
                this.Desde.Equals(inasistencia.Desde) &&
                this.Hasta.Equals(inasistencia.Hasta);
        }

        public override int GetHashCode()
        {
            string hashCode = this.Id + "|" + this.Motivo + "|" + this.Desde + "|" + this.Hasta;
            return hashCode.GetHashCode();
        }
    }
}
