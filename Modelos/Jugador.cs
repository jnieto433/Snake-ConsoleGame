using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Modelos
{
    class Jugador
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public long Puntuacion { get; set; }
        public DateTime Fecha { get; set; }

        public Jugador()
        {

        }

        public Jugador(string nombre, long puntuacion, DateTime fecha)
        {
            this.Nombre = nombre;
            this.Puntuacion = puntuacion;
            this.Fecha = fecha;
        }

        public Jugador(long id, string nombre, long puntuacion, DateTime fecha)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Puntuacion = puntuacion;
            this.Fecha = fecha;
        }
    }
}
