using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_1.Elementos_juego
{
    internal class Dado
    {
        public int lanzarDado()
        {
            Random random = new Random();
            return random.Next(1, 6);
        }
    }
}
