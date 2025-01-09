using MongoDB.Driver;
using Pokemons.Models;

namespace Pokemons.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IMongoCollection<Pokemon> _pokemonCollection; //it holds the data entry on the pokemon database, if we write someting on this it will write it on the database. it holds everthing on the databse related to that specific collection.
        public PokemonService(IConfiguration configuration)
        { //Iconfig hold everything on the appsettings.Json.
            var client = new MongoClient(configuration["MongoDbSettings:ConncetionString"]); //mongoClient uses the URL that is passed to it to conncet to the mongoDB
            var database = client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]); // client is used to connect to the specific database named PokemonDB
            _pokemonCollection = database.GetCollection<Pokemon>(configuration["MongoDbSettings:CollectionName"]);// gets the Pokemons collection form the database
        }
        public async Task<List<Pokemon>> GetAllPokemon()
        {
            return await _pokemonCollection.Find(p => true).ToListAsync();
        }

        public async Task<Pokemon> GetPokemonById(string id)
        {
            return await _pokemonCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Pokemon> GetPokemonByName(string name)
        {
            return await _pokemonCollection.Find(p => p.Name == name).FirstOrDefaultAsync();
        }
        public async Task<bool> AddPokemon(Pokemon pokemon)
        {
            try
            {
                await _pokemonCollection.InsertOneAsync(pokemon);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdatePokemonById(string id, Pokemon pokemon)
        {
            try
            {
                pokemon.Id = id;
                var status = await _pokemonCollection.ReplaceOneAsync(p => p.Id == id, pokemon);
                if (status.ModifiedCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeletePokemonById(string id)
        {
            try
            {
                var status = await _pokemonCollection.DeleteOneAsync(p => p.Id == id);
                if (status.DeletedCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}