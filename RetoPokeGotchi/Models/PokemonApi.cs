using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetoPokeGotchi.Models
{
    public class PokemonApi
    {
        string nombre;
        string tipo;
        int id;
        int evolucionSiguiente;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Id { get => id; set => id = value; }
        public int EvolucionSiguiente { get => evolucionSiguiente; set => evolucionSiguiente = value; }

    }
}