using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System;

namespace EscuelaSimple.Aplicacion.Entidades
{
    public class Inasistencia : Entidad<int, Inasistencia>
    {
        #region Propiedades

        public string Motivo { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

        #region Propiedades de Navegacion

        public int IdPersonal { get; set; }
        public Personal PersonalAsociado { get; set; }

        #endregion

        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Inasistencia inasistencia = obj as Inasistencia;
            if (inasistencia == null)
            {
                return false;
            }

            return base.Equals(obj) &&
                Motivo.Equals(inasistencia.Motivo) &&
                Desde.Equals(inasistencia.Desde) &&
                Hasta.Equals(inasistencia.Hasta);
        }

        public override bool Equals(Inasistencia other)
        {
            if (other == null)
            {
                return false;
            }

            return base.Equals(other) &&
                Motivo.Equals(other.Motivo) &&
                Desde.Equals(other.Desde) &&
                Hasta.Equals(other.Hasta);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^
                Motivo.GetHashCode() ^
                Desde.GetHashCode() ^
                Hasta.GetHashCode();
        }
    }
}
