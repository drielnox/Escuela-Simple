using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Personal : Entidad<int, Personal>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public string Barrio { get; set; }
        public string Localidad { get; set; }
        public virtual ICollection<Telefono> Telefonos { get; protected set; }
        public DateTime? IngresoDocencia { get; set; }
        public DateTime? IngresoEstablecimiento { get; set; }
        public virtual ICollection<Titulo> Titulos { get; protected set; }
        public virtual ICollection<Cargo> Cargos { get; protected set; }
        public string Observacion { get; set; }
        public virtual ICollection<Inasistencia> Inasistencias { get; protected set; }

        public Personal()
        {
            this.Telefonos = new List<Telefono>();
            this.Titulos = new List<Titulo>();
            this.Cargos = new List<Cargo>();
            this.Inasistencias = new List<Inasistencia>();
        }

        public virtual void AgregarTelefono(Telefono telefono)
        {
            if (!this.Telefonos.Contains(telefono))
            {
                this.Telefonos.Add(telefono);
            }
        }

        public virtual void QuitarTelefono(Telefono telefono)
        {
            if (this.Telefonos.Contains(telefono))
            {
                this.Telefonos.Remove(telefono);
            }
        }

        public virtual void AgregarTitulo(Titulo titulo)
        {
            if (!this.Titulos.Contains(titulo))
            {
                this.Titulos.Add(titulo);
            }
        }

        public virtual void QuitarTitulo(Titulo titulo)
        {
            if (this.Titulos.Contains(titulo))
            {
                this.Titulos.Remove(titulo);
            }
        }

        public virtual void AgregarCargo(Cargo cargo)
        {
            if (!this.Cargos.Contains(cargo))
            {
                this.Cargos.Add(cargo);
            }
        }

        public virtual void QuitarCargo(Cargo cargo)
        {
            if (this.Cargos.Contains(cargo))
            {
                this.Cargos.Remove(cargo);
            }
        }

        public virtual void AgregarInasistencia(Inasistencia inasistencia)
        {
            if (!this.Inasistencias.Contains(inasistencia))
            {
                this.Inasistencias.Add(inasistencia);
            }
        }

        public virtual void QuitarInasistencia(Inasistencia inasistencia)
        {
            if (this.Inasistencias.Contains(inasistencia))
            {
                this.Inasistencias.Remove(inasistencia);
            }
        }

        public override bool Equals(Personal obj)
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
                this.IngresoEstablecimiento + "|" + this.Titulos + "|" + this.Cargos + "|" +
                this.Observacion + "|" + this.Inasistencias;
            return hashCode.GetHashCode();
        }

        public override int CompareTo(Personal other)
        {
            throw new NotImplementedException();
        }
    }
}
