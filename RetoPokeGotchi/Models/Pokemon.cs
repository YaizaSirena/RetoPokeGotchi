using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetoPokeGotchi.Models
{
    public class Pokemon
    {
        int id;
        string nombrePokemon;
        string tipo;
        int idApi;

        int idPokegotchi;

        public int Id { get => id; set => id = value; }
        public string NombrePokemon { get => nombrePokemon; set => nombrePokemon = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int IdPokegotchi { get => idPokegotchi; set => idPokegotchi = value; }
        public int IdApi { get => idApi; set => idApi = value; }
    }
}