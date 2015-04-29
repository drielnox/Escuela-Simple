
using System.Xml.Serialization;

namespace EscuelaSimple.Entidad
{
    public interface IEntidad<TClavePrimaria>
        where TClavePrimaria : struct
    {
        [XmlAttribute]
        TClavePrimaria Identificador { get; set; }
    }
}
