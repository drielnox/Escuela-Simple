
using System.Xml.Serialization;

namespace EscuelaSimple.Entidad
{
    public interface IEntity<TKey>
        where TKey : struct
    {
        [XmlAttribute]
        TKey Id { get; set; }
    }
}
