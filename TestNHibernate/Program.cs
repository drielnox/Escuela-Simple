using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olfrad.EscuelaSimple.Modelo;

namespace TestNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            NHibernateWrapper.CreateDabataseSchema();
            NHibernateWrapper.ValidateSchema();
            NHibernateWrapper.InsertTestData();
        }
    }
}
