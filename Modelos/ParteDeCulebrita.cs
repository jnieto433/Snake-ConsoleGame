using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Modelos
{
    class ParteDeCulebrita
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Simbolo { get; set; }

        public ParteDeCulebrita()
        {

        }

        // Simbolo representará el caracter que muestre la parte de la serpiente
        public ParteDeCulebrita(int x, int y, char simbolo)
        {
            this.X = x;
            this.Y = y;
            this.Simbolo = simbolo;
        }

        public override string ToString()
        {
            return this.Simbolo.ToString();
        }
    }
}
