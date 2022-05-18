using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Model
{
    [Table("FechasDePublicacion")]
    public class FechaDePublicacion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
    }
}
