using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscanerQR.Models
{
    internal class ValidarCarnet
    {
        public int? digitoValidacion(string carnet)
        {
            int[] digitosCarnet = new int[carnet.Length - 1];
            int[] controlV = { 3, 1, 3, 1, 3, 1, 3, 1, 3 };
            int suma = 0;

            //Convertir carnet en array de enteros
            for (int i = 0; i < digitosCarnet.Length; i++)
            {
                digitosCarnet[i] = int.Parse(carnet[i].ToString());
            }

            //Calcular digito de validacion
            for (int i = 0; i < digitosCarnet.Length; i++)
            {
                suma += digitosCarnet[i] * controlV[i];
            }

            int digitoV = suma % 10;
            return digitoV;
        }
    }
}
