using backend.Models;
namespace backend.Interfaces
{
    public interface IPokemonRepository
    {
        Task<Pokemon> CreatePokemon(Pokemon pokemon);
        Task<List<Pokemon>> GetPokemon();
        Task<Pokemon> GetPokemonById(int Id);
        Task<Pokemon> EditPokemon(Pokemon pokemon);
        Task<bool> DeletePokemon(int id);
    }
}