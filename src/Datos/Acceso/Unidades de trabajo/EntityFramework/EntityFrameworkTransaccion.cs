using System;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;
using System.Transactions;

namespace EscuelaSimple.Datos.Acceso.UnidadesDeTrabajo
{
    class EntityFrameworkTransaccion : ITransaccion
    {
        #region Propiedades

        protected EntityFrameworkUnidadDeTrabajo UnidadDeTrabajo { get; private set; }
        protected TransactionScope AmbienteTransaccional { get; private set; }

        #endregion

        #region Constructores

        public EntityFrameworkTransaccion(EntityFrameworkUnidadDeTrabajo unidadDeTrabajo)
        {
            UnidadDeTrabajo = unidadDeTrabajo;
        }

        #endregion

        #region Metodos publicos

        public void Comprometer()
        {
            UnidadDeTrabajo.Fluir();
            AmbienteTransaccional.Complete();
        }

        public void Devolver()
        {
            
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
        // ~EntityFrameworkTransaccion() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            if (AmbienteTransaccional != null)
            {
                AmbienteTransaccional.Dispose();
                AmbienteTransaccional = null;
                UnidadDeTrabajo = null;
            }

            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }

        #endregion

    }
}
