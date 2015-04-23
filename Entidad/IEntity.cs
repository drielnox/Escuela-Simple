using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Entidad
{
    public interface IEntity<TKey> 
        where TKey : struct
    {
        TKey Id { get; set; }
    }
}
