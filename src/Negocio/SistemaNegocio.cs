﻿using EscuelaSimple.Datos;

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