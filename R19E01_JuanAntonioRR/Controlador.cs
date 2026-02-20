using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R19E01_JuanAntonioRR
{
    public static class Controlador
    {
        public static void MostrarListado(Vehículo[] listadoVehiculos)
        {
            Interfaz.MostrarListaCoches(listadoVehiculos);
        }

        public static void MostrarVehiculo(Vehículo[] listadoVehiculos)
        {
            Interfaz.VehiculoSeleccionado(listadoVehiculos);
        }
    }
}
