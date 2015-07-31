using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EscuelaSimple.Datos.UnidadDeTrabajo;
using EscuelaSimple.Datos;
using EscuelaSimple.Modelos;
using EscuelaSimple.Datos.Repositorio.NHibernate;

namespace PruebasDatos
{
    /// <summary>
    /// Descripción resumida de PersonalRepositorioPrueba
    /// </summary>
    [TestClass]
    public class PersonalRepositorioPrueba
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; set; }
        public IPersonalRepositorio Repositorio { get; set; }

        public PersonalRepositorioPrueba()
        {
            this.UnidadDeTrabajo = new NHibernateUnidadDeTrabajo(NHibernateWrapper.SesionActual);
            this.Repositorio = new PersonalRepositorio(NHibernateWrapper.SesionActual);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) { }

        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        [ClassCleanup()]
        public static void MyClassCleanup() { }

        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        [TestInitialize()]
        public void MyTestInitialize() { }

        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        [TestCleanup()]
        public void MyTestCleanup() { }

        #endregion

        [TestMethod]
        public void PuedoObtenerUnPersonalPorIdentificadorCuandoExiste()
        {
            var personal = this.Repositorio.ObtenerPorIdentificador(1);

            Assert.IsNotNull(personal);
        }

        [TestMethod]
        public void PuedoObtenerUnPersonalPorIdentificadorCuandoNoExiste()
        {
            var personal = this.Repositorio.ObtenerPorIdentificador(10);

            Assert.IsNull(personal);
        }

        [TestMethod]
        public void PuedoObtenerUnPersonalPorUnCriterioCuandoExiste()
        {
            var personal = this.Repositorio.ObtenerPor(x => x.Nombre == "Jose");

            Assert.IsNotNull(personal);
        }

        [TestMethod]
        public void PuedoObtenerUnPersonalPorCriterioCuandoNoExiste()
        {
            var personal = this.Repositorio.ObtenerPor(x => x.Nombre == "Ernesto");

            Assert.IsNull(personal);
        }

        [TestMethod]
        public void PuedoAgregarUnPersonalCuandoNoExiste()
        {
            var personal = new Personal() { Nombre = "Jose", Apellido = "Barrionuevo", DNI = 13456789, FechaNacimiento = new DateTime(2012, 5, 1), Domicilio = "Alejandria 25", Barrio = "San Miguel", Localidad = "Carranza", IngresoDocencia = new DateTime(2012, 6, 4), IngresoEstablecimiento = new DateTime(2001, 7, 13), Observacion = "Una observacion sobre el personal." };
            this.Repositorio.Crear(personal);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void PuedoAgregarUnPersonalCuandoExiste()
        {
            var personalExistente = new Personal() { Nombre = "Jose", Apellido = "Barrionuevo", DNI = 13456789, FechaNacimiento = new DateTime(2012, 5, 1), Domicilio = "Alejandria 25", Barrio = "San Miguel", Localidad = "Carranza", IngresoDocencia = new DateTime(2012, 6, 4), IngresoEstablecimiento = new DateTime(2001, 7, 13), Observacion = "Una observacion sobre el personal." };
            this.Repositorio.Crear(personalExistente);

            Assert.Fail();
        }

        [TestMethod]
        public void PuedoModificarUnPersonalCuandoExiste()
        {
            var personal = this.Repositorio.ObtenerPorIdentificador(1);
            personal.Nombre = "Alberto";
            personal.Apellido = "Magnifico";
            this.Repositorio.Actualizar(personal);

            this.UnidadDeTrabajo.GuardarCambios();

            var personal2 = this.Repositorio.ObtenerPorIdentificador(1);

            Assert.AreNotEqual(personal2, personal);
        }

        [TestMethod]
        public void PuedoModificarUnPersonalCuandoNoExiste()
        {
            var personalInexistente = this.Repositorio.ObtenerPorIdentificador(10);
            this.Repositorio.Actualizar(personalInexistente);
            this.UnidadDeTrabajo.GuardarCambios();

            Assert.Fail();
        }

        [TestMethod]
        public void PuedoBorrarUnPersonalCuandoExiste()
        {
            var personalABorrar = this.Repositorio.ObtenerPorIdentificador(1);
            this.Repositorio.Borrar(personalABorrar);
            this.UnidadDeTrabajo.GuardarCambios();
            var personalBorrado = this.Repositorio.ObtenerPorIdentificador(1);

            Assert.IsNull(personalBorrado);
        }

        [TestMethod]
        public void PuedoBorrarUnPersonalCuandoNoExiste()
        {
            var personalABorrar = this.Repositorio.ObtenerPorIdentificador(1);
            this.Repositorio.Borrar(personalABorrar);
            this.UnidadDeTrabajo.GuardarCambios();

            Assert.Fail();
        }

        [TestMethod]
        public void PuedoObtenerUnaListaDePersonalCuandoHay()
        {
            var listaPersonal = this.Repositorio.ObtenerTodo();

            Assert.IsNotNull(listaPersonal);
        }

        [TestMethod]
        public void PuedoObtenerUnaListaDePersonalCuandoNoHay()
        {
            var listaPersonal = this.Repositorio.ObtenerTodo();

            Assert.Fail();
        }

        [TestMethod]
        public void PuedoAgregarVariosPersonales()
        {
            var personal1 = new Personal() { Nombre = "Jose", Apellido = "Barrionuevo", DNI = 13456789, FechaNacimiento = new DateTime(2012, 5, 1), Domicilio = "Alejandria 25", Barrio = "San Miguel", Localidad = "Carranza", IngresoDocencia = new DateTime(2012, 6, 4), IngresoEstablecimiento = new DateTime(2001, 7, 13), Observacion = "Una observacion sobre el personal." };
            var personal2 = new Personal() { Nombre = "Pepe", Apellido = "Guardala", DNI = 32659874, FechaNacimiento = new DateTime(1987, 3, 29), Domicilio = "Menguado 937", Barrio = "Iconico", Localidad = "Villa Ulara", IngresoDocencia = new DateTime(2000, 3, 12), IngresoEstablecimiento = new DateTime(1999, 12, 25), Observacion = "Una observacion sobre el personal." };

            foreach (var item in new[] { personal1, personal2 })
            {
                this.Repositorio.Crear(item);
            }

            this.UnidadDeTrabajo.GuardarCambios();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void PuedoAgregarVariosPersonalesRepetidos()
        {
            var personal1 = new Personal() { Nombre = "Jose", Apellido = "Barrionuevo", DNI = 13456789, FechaNacimiento = new DateTime(2012, 5, 1), Domicilio = "Alejandria 25", Barrio = "San Miguel", Localidad = "Carranza", IngresoDocencia = new DateTime(2012, 6, 4), IngresoEstablecimiento = new DateTime(2001, 7, 13), Observacion = "Una observacion sobre el personal." };

            foreach (var item in new[] { personal1, personal1 })
            {
                this.Repositorio.Crear(item);
            }

            this.UnidadDeTrabajo.GuardarCambios();

            Assert.Fail();
        }

        [TestMethod]
        public void PuedoAgregarVariosPersonalesCuandoUnoYaExiste()
        {
            var personal1 = new Personal() { Nombre = "Jose", Apellido = "Barrionuevo", DNI = 13456789, FechaNacimiento = new DateTime(2012, 5, 1), Domicilio = "Alejandria 25", Barrio = "San Miguel", Localidad = "Carranza", IngresoDocencia = new DateTime(2012, 6, 4), IngresoEstablecimiento = new DateTime(2001, 7, 13), Observacion = "Una observacion sobre el personal." };
            var personal2 = new Personal() { Nombre = "Pepe", Apellido = "Guardala", DNI = 32659874, FechaNacimiento = new DateTime(1987, 3, 29), Domicilio = "Menguado 937", Barrio = "Iconico", Localidad = "Villa Ulara", IngresoDocencia = new DateTime(2000, 3, 12), IngresoEstablecimiento = new DateTime(1999, 12, 25), Observacion = "Una observacion sobre el personal." };

            foreach (var item in new[] { personal1, personal2 })
            {
                this.Repositorio.Crear(item);
            }

            this.UnidadDeTrabajo.GuardarCambios();

            Assert.Fail();
        }

        [TestMethod]
        public void PuedoAgregarVariosPersonalesCuandoAmbosYaExiste()
        {
            var personal1 = new Personal() { Nombre = "Jose", Apellido = "Barrionuevo", DNI = 13456789, FechaNacimiento = new DateTime(2012, 5, 1), Domicilio = "Alejandria 25", Barrio = "San Miguel", Localidad = "Carranza", IngresoDocencia = new DateTime(2012, 6, 4), IngresoEstablecimiento = new DateTime(2001, 7, 13), Observacion = "Una observacion sobre el personal." };
            var personal2 = new Personal() { Nombre = "Pepe", Apellido = "Guardala", DNI = 32659874, FechaNacimiento = new DateTime(1987, 3, 29), Domicilio = "Menguado 937", Barrio = "Iconico", Localidad = "Villa Ulara", IngresoDocencia = new DateTime(2000, 3, 12), IngresoEstablecimiento = new DateTime(1999, 12, 25), Observacion = "Una observacion sobre el personal." };

            foreach (var item in new[] { personal1, personal2 })
            {
                this.Repositorio.Crear(item);
            }

            this.UnidadDeTrabajo.GuardarCambios();

            Assert.Fail();
        }

        [TestMethod]
        public void PuedoModificarVariosPersonales()
        {
            var personal1 = this.Repositorio.ObtenerPorIdentificador(1);
            var personal2 = this.Repositorio.ObtenerPorIdentificador(2);

            personal1.Nombre = "Juan";
            personal2.Nombre = "Pedro";

            foreach (var item in new[] { personal1, personal2 })
            {
                this.Repositorio.Actualizar(item);
            }

            this.UnidadDeTrabajo.GuardarCambios();

            var personaMod1 = this.Repositorio.ObtenerPorIdentificador(1);
            var personaMod2 = this.Repositorio.ObtenerPorIdentificador(2);

            Assert.AreNotEqual(personal1, personaMod1);
            Assert.AreNotEqual(personal2, personaMod2);
        }

        [TestMethod]
        public void PuedoBorrarVariosPersonales()
        {
            var personal1 = this.Repositorio.ObtenerPorIdentificador(1);
            var personal2 = this.Repositorio.ObtenerPorIdentificador(2);

            foreach (var item in new[] { personal1, personal2 })
            {
                this.Repositorio.Borrar(item);
            }

            this.UnidadDeTrabajo.GuardarCambios();
        }

        [TestMethod]
        public void PuedoBorrarVariosPersonalesCuandoUnoNoExiste()
        {
            var personal1 = this.Repositorio.ObtenerPorIdentificador(1);
            var personal2 = this.Repositorio.ObtenerPorIdentificador(10);

            foreach (var item in new[] { personal1, personal2 })
            {
                this.Repositorio.Borrar(item);
            }

            this.UnidadDeTrabajo.GuardarCambios();

            Assert.Fail();
        }

        [TestMethod]
        public void PuedoBorrarVariosPersonalesCuandoAmbosNoExiste()
        {
            var personal1 = this.Repositorio.ObtenerPorIdentificador(10);
            var personal2 = this.Repositorio.ObtenerPorIdentificador(11);

            foreach (var item in new[] { personal1, personal2 })
            {
                this.Repositorio.Borrar(item);
            }

            this.UnidadDeTrabajo.GuardarCambios();

            Assert.Fail();
        }
    }
}
