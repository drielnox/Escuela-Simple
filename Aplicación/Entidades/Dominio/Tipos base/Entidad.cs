using EscuelaSimple.Aplicacion.Entidades.Contratos;
using System;

namespace EscuelaSimple.Aplicacion.Entidades.TiposBase
{
    public abstract class Entidad<TIdentificador, TTipo> : ObjetoValor<TTipo>, IEntidad<TIdentificador>
        where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
        where TTipo : Entidad<TIdentificador, TTipo>
    {
        public TIdentificador Identificador { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Entidad<TIdentificador, TTipo> entidad = obj as Entidad<TIdentificador, TTipo>;
            if (entidad == null)
            {
                return false;
            }

            return Identificador.Equals(entidad.Identificador);
        }

        public override bool Equals(TTipo other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Identificador.Equals(other.Identificador);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                this.Identificador.GetHashCode();
        }

        public override int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            Entidad<TIdentificador, TTipo> entidad = obj as Entidad<TIdentificador, TTipo>;
            if (entidad == null)
            {
                string mensaje = string.Format("obj no es {0}", typeof(TTipo).Name);
                throw new ArithmeticException(mensaje);
            }

            return this.Identificador.CompareTo(entidad.Identificador);
        }

        public override int CompareTo(TTipo other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            return this.Identificador.CompareTo(other.Identificador);
        }
    }
}
