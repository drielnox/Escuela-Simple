using EscuelaSimple.Aplicacion.Entidades;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Inicializadores
{
    public class DebugInitializer : DropCreateDatabaseAlways<EscuelaSimpleContext>
    {
        protected override void Seed(EscuelaSimpleContext context)
        {
            List<TipoTelefono> tipoTelefonos = new List<TipoTelefono>()
            {
                new TipoTelefono() { Descripcion = "Linea" },
                new TipoTelefono() { Descripcion = "Celular" },
                new TipoTelefono() { Descripcion = "Fax" }
            };

            context.TipoTelefono.AddRange(tipoTelefonos);

            List<Telefono> telefonos = new List<Telefono>()
            {
                new Telefono() { Numero = 42555896, Tipo = tipoTelefonos[0] },
                new Telefono() { Numero = 1565987926, Tipo = tipoTelefonos[1] },
                new Telefono() { Numero = 48956257, Tipo = tipoTelefonos[2] },
            };

            context.Telefono.AddRange(telefonos);

            context.SaveChanges();

            List<SituacionRevista> situacionesRevista = new List<SituacionRevista>()
            {
                new SituacionRevista() { Abreviacion = "TIT", Descripcion = "Titular" },
                new SituacionRevista() { Abreviacion = "SUP", Descripcion = "Suplente" },
                new SituacionRevista() { Abreviacion = "AUX", Descripcion = "Auxiliar" },
                new SituacionRevista() { Abreviacion = "TII", Descripcion = "Titular Interino" },
                new SituacionRevista() { Abreviacion = "TIP", Descripcion = "Titular Provisional" },
                new SituacionRevista() { Abreviacion = "TMP", Descripcion = "Temporario" },
            };

            context.SituacionRevista.AddRange(situacionesRevista);

            List<Tarea> tareas = new List<Tarea>()
            {
                new Tarea() { Abreviacion = "MG", Descripcion = "Maestra de Grado" },
                new Tarea() { Abreviacion = "DIR", Descripcion = "Director" },
                new Tarea() { Abreviacion = "VD", Descripcion = "Vicedirector" },
                new Tarea() { Abreviacion = "SEC", Descripcion = "Secreatario" },
            };

            context.Tarea.AddRange(tareas);

            List<Funcion> funciones = new List<Funcion>()
            {
                new Funcion() { Tarea = tareas[0], TomaDePosesion = new DateTime(2001, 5, 13), SituacionDeRevista = situacionesRevista[0] },
                new Funcion() { Tarea = tareas[0], TomaDePosesion = new DateTime(2004, 8, 5), SituacionDeRevista = situacionesRevista[1] },
                new Funcion() { Tarea = tareas[2], TomaDePosesion = new DateTime(1998, 11, 1), SituacionDeRevista = situacionesRevista[0] },
            };

            context.Funcion.AddRange(funciones);

            context.SaveChanges();

            List<Inasistencia> inasistencias = new List<Inasistencia>()
            {
                new Inasistencia() { Motivo = "M43", Desde = new DateTime(2001, 12, 25), Hasta = new DateTime(2001, 12, 30) },
                new Inasistencia() { Motivo = "A1", Desde = new DateTime(2002, 6, 13), Hasta = new DateTime(2003, 4, 2) },
                new Inasistencia() { Motivo = "F5", Desde = new DateTime(2010, 7, 21), Hasta = new DateTime(2001, 9, 8) },
            };

            context.Inasistencia.AddRange(inasistencias);

            List<Titulo> titulos = new List<Titulo>()
            {
                new Titulo() { Descripcion = "Tecnico Superior en Electromecanica" },
                new Titulo() { Descripcion = "Bachiller en Bienes y Servicios" },
                new Titulo() { Descripcion = "Licenciatura en Kinesiologia" },
                new Titulo() { Descripcion = "Ingeniero Hidraulico" },
            };

            context.Titulo.AddRange(titulos);

            context.SaveChanges();

            var cargo1 = new Cargo();
            cargo1.AgregarFuncion(funciones[0]);
            cargo1.AgregarFuncion(funciones[1]);
            var cargo2 = new Cargo();
            cargo2.AgregarFuncion(funciones[2]);

            List<Cargo> cargos = new List<Cargo>() 
            { 
                cargo1,
                cargo2
            };

            context.Cargo.AddRange(cargos);

            context.SaveChanges();

            var personal1 = new Personal() { Nombre = "Pablo", Apellido = "Leiros", DNI = 34624421, FechaNacimiento = new DateTime(1989, 6, 30) };
            personal1.AgregarTelefono(telefonos[0]);
            personal1.AgregarTelefono(telefonos[1]);
            personal1.AgregarInasistencia(inasistencias[0]);
            personal1.AgregarCargo(cargo1);
            personal1.AgregarCargo(cargo2);
            personal1.AgregarTitulo(titulos[0]);
            personal1.AgregarTitulo(titulos[2]);
            var personal2 = new Personal() { Nombre = "Jesica", Apellido = "Genovese", DNI = 34517157, FechaNacimiento = new DateTime(1989, 5, 4) };
            personal2.AgregarTelefono(telefonos[2]);
            personal2.AgregarInasistencia(inasistencias[1]);
            personal2.AgregarInasistencia(inasistencias[2]);
            personal2.AgregarTitulo(titulos[1]);
            personal2.AgregarTitulo(titulos[3]);

            List<Personal> personal = new List<Personal>()
            {
                personal1,
                personal2
            };

            context.Personal.AddRange(personal);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
