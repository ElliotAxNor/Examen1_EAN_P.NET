using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_1.Elementos_juego
{ 
	internal class Tirada
    {
		int numero_tirada;


		public Tirada(int numero_tirada)
		{
			this.numero_tirada = numero_tirada;
		}


		public int getNumeroTirada()
		{
			return numero_tirada;
		}

		public void mostrarTirada()
		{
			Console.WriteLine("La tirada fue de " + numero_tirada);
		}
	}
}
