using p2_full_stack_2026.DTO;
using p2_full_stack_2026.Entities;
using p2_full_stack_2026.Interfaces;

namespace p2_full_stack_2026.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public AutorResposta Create(AutorRequisicao requisicao)
        {
            ValidarAtributos(requisicao);

            AutorEntity autor = new AutorEntity
            {
                Nome = requisicao.Nome.Trim(),
                Nacionalidade = requisicao.Nacionalidade.Trim()
            };

            _autorRepository.Create(autor);

            return new AutorResposta
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Nacionalidade = autor.Nacionalidade
            };

        }

        public void Delete(int id)
        {
            var autor = _autorRepository.GetById(id);

            if (autor == null)
            {
                throw new Exception($"Autor com ID {id} não encontrado.");
            }

            bool autorTemLivros = _autorRepository.AutorTemLivros(id);

            if (autorTemLivros)
            {
                throw new Exception($"O autor com ID {id} possui livros associados e não pode ser excluído.");
            }

            _autorRepository.Delete(autor);
        }

        public List<AutorResposta> GetAll()
        {
            var autores = _autorRepository.GetAll();

            return autores.Select(autor => new AutorResposta
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Nacionalidade = autor.Nacionalidade
            }).ToList();
        }

        public AutorResposta GetById(int id)
        {
            var autor = _autorRepository.GetById(id);

            if (autor == null)
            {
                throw new Exception($"Autor com ID {id} não encontrado.");
            }

            return new AutorResposta
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Nacionalidade = autor.Nacionalidade
            };
        }

        public AutorResposta Update(int id, AutorRequisicao requisicao)
        {

            ValidarAtributos(requisicao);

            var autorExistente = _autorRepository.GetById(id);

            if (autorExistente == null)
            {
                throw new Exception($"Autor com ID {id} não encontrado.");
            }

            autorExistente.Nome = requisicao.Nome.Trim();
            autorExistente.Nacionalidade = requisicao.Nacionalidade.Trim();

            _autorRepository.Update(autorExistente);

            return new AutorResposta
            {
                Id = autorExistente.Id,
                Nome = autorExistente.Nome,
                Nacionalidade = autorExistente.Nacionalidade
            };
        }

        private void ValidarAtributos(AutorRequisicao requisicao)
        {
            if (string.IsNullOrWhiteSpace(requisicao.Nome))
            {
                throw new ArgumentException("O nome do autor não pode ser nulo ou vazio.");
            }

            if (string.IsNullOrWhiteSpace(requisicao.Nacionalidade))
            {
                throw new ArgumentException("A nacionalidade do autor não pode ser nula ou vazia.");
            }

            string nomeCorreto = requisicao.Nome.Trim();
            string nacionalidadeCorreta = requisicao.Nacionalidade.Trim();

            if (nomeCorreto.Length > 100)
            {
                throw new ArgumentException("O nome do autor não pode ter mais de 100 caracteres.");
            }

            if (nacionalidadeCorreta.Length > 50)
            {
                throw new ArgumentException("A nacionalidade do autor não pode ter mais de 50 caracteres.");
            }
        }
    }
}
