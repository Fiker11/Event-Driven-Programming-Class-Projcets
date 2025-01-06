using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pokemons.Models{
    public class Pokemon{
        [BsonId]//telling hte database that the id is the id I defined here 
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id{ get; set;}
        public string? Name{ get; set;}
        public string? Ability{ get; set;}
        public string? Type{ get; set;}
        public string? Level{ get; set;}
    }
}