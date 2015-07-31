using EscuelaSimple.Modelos;
using EscuelaSimple.Datos;
using EscuelaSimple.Datos.Repositorio.NHibernate;
using EscuelaSimple.Datos.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using NHibernate.Engine;
using System.Collections.ObjectModel;

namespace EscuelaSimple.Negocio
{
    public class PersonalNegocio
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IPersonalRepositorio _repositorio;

        public PersonalNegocio()
        {
            this._unidadDeTrabajo = new NHibernateUnidadDeTrabajo(NHibernateWrapper.SesionActual);
            this._repositorio = new PersonalRepositorio(NHibernateWrapper.SesionActual);
        }

        public List<Personal> ObtenerTodoPersonal()
        {
            try
            {
                IEnumerable<Personal> listaPersonal = this._repositorio.ObtenerTodo();
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
                IEnumerable<Personal> listaPersonal = this._repositorio.FiltrarPor(x =>
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
                this._repositorio.Borrar(personalSeleccionado);
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
                this._repositorio.Crear(personalAGuardar);
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
                this._repositorio.Actualizar(personalAGuardar);
                //this._unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
