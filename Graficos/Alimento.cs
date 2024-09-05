using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Graficos
{
    class Alimento
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        private Marco marco;
        private Random random;

        public Alimento(Marco marco)
        {
            this.marco = marco;
            this.GenerarNuevo();
        }

        public int getCoordX()
        {
            return this.CoordX;
        }

        public int getCoordY()
        {
            return this.CoordY;
        }

        /// <summary>
        /// Genera alimento en una coordenada nueva
        /// </summary>
        public void GenerarNuevo()
        {
            int limiteIzqX = 1;     // Limite 1 porque en 0 está impreso el muro del marco
            int limiteDerX = this.marco.base1;
            int limiteSupY = 4;     // Porque el marco comienza a partir de Y = 3 donde se pinta el muro superior
            int limiteInfY = this.marco.altura;

            random = new Random();
            this.CoordX = random.Next(limiteIzqX, limiteDerX);
            this.CoordY = random.Next(limiteSupY, limiteInfY);
        }

        public void Pintar()
        {
            Console.SetCursorPosition(this.CoordX, this.CoordY);
            Console.Write("+");
        }

        public void BorrarAlimento()
        {
            Console.SetCursorPosition(this.CoordX-1, this.CoordY);
            Console.Write(" ");
        }

        public void Actualizar()
        {
            this.Pintar();
        }
    }
}
