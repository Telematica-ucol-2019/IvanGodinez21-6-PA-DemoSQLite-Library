using DemoSQLite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Repositories
{
    public class FechaDePublicacionRepository
    {
        SQLiteConnection connection;
        public FechaDePublicacionRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<FechaDePublicacion>();
        }
        public void Init()
        {
            connection.CreateTable<FechaDePublicacion>();
        }
        public void InsertOrUpdate(FechaDePublicacion fecha)
        {
            if (fecha.Id == 0)
            {
                connection.Insert(fecha);
            }
            else
            {
                connection.Update(fecha);
            }
        }
        public FechaDePublicacion GetById(int Id)
        {
            return connection.Table<FechaDePublicacion>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();
        }
        public List<FechaDePublicacion> GetAll()
        {
            return connection.Table<FechaDePublicacion>().ToList();
        }
        public void DeleteItem(int Id)
        {
            FechaDePublicacion fecha = GetById(Id);
            connection.Delete(fecha);
        }
    }
}
