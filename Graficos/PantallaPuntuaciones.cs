using Snake_ConsoleGame.Datos;
using Snake_ConsoleGame.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Graficos
{
    class PantallaPuntuaciones
    {
        private Marco Marco;
        private List<Jugador> Jugadores;
        ConexionSQLite db_jugadores;

        public PantallaPuntuaciones(Marco marco)
        {
            this.Marco = marco;

            db_jugadores = new ConexionSQLite();
            Jugadores = db_jugadores.SelectAllJugadores();
            this.OrdenarListaJugadores();
        }

        public void Pintar()
        {
            // Pintar el marco delimitante
            this.Marco.Pintar();
            int x = Marco.base1 / 8;
            int y = 5;
            int contJugadores = y;

            // Titulo
            Console.SetCursorPosition((this.Marco.base1 / 5) *  2, 1);
            Console.WriteLine("Puntuaciones");

            // Columnas
            Console.SetCursorPosition(x, y);
            Console.Write("Nombre");
            Console.SetCursorPosition( x*3 - 4, y);
            Console.Write("Puntuacion");
            Console.SetCursorPosition(x*6, y);
            Console.Write("Fecha");
            y += 2;

            Jugadores = db_jugadores.SelectAllJugadores();
            this.OrdenarListaJugadores();
            // Informacion de cada columna
            foreach (var jugador in Jugadores)
            {
                // No imprimir mas Jugadores de lo que elmarco permite.
                // Solo se muestran los mejores jugadores dependiendo su puntuacion
                // La lista ya ha sido ordenada previamente con el metodo OrdenarListaJugadores()
                
                if(contJugadores < (Marco.altura-5)) // se deja unos espacios para poner opciones abajo
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(jugador.Nombre);
                    Console.SetCursorPosition(x * 2, y);
                    Console.Write(" - ");
                    Console.SetCursorPosition(x * 3, y);
                    Console.Write(jugador.Puntuacion);
                    Console.SetCursorPosition(x * 4, y);
                    Console.Write(" - ");
                    Console.SetCursorPosition(x * 5, y);
                    Console.Write(jugador.Fecha);
                    y++;
                }
                contJugadores++;
            }

            Console.SetCursorPosition(x * 2, Marco.altura-2);
            Console.Write("Regresar - Esc");
            Console.SetCursorPosition(x * 4, Marco.altura - 2);
            Console.Write("Borrar todo - Supr");
        }

        public void Actualizar()
        {
            Console.Clear();
            this.Pintar();
        }

        // Ordena lista de jugadores del Mayor al Menor
        private void OrdenarListaJugadores()
        {
            Jugador jugadorTemp1, jugadorTemp2;
            for(int i = 0; i < this.Jugadores.Count; i++)
            {
                for(int j = 0; j < this.Jugadores.Count; j++)
                {
                    jugadorTemp1 = Jugadores[j];
                    if(j < this.Jugadores.Count - 1)
                    {
                        jugadorTemp2 = Jugadores[j+1];
                        if(jugadorTemp1.Puntuacion < jugadorTemp2.Puntuacion)
                        {
                            this.Jugadores[j] = jugadorTemp2;
                            this.Jugadores[j+1] = jugadorTemp1;
                        }
                    }
                }
            }
        }

        public void BorrarTodosJugadores()
        {
            ConexionSQLite datos = new ConexionSQLite();
            datos.DeleteAllJugadores();
        }
    }
}
