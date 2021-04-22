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
        int salud ;
        int felicidad;
        string estado;

        public int Id { get => id; set => id = value; }
        public string NombrePokemon { get => nombrePokemon; set => nombrePokemon = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Felicidad { get => felicidad; set => felicidad = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}