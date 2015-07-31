using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Aplicacion.Entidades.TiposBase
{
    public abstract class ObjetoValor : IEquatable<ObjetoValor>, IComparable<ObjetoValor>
    {
        public abstract bool Equals(ObjetoValor other);
        public abstract int CompareTo(ObjetoValor other);
    }
}
