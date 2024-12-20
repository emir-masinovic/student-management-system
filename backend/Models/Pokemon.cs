namespace backend.Models
{
    public class Pokemon
    {
        public int PokemonId { get; set; }
        public string? Name { get; set; }
        public int? TypeId { get; set; }
        public int? PokedexNumber { get; set; }
        public int? RegionId { get; set; }
        public virtual Region? Region { get; set; }
        public virtual Type? Type { get; set; }
    }
}
