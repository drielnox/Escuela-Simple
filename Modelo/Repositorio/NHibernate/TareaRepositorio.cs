using EscuelaSimple.Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class TareaRepositorio : NHibernateRepositorio<Tarea, int>, ITareaRepositorio
    {
        public TareaRepositorio(ISession sesion)
            : base(sesion)
        {

        }
    }

    internal interface ITareaRepositorio : IRepositorio<Tarea, int>
    {

    }
}
