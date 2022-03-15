using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_1
{
    internal class Jugador
    {
		protected int dinero;
		protected int dinero_ganado;
		protected int dinero_perdido;
		public Jugador()
		{
			dinero = 300;
			dinero_ganado = 0;
			dinero_perdido = 0;
		}

		public void sumarDinero(int monto)
		{
			dinero += monto;
		}

		public void restarDinero(int monto)
		{
			dinero -= monto;
		}

		public void sumarDineroGanado(int monto)
		{
			dinero_ganado += monto;
		}

		public void sumarDineroPerdido(int monto)
		{
			dinero_perdido += monto;
		}

		public int getDinero()
		{
			return dinero;
		}

		public void mostrarDinero()
		{
			Console.WriteLine("La cantidad de dinero que tienes es de " + dinero);
		}

		public void mostrarDineroGanado()
		{
			Console.WriteLine("La cantidad de dinero ganado es de " + dinero_ganado);
		}

		public void mostrarDineroPerdido()
		{
			Console.WriteLine("La cantidad de dinero perdido es de " + dinero_perdido);
		}
	}
}
