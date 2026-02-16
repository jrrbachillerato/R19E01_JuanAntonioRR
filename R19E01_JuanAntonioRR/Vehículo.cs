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
        private const byte TAM_MIN_MODELO = 4;
        private const string TIPO_VEH_DEF = "Turismo";
        private const string TIPO_VEH = "TURISMO FURGONETA CAMIÓN";
        private const float PRECIO_MIN = 1000;
        private const float PRECIO_MAX = 100000;
        private const float PRECIO_DEF = 0;
        private const float DESCUENTO = 0.10F;

        // CAMPOS | MIEMBROS
        private string _marca;
        private string _modelo;
        private string _tipoVehiculo;
        private float _precioContado;

        // private float _precioFinanciado; NO ES NECESARIO YA QUE ES UN CÁLCULO QUE SE LE VA A PASAR EL PRECIO AL CONTADO

        #region CONSTRUCTORES

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
        #endregion

        #region MÉTODOS PÚBLICOS
        public float CalcularPrecioFinanciado()
        {
            float precioF;

            precioF = PrecioContado - PrecioContado * DESCUENTO;

            return precioF;
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
        #endregion
    }
}
