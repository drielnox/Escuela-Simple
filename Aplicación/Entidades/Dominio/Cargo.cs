using EscuelaSimple.Aplicacion.Entidades.Contratos;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Cargo : Entidad<int, Cargo>
    {
        public virtual int Identificador { get; set; }
        public virtual byte Secuencia { get; set; }
        public virtual ICollection<Funcion> Funciones { get; protected set; }

        public Cargo()
        {
            this.Secuencia = default(byte);
            this.Funciones = new List<Funcion>();
        }

        public virtual void AgregarFuncion(Funcion funcion)
        {
            if (!this.Funciones.Contains(funcion))
            {
                this.Funciones.Add(funcion);
            }
        }

        public virtual void QuitarFuncion(Funcion funcion)
        {
            if (this.Funciones.Contains(funcion))
            {
                this.Funciones.Remove(funcion);
            }
        }

        public virtual string ObtenerCargoActualAbreviacion()
        {
            string abreviacion = string.Empty;

            foreach (Funcion item in this.Funciones)
            {
                if (item.SituacionDeRevista.Descripcion == "Titular")
                {
                    abreviacion = item.Tarea.Abreviacion;
                    break;
                }
            }

            return abreviacion;
        }

        public virtual string ObtenerCargoActualDescripcionLarga()
        {
            string descripcion = string.Empty;

            foreach (Funcion item in this.Funciones)
            {
                if (item.SituacionDeRevista.Descripcion == "Titular")
                {
                    descripcion = item.Tarea.Descripcion;
                    break;
                }
            }

            return descripcion;
        }

        public override bool Equals(Cargo obj)
        {
            if (obj == null)
            {
                return false;
            }

            Cargo cargo = obj as Cargo;
            if (cargo == null)
            {
                return false;
            }

            return this.Identificador.Equals(cargo.Identificador) &&
                this.Secuencia.Equals(cargo.Secuencia) &&
                this.Funciones.Equals(cargo.Funciones);
        }

        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" +
                this.Secuencia + "|" +
                this.Funciones;
            return hashCode.GetHashCode();
        }

        public override string ToString()
        {
            return "Cargo " + this.Secuencia + " - " + this.ObtenerCargoActualDescripcionLarga();
        }

        public override int CompareTo(Cargo other)
        {
            throw new NotImplementedException();
        }
    }
}