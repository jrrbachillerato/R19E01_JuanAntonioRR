
namespace R19E01_JuanAntonioRR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CONSTANTES
            const int NUM_VEHICULOS = 5;

            // VARIABLES

            // Estructura que almacenará los vehículos
            Vehículo[] concesionario;

            bool salir = false;
            byte opcion = 0;      // 0 - Salir    

            // INICIALIZACIÓN

            // 1.- Carga Inicial de Vehículos
            concesionario = new Vehículo[NUM_VEHICULOS];
            CargarVehiculos(concesionario);              // Se pasa el concesionario por referencia para modificarlo en su lugar de memoria.
            // 2.- Acciones del Programa
            do
            {
                // ENTRADA

                // 2.1.- Seleccionar la acción a realizar
                opcion = Interfaz.ObtenerOpcionMenu();

                // PROCESO

                // 2.2.- Realizar la acción según la opción seleccionada
                switch (opcion)
                {
                    // 2.2.1.- Salida del programa

                    case 0:
                        salir = true;
                        break;

                    // 2.2.2.- Mostrar listado de Vehículos
                    case 1:
                        Controlador.MostrarListado(concesionario);
          
                        break;

                    // 2.2.3.- Mostrar datos de un Vehículo
                    case 2:
                        Controlador.MostrarVehiculo(concesionario);
                        break;

                }

                // SALIDA
            }
            while (!salir);
        }

        private static void CargarVehiculos(Vehículo[] listaVehiculos)
        {
            // RECURSOS
            Vehículo coche;   // No instanciado (Null)
            coche = new Vehículo();

            // Cargar Vehículo 1

            coche.Marca = "Seat";
            coche.Modelo = "Altea";
            coche.PrecioContado = 18500f;

            listaVehiculos[0] = coche;     // Se almacena el vehículo en el array.

            // Cargar Vehículo 2
            coche = new Vehículo();
            coche.Marca = "Wolswagen";
            coche.Modelo = "Golf";
            coche.PrecioContado = 23000;

            listaVehiculos[1] = coche;

            // Cargar Vehículo 3
            coche = new Vehículo("Ferrari", "Testarrosa");  // Podemos modificar el constructor
         
            coche.PrecioContado = 75500f;

            listaVehiculos[2] = coche;

            // Cargar Vehículo 4
            coche = new Vehículo("BMW", "M3");

            coche.PrecioContado = 58500f;

            listaVehiculos[3] = coche;

            // Cargar Vehículo 5
            coche = new Vehículo();

            coche.Marca = "Audi";
            coche.Modelo = "TT";
            coche.PrecioContado = 48500f;

            listaVehiculos[4] = coche;
        }
    }
}
