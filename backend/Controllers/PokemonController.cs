using Microsoft.AspNetCore.Mvc;
using backend.Interfaces;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet("GetPokemon")]
        public async Task<IActionResult> GetPokemon()
        {
            var x = await _pokemonRepository.GetPokemon();
            return Ok(x);
        }

        [HttpPost("CreatePokemon")]
        public async Task<IActionResult> CreatePokemon([FromBody] Pokemon pokemon)
        {
            var pokemons = await _pokemonRepository.CreatePokemon(pokemon);
            return Ok(pokemons);
        }

        [HttpPut("EditPokemon")]
        public async Task<IActionResult> EditPokemon([FromBody] Pokemon pokemon)
        {
            var editedPokemon = await _pokemonRepository.EditPokemon(pokemon);
            return Ok(editedPokemon);
        }

        [HttpDelete("DeletePokemon")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var pokemonToDelete = await _pokemonRepository.DeletePokemon(id);
            return Ok(pokemonToDelete);
        }
    }
}

// CreatePokemon JSON body for endpoint
// {
//   "PokemonId": 7, 
//   "Name": "Bulbasaur",
//   "TypeId": 1,
//   "PokedexNumber": 7, 
//   "RegionId": 1, 
//   "RegionName": "Kanto",
//   "TypeName": "Grass"
// }

// EditPokemon JSON
// {
//   "PokemonId": 3,
//   "name": "NewName2"
// }