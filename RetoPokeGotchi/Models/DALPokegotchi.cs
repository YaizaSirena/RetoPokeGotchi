using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RetoPokeGotchi.Models
{
    public class DALPokegotchi
    {
        DBConnect conexion;
        
        public DALPokegotchi()
        {
            conexion = new DBConnect();
        }

        public Usuario SelectUsuario(string nombreIntroducido)
        {
            Usuario usuarioExistente = new Usuario();
            try
            {
                string sql = @"select NombreUsuario from Usuario where NombreUsuario = @pNombreUsuario";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                SqlParameter pNombreUsuario = new SqlParameter("@pNombreUsuario", nombreIntroducido);
                cmd.Parameters.Add(pNombreUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuarioExistente.NombreUsuario = nombreIntroducido;
                }
                dr.Close();
            }
                catch (Exception error)
                {
                    
                }
            return usuarioExistente;
        }


        public void InsertarUsuario(Usuario usuario)
        {
            try
            {
                string sql = @"insert into Usuario (NombreUsuario)   values('@pNombreUsuario')";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);

                cmd.Parameters.Add(CrearParametro("@pNombreUsuario", System.Data.SqlDbType.VarChar, 15, usuario.NombreUsuario ));

                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                
            }
        }


        public SqlParameter CrearParametro(string pName, System.Data.SqlDbType type, int size, object value)
        {
            SqlParameter param = new SqlParameter(pName, type, size);
            param.Value = value;
            return param;
        }

    }
}