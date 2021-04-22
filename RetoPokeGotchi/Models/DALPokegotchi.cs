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

        public bool ComprobarPokemonEnTabla(string pokemonSolicitado)
        {
            string sql = "select * from Pokemon where NombrePokemon like @pNombrePokemon";
            SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
            SqlParameter pNombrePokemon = new SqlParameter("@pNombrePokemon", pokemonSolicitado);
            cmd.Parameters.Add(pNombrePokemon);

            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                dr.Close();
                return true;
            }
            dr.Close();
            return false;
        }

        public void InsertarPokemon(string pokemonSolicitado)
        {
            try
            {
                DALPokemonApi pokemon = new DALPokemonApi();
                string sql = "insert into Pokemon(NombrePokemon, Tipo) values(@pNombrePokemon, @pTipo)";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);

                cmd.Parameters.Add(CrearParametro("@pNombrePokemon", System.Data.SqlDbType.VarChar, 50, Convert.ToString(pokemonSolicitado)));
                cmd.Parameters.Add(CrearParametro("@pTipo", System.Data.SqlDbType.VarChar, 50, "Estandar"));
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
        public int ObtenerIdUsuario(string nombreUsuario)
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

        public Pokemon ObtenerIdPokemon(string pokemonSolicitado)
        {
            try
            {
                string sql = "select id from Pokemon where NombrePokemon = @pNombrePokemon";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                SqlParameter pNombrePokemon = new SqlParameter("pNombrePokemon", pokemonSolicitado);
                cmd.Parameters.Add(pNombrePokemon);
                SqlDataReader dr = cmd.ExecuteReader();

                Pokemon pokemon = new Pokemon();
                while (dr.Read())
                {
                    pokemon.Id = (int)dr["id"];
                    dr.Close();
                    return pokemon;
                }
                dr.Close();
            }
            catch (Exception error) { }
            return null;
        }
        public List<int> ObtenerListaIdPokemon(int idUsuario)
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
                string sql = @" select p.NombrePokemon,  p.Tipo  from Pokemon p INNER JOIN Pokegotchi as l  on p.id = l.idPokemon and idUsuario = @pIdUsuario";
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

        public void InsertarEnPokegotchi(Pokemon pokemonSolicitado, int idUsuario)
        {
            Pokemon pokemon = new Pokemon();
            pokemon = pokemonSolicitado;
            try
            {
                string sql = "insert into Pokegotchi (idUsuario, idPokemon) values (@pidUsuario, @pidPokemon)";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);

                cmd.Parameters.Add(CrearParametro("@pidUsuario", System.Data.SqlDbType.Int, 0, idUsuario));
                cmd.Parameters.Add(CrearParametro("@pidPokemon", System.Data.SqlDbType.Int, 0, pokemon.Id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception error) { }
        }

    }
}

