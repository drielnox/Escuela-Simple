using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Modelos
{
    public class Cargo : IEntidad<int>
    {
        public virtual int Identificador { get; set; }
        public virtual ICollection<Funcion> Funciones { get; protected set; }

        public Cargo()
        {
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

        // override object.Equals
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

            return this.Identificador.Equals(cargo.Identificador) &&
                this.Funciones.Equals(cargo.Funciones);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            string hashCode = this.Identificador + "|" +
                this.Funciones;
            return hashCode.GetHashCode();
        }
    }
}
