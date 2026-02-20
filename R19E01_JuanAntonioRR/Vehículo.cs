using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R19E01_JuanAntonioRR
{
    public class Vehículo
    {
        // CONSTANTES
        private const byte TAM_MAX_MARCA = 20;
        private const byte TAM_MIN_MARCA = 3;
        private const string MARCA_MODELO_DEF = "Desconocido";
        private const byte TAM_MAX_MODELO = 25;
        private const byte TAM_MIN_MODELO = 2;
        private const string TIPO_VEH_DEF = "Turismo";
        private const string TIPO_VEH = "TURISMO FURGONETA CAMIÓN";
        
        private const float PRECIO_MIN = 1000;
        private const float PRECIO_MAX = 100000;
        private const float PRECIO_DEF = 0;
       
        private const float DESCUENTO = 0.10F;
        private const int LIMITE_AÑOS = 10;

        // CAMPOS | MIEMBROS
        private string _marca;
        private string _modelo;
        private string _tipoVehiculo;
        private float _precioContado;
        private DateTime _fechaMatriculacion;
        
        // private float _precioFinanciado; NO ES NECESARIO YA QUE ES UN CÁLCULO QUE SE LE VA A PASAR EL PRECIO AL CONTADO

        #region CONSTRUCTORES

        public Vehículo()
        {
            _marca = MARCA_MODELO_DEF;
            _modelo = MARCA_MODELO_DEF;
            _tipoVehiculo= "TURISMO";
            _precioContado = PRECIO_DEF;
        }
        public Vehículo(string marca,string modelo) // Constructor por defecto instanciando solo la marca y el modelo, los demás atributos se mantienen por defecto.
        {
            Marca = marca;          // Para ello se utiliza la propiedad para que no perder seguridad con datos de fuera.
            Modelo = modelo;


            // HE COPIADO Y PEGADO y daba error en este punto al inicializarse la marca y modelo por defecto, lo que sobreescribia la marca y modelo "Ferrari" "Testarrosa"
            //_marca = MARCA_MODELO_DEF;
            //_modelo = MARCA_MODELO_DEF;
            _tipoVehiculo = "TURISMO";
            _precioContado = PRECIO_DEF;

        }
        #endregion

        #region PROPIEDADES
        public string Marca
        {
            get
            {
                // Comprobación de inicialización
                if (_marca == MARCA_MODELO_DEF)
                {
                    throw new Exception("¡ERROR! La marca no se ha inicializado para el vehículo");
                }
                return _marca;
            }
            set
            {
                // Validación del dato a establecer

                ValidarCadena(value,TAM_MAX_MARCA,TAM_MIN_MARCA);

                // Validación de caracteres especiales y signos de puntuación

                ValidarEspecialMarca(value);

                _marca = value;
            }
        }


        public string Modelo
        {
            get
            {
                // Comprobación de inicialización

                if (_modelo == MARCA_MODELO_DEF)
                {
                    throw new Exception("¡ERROR! Modelo del vehículo no se ha establecido.");
                }                
                return _modelo;
            }
            set
            {
                // Validación del dato a establecer

                ValidarCadena(value,TAM_MAX_MODELO, TAM_MIN_MODELO);
                _modelo= value;
            }
        }
        public string TipoVehiculo
        {
            get
            {
                return _tipoVehiculo;
            }
            set
            {
                // Validación del tipo de Vehículo
                value = value.ToUpper();
                if (!TIPO_VEH.Contains(value))
                {
                    throw new Exception("ERROR: Tipo de vehículo no valido.");
                }
                _tipoVehiculo = value;
            }
        }
        public float PrecioContado
        {
            get
            {
                if (_precioContado == PRECIO_DEF)
                {
                    throw new Exception("ERROR: El valor introducido es menor al permitido.");
                }
                return _precioContado;
            }
            set
            {
                ValidarPrecioContado(value);
                _precioContado = value;
            }
        }
        public float PrecioFinanciado
        {
            get
            {
                return CalcularPrecioFinanciado();
            }
        }     
        public DateTime FechaMatriculacion
        {
            get
            {
                
                return _fechaMatriculacion;
            }
            set
            {
                // Validación Fecha Matriculación

                ValidarFechaMatriculacion(value);
                _fechaMatriculacion = value;
            }
        }
        #endregion

        #region MÉTODOS PRIVADOS
        private void ValidarCadena(string dato, byte tamMax, byte tamMin)
        {
            // 1.- Nulo o vacío
            if (string.IsNullOrEmpty(dato))
            {
                throw new ArgumentNullException("ERROR: No se ha introducido el dato.");
            }
            
            // 2.- Tamaño 
            if(dato.Length < TAM_MIN_MODELO || dato.Length > TAM_MAX_MODELO)
            {
                throw new FormatException("ERROR: Tamaño de la cadena incorrecto.");
            }

            // 3.- Caracteres especiales
            for(int i = 0; i < dato.Length; i++)
            {
                if (char.IsSymbol(dato[i]))
                {
                    throw new Exception("ERROR: El dato contiene simbolos.");
                }
            }

        }

        private void ValidarEspecialMarca(string marca)
        {
            // 1.- Caracteres especiales

            for(int i = 0;i< marca.Length; i++)
            {
                if (Char.IsDigit(marca[i]))
                {
                    throw new ArgumentException("ERROR: Dígitos no permitidos.");
                }
                if (Char.IsPunctuation(marca[i]))
                {
                    throw new ArgumentException("ERROR: Signos de puntuación no permitidos.");
                }
            }
        }
        private void ValidarPrecioContado(float precioContado)
        {
            if (precioContado < PRECIO_MIN)
            {
                throw new Exception("ERROR: El precio introducido es menor al permitido");
            }
            if(precioContado > PRECIO_MAX)
            {
                throw new Exception("ERROR: El precio excede el máximo permitido.");
            }
        }
        private void ValidarFechaMatriculacion(DateTime fecha)
        {
            // RECURSOS
            DateTime fechaActual = DateTime.Today;

            // 0.- Comprobar el parámetro

            //if (fecha == null)
            //{
            //    throw new Exception("ERROR: No se ha establecido una fecha");
            //}

            // Nunca se ejecutará el throw porque un DateTime nunca será Null

            // 1.- Fecha posterior a la actual
            if (fecha > fechaActual)
            {
                throw new Exception("ERROR: El vehículo no puede estar matriculado posterior a la fecha actual. ");
            }

            // 2.- Coche con una matriculación con un límite establecido 
            fechaActual = fechaActual.AddYears(-LIMITE_AÑOS);

            if (fechaActual>fecha)
            {
                throw new Exception("ERROR: El vehículo no puede tener más de 10 años.");
            }
        }
        #endregion

        #region MÉTODOS PÚBLICOS
        public float CalcularPrecioFinanciado()
        {
            float precioF;

            precioF = PrecioContado - PrecioContado * DESCUENTO;

            return precioF;
        }
        #endregion

    }
}
