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
            string aux;

            // INICIALIZACIÓN
            option = 1;
            aux = "";
            esCorrecto = true;

            // ENTRADA

            do
            {
                try
                {
                    esCorrecto = true;

                    Console.WriteLine("\t\tBIENVENIDO AL CONCESIONARIO\n" +
                  "--------------------------------------------------------\n" +
                  "Seleccione la operación a realizar\n" +
                  "--------------------------------------------------------\n" +
                  "0 - SALIR\n" +
                  "1 - MOSTRAR LISTADO DE VEHÍCULOS\n" +
                  "2 - MOSTRAR VEHÍCULO\n" +
                  "--------------------------------------------------------\n");

                    aux = Console.ReadLine();
                    esCorrecto = Byte.TryParse(aux, out option);

                    if (esCorrecto)
                    {
                        if (option > MAX_SEL)
                        {
                            throw new Exception("La elección no está entre las opciones disponibles");
                        }
                    }
                    else
                    {
                        throw new Exception("No ha introducido un dato valido para su elección.");
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine("Pulse ENTER para volver a intentarlo...");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (!esCorrecto);

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
            
            // CONSTANTES
            const byte MAX_SEL = 5;

            // VARIABLES
            byte option;
            bool esCorrecto;
            string aux;

            // INICIALIZACIÓN
            option = 1;
            aux = "";
            esCorrecto = true;

            // ENTRADA

            do
            {
                try
                {
                    esCorrecto = true;

                    Console.WriteLine("\t\tSELECCIÓN DE VEHÍCULO\n" +

                  "--------------------------------------------------------\n" +
                  "1 - Seat Altea\n" +
                  "2 - Wolswagen Golf\n" +
                  "3 - Ferrari Testarrosa\n" +
                  "4 - BMW M3\n" +
                  "5 - Audi TT");

                    aux = Console.ReadLine();
                    esCorrecto = Byte.TryParse(aux, out option);

                    if (esCorrecto)
                    {
                        if (option > MAX_SEL)
                        {
                            throw new Exception("La elección no está entre las opciones disponibles");
                        }
                    }
                    else
                    {
                        throw new Exception("No ha introducido un dato valido para su elección de vehículo.");
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine("Pulse ENTER para volver a intentarlo...");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (!esCorrecto);

        }
    }
    #endregion
}

