
namespace EscuelaSimple.Entidad
{
    public class TipoTelefono : IEntity<uint>
    {
        public virtual uint Id { get; set; }
        public virtual string Descripcion { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            TipoTelefono tipo = obj as TipoTelefono;
            if (tipo == null)
            {
                return false;
            }

            return this.Id.Equals(tipo.Id) &&
                this.Descripcion.Equals(tipo.Descripcion);
        }

        public override int GetHashCode()
        {
            string hashCode = this.Id + "|" + this.Descripcion;
            return hashCode.GetHashCode();
        }
    }
}
