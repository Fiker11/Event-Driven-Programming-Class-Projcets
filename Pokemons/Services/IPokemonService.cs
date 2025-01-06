using Pokemons.Models;

namespace Pokemons.Services{
    public interface IPokemonService{
        public Task<List<Pokemon>> GetAllPokemon();
        public Task<Pokemon> GetPokemonById(string id);
        public Task<Pokemon> GetPokemonByName(string name);
        public Task<bool> AddPokemon(Pokemon pokemon);
        public Task<bool> UpdatePokemonById(string id, Pokemon pokemon);
        public Task<bool> DeletePokemonById(string id);
    }
}