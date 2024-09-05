using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Graficos
{
    class Marco
    {
        public int base1 { get; }
        public int altura { get; }

        /** 
         * Constructor inicializa con datos de base y altura del rectangulo(Marco) que representan los muros
         * que delimitaran el area donde podrá moverse la serpiente
         * */
        public Marco(int base1, int altura)
        {
            this.base1 = base1;
            this.altura = altura;
        }

        public void Pintar()
        {
            for (int y = 3; y < altura; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("#");

                Console.SetCursorPosition(base1, y);
                Console.Write("#");
            }

            for(int x = 0; x <= base1; x++)
            {
                Console.SetCursorPosition(x, 3);
                Console.Write("#");

                Console.SetCursorPosition(x, altura);
                Console.Write("#");
            }
        }

        public void Actualizar()
        {
            Console.Clear();
            this.Pintar();
        }
    }
}
