using System;

namespace EscuelaSimple.Aplicacion.Entidades.TiposBase
{
    public abstract class ObjetoValor<TTipo> : IEquatable<TTipo>, IComparable, IComparable<TTipo>
        where TTipo : class, IEquatable<TTipo>, IComparable, IComparable<TTipo>
    {
        public abstract bool Equals(TTipo other);
        public abstract int CompareTo(object obj);
        public abstract int CompareTo(TTipo other);
    }
}
