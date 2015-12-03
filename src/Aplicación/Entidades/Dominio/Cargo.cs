using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System.Collections.Generic;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Cargo : Entidad<int, Cargo>
    {
        #region Propiedades

        public byte Secuencia { get; set; }
        public virtual ICollection<Funcion> Funciones { get; protected set; }

        #region Propiedades de Navegacion

        public int IdPersonal { get; set; }
        public Personal PersonalAsociado { get; set; }

        #endregion

        #endregion
        
        public Cargo()
        {
            Secuencia = default(byte);
            Funciones = new List<Funcion>();
        }

        public void AgregarFuncion(Funcion funcion)
        {
            if (!Funciones.Contains(funcion))
            {
                Funciones.Add(funcion);
            }
        }

        public void QuitarFuncion(Funcion funcion)
        {
            if (Funciones.Contains(funcion))
            {
                Funciones.Remove(funcion);
            }
        }

        public string ObtenerCargoActualAbreviacion()
        {
            string abreviacion = string.Empty;

            foreach (Funcion item in Funciones)
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

            foreach (Funcion item in Funciones)
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
                Secuencia.Equals(other.Secuencia) &&
                Funciones.Equals(other.Funciones);
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
                Secuencia.Equals(cargo.Secuencia) &&
                Funciones.Equals(cargo.Funciones);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                Secuencia.GetHashCode() ^
                Funciones.GetHashCode();
        }

        public override string ToString()
        {
            return "Cargo " + Secuencia + " - " + ObtenerCargoActualDescripcionLarga();
        }
    }
}