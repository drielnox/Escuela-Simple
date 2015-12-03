using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscuelaSimple.Aplicacion.Componentes.Negocio
{
    public class InasistenciaNegocio
    {
        public List<Inasistencia> ObtenerInasistenciaPorPersonal(Personal personal)
        {
            List<Inasistencia> listaInasistencia = new List<Inasistencia>();

            try
            {
                using (var contexto = new EscuelaSimpleContext())
                {
                    listaInasistencia = contexto.Inasistencia
                        .Where(x => x.PersonalAsociado.Equals(personal))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaInasistencia;
        }
    }
}
