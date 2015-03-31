﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olfrad.EscuelaSimple.Entidad;
using NHibernate;

namespace Olfrad.EscuelaSimple.Modelo.Repositorio
{
    public class PersonalRepository : NHibernateRepository<Personal, uint>, IPersonalRepository
    {
        public PersonalRepository(ISession session)
            : base(session)
        {

        }
    }

    public interface IPersonalRepository : IRepository<Personal, uint>
    {
    }
}