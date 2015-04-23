using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olfrad.EscuelaSimple.DatosEntityFramework;
using Olfrad.EscuelaSimple.DatosEntityFramework.Dominio; 

namespace DatosEFConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EscuelaSimpleContext())
            {
                var tipoTel1 = new TipoTelefono() { Descripcion = "Linea" };
                var tipoTel2 = new TipoTelefono() { Descripcion = "Celular" };
                var tipoTel3 = new TipoTelefono() { Descripcion = "Fax" };

                var tel1 = new Telefono() { Numero = 42555896, Tipo = tipoTel1 };
                var tel2 = new Telefono() { Numero = 1565987926, Tipo = tipoTel2 };
                var tel3 = new Telefono() { Numero = 48956257, Tipo = tipoTel3 };

                var inas1 = new Inasistencia() { Motivo = "M43", Desde = new DateTime(2001, 12, 25), Hasta = new DateTime(2001, 12, 30) };
                var inas2 = new Inasistencia() { Motivo = "A1", Desde = new DateTime(2002, 6, 13), Hasta = new DateTime(2003, 4, 2) };
                var inas3 = new Inasistencia() { Motivo = "F5", Desde = new DateTime(2010, 7, 21), Hasta = new DateTime(2001, 9, 8) };

                var pers1 = new Personal() { Nombre = "Pablo", Apellido = "Leiros", DNI = 34624421, FechaNacimiento = new DateTime(1989, 6, 30) };
                pers1.Telefonos = new[] { tel1, tel2 };
                pers1.Inasistencias = new[] { inas1 };
                var pers2 = new Personal() { Nombre = "Jesica", Apellido = "Genovese", DNI = 34517157, FechaNacimiento = new DateTime(1989, 5, 4) };
                pers2.Telefonos = new[] { tel3 };
                pers2.Inasistencias = new[] { inas2, inas3 };

                Personal pers3 = new Personal()
                {
                    Apellido = "Giorgetta",
                    Cargo = "MG",
                    DNI = 13456789,
                    Domicilio = "25 de Mayo de 1810 787",
                    FechaNacimiento = new DateTime(1961, 7, 21),
                    Inasistencias = new List<Inasistencia>() 
                        { 
                            new Inasistencia() 
                            {
                                Motivo = "A1",
                                Desde = new DateTime(2011, 2, 3),
                                Hasta = new DateTime(2011, 2, 15),
                            },
                            new Inasistencia() 
                            {
                                Motivo = "A2",
                                Desde = new DateTime(2012, 4, 6),
                                Hasta = new DateTime(2012, 4, 12),
                            },
                        },
                    IngresoDocencia = new DateTime(1987, 2, 17),
                    IngresoEstablecimiento = new DateTime(1989, 5, 25),
                    Localidad = "Florencio Varela",
                    Nombre = "Mercedes",
                    Observacion = "Esta es una observacion.",
                    SituacionRevista = "Una situacion de revista",
                    Telefonos = new List<Telefono>() 
                        { 
                            new Telefono() 
                            {
                                Numero = 42555896,
                                Tipo = tipoTel1,
                            },
                            new Telefono() 
                            {
                                Numero = 1598875465,
                                Tipo = tipoTel2,
                            },
                        },
                    Titulo = "Titulo de grado",
                };

                ctx.Personal.Add(pers1);
                ctx.Personal.Add(pers2);
                ctx.Personal.Add(pers3);

                ctx.
            }
        }
    }
}
