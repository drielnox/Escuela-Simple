using EscuelaSimple.Aplicacion.Entidades.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Aplicacion.Entidades.TiposBase
{
    public abstract class Entidad<TIdentificador> : ObjetoValor, IEntidad<TIdentificador>
    {
        public abstract TIdentificador Identificador { get; set; }
    }
}
