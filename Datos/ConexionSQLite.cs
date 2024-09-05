using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Snake_ConsoleGame.Modelos;

namespace Snake_ConsoleGame.Datos
{
    class ConexionSQLite
    {
        private string DatabasePath;
        private string DatabaseTableName;

        public ConexionSQLite()
        {
            DatabasePath = "Puntuaciones.sqlite";
            DatabaseTableName = "Puntuaciones";
            
            this.CrearTabla();
        }

        // Se crea archivo y tabla en caso de no existir
        public void CrearTabla()
        {
            try
            {

                if(!System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "/" + DatabasePath))
                {
                    SQLiteConnection.CreateFile(DatabasePath);

                    SQLiteConnection conexion = new SQLiteConnection("Data Source=" + DatabasePath + ";Version=3;");
                    conexion.Open();

                    string sql = "CREATE TABLE IF NOT EXISTS " + DatabaseTableName + "(id INTEGER PRIMARY KEY, " +
                                                                                "nombre VARCHAR(60) NOT NULL, " +
                                                                                "puntuacion INTEGER, " +
                                                                                "fecha TEXT)";

                    SQLiteCommand command = new SQLiteCommand(sql, conexion);
                    command.ExecuteNonQuery();

                    conexion.Close();
                    command.Dispose();
                }
            }
            catch(SQLiteException e)
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("ERROR CREATE TABLE - " + e.Message);
                Console.ReadKey();
            }
        }

        public void InsertarJugador(Jugador jugador)
        {
            try
            {
                SQLiteConnection conexion = new SQLiteConnection("Data Source=" + DatabasePath + ";Version=3;");
                conexion.Open();

                string sql = "INSERT INTO " + DatabaseTableName + "(nombre, puntuacion, fecha)" +
                                                               "values(" +
                                                               "'" + jugador.Nombre + "'," +
                                                               jugador.Puntuacion + "," +
                                                               "'" + jugador.Fecha.ToString() + "'" +
                                                               ")";

                SQLiteCommand command = new SQLiteCommand(sql, conexion);
                command.ExecuteNonQuery();

                conexion.Close();
                command.Dispose();
            }catch(SQLiteException e)
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("ERROR INSERT INTO - " + e.Message);
                Console.ReadKey();
            }
           
        }

        public List<Jugador> SelectAllJugadores()
        {
            List<Jugador> jugadores = new List<Jugador>();

            try
            {
                SQLiteConnection conexion = new SQLiteConnection("Data Source=" + DatabasePath + ";Version=3;");
                conexion.Open();

                string sql = "SELECT id, nombre, fecha, puntuacion FROM " + DatabaseTableName + ";";

                SQLiteCommand command = new SQLiteCommand(sql, conexion);
                SQLiteDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    long id = (long)result["id"];
                    string nombre = (string)result["nombre"];
                    long puntuacion = (long)result["puntuacion"];
                    string fechaStr = (string)result["fecha"];
                    DateTime fecha = DateTime.Parse(fechaStr);

                    jugadores.Add(new Jugador(id, nombre, puntuacion, fecha));
                }
                conexion.Close();
                command.Dispose();
            }
            catch (SQLiteException e)
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("ERROR SELECT INTO - " + e.Message);
                Console.ReadKey();
            }
            return jugadores;
        }

        public void DeleteAllJugadores()
        {
            try
            {
                SQLiteConnection conexion = new SQLiteConnection("Data Source=" + DatabasePath + ";Version=3;");
                conexion.Open();

                string sql = "DELETE FROM " + DatabaseTableName + ";";

                SQLiteCommand command = new SQLiteCommand(sql, conexion);
                command.ExecuteNonQuery();

                conexion.Close();
                command.Dispose();
            }
            catch (SQLiteException e)
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine("ERROR DELETE TABLE - " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
