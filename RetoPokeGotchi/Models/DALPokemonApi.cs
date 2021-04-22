using PokeAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RetoPokeGotchi.Models
{
    public class DALPokemonApi
    {
        public async Task<PokemonApi> recuperarPokemonAPI(string nombrePokemon)
        {
            PokemonApi pokemonApi = new PokemonApi();
            PokemonSpecies pokemonSpecie = await DataFetcher.GetNamedApiObject<PokemonSpecies>(nombrePokemon.ToLower());
            if(pokemonSpecie != null)
            {
               //await DataFetcher.GetNamedApiObject<PokeAPI.Pokemon>("25");
                //pokemonApi.Id = pokemonSpecie.ID;
                pokemonApi.Nombre = pokemonSpecie.Name;
            }
            return pokemonApi;
        }



    }
}