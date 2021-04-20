using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RetoPokeGotchi.Models
{
    public class DBConnect
    {
        System.Data.SqlClient.SqlConnection conexion = null;

        public SqlConnection Conexion { get => conexion; set => conexion = value; }


        public DBConnect()
        {
            Conexion = new SqlConnection("Data Source =DESKTOP-GSHP0S4; Initial Catalog = RetoPokeGotchi; Integrated Security = true;");
            Conexion.Open();
        }
        
       
       

    }
}