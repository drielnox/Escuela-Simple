using EscuelaSimple.Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class SituacionRevistaRepositorio : NHibernateRepositorio<SituacionRevista, int>, ISituacionRevistaRepositorio
    {
        public SituacionRevistaRepositorio(ISession sesion)
            : base(sesion)
        {

        }
    }

    internal interface ISituacionRevistaRepositorio : IRepositorio<SituacionRevista, int>
    {

    }
}
