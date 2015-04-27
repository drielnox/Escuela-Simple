
namespace EscuelaSimple.Entidad
{
    public class Telefono : IEntity<uint>
    {
        public virtual uint Id { get; set; }
        public virtual TipoTelefono Tipo { get; set; }
        public virtual uint Numero { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Telefono telefono = obj as Telefono;
            if (telefono == null)
            {
                return false;
            }

            return this.Id.Equals(telefono.Id) &&
                this.Tipo.Equals(telefono.Tipo) &&
                this.Numero.Equals(telefono.Numero);
        }

        public override int GetHashCode()
        {
            string hashCode = this.Id + "|" + this.Tipo.GetHashCode() + "|" + this.Numero;
            return hashCode.GetHashCode();
        }
    }
}
