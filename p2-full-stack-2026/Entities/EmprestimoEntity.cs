namespace p2_full_stack_2026.Entities
{
    public class EmprestimoEntity
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public string NomeLeitor { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public virtual LivroEntity? Livro { get; set; }
    }
}
