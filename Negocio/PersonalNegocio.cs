using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscuelaSimple.Entidad;
using EscuelaSimple.Modelo;
using EscuelaSimple.Modelo.Repositorio;
using EscuelaSimple.Modelo.UnidadDeTrabajo;

namespace EscuelaSimple.Negocio
{
    public class PersonalNegocio
    {
        private IUnidadDeTrabajo _unitOfWork;
        private IPersonalRepositorio _repoPersonal;

        public PersonalNegocio()
        {
            this._unitOfWork = new NHibernateUnidadDeTrabajo(NHibernateWrapper.CurrentSession);
            this._repoPersonal = new PersonalRepositorio(NHibernateWrapper.CurrentSession);
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
                this._unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
