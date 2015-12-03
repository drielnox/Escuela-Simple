using EscuelaSimple.Presentacion.Logica.Presentador.Contratos;
using EscuelaSimple.Presentacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscuelaSimple.Presentacion.Logica.Presentador
{
    public class ListadoPersonalPresentador
    {
        private IListadoPersonalVista _vista;
        private ListadoPersonalModelo _modeloDePresentacion;

        public ListadoPersonalPresentador(IListadoPersonalVista vista)
        {
            _vista = vista;
        }

        public ListadoPersonalPresentador(IListadoPersonalVista vista, ListadoPersonalModelo modelo)
            : this(vista)
        {
            _modeloDePresentacion = modelo;
        }
    }
}
