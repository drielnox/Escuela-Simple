using EscuelaSimple.Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class FuncionRepostorio : NHibernateRepositorio<Funcion, int>, IFuncionRepositorio
    {
        public FuncionRepostorio(ISession sesion)
            : base(sesion)
        {

        }
    }

    internal interface IFuncionRepositorio : IRepositorio<Funcion, int>
    {

    }
}