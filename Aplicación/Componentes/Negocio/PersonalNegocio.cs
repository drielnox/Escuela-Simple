using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscuelaSimple.Aplicacion.Componentes.Negocio
{
    public class PersonalNegocio
    {
        public List<Personal> ObtenerTodoPersonal()
        {
            List<Personal> listaPersonal = new List<Personal>();

            try
            {
                using (var contexto = new EscuelaSimpleContext())
                {
                    listaPersonal = contexto.Personal.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaPersonal;
        }

        public List<Personal> ObtenerPersonal(Personal personal)
        {
            List<Personal> listaPersonal = new List<Personal>();

            try
            {
                using (var contexto = new EscuelaSimpleContext())
                {
                    listaPersonal = contexto.Personal
                        .Where<Personal>(x => 
                            x.Apellido.ToLower().StartsWith(personal.Apellido.ToLower()) ||
                            x.DNI.ToString().ToLower().StartsWith(personal.DNI.ToString().ToLower())
                            )
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaPersonal as List<Personal>;
        }

        public void BorrarPersonal(Personal personalSeleccionado)
        {
            try
            {
                using (var contexto = new EscuelaSimpleContext())
                {
                    contexto.Personal.Remove(personalSeleccionado);

                    contexto.SaveChanges();
                }
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
                using (var contexto = new EscuelaSimpleContext())
                {
                    contexto.Personal.Add(personalAGuardar);

                    contexto.SaveChanges();
                }
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
                using (var contexto = new EscuelaSimpleContext())
                {
                    var personalAActualizar = contexto.Personal.Where<Personal>(x => x.Identificador == personalAGuardar.Identificador).First<Personal>();
                    personalAActualizar = personalAGuardar;

                    contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
