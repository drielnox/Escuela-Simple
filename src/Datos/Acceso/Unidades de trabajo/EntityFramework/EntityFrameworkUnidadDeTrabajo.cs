using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;
using System;
using System.Collections.Generic;
using EscuelaSimple.Aplicacion.Entidades.TiposBase;
using System.Data.Entity;
using System.Linq;

namespace EscuelaSimple.Datos.Acceso.UnidadesDeTrabajo
{
    class EntityFrameworkUnidadDeTrabajo : IUnidadDeTrabajo
    {
        #region Propiedades

        public DbContext Contexto { get; protected set; }

        #endregion

        #region Constructores

        public EntityFrameworkUnidadDeTrabajo(DbContext contexto)
        {
            Contexto = contexto;
        }

        #endregion

        #region Metodos publicos

        public IEnumerable<TEntidad> ObtenerTodo<TIdentificador, TEntidad>()
            where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
            where TEntidad : Entidad<TIdentificador, TEntidad>
        {
            return Contexto.Set<TEntidad>().ToList();
        }

        public TEntidad ObtenerPorIdentificador<TIdentificador, TEntidad>(TIdentificador identificador)
            where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
            where TEntidad : Entidad<TIdentificador, TEntidad>
        {
            return Contexto.Set<TEntidad>().Find(identificador);
        }

        public TIdentificador? Insertar<TIdentificador, TEntidad>(TEntidad entidad)
            where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
            where TEntidad : Entidad<TIdentificador, TEntidad>
        {
            TEntidad resultado = Contexto.Set<TEntidad>().Add(entidad);
            return resultado.Identificador;
        }

        public void Actualizar<TIdentificador, TEntidad>(TEntidad entidad)
            where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
            where TEntidad : Entidad<TIdentificador, TEntidad>
        {
            Contexto.Set<TEntidad>().Attach(entidad);
            Contexto.Entry<TEntidad>(entidad).State = EntityState.Modified;
        }

        public void Borrar<TIdentificador, TEntidad>(TEntidad entidad)
            where TIdentificador : struct, IEquatable<TIdentificador>, IComparable, IComparable<TIdentificador>
            where TEntidad : Entidad<TIdentificador, TEntidad>
        {
            Contexto.Set<TEntidad>().Remove(entidad);
        }
        
        public void Fluir()
        {
            Contexto.SaveChanges();
        }
        
        public ITransaccion EmpezarTransaccion()
        {
            return new EntityFrameworkTransaccion(this);
        }

        public void TerminarTransaccion(ITransaccion transaccion)
        {
            if (transaccion != null)
            {
                transaccion.Dispose();
                transaccion = null;
            }
        }

        #endregion
        
        #region IDisposable Support

        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~EntityFrameworkUnidadDeTrabajo() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            if (Contexto != null)
            {
                Contexto.SaveChanges();
                Contexto.Dispose();
                Contexto = null;
            }

            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
