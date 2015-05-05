using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EscuelaSimple.Modelos
{
    [Serializable]
    public class Personal : IEntidad<int>
    {
        [XmlAttribute]
        public virtual int Identificador { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual int DNI { get; set; }
        public virtual DateTime FechaNacimiento { get; set; }
        public virtual string Domicilio { get; set; }
        public virtual string Localidad { get; set; }
        [XmlIgnore]
        public virtual ICollection<Telefono> Telefonos { get; protected set; }
        [XmlElementAttribute(IsNullable = true)]
        public virtual DateTime? IngresoDocencia { get; set; }
        [XmlElementAttribute(IsNullable = true)]
        public virtual DateTime? IngresoEstablecimiento { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Cargo { get; set; }
        public virtual string SituacionRevista { get; set; }
        public virtual string Observacion { get; set; }
        [XmlIgnore]
        public virtual ICollection<Inasistencia> Inasistencias { get; protected set; }

        public Personal()
        {
            this.Telefonos = new List<Telefono>();
            this.Inasistencias = new List<Inasistencia>();
        }

        public void AgregarTelefono(Telefono telefono)
        {
            if (!this.Telefonos.Contains(telefono))
            {
                this.Telefonos.Add(telefono);
            }
        }

        public void QuitarTelefono(Telefono telefono)
        {
            if (this.Telefonos.Contains(telefono))
            {
                this.Telefonos.Remove(telefono);
            }
        }

        public void AgregarInasistencia(Inasistencia inasistencia)
        {
            if (!this.Inasistencias.Contains(inasistencia))
            {
                this.Inasistencias.Add(inasistencia);
            }
        }

        public void QuitarInasistencia(Inasistencia inasistencia)
        {
            if (this.Inasistencias.Contains(inasistencia))
            {
                this.Inasistencias.Remove(inasistencia);
            }
        }

        #region Sobrecarga a Object

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

            return this.Identificador.Equals(personal.Identificador) &&
                this.Nombre.Equals(personal.Nombre) &&
                this.Apellido.Equals(personal.Apellido) &&
                this.DNI.Equals(personal.DNI) &&
                this.FechaNacimiento.Equals(personal.FechaNacimiento);
        }

        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" + this.Nombre + "|" + this.Apellido + "|" +
                this.DNI + "|" + this.FechaNacimiento + "|" + this.Domicilio + "|" +
                this.Localidad + "|" + this.Telefonos + "|" + this.IngresoDocencia + "|" +
                this.IngresoEstablecimiento + "|" + this.Titulo + "|" + this.Cargo + "|" +
                this.SituacionRevista + "|" + this.Observacion + "|" + this.Inasistencias;
            return hashCode.GetHashCode();
        }

        #endregion
    }
}
