using System;
using EscuelaSimple.Datos.Acceso.UnidadDeTrabajo.Contratos;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace EscuelaSimple.Datos.Acceso.UnidadesDeTrabajo
{
    public class FabricaEntityFrameworkUnidadDeTrabajo : IFabricaUnidadDeTrabajo
    {
        #region Propiedades

        protected string CadenaDeConexion { get; private set; }
        protected DbModel Modelo { get; private set; }

        #endregion

        #region Constructores

        public FabricaEntityFrameworkUnidadDeTrabajo(string cadenaDeConexion, DbModel modelo)
        {
            CadenaDeConexion = cadenaDeConexion;
            Modelo = modelo;
        }

        #endregion

        #region Metodos publicos

        public IUnidadDeTrabajo EmpezarUnidadDeTrabajo()
        {
            DbContext contexto = CrearContexto();
            return new EntityFrameworkUnidadDeTrabajo(contexto);
        }

        public void TerminarUnidadDeTrabajo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            if (unidadDeTrabajo != null)
            {
                unidadDeTrabajo.Dispose();
                unidadDeTrabajo = null;
            }
        }

        #endregion

        #region Metodos privados

        private DbContext CrearContexto()
        {
            DbCompiledModel modeloCompilado = Modelo.Compile();
            return new DbContext(CadenaDeConexion, modeloCompilado);
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
        // ~FabricaEntityFrameworkUnidadDeTrabajo() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            CadenaDeConexion = null;
            Modelo = null;

            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
