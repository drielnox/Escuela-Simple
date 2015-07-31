﻿using EscuelaSimple.Modelos;
using NHibernate;

namespace EscuelaSimple.Datos.Repositorio.NHibernate
{
    public class TipoTelefonoRepositorio : NHibernateRepositorio<TipoTelefono, int>, ITipoTelefonoRepositorio
    {
        public TipoTelefonoRepositorio(ISession session)
            : base(session)
        {

        }
    }

    public interface ITipoTelefonoRepositorio : IRepositorio<TipoTelefono, int>
    {

    }
}
