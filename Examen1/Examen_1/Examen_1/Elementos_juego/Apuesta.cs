using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_1.Elementos_juego
{
    internal class Apuesta
    {
        public bool apostarNumeroEspecifico(int num_especifico, Tirada tirada)
        {
            if (num_especifico == tirada.getNumeroTirada())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool apostarNumeroExtremo(Tirada tirada)
        {
            int numero_tirada = tirada.getNumeroTirada();
            if (numero_tirada == 2 || numero_tirada == 3 || numero_tirada == 4 || numero_tirada == 10 || numero_tirada == 11 || numero_tirada == 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool apostarNumeroMedio(Tirada tirada)
        {
            int numero_tirada = tirada.getNumeroTirada();
            if (numero_tirada == 5 || numero_tirada == 6 || numero_tirada == 7 || numero_tirada == 8 || numero_tirada == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool apostarNumeroPar(Tirada tirada)
        {
            int numero_tirada = tirada.getNumeroTirada();
            if ((numero_tirada % 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool apostarNumeroImpar(Tirada tirada)
        {
            int numero_tirada = tirada.getNumeroTirada();
            if ((numero_tirada % 2) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
