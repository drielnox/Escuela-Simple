
using System.Xml.Serialization;

namespace EscuelaSimple.Modelos
{
    public interface IEntidad<TClavePrimaria>
        where TClavePrimaria : struct
    {
        TClavePrimaria Identificador { get; set; }
    }
}
