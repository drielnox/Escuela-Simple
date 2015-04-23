using EscuelaSimple.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Negocio
{
    public class SistemaNegocio
    {
        public void ValidarEsquema()
        {
            NHibernateWrapper.ValidateSchema();
        }

        public void CrearBaseDeDatos()
        {
            NHibernateWrapper.CreateDabataseSchema();
        }

        public void InstarDatosEjemplo()
        {
            NHibernateWrapper.InsertTestData();
        }
    }
}
