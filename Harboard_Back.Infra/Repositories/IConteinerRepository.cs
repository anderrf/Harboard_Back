using Harboard_Back.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Harboard_Back.Infra.Repositories
{
    public interface IConteinerRepository
    {

        public Task<List<Conteiner>> ListarConteineres();

        public Task<Conteiner> PesquisarConteinerPorId(int idConteiner);

        public Task<Conteiner> CadastrarConteiner(Conteiner conteinerCadastrar);

        public Conteiner AtualizarConteiner(int idConteiner, Conteiner conteinerAtualizar);

        public Conteiner ExcluirConteinerPorId(int idConteiner);

    }
}
