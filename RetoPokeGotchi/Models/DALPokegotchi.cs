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
        public Usuario SelectUsuario(string nombreUsuario)
        {
            Usuario usuarioExistente = new Usuario();
            try
            {
                string sql = @"select NombreUsuario from Usuario where NombreUsuario = @pNombreUsuario";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                SqlParameter pNombreUsuario = new SqlParameter("@pNombreUsuario", nombreUsuario);
                cmd.Parameters.Add(pNombreUsuario);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    usuarioExistente.NombreUsuario = nombreUsuario;
                    dr.Close();
                    return usuarioExistente;
                }
                dr.Close();
            }
            catch (Exception error) { }
            
            return null;
        }
        public void InsertarUsuario(String usuario)
        {
            try
            {
                string sql = @"insert into Usuario (NombreUsuario)   values(@pNombreUsuario)";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);

                cmd.Parameters.Add(CrearParametro("@pNombreUsuario", System.Data.SqlDbType.VarChar, 15, Convert.ToString(usuario)));
                cmd.ExecuteNonQuery();
            }
            catch (Exception error) { }
        }
        public SqlParameter CrearParametro(string pName, System.Data.SqlDbType type, int size, object value)
        {
            SqlParameter param = new SqlParameter(pName, type, size);
            param.Value = value;
            return param;
        }
        public int SelectIdUsuario(string nombreUsuario)
        {
            int idUsuario = 0;
            try
            {
                string sql = @"Select id from Usuario where NombreUsuario = @pNombreUsuario";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                SqlParameter pNombreUsuario = new SqlParameter("@pNombreUsuario", nombreUsuario);
                cmd.Parameters.Add(pNombreUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    idUsuario = (int)dr["id"];
                }
                dr.Close();
            }
            catch (Exception error) { }
            
            return idUsuario;
        }
        public List<int> SelectIdPokemons(int idUsuario)
        {
            List<int> listaIdPokegotchi = new List<int>();
            List<Pokemon> listaIdPokemons = new List<Pokemon>();
            try
            {
                string sql = @"Select id from Pokegotchi where idUsuario = @pIdUsuario";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                SqlParameter pIdUsuario = new SqlParameter("@pIdUsuario", idUsuario);
                cmd.Parameters.Add(pIdUsuario);
               
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listaIdPokegotchi.Add((int)dr["id"]);
                }
                dr.Close();
            }
            catch (Exception error ) { }
            return listaIdPokegotchi;
        }

        public List<Pokemon> MostrarPokemons(int idUsuario)
        {
            List<Pokemon> listaPokemons = new List<Pokemon>();

            try
            {
                string sql = @" select p.NombrePokemon,  p.Tipo  from Pokemon p INNER JOIN Pokegotchi as l
                                 on p.id = l.idPokemon and idUsuario = @pIdUsuario";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                SqlParameter pIdUsuario = new SqlParameter("@pIdUsuario", idUsuario);
                cmd.Parameters.Add(pIdUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pokemon pokemon = new Pokemon();
                    pokemon.NombrePokemon = (string)dr["NombrePokemon"];
                    pokemon.Tipo = (string)dr["Tipo"];
                    listaPokemons.Add(pokemon);
                }
                dr.Close();

            }
            catch (Exception error) { }
            return listaPokemons;
        }






    }
}

