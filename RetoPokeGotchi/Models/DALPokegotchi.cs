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

        public void InsertarPokemon(PokemonApi pokemonApi)
        {
            try
            {
                DALPokemonApi pokemon = new DALPokemonApi();
                string sql = "insert into Pokemon(NombrePokemon, Tipo, idApi) values(@pNombrePokemon, @pTipo, @pIdApi)";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);

                cmd.Parameters.Add(CrearParametro("@pNombrePokemon", System.Data.SqlDbType.VarChar, 50, Convert.ToString(pokemonApi.Nombre)));
                cmd.Parameters.Add(CrearParametro("@pTipo", System.Data.SqlDbType.VarChar, 50, Convert.ToString(pokemonApi.Tipo)));
                cmd.Parameters.Add(CrearParametro("@pIdApi", System.Data.SqlDbType.VarChar, 50, pokemonApi.Id));
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

        public List<Pokegotchi> RecuperaPokegotchisPorIdUsuario(int idUsuario)
        {
            List<Pokegotchi> listaPokegotchi = new List<Pokegotchi>();
            try
            {
               string sql = @"select  p.idApi, l.felicidad, l.idPokemon, l.idUsuario, p.NombrePokemon, l.id, p.Tipo , l.salud from Pokemon p
                                        INNER JOIN Pokegotchi as l
                                        on p.id = l.idPokemon and idUsuario =  @pIdUsuario";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                SqlParameter pIdUsuario = new SqlParameter("@pIdUsuario", idUsuario);
                cmd.Parameters.Add(pIdUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pokegotchi pokegotchi = new Pokegotchi();
                    pokegotchi.IdUsuario = (int)dr["idUsuario"];
                    pokegotchi.Salud = (int)dr["salud"];
                    pokegotchi.IdPokemon = (int)dr["idPokemon"];
                    pokegotchi.Felicidad = (int)dr["felicidad"];
                    pokegotchi.Id = (int)dr["id"];
                    pokegotchi.Salud = (int)dr["salud"];


                    Pokemon pokemon = new Pokemon();
                    pokemon.NombrePokemon = (string)dr["NombrePokemon"];
                    pokemon.Tipo = (string)dr["Tipo"];
                    pokemon.IdPokegotchi = (int)dr["id"];
                    pokemon.IdApi = (int)dr["idApi"];

                    pokegotchi.Pokemon = pokemon;

                    listaPokegotchi.Add(pokegotchi);
                }
                dr.Close();
            }
            catch (Exception error) { }
            return listaPokegotchi;
        }

        public Pokegotchi RecuperaPokegotchiPorId(int idPokegotchi)
        {
            Pokegotchi pokegotchi = new Pokegotchi();
            try
            {
                string sql = @"select p.idApi, l.felicidad, l.idPokemon, l.idUsuario, p.NombrePokemon, l.id, p.Tipo , l.salud from Pokemon p
                                        INNER JOIN Pokegotchi as l
                                        on p.id = l.idPokemon and l.id =  @pIdPokegotchi";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                SqlParameter pIdPokegotchi = new SqlParameter("@pIdPokegotchi", idPokegotchi);
                cmd.Parameters.Add(pIdPokegotchi);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pokegotchi.IdUsuario = (int)dr["idUsuario"];
                    pokegotchi.Salud = (int)dr["salud"];
                    pokegotchi.IdPokemon = (int)dr["idPokemon"];
                    pokegotchi.Felicidad = (int)dr["felicidad"];
                    pokegotchi.Id = (int)dr["id"];
                    pokegotchi.Salud = (int)dr["salud"];


                    Pokemon pokemon = new Pokemon();
                    pokemon.NombrePokemon = (string)dr["NombrePokemon"];
                    pokemon.Tipo = (string)dr["Tipo"];
                    pokemon.IdPokegotchi = (int)dr["id"];
                    pokemon.IdApi = (int)dr["idApi"];

                    pokegotchi.Pokemon = pokemon;

                }
                dr.Close();
            }
            catch (Exception error) { }
            return pokegotchi;
        }

        public void InsertarEnPokegotchi(Pokemon pokemonSolicitado, int idUsuario)
        {
            Random random = new Random();
            int salud = random.Next(1, 3);
            int felicidad = random.Next(1, 11);
            Pokemon pokemon = new Pokemon();
            pokemon = pokemonSolicitado;
            try
            {
                string sql = "insert into Pokegotchi (idUsuario, idPokemon, salud, Felicidad) values (@pidUsuario, @pidPokemon, @pSalud, @pFelicidad)";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);

                cmd.Parameters.Add(CrearParametro("@pidUsuario", System.Data.SqlDbType.Int, 0, idUsuario));
                cmd.Parameters.Add(CrearParametro("@pidPokemon", System.Data.SqlDbType.Int, 0, pokemon.Id));
                cmd.Parameters.Add(CrearParametro("@pSalud", System.Data.SqlDbType.Int, 0, salud));
                cmd.Parameters.Add(CrearParametro("@pFelicidad", System.Data.SqlDbType.Int, 0, felicidad));

                cmd.ExecuteNonQuery();
            }
            catch (Exception error) { }
        }
       public void AumentarFelicidad(int idPoketgotchi)
        {
            Pokegotchi pokegotchi = RecuperaPokegotchiPorId(idPoketgotchi);
            try
            {
                string sql = @"UPDATE Pokegotchi
                            SET felicidad = @pFelicidad
                            WHERE id = @pId";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                cmd.Parameters.Add(CrearParametro("@pId", System.Data.SqlDbType.Int, 0, pokegotchi.Id));
                cmd.Parameters.Add(CrearParametro("@pFelicidad", System.Data.SqlDbType.Int, 0, pokegotchi.Felicidad + new Random().Next(1, 3)));
                cmd.ExecuteNonQuery();
            }
            catch (Exception error) { }

        }


        public void DisminuirFelicidad(int idPoketgotchi)
        {
            
            Pokegotchi pokegotchi = RecuperaPokegotchiPorId(idPoketgotchi);
            try
            {
                string sql = @"UPDATE Pokegotchi
                            SET felicidad = @pFelicidad
                            WHERE id = @pId";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                cmd.Parameters.Add(CrearParametro("@pId", System.Data.SqlDbType.Int, 0, pokegotchi.Id));
                cmd.Parameters.Add(CrearParametro("@pFelicidad", System.Data.SqlDbType.Int, 0, pokegotchi.Felicidad - new Random().Next(1, 3)));
                cmd.ExecuteNonQuery();
            }
            catch (Exception error) { }
        }

        public void AumentarSalud(int idPoketgotchi)
        {
            Pokegotchi pokegotchi = RecuperaPokegotchiPorId(idPoketgotchi);
            try
            {
                string sql = @"UPDATE Pokegotchi
                            SET salud = @pSalud
                            WHERE id = @pId";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                cmd.Parameters.Add(CrearParametro("@pId", System.Data.SqlDbType.Int, 0, pokegotchi.Id));
                cmd.Parameters.Add(CrearParametro("@pSalud", System.Data.SqlDbType.Int, 0, pokegotchi.Salud + new Random().Next(1, 3)));
                cmd.ExecuteNonQuery();
            }
            catch (Exception error) { }

        }


        public void DisminuirSalud(int idPoketgotchi)
        {
            Pokegotchi pokegotchi = RecuperaPokegotchiPorId(idPoketgotchi);
            try
            {
                string sql = @"UPDATE Pokegotchi
                            SET salud = @pSalud
                            WHERE id = @pId";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                cmd.Parameters.Add(CrearParametro("@pId", System.Data.SqlDbType.Int, 0, pokegotchi.Id));
                cmd.Parameters.Add(CrearParametro("@pSalud", System.Data.SqlDbType.Int, 0, pokegotchi.Salud - new Random().Next(1, 3)));
                cmd.ExecuteNonQuery();
            }
            catch (Exception error) { }
        }

        public int SelectMediaFelicidadPokegotchiPorIdUsuario(int idUsuario)
        {
            int felicidad = 0;
            try
            {
                string sql = @"select avg(Felicidad) felicidad from Pokegotchi where idUsuario =  @pidUsuario";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                SqlParameter pIdPokegotchi = new SqlParameter("@pidUsuario", idUsuario);
                cmd.Parameters.Add(pIdPokegotchi);

                felicidad = (int)cmd.ExecuteScalar();
            }
            catch (Exception error) { }
            return felicidad;
        }

        public int SelectMediaSaludPokegotchiporIdUsuario(int idUsuario)
        {
            int salud =0;
            try
            {
                string sql = @"select avg(salud) from Pokegotchi where idUsuario = @pIdUsuario";
                SqlCommand cmd = new SqlCommand(sql, conexion.Conexion);
                SqlParameter pIdPokegotchi = new SqlParameter("@pIdUsuario", idUsuario);
                cmd.Parameters.Add(pIdPokegotchi);

                salud = (int)cmd.ExecuteScalar();
               
            }
            catch (Exception error) { }
            return salud;
        }

        

    }
}

