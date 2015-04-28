using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EscuelaSimple.Entidad
{
    [Serializable()]
    public class Personal : IEntity<uint>
    {
        public virtual uint Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual uint DNI { get; set; }
        public virtual DateTime FechaNacimiento { get; set; }
        public virtual string Domicilio { get; set; }
        public virtual string Localidad { get; set; }
        public virtual IEnumerable<Telefono> Telefonos { get; set; }
        public virtual DateTime? IngresoDocencia { get; set; }
        public virtual DateTime? IngresoEstablecimiento { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Cargo { get; set; }
        public virtual string SituacionRevista { get; set; }
        public virtual string Observacion { get; set; }
        public virtual IEnumerable<Inasistencia> Inasistencias { get; set; }

        public Personal()
        {
            this.Telefonos = new List<Telefono>();
            this.Inasistencias = new List<Inasistencia>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Personal personal = obj as Personal;
            if (personal == null)
            {
                return false;
            }

            return this.Id.Equals(personal.Id) &&
                this.Nombre.Equals(personal.Nombre) &&
                this.Apellido.Equals(personal.Apellido) &&
                this.DNI.Equals(personal.DNI) &&
                this.FechaNacimiento.Equals(personal.FechaNacimiento);
        }

        public override int GetHashCode()
        {
            string hashCode = this.Id + "|" + this.Nombre + "|" + this.Apellido + "|" +
                this.DNI + "|" + this.FechaNacimiento + "|" + this.Domicilio + "|" +
                this.Localidad + "|" + this.Telefonos + "|" + this.IngresoDocencia + "|" +
                this.IngresoEstablecimiento + "|" + this.Titulo + "|" + this.Cargo + "|" +
                this.SituacionRevista + "|" + this.Observacion + "|" + this.Inasistencias;
            return hashCode.GetHashCode();
        }
    }
}
