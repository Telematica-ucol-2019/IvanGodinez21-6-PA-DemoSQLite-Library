using DemoSQLite.Model;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Repositories
{
    public class LibroRepository
    {
        SQLiteConnection connection;
        public LibroRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Libro>();
        }
        public void Init()
        {
            connection.CreateTable<Libro>();
        }
        public void InsertOrUpdate(Libro libro)
        {
            if (libro.Id == 0)
            {
                Console.WriteLine($"Id antes de registrar {libro.Id}");
                connection.InsertWithChildren(libro);
                Console.WriteLine($"Id despues de registrar {libro.Id}");
            }
            else
            {
                Console.WriteLine($"Id antes de actualizar {libro.Id}");
                connection.Update(libro);
                App.FechasDePublicacionDb.InsertOrUpdate(libro.FechaDePublicacion);
                Console.WriteLine($"Id despues de actualizar {libro.Id}");
            }
        }
        public Libro GetById(int Id)
        {
            return connection.Table<Libro>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();
        }
        public List<Libro> GetAll()
        {
            return connection.GetAllWithChildren<Libro>();
        }

        public void DeleteItem(int Id)
        {
            Libro libro = GetById(Id);
            connection.Delete(libro);
        }
    }
}
