using System.Text.Json.Serialization;

namespace p2_full_stack_2026.Entities
{
    public class LivroEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
        public int AutorId { get; set; }
        public virtual AutorEntity? Autor { get; set; }

        [JsonIgnore]
        public virtual List<EmprestimoEntity> Emprestimos { get; set; }
    }
}
