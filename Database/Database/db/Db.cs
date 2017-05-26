using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public static class Db
    {
        private static SqlConnection conexion = null;
        public static void Conectar()
        {
          

            try
            {
                string cadenaConexion = @"
                    Server=.\sqlexpress;
                    Database=testdb;
                    User Id=testuser;
                    Password= !Curso@2017";

                //Creo la conexión
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                //Trato de abrir la conexión
                conexion.Open();
                ////Pregunto por el estado de la conexión

                //if (conexion.State == ConnectionState.Open)
                //{
                //    Console.WriteLine("conexión abierta con éxito");
                //    //Cierro la conexión
                //    conexion.Close();
                //}



            }
            catch (Exception)
            {

                Console.WriteLine("Lo siento mijo, pero la base de datos esta RIP");

                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                        Console.WriteLine("Conexión cerrada con éxito");
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
            finally
            {
                //Destruyo la conexión
                //if (conexion != null)
                //{
                //    if (conexion.State != ConnectionState.Closed)
                //    {
                //        conexion.Close();
                //        Console.WriteLine("Conexión cerrada con éxito");
                //    }
                //    conexion.Dispose();
                //    conexion = null;
                //}

            }


            //Preparo la cadena de coneccion a la base de datos



        }

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        { 
            if (this.conexion != null)
            {
                if(this.conexion.State != ConnectionState.Closed)
                {
                    this.conexion.Close();
                }
            }
            
        }

        public static List<Usuario> DameLosUsuarios()
        {
            List<Usuario> usuarios = null;
            //Preparo la consulta SQL para obtener los usuarios

            string consultaSQL = "SELECT *FROM Users;";
            //Preparo un comando para ejecutar a la base de datos

            SqlCommand comando = new SqlCommand(consultaSQL, this.conexion);
            //Recojo los datos 
            SqlDataReader reader = comando.ExecuteReader();
            usuarios = new List<Usuario>();

            
            while (reader.Read())
            {
                // Console.WriteLine("Nombre: " + reader["firstName"]);//con esta instruccion puede acceder a cada apartado nombrado.

                usuarios.Add( new Usuario()
                {
                    hiddenId = int.Parse(reader["hiddenId"].ToString()),
                    id = reader["id"].ToString(),
                    email = reader["email"].ToString(),
                    password = reader["password"].ToString(),
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    photoUrl = reader["photoUrl"].ToString(),
                    searchPreferences = reader["searchPreferences"].ToString(),
                    status = bool.Parse(reader["status"].ToString()),
                    deleted = (bool)reader["deleted"],
                    isAdmin = Convert.ToBoolean(reader["isAdmin"]),

                });
                
            }

            //Devuelvo los datos
            return usuarios;

        }

        public static void InsertarUsuario(Usuario usuario)
        {


            //Preparo la consulta SQL insertar al nuevo usuario
            string consultaSQL = @"INSERT INTO Users (
                                                email
                                               ,password
                                               ,firstName
                                               ,lastName
                                               ,photoUrl
                                               ,searchPreferences
                                               ,status
                                               ,deleted
                                               ,isAdmin
                                               )
                                         VALUES (";
            consultaSQL += "'" + usuario.email + "'";
            consultaSQL += ",'" + usuario.password + "'";
            consultaSQL += ",'" + usuario.firstName + "'";
            consultaSQL += ",'" + usuario.lastName + "'";
            consultaSQL += ",'" + usuario.photoUrl + "'";
            consultaSQL += ",'" + usuario.searchPreferences + "'";
            consultaSQL += "," + (usuario.status ? "1" : "0");
            consultaSQL += "," + (usuario.deleted ? "1" : "0");
            consultaSQL += "," + (usuario.isAdmin ? "1" : "0");
            consultaSQL += ");";
            //Preparo un comando para ejecutar a la base de datos

            SqlCommand comando = new SqlCommand(consultaSQL, this.conexion);
                //Recojo los datos 
                comando.ExecuteNonQuery();






            }

        public static void EliminarUsuario(string email)
        {
            //Preparo la consulta SQL insertar al nuevo usuario
            string consultaSQL = @"DELETE FROM Users  
                                   WHERE email = '" + email + "';";
            //Preparo un comando para ejecutar a la base de datos

            SqlCommand comando = new SqlCommand(consultaSQL, this.conexion);
            //Recojo los datos 
            comando.ExecuteNonQuery();
        }

        public static void ActualizarUsuario(Usuario usuario)
        {
            //Preparo la consulta SQL insertar al nuevo usuario
            string consultaSQL = @"UPDATE Users ";
            consultaSQL += " SET password = '" + usuario.password + "'";
            consultaSQL += ",firstName = '" + usuario.firstName + "'";
            consultaSQL += " ,lastName = '" + usuario.lastName + "'";
            consultaSQL += ",photoUrl = '" + usuario.photoUrl + "'";
            consultaSQL += ",searchPreferences = '" + usuario.photoUrl + "'";
            consultaSQL += "      , status = " + (usuario.status ? "1" : "0");
            consultaSQL += "      , deleted = " + (usuario.deleted ? "1" : "0");
            consultaSQL += "      , isAdmin = " + (usuario.isAdmin ? "1" : "0");
            consultaSQL +=  " WHERE email ='" + usuario.email + "';";
            
            //Preparo un comando para ejecutar a la base de datos

            SqlCommand comando = new SqlCommand(consultaSQL,conexion);
            //Recojo los datos 
            comando.ExecuteNonQuery();
        }


    }
}

