using Microsoft.EntityFrameworkCore;
using backend.Interfaces;
using backend.Models;

namespace backend.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        public readonly TestingDBContext _testDBContext;
        public PokemonRepository(TestingDBContext testDBContext)
        {
            _testDBContext = testDBContext;
        }
        public async Task<Pokemon> CreatePokemon(Pokemon pokemon)
        {
            _testDBContext.PokemonsTable.Add(pokemon);
            await _testDBContext.SaveChangesAsync();
            return pokemon;
        }

        public async Task<bool> DeletePokemon(int pokemonId)
        {
            var rows = await _testDBContext.PokemonsTable
                .Where(x => x.PokemonId == pokemonId)
                .ExecuteDeleteAsync();
            return true;
        }

        public async Task<Pokemon> EditPokemon(Pokemon pokemon)
        {
            var rows = await _testDBContext.PokemonsTable.Where(x => x.PokemonId == pokemon.PokemonId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.Name, pokemon.Name));
            return pokemon;
        }

        public async Task<List<Pokemon>> GetPokemon()
        {
            var result = await _testDBContext.PokemonsTable.Include(x => x.Region).Include(x => x.Type)
                .Select(x => new Pokemon
                {
                    PokemonId = x.PokemonId,
                    Name = x.Name,
                    PokedexNumber = x.PokedexNumber,
                    Region = x.Region,
                    Type = x.Type,
                    RegionId = x.RegionId,
                    TypeId = x.TypeId
                }).ToListAsync();
            return result;
        }

        public async Task<Pokemon> GetPokemonById(int Id)
        {
            var result = await _testDBContext.PokemonsTable.Include(x => x.Region).Include(x => x.Type).Where(x => x.PokemonId == Id)
              .Select(x => new Pokemon
              {
                  PokemonId = x.PokemonId,
                  Name = x.Name,
                  PokedexNumber = x.PokedexNumber,
                  Region = x.Region,
                  Type = x.Type,
                  RegionId = x.RegionId,
                  TypeId = x.TypeId
              }).FirstOrDefaultAsync();
            return result;
        }
    }
}