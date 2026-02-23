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

            // CONSTANTES
            const byte MAX_SEL = 3;

            // VARIABLES
            byte option;
            bool esCorrecto;
            //string aux;
            string mensajeError;

            // INICIALIZACIÓN
            option = 0;
            mensajeError = "";
            //aux = "";
            esCorrecto = true;

            // ENTRADA

            // VERSIÓN PROPIA

            //do
            //{
            //    try
            //    {
            //        esCorrecto = true;

            //        Console.WriteLine("\t\tBIENVENIDO AL CONCESIONARIO\n" +
            //      "--------------------------------------------------------\n" +
            //      "Seleccione la operación a realizar\n" +
            //      "--------------------------------------------------------\n" +
            //      "0 - SALIR\n" +
            //      "1 - MOSTRAR LISTADO DE VEHÍCULOS\n" +
            //      "2 - MOSTRAR VEHÍCULO\n" +
            //      "--------------------------------------------------------\n");

            //        aux = Console.ReadLine();
            //        esCorrecto = Byte.TryParse(aux, out option);

            //        if (esCorrecto)
            //        {
            //            if (option > MAX_SEL)
            //            {
            //                throw new Exception("La elección no está entre las opciones disponibles");
            //            }
            //        }
            //        else
            //        {
            //            throw new Exception("No ha introducido un dato valido para su elección.");
            //        }
            //    }
            //    catch (Exception e)
            //    {

            //        Console.WriteLine(e.Message);
            //        Console.WriteLine("Pulse ENTER para volver a intentarlo...");
            //        Console.ReadLine();
            //        Console.Clear();
            //    }
            //} while (!esCorrecto);

            // VERSIÓN DE JESÚS

            do
            {
                esCorrecto = true;

                // 1.- Mostrar Menú

                Console.Clear();

                Console.WriteLine("\t\tBIENVENIDO AL CONCESIONARIO\n" +
              "--------------------------------------------------------\n" +
              "Seleccione la operación a realizar\n" +
              "--------------------------------------------------------\n" +
              "0 - SALIR\n" +
              "1 - MOSTRAR LISTADO DE VEHÍCULOS\n" +
              "2 - MOSTRAR VEHÍCULO\n" +
              "--------------------------------------------------------\n");
                try
                {
                    // 2.- Obtener opción
                    option = Convert.ToByte(Console.ReadLine());

                    // 3.- Validar opción
                    if (option >= MAX_SEL)
                    {
                        throw new OverflowException();
                    }
                }
                catch (FormatException error)
                {
                    esCorrecto = false;
                    mensajeError = "ERROR:Ha introducido caracteres no numéricos.";
                }
                catch (OverflowException error)
                {
                    esCorrecto = false;
                    mensajeError = "ERROR:Ha introducido una opción que no está en el menú";
                }
                // 4.- Retroalimentación de errores

                if (!esCorrecto)
                {
                    Console.WriteLine(mensajeError);
                    Console.Write("Pulse ENTER para continuar");
                    Console.ReadLine();
                }
            }
            while (!esCorrecto);
            // SALIDA
            return option;
        }


        #endregion

        #region MÉTODOS DE SALIDA
        public static void MostrarListaCoches(Vehículo[] lista)
        {
            Console.Clear();

            Console.WriteLine("\tLISTADO DE VEHÍCULOS");

            for (int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine($"\t{i + 1} - {lista[i].Marca} {lista[i].Modelo}");
            }
            Console.ReadLine();
        }

        public static void VehiculoSeleccionado(Vehículo[] listado)
        {

            //        // CONSTANTES
            //        const byte MAX_SEL = 5;

            //        // VARIABLES
            //        byte option;
            //        bool esCorrecto;
            //        string aux;

            //        // INICIALIZACIÓN
            //        option = 1;
            //        aux = "";
            //        esCorrecto = true;

            //        // ENTRADA

            //        do
            //        {
            //            try
            //            {
            //                esCorrecto = true;

            //                Console.WriteLine("\t\tSELECCIÓN DE VEHÍCULO\n" +

            //              "--------------------------------------------------------\n" +
            //              "1 - Seat Altea\n" +
            //              "2 - Wolswagen Golf\n" +
            //              "3 - Ferrari Testarrosa\n" +
            //              "4 - BMW M3\n" +
            //              "5 - Audi TT\n"+
            //              "---------------------------------------------------------");

            //                aux = Console.ReadLine();
            //                esCorrecto = Byte.TryParse(aux, out option);

            //                if (esCorrecto)
            //                {
            //                    if (option > MAX_SEL)
            //                    {
            //                        throw new Exception("La elección no está entre las opciones disponibles");
            //                    }
            //                }
            //                else
            //                {
            //                    throw new Exception("No ha introducido un dato valido para su elección de vehículo.");
            //                }
            //            }
            //            catch (Exception e)
            //            {

            //                Console.WriteLine(e.Message);
            //                Console.WriteLine("Pulse ENTER para volver a intentarlo...");
            //                Console.ReadLine();
            //                Console.Clear();
            //            }
            //        } while (!esCorrecto);

            //    }
            //}


            // RECURSOS
            int seleccion;
            string aux;
            
            // INICIALIZACIÓN
            seleccion = 0;
            aux = "";

            // 1.- Mostrar lista de Vehículos

            // 2.- Seleccionar Vehículo

            // 3.- Validar selección

            // 4.- Mostrar retroalimentación

            // 5.- Mostrar datos del vehículo
            Interfaz.MostrarDatosVehiculo(listado[seleccion]);


        }

        public static void MostrarDatosVehiculo(Vehículo coche)
        {
            Console.Clear();
            Console.WriteLine($"Marca: {coche.Marca}");
            Console.WriteLine($"Modelo: {coche.Modelo}");
            Console.WriteLine($"Tipo de Vehículo: {coche.Tipo}");
            Console.WriteLine($"Tipo de Combustible: {coche.Combustible}");
            Console.WriteLine($"Estado del Vehículo: {coche.Estado}");
            Console.WriteLine($"Precio al Contado: {coche.PrecioContado} Euros");
            Console.WriteLine($"Precio Financiado: {coche.PrecioFinanciado} Euros");

            Console.ReadLine();
        }
    }
    #endregion
}

