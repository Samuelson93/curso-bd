﻿using System;
using System.Collections.Generic;

namespace Database
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conectando a la base de datos");

            Db database = new Db();
            database.Conectar();

            if (database.EstaLaConexionAbierta())
            {
                Usuario nuevoUsuario = new Usuario()
                {
                    //hiddenId = 0, No podemos pasarle estos datos porque se generan por defecto.
                    //id ="",
                    firstName = "MANOLO",
                    lastName = "EL DEL BOMBO",
                    email = "kk3@kk.com",
                    password = "123456",
                    photoUrl = "",
                    searchPreferences = "",
                    status = false,
                    deleted = false,
                    isAdmin = false,
                };
                database.InsertarUsuario(nuevoUsuario);
                Console.WriteLine("Usuario insertado, pulsa una tecla para continuar...");
                Console.ReadKey();

                nuevoUsuario.firstName += "modificado!!";
                database.ActualizarUsuario(nuevoUsuario);
                Console.WriteLine("Usuario Actualizado, pulsa una tecla para continuar");
                Console.ReadKey();

                database.EliminarUsuario("kk3@kk.com");
                Console.WriteLine("Usuario Elmininado, pulsa una tecla para cuntinuar");

                List<Usuario> listaUsuarios = database.DameLosUsuarios();
                listaUsuarios.ForEach(usuario =>
                {
                    Console.WriteLine(
                        "Nombre: " + usuario.firstName 
                        +
                        "Apellidos: " + usuario.lastName
                        +
                         "id: " + usuario.id
                        +
                         "email: " + usuario.id
                        +
                         "password: " + usuario.password
                        +
                         "photoUrl: " + usuario.photoUrl
                        +
                         "seachPreferences: " + usuario.searchPreferences
                        +
                        "status: " + usuario.status
                        +
                         "deleted: " + usuario.deleted
                        +
                         "isAdmin: " + usuario.isAdmin
                        );
                });
            }
            database.Desconectar();
            database = null;
            Console.ReadKey();
        }

       
    }
}
