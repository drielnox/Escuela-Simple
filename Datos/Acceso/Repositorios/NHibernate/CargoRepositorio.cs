using EscuelaSimple.Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class CargoRepositorio : NHibernateRepositorio<Cargo, int>, ICargoRepositorio
    {
        public CargoRepositorio(ISession sesion)
            : base(sesion)
        {

        }
    }

    internal interface ICargoRepositorio : IRepositorio<Cargo, int>
    {

    }
}
