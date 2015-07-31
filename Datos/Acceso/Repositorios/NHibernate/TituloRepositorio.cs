using EscuelaSimple.Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class TituloRepositorio : NHibernateRepositorio<Titulo, int>, ITituloRepositorio
    {
        public TituloRepositorio(ISession sesion)
            : base(sesion)
        {

        }
    }

    internal interface ITituloRepositorio : IRepositorio<Titulo, int>
    {

    }
}
