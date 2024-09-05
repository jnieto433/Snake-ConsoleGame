using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame.Graficos
{
    class MenuPrincipal
    {
        // Coordenadas del cursor para seleccionar opciones
        private int CursorX;
        private int CursorY;
        // Coordenadas para calcular las esquinas y los lados de la ventana o area de menu
        private int IzqX;
        private int DerX;
        private int SupY;
        private int InfY;
        // Diviciones de pantalla (Grid)
        private int divisionX;
        private int divisionY;
        // Opcion seleccionada 
        // 1 = Juego nuevo, 2 = Puntuaciones, 3 = Salir
        private int opcion;
        // Menu activo o no
        public bool EstaActivo { get; set; }

        public MenuPrincipal(int IzqX, int DerX, int SupY, int InfY)
        {
            this.IzqX = IzqX;
            this.DerX = DerX;
            this.SupY = SupY;
            this.InfY = InfY;
            // si tendremos 3 opciones, dividire la pantalla en coordenada Y en 3
            this.divisionY = (InfY - SupY) / 3;
            // imprimiré a partir del segundo cuarto de pantalla en coordenadas X
            this.divisionX = (DerX - IzqX) / 4;

            // establecer que el cursor aparezca del lado derecho del texto en el tercer cuarto de la pantalla
            this.CursorX = divisionX * 3;
            // Aparecerá en la primera opcion como defecto
            this.CursorY = divisionY;

            // establecer opcion marcada por defecto 1 = Juego nuevo
            this.opcion = 1;

            // Establecer menu como activo
            this.EstaActivo = true;
        }

        // Metodo para recuperar la opcion seleccionada
        public int GetOpcion()
        {
            return this.opcion;
        }

        public void Pintar()
        {
            // Mostrar opciones
            Console.SetCursorPosition(this.divisionX, this.divisionY);
            Console.Write("Juego nuevo");
            Console.SetCursorPosition(this.divisionX, this.divisionY * 2);
            Console.Write("Puntuaciones");
            Console.SetCursorPosition(this.divisionX, this.divisionY * 3);
            Console.Write("Salir");

            Console.SetCursorPosition(this.CursorX, this.CursorY);
            Console.Write("<--");
        }

        // Refrescar la pantalla si algun valor a cambiado
        public void Actualizar()
        {
            Console.Clear();
            this.Pintar();
        }

        public void CursorArriba()
        {
            // si el cursor sube y se encuentra en la posicion 1, entonces baja a la ultima opcion automaticamente 3
            if(opcion == 1)
            {
                opcion = 3;
            }
            else
            {
                // En caso que sea otro numero como 3 o 2, solo tiene que retroceder atras un numero
                opcion--;
            }
            // La coordenada del cursor cambiará a la opcion seleccionada
            this.CursorY = this.divisionY * opcion;
        }

        public void CursorAbajo()
        {
            // Al bajar el cursor y no haber mas opciones, regresa a la opcion 1
            if(opcion == 3)
            {
                opcion= 1;
            }
            else
            {
                // si la opcion es 1 o 2, entonces solo aumenta un lugar para pasar a la siguiente opcion
                opcion++;
            }
            // La coordenada del cursor cambiará a la opcion seleccionada
            this.CursorY = this.divisionY * opcion;
        }
    }
}
