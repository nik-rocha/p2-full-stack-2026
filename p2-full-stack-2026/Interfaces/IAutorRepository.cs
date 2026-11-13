using p2_full_stack_2026.Entities;

namespace p2_full_stack_2026.Interfaces
{
    public interface IAutorRepository
    {
        public List<AutorEntity> GetAll();
        public AutorEntity GetById(int id);
        public AutorEntity Create(AutorEntity autor);
        public AutorEntity Update(AutorEntity autor);
        public void Delete(AutorEntity autor);
        public bool AutorTemLivros(int id);
    }
}
