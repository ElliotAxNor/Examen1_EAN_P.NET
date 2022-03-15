using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen_1.Elementos_juego;
namespace Examen_1
{
    internal class Juego
    {
		List<Tirada> lista_tiradas;
		Apuesta apuesta;
		Dado dado1;
		Dado dado2;
		Jugador jugador;

		public Juego()
		{
			this.dado1 = new Dado();
			this.dado2 = new Dado();
			jugador = new Jugador();
			apuesta = new Apuesta();
			lista_tiradas = new List<Tirada>();
		}

		public void iniciarJuego()
		{
			int opcion_principal = 1;
			while (opcion_principal != 8)
			{
				mostrarMenuPrincipal();
				Console.Write("Ingresa opcion: ");
				opcion_principal = int.Parse(Console.ReadLine());
				while (opcion_principal <= 0 || opcion_principal > 8)
				{
					Console.WriteLine("Opcion incorrecta.");
					Console.WriteLine("Ingresa opcion: ");
					opcion_principal = int.Parse(Console.ReadLine());
				}

                if (opcion_principal == 1)
                {
					jugador.mostrarDinero();
                }else if (opcion_principal >= 2 && opcion_principal <= 6)
				{
					int cantidad = pedirCantidadDineroApuesta();

					if (opcion_principal == 2)
					{
						int numero_especifico = pedirNumeroEspecifico();
						Tirada tirada = hacerTirada();
						tirada.mostrarTirada();
						realizarApuestaANumeroEspecifico(cantidad, tirada, numero_especifico);
						agregarTirada(tirada);
					}
					else
					{
						Tirada tirada = hacerTirada();
						tirada.mostrarTirada();
						if (opcion_principal == 3)
						{
							realizarApuestaANumeroExtremo(cantidad, tirada);
						}
						else if (opcion_principal == 4)
						{
							realizarApuestaANumeroMedio(cantidad, tirada);

						}
						else if (opcion_principal == 5)
						{
							realizarApuestaANumeroPar(cantidad, tirada);

						}
						else if (opcion_principal == 6)
						{
							realizarApuestaANumeroImpar(cantidad, tirada);

						}
						agregarTirada(tirada);

					}
				}else if (opcion_principal == 7)
                {
					int opcion_estadistica = 1;
                    while (opcion_estadistica != 9)
                    {
						mostrarMenuEstadisticas();
						Console.Write("Ingresa opcion: ");
						opcion_estadistica = int.Parse(Console.ReadLine());
						while (opcion_estadistica <= 0 || opcion_principal > 9)
						{
							Console.WriteLine("Opcion incorrecta.");
							Console.WriteLine("Ingresa opcion: ");
							opcion_estadistica = int.Parse(Console.ReadLine());
						}

                        if (opcion_estadistica == 1)
                        {
							mostrarBalance();
                        }else if (opcion_estadistica == 2)
                        {
							mostrarCantidadTiradasRealizadas();
                        }
						else if (opcion_estadistica == 3)
						{
							mostrarNumeroMasSeHaTirado();
						}
						else if (opcion_estadistica == 4)
						{
							mostrarNumeroMenosSeHaTirado();
						}
						else if (opcion_estadistica == 5)
						{
							mostrarCantidadTiradasExtremos();
						}
						else if (opcion_estadistica == 6)
						{
							mostrarCantidadTiradasMedios();
						}
						else if (opcion_estadistica == 7)
						{
							mostrarCantidadTiradasPares();
						}
						else if (opcion_estadistica == 8)
						{
							mostrarCantidadTiradasImpares();
                        }
                        else
                        {
							Console.WriteLine("Has salido de las estadisticas");
                        }
					}
                }else if(opcion_principal == 8)
                {
					Console.WriteLine("Has salido por tu cuenta");
                }
				
				if (jugador.getDinero() == 0)
                {
					opcion_principal = 8;
					Console.WriteLine("El jugador se ha quedado sin dinero");
                }

			}

			jugador.mostrarDineroGanado();
			jugador.mostrarDineroPerdido();
		}

		public void mostrarMenuPrincipal()
        {
			Console.WriteLine("------------------JUEGO------------------");
			Console.WriteLine("1.- Ver cuanto dinero tienes.");
			Console.WriteLine("2.- Apostar a un numero especifico.");
			Console.WriteLine("3.- Apostar a un numero extremo.");
			Console.WriteLine("4.- Apostar a un numero medio.");
			Console.WriteLine("5.- Apostar a un numero par.");
			Console.WriteLine("6.- Apostar a un numero impar.");
			Console.WriteLine("7.- Ver estadisticas.");
			Console.WriteLine("8.- Salir juego.");
		}

		public void mostrarMenuEstadisticas()
        {
			Console.WriteLine("--------------ESTADISTICAS---------------");
			Console.WriteLine("1.- Balance.");
			Console.WriteLine("2.- Cantidad de tiradas realizadas.");
			Console.WriteLine("3.- Numero que mas veces se ha tirado.");
			Console.WriteLine("4.- Numero que menos veces se ha tirado.");
			Console.WriteLine("5.- Cantidad de resultados extremos.");
			Console.WriteLine("6.- Cantidad de resultados medios.");
			Console.WriteLine("7.- Cantidad de resultados pares.");
			Console.WriteLine("8.- Cantidad de resultados impares.");
			Console.WriteLine("9.- Salir estadisticas.");
		}


		public int lanzarDados()
		{
			int valor_dado1 = dado1.lanzarDado();
			int valor_dado2 = dado2.lanzarDado();

			return valor_dado1 + valor_dado2;
		}

		public void agregarTirada(Tirada tirada)
		{
			lista_tiradas.Add(tirada);
		}

		public int pedirCantidadDineroApuesta()
		{
			Console.Write("Ingresa la cantidad de dinero que apostara: ");
			int cantidad = int.Parse(Console.ReadLine());

			while (!multiploDe10(cantidad) || !cubreCantidad(cantidad))
			{
				Console.Write("Ingresa la cantidad de dinero que apostara: ");
				cantidad = int.Parse(Console.ReadLine());
			}

			jugador.restarDinero(cantidad);
			return cantidad;
		}

		public bool multiploDe10(int cantidad)
		{
			if (cantidad % 10 != 0)
			{
				Console.WriteLine("La cantidad no es multiplo de 10.");
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool cubreCantidad(int cantidad)
		{
			if (cantidad > jugador.getDinero())
			{
				Console.WriteLine("La cantidad que ingresaste no se tiene.");
				return false;
			}
			else
			{
				return true;
			}
		}

		public void realizarApuestaANumeroEspecifico(int cantidad, Tirada tirada, int numero_especifico)
		{
			if (apuesta.apostarNumeroEspecifico(numero_especifico, tirada))
			{
				Console.WriteLine("Apuesta ganada");
				jugador.sumarDinero(cantidad * 10);
				jugador.sumarDineroGanado((cantidad * 8) - cantidad);
			}
			else
			{
				Console.WriteLine("Apuesta perdida");
				jugador.sumarDineroPerdido(cantidad);
			}

		}

		public void realizarApuestaANumeroExtremo(int cantidad, Tirada tirada)
		{
			if (apuesta.apostarNumeroExtremo(tirada))
			{
				Console.WriteLine("Apuesta ganada");
				jugador.sumarDinero(cantidad * 8);
				jugador.sumarDineroGanado((cantidad * 8) - cantidad);
			}
			else
			{
				Console.WriteLine("Apuesta perdida");
				jugador.sumarDineroPerdido(cantidad);
			}

		}

		public void realizarApuestaANumeroMedio(int cantidad, Tirada tirada)
		{

			if (apuesta.apostarNumeroMedio(tirada))
			{
				Console.WriteLine("Apuesta ganada");
				jugador.sumarDinero(cantidad * 4);
				jugador.sumarDineroGanado((cantidad * 4) - cantidad);
			}
			else
			{
				Console.WriteLine("Apuesta perdida");
				jugador.sumarDineroPerdido(cantidad);
			}

		}

		public void realizarApuestaANumeroPar(int cantidad, Tirada tirada)
		{

			if (apuesta.apostarNumeroPar(tirada))
			{
				Console.WriteLine("Apuesta ganada");
				jugador.sumarDinero(cantidad * 2);
				jugador.sumarDineroGanado((cantidad * 2) - cantidad);

			}
			else
			{
				Console.WriteLine("Apuesta perdida");
				jugador.sumarDineroPerdido(cantidad);
			}

		}

		public void realizarApuestaANumeroImpar(int cantidad, Tirada tirada)
		{

			if (apuesta.apostarNumeroImpar(tirada))
			{
				Console.WriteLine("Apuesta ganada");
				jugador.sumarDinero(cantidad * 2);
				jugador.sumarDineroGanado((cantidad * 2) - cantidad);
			}
			else
			{
				Console.WriteLine("Apuesta perdida");
				jugador.sumarDineroPerdido(cantidad);
			}

		}

		public int pedirNumeroEspecifico()
		{
			Console.Write("Escribe el numero especifico (2 al 12):");
			int numero_especifico = int.Parse((Console.ReadLine()));
			while (numero_especifico < 2 || numero_especifico > 12)
			{
				Console.WriteLine("Numero fuera del rango");
				Console.Write("Escribe el numero especifico (2 al 12):");
				numero_especifico = int.Parse((Console.ReadLine()));
			}

			return numero_especifico;
		}

		public Tirada hacerTirada()
		{
			int numero_dados = lanzarDados();
			return new Tirada(numero_dados);
		}
		public void mostrarBalance()
        {
			Console.WriteLine("---------BALANCE---------");
			jugador.mostrarDinero();
			jugador.mostrarDineroGanado();
			jugador.mostrarDineroPerdido();
        }

		public void mostrarCantidadTiradasRealizadas()
		{
			Console.WriteLine("Cantidad de tiradas realizadas: " + lista_tiradas.LongCount());
		}

		public void mostrarNumeroMasSeHaTirado()
		{
			if (hayTiradas())
			{
				Console.WriteLine("El numero que mas se ha tirado es:");
				List<int> numeros = new List<int>();

				int tiradas_2 = contarTiradasNumero(2);
				numeros.Add(tiradas_2);
				int tiradas_3 = contarTiradasNumero(3);
				numeros.Add(tiradas_3);
				int tiradas_4 = contarTiradasNumero(4);
				numeros.Add(tiradas_4);
				int tiradas_5 = contarTiradasNumero(5);
				numeros.Add(tiradas_5);
				int tiradas_6 = contarTiradasNumero(6);
				numeros.Add(tiradas_6);
				int tiradas_7 = contarTiradasNumero(7);
				numeros.Add(tiradas_7);
				int tiradas_8 = contarTiradasNumero(8);
				numeros.Add(tiradas_8);
				int tiradas_9 = contarTiradasNumero(9);
				numeros.Add(tiradas_9);
				int tiradas_10 = contarTiradasNumero(10);
				numeros.Add(tiradas_10);
				int tiradas_11 = contarTiradasNumero(11);
				numeros.Add(tiradas_11);
				int tiradas_12 = contarTiradasNumero(12);
				numeros.Add(tiradas_12);

				int mayor = 0;
				foreach (int numero in numeros)
				{
					if (mayor < numero)
					{
						mayor = numero;
					}
				}

				if (mayor == tiradas_2)
				{
					Console.WriteLine(2);
				}
				if (mayor == tiradas_3)
				{
					Console.WriteLine(3);
				}
				if (mayor == tiradas_4)
				{
					Console.WriteLine(4);
				}
				if (mayor == tiradas_5)
				{
					Console.WriteLine(5);
				}
				if (mayor == tiradas_6)
				{
					Console.WriteLine(6);
				}
				if (mayor == tiradas_7)
				{
					Console.WriteLine(7);
				}
				if (mayor == tiradas_8)
				{
					Console.WriteLine(8);
				}
				if (mayor == tiradas_9)
				{
					Console.WriteLine(9);
				}
				if (mayor == tiradas_10)
				{
					Console.WriteLine(10);
				}
				if (mayor == tiradas_11)
				{
					Console.WriteLine(11);
				}
				if (mayor == tiradas_12)
				{
					Console.WriteLine(12);
				}
			}
		}

		public void mostrarNumeroMenosSeHaTirado()
		{
			if (hayTiradas())
			{
				Console.WriteLine("El numero que menos se ha tirado es:");
				List<int> numeros = new List<int>();

				int tiradas_2 = contarTiradasNumero(2);
				numeros.Add(tiradas_2);
				int tiradas_3 = contarTiradasNumero(3);
				numeros.Add(tiradas_3);
				int tiradas_4 = contarTiradasNumero(4);
				numeros.Add(tiradas_4);
				int tiradas_5 = contarTiradasNumero(5);
				numeros.Add(tiradas_5);
				int tiradas_6 = contarTiradasNumero(6);
				numeros.Add(tiradas_6);
				int tiradas_7 = contarTiradasNumero(7);
				numeros.Add(tiradas_7);
				int tiradas_8 = contarTiradasNumero(8);
				numeros.Add(tiradas_8);
				int tiradas_9 = contarTiradasNumero(9);
				numeros.Add(tiradas_9);
				int tiradas_10 = contarTiradasNumero(10);
				numeros.Add(tiradas_10);
				int tiradas_11 = contarTiradasNumero(11);
				numeros.Add(tiradas_11);
				int tiradas_12 = contarTiradasNumero(12);
				numeros.Add(tiradas_12);

				int menor = 12;
				foreach (int numero in numeros)
				{
					if (menor > numero)
					{
						menor = numero;
					}
				}

				if (menor == tiradas_2)
				{
					Console.WriteLine(2);
				}
				if (menor == tiradas_3)
				{
					Console.WriteLine(3);
				}
				if (menor == tiradas_4)
				{
					Console.WriteLine(4);
				}
				if (menor == tiradas_5)
				{
					Console.WriteLine(5);
				}
				if (menor == tiradas_6)
				{
					Console.WriteLine(6);
				}
				if (menor == tiradas_7)
				{
					Console.WriteLine(7);
				}
				if (menor == tiradas_8)
				{
					Console.WriteLine(8);
				}
				if (menor == tiradas_9)
				{
					Console.WriteLine(9);
				}
				if (menor == tiradas_10)
				{
					Console.WriteLine(10);
				}
				if (menor == tiradas_11)
				{
					Console.WriteLine(11);
				}
				if (menor == tiradas_12)
				{
					Console.WriteLine(12);
				}
			}
		}

		public void mostrarCantidadTiradasExtremos()
		{
			if (hayTiradas())
			{
				int contador = 0;
				foreach (Tirada tirada in lista_tiradas)
				{
					int numero_tirada = tirada.getNumeroTirada();
					if (numero_tirada == 2 || numero_tirada == 3 || numero_tirada == 4 || numero_tirada == 10 || numero_tirada == 11 || numero_tirada == 12)
					{
						contador++;
					}
				}
				if (contador == 0)
				{
					Console.WriteLine("No hay resultados extremos.");


				}
				else
				{
					Console.WriteLine("La cantidad de resultados extremos es de " + contador);
				}
			}
		}

		public void mostrarCantidadTiradasMedios()
		{
			if (hayTiradas())
			{
				int contador = 0;
				foreach (Tirada tirada in lista_tiradas)
				{
					int numero_tirada = tirada.getNumeroTirada();
					if (numero_tirada == 5 || numero_tirada == 6 || numero_tirada == 7 || numero_tirada == 8 || numero_tirada == 9)
					{
						contador++;
					}
				}
				if (contador == 0)
				{
					Console.WriteLine("No hay resultados medios.");


				}
				else
				{
					Console.WriteLine("La cantidad de resultados medios es de " + contador);

				}

			}
		}

		public void mostrarCantidadTiradasImpares()
		{
			if (hayTiradas())
			{
				int contador = 0;
				foreach (Tirada tirada in lista_tiradas)
				{
					int numero_tirada = tirada.getNumeroTirada();
					if ((numero_tirada % 2) != 0)
					{
						contador++;
					}
				}
				if (contador == 0)
				{
					Console.WriteLine("No hay resultados impares.");

				}
				else
				{
					Console.WriteLine("La cantidad de resultados impares es de " + contador);

				}
			}
		}

		public int contarTiradasNumero(int numero)
		{
			int contador = 0;
			foreach (Tirada tirada in lista_tiradas)
			{
				if (tirada.getNumeroTirada() == numero)
				{
					contador++;
				}
			}
			return contador;

		}

		public bool hayTiradas()
		{
			if (lista_tiradas.LongCount() == 0)
			{
				Console.WriteLine("No hay tiradas");
				return false;
			}
			else
			{
				return true;
			}
		}

		public void mostrarCantidadTiradasPares()
		{
			if (hayTiradas())
			{
				int contador = 0;
				foreach (Tirada tirada in lista_tiradas)
				{
					int numero_tirada = tirada.getNumeroTirada();
					if ((numero_tirada % 2) == 0)
					{
						contador++;
					}
				}
				if (contador == 0)
				{
					Console.WriteLine("No hay resultados pares.");

				}
				else
				{
					Console.WriteLine("La cantidad de resultados pares es de " + contador);

				}
			}
		}
	}
}
