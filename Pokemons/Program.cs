using Pokemons.Models;
using Pokemons.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPokemonService, PokemonService>();//for every request it creates the pokemon service object and deletes it after it finishes with the request.
// builder.Services.AddTransient<IPokemonService, PokemonService>();//a new instance of the PokemonService is created everytime it is requested form the dependency injection container.(eveyline)
// builder.Services.AddSingleton<IPokemonService, PokemonService>();//it creates an instance one for the whole application and delets it when the server stops.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization(); 

app.MapControllers();

app.Run();