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
            try
            {
                PokemonApi pokemonApi = new PokemonApi();
                PokemonSpecies pokemonSpecie = await DataFetcher.GetNamedApiObject<PokemonSpecies>(nombrePokemon.ToLower());
                if (pokemonSpecie != null)
                {
                    pokemonApi.Id = pokemonSpecie.ID;
                    pokemonApi.Nombre = pokemonSpecie.Name;
             

                    PokeAPI.Pokemon pokemon = await DataFetcher.GetNamedApiObject<PokeAPI.Pokemon>(pokemonSpecie.ID.ToString());
                    if(pokemon.Types != null)
                    {
                        pokemonApi.Tipo = pokemon.Types[0].Type.Name;
                    }

                    return pokemonApi;
                }
            }
            catch (Exception error) { }
            return null;
        }
    }
}