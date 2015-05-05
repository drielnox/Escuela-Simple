using EscuelaSimple.Modelos;
using EscuelaSimple.Datos;
using EscuelaSimple.Datos.Repositorio;
using EscuelaSimple.Datos.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using NHibernate.Engine;
using System.Collections.ObjectModel;

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
                IEnumerable<Personal> listaPersonal = this._repoPersonal.ObtenerTodo();
                //this._unitOfWork.SaveChanges();
                return listaPersonal as List<Personal>;
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
                IEnumerable<Personal> listaPersonal = this._repoPersonal.FiltrarPor(x =>
                {
                    return x.Apellido.ToLower().StartsWith(personal.Apellido.ToLower()) ||
                        x.DNI.ToString().ToLower().StartsWith(personal.DNI.ToString().ToLower());
                });
                //this._unitOfWork.SaveChanges();
                return listaPersonal as List<Personal>;
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
                this._repoPersonal.Borrar(personalSeleccionado);
                //this._unitOfWork.SaveChanges();
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
                this._repoPersonal.Crear(personalAGuardar);
                //this._unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarPersonal(Personal personalAGuardar)
        {
            try
            {
                this._repoPersonal.Actualizar(personalAGuardar);
                //this._unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
