using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake_ConsoleGame.Graficos;
using Snake_ConsoleGame.Logica;

namespace Snake_ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Autor
            // Ricardo Antonio Canul Flota

            MenuPrincipal menu = new MenuPrincipal(0, 60, 0, 20);
            menu.Pintar();

            Juego juego = new Juego(new Marco(75, 23));

            ConsoleKeyInfo tecla;

            do
            {
                if(menu.EstaActivo)
                {
                    // Movimiento del cursor para seleccionar opciones
                    do
                    {
                        tecla = Console.ReadKey();

                        if (tecla.Key == ConsoleKey.UpArrow)
                        {
                            menu.CursorArriba();
                        }

                        if (tecla.Key == ConsoleKey.DownArrow)
                        {
                            menu.CursorAbajo();
                        }

                        menu.Actualizar();
                    } while (tecla.Key != ConsoleKey.Enter);
                    // Al presionar Enter en el menu y seleccionar una opcion, el menú se pasa a inactivo
                    menu.EstaActivo = false;
                    Console.Clear(); // Se limpia la consola porque el menú está inactivo
                }


                // Ejecutar opcion seleccionada
                switch (menu.GetOpcion())
                {
                    case 1: // JUEGO NUEVO
                        juego.JuegoNuevo(ref menu);
                        break;
                    case 2: // PUNTUACIONES
                        juego.Puntuaciones(ref menu);
                        break;
                    case 3: // SALIR
                        Console.SetCursorPosition(0, 23);
                        Console.Write("Presiona cualquier tecla para salir...");
                        break;
                    default:
                        Console.WriteLine("ERROR! OPCION INCORRECTA!");
                        break;
                }
            } while (menu.GetOpcion() != 3); // Si opcion es 3 entonces se ha seleccionado salir del programa

            Console.ReadKey();
        }
    }
}
