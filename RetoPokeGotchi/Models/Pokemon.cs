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
        string salud ;

        public int Id { get => id; set => id = value; }
        public string NombrePokemon { get => nombrePokemon; set => nombrePokemon = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Salud { get => salud; set => salud = value; }
    }
}