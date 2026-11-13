using p2_full_stack_2026.Data;
using p2_full_stack_2026.Entities;
using p2_full_stack_2026.Interfaces;

namespace p2_full_stack_2026.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ContextDB _context;

        public AutorRepository(ContextDB context)
        {
            _context = context;
        }

        public bool AutorTemLivros(int id)
        {
            var livroAutor = _context.Livros.Any(livro => livro.AutorId == id);
            return livroAutor;
        }

        public AutorEntity Create(AutorEntity autor)
        {
            _context.Autor.Add(autor);
            _context.SaveChanges();
            return autor;
        }

        public void Delete(AutorEntity autor)
        {
            _context.Autor.Remove(autor);
            _context.SaveChanges();
        }

        public List<AutorEntity> GetAll()
        {
            var autores = _context.Autor.OrderBy(autor => autor.Nome).ToList();
            return autores;
        }

        public AutorEntity GetById(int id)
        {
           var autor = _context.Autor.FirstOrDefault(autor => autor.Id == id);
            return autor;
        }

        public AutorEntity Update(int id, AutorEntity autor)
        {
            _context.SaveChanges();
            return autor;
        }
    }
}
