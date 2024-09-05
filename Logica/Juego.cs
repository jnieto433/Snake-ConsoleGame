using Snake_ConsoleGame.Datos;
using Snake_ConsoleGame.Graficos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Logica
{
    class Juego
    {
        Marco Marco;
        // Se pasa por referencia el menu inicial para poder reactivarlo al salir de la partida
        // o al perder del juego
        public Juego(Marco marco)
        {
            this.Marco = marco;
        }


        public void JuegoNuevo(ref MenuPrincipal menu)
        {
            ConsoleKeyInfo tecla;

            Marco.Pintar();
            Puntuacion puntos = new Puntuacion(2, 1);
            puntos.Pintar();
            Alimento alimento = new Alimento(this.Marco);
            alimento.Pintar();

            Culebrita snake = new Culebrita(this.Marco);
            snake.Pintar();

            tecla = new ConsoleKeyInfo((char)39, ConsoleKey.RightArrow, false, false, false);
            do{
                Console.SetCursorPosition(60, 1);
                Console.Write("Velocidad: " + snake.Velocidad);

                if(300 - snake.Velocidad > 0)
                {
                    Thread.Sleep(300 - snake.Velocidad);
                    if (Console.KeyAvailable)
                    {
                        tecla = Console.ReadKey(true);
                    }
                }
                else
                {
                    Thread.Sleep(0);
                    if (Console.KeyAvailable)
                    {
                        tecla = Console.ReadKey(true);
                    }
                }

                // Si serpiente come alimento... Generar uno nuevo
                if (snake.Comio(alimento))
                {
                    snake.Crecer();
                    snake.Velocidad+=20;
                    alimento.BorrarAlimento();
                    puntos.AgregarPuntos();
                    puntos.Actualizar();
                    alimento.GenerarNuevo();
                    alimento.Actualizar();
                }

                if (tecla.Key == ConsoleKey.UpArrow)
                {
                    snake.MoverArriba();
                }
                if(tecla.Key == ConsoleKey.RightArrow)
                {
                    snake.MoverDerecha();
                }
                if (tecla.Key == ConsoleKey.LeftArrow)
                {
                    snake.MoverIzquierda();
                }
                if (tecla.Key == ConsoleKey.DownArrow)
                {
                    snake.MoverAbajo();
                }

                snake.Actualizar();
            } while (snake.Colisiona() == false && tecla.Key != ConsoleKey.Escape) ;

            /** Si se presiona ESQ en el teclado, 
             *  o la culebrita está muerta
             *  se regresa al menu principal */
            if (tecla.Key == ConsoleKey.Escape || snake.EstaViva == false)
            {
                if (!snake.EstaViva)
                {
                    GameOver gameOver = new GameOver(this.Marco, puntos);
                    gameOver.Pintar();
                    Console.ReadKey();
                }
                Console.Clear();
                // Se imprime nuevamente el menú en pantalla
                menu.EstaActivo = true;
                menu.Pintar();
            } 
        }

        public void Puntuaciones(ref MenuPrincipal menu)
        {
            PantallaPuntuaciones puntuaciones = new PantallaPuntuaciones(this.Marco);
            puntuaciones.Pintar();

            ConsoleKeyInfo tecla;

            // Leer algo del teclado
            tecla = Console.ReadKey();
            // Si se presiona ESQ o Enter en el teclado, se regresa al menu principal
            if (tecla.Key == ConsoleKey.Enter || tecla.Key == ConsoleKey.Escape)
            {
                // Se limpia la pantalla del juego
                Console.Clear();
                // Se imprime nuevamente el menú en pantalla
                menu.EstaActivo = true;
                menu.Pintar();
            }

            if(tecla.Key == ConsoleKey.Delete)
            {
                puntuaciones.BorrarTodosJugadores();
                puntuaciones.Actualizar();
            }
        }
    }
}
