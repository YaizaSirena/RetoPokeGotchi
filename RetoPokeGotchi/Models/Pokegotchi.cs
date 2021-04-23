using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetoPokeGotchi.Models
{
    public class Pokegotchi
    {
        int id;           
        int idUsuario;
        int idPokemon;
        int salud;
        int felicidad;
        Pokemon pokemon;

     

        public int Id { get => id; set => id = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdPokemon { get => idPokemon; set => idPokemon = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Felicidad { get => felicidad; set => felicidad = value; }
        public Pokemon Pokemon { get => pokemon; set => pokemon = value; }
    }
}