﻿using System;
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
        string salud = "Tranquilo";

        Pokemon pokemon = new Pokemon()
        {
        };

        public int Id { get => id; set => id = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdPokemon { get => idPokemon; set => idPokemon = value; }
        public string Salud { get => salud; set => salud = value; }
    }
}