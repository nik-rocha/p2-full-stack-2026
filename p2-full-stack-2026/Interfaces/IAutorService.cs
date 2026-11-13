
using p2_full_stack_2026.DTO;

namespace p2_full_stack_2026.Interfaces
{
    public interface IAutorService
    {
        public List<AutorResposta> GetAll();

        public AutorResposta GetById(int id);

        public AutorResposta Create(AutorRequisicao requisicao);

        public AutorResposta Update(int id, AutorRequisicao requisicao);

        public void Delete(int id);
    }
}
