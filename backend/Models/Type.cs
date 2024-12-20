namespace backend.Models
{
    public class Type
    {
        public int TypeId { get; set; }
        public string? TypeName { get; set; }
        public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    }
}