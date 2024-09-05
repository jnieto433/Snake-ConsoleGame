using Snake_ConsoleGame.Datos;
using Snake_ConsoleGame.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Graficos
{
    class GameOver
    {
        ConexionSQLite Datos;
        Marco Marco;
        Puntuacion Puntuacion;

        public GameOver(Marco marco, Puntuacion puntuacion)
        {
            this.Marco = marco;
            this.Puntuacion = puntuacion;
            this.Datos = new ConexionSQLite();
        }

        public void Pintar()
        {
            // Mensaje Game Over
            int coordXmsj = (Marco.base1 / 20);
            int coordYmsj = (Marco.altura / 3);
            Console.SetCursorPosition(coordXmsj * 11, coordYmsj);
            Console.Write("Game Over!");

            // Ingresar datos del jugador
            Jugador jugador = new Jugador();

            Console.SetCursorPosition(coordXmsj * 8, coordYmsj * 2);
            Console.Write("Nombre del jugador: ");
            jugador.Nombre = Console.ReadLine();

            jugador.Puntuacion = Convert.ToInt64(Puntuacion.GetPuntos());
            jugador.Fecha = DateTime.Now;

            Datos.InsertarJugador(jugador);
            Console.SetCursorPosition(coordXmsj * 11, (coordYmsj * 2) + 5);
            Console.Write("Guardado!");
        }

        public void Actualizar()
        {
            this.Pintar();
        }
    }
}
