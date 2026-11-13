using System.Text.Json.Serialization;

namespace p2_full_stack_2026.Entities
{
    public class AutorEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }

        [JsonIgnore]
        public virtual List<LivroEntity> Livros { get; set; }
    }
}
