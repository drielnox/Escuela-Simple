using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo;
using EscuelaSimple.Aplicacion.Entidades;
using System.Linq;

namespace EscuelaSimple.Datos.Acceso.Repositorios.Pruebas.EntityFramework
{
    [TestClass]
    public class TipoTelefonoRepositorioPrueba
    {
        [TestMethod]
        public void PuedoAgregarUnNuevoTipoDeTelefono()
        {
            var unTipoTelefono = new TipoTelefono() { Identificador = 1, Descripcion = "Fax" };

            using (var contexto = new EscuelaSimpleContext())
            {
                contexto.TipoTelefono.Add(new TipoTelefono() { Descripcion = "Fax" });

                contexto.SaveChanges();
            }

            TipoTelefono resultado;

            using (var contexto = new EscuelaSimpleContext())
            {
		        resultado = contexto
                    .TipoTelefono
                    .Where(x => x.Descripcion == "Fax")
                    .First();
            }

            Assert.IsNotNull(resultado);
            Assert.AreEqual<TipoTelefono>(unTipoTelefono, resultado);
        }
    }
}
