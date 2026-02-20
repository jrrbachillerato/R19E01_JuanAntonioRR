using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R19E01_JuanAntonioRR
{
    public static class Interfaz
    {
        #region MÉTODOS DE ENTRADA
        public static byte ObtenerOpcionMenu()
        {
            // TODO: Implementación del método ObtenerOpcionMenu

            // CONSTANTES

            // VARIABLES
            byte option;

            // INICIALIZACIÓN
            option = 1;
            // ENTRADA
            Console.WriteLine();
            // PROCESO

            // SALIDA
            return option;
        }


        #endregion

        #region MÉTODOS DE SALIDA
        public static void MostrarListaCoches(Vehículo[] lista)
        {
            Console.Clear();

            Console.WriteLine("\tLISTADO DE VEHÍCULOS");
             
            for(int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine($"\t{i+1} - {lista[i].Marca} {lista[i].Modelo}");
            }
            Console.ReadLine();
        }

        public static void VehiculoSeleccionado(Vehículo[] listado)
        {
            // TODO: Implementar método VehiculoSeleccionado
        }
        #endregion
    }
}
