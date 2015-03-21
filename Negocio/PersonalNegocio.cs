using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olfrad.EscuelaSimple.Entidad;
using Olfrad.EscuelaSimple.Modelo;
using Olfrad.EscuelaSimple.Modelo.Repositorio;
using Olfrad.EscuelaSimple.Modelo.UnidadDeTrabajo;

namespace Olfrad.EscuelaSimple.Negocio
{
    public class PersonalNegocio
    {
        private IUnitOfWork _unitOfWork;
        private IPersonalRepository _repoPersonal;

        public PersonalNegocio()
        {
            this._unitOfWork = new NHibernateUnitOfWork(NHibernateWrapper.CurrentSession);
            this._repoPersonal = new PersonalRepository(NHibernateWrapper.CurrentSession);
        }

        public List<Personal> ObtenerTodoPersonal()
        {
            try
            {
                return this._repoPersonal.GetAll() as List<Personal>;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Personal> ObtenerPersonal(Personal personal)
        {
            try
            {
                return this._repoPersonal.FilterBy(x =>
                {
                    return x.Apellido.ToLower().StartsWith(personal.Apellido.ToLower()) ||
                        x.DNI.ToString().ToLower().StartsWith(personal.DNI.ToString().ToLower());
                }) as List<Personal>;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BorrarPersonal(Personal personalSeleccionado)
        {
            try
            {
                this._repoPersonal.Delete(personalSeleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void GuardarPersonal(Personal personalAGuardar)
        {
            try
            {
                this._repoPersonal.Create(personalAGuardar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
