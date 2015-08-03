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
        public override int Identificador { get; set; }
        public byte Secuencia { get; set; }
        public virtual ICollection<Funcion> Funciones { get; protected set; }

        public Cargo()
        {
            this.Secuencia = default(byte);
            this.Funciones = new List<Funcion>();
        }

        public void AgregarFuncion(Funcion funcion)
        {
            if (!this.Funciones.Contains(funcion))
            {
                this.Funciones.Add(funcion);
            }
        }

        public void QuitarFuncion(Funcion funcion)
        {
            if (this.Funciones.Contains(funcion))
            {
                this.Funciones.Remove(funcion);
            }
        }

        public string ObtenerCargoActualAbreviacion()
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

        public string ObtenerCargoActualDescripcionLarga()
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

        public override bool Equals(Cargo other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                this.Secuencia.Equals(other.Secuencia) &&
                this.Funciones.Equals(other.Funciones);
        }

        public override bool Equals(object obj)
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

            return base.Equals(obj) &&
                this.Secuencia.Equals(cargo.Secuencia) &&
                this.Funciones.Equals(cargo.Funciones);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                this.Secuencia.GetHashCode() ^
                this.Funciones.GetHashCode();
        }

        public override string ToString()
        {
            return "Cargo " + this.Secuencia + " - " + this.ObtenerCargoActualDescripcionLarga();
        }
    }
}