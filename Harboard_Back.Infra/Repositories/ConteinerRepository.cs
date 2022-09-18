using Harboard_Back.Domain.Entities;
using Harboard_Back.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Harboard_Back.Infra.Repositories
{
    public class ConteinerRepository : IConteinerRepository
    {
        private PostgreSQLDbContext dbContext;

        public ConteinerRepository(PostgreSQLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Conteiner AtualizarConteiner(int idConteiner, Conteiner conteinerAtualizar)
        {
            Conteiner conteinerAntigo = this.PesquisarConteinerPorId(idConteiner).Result;
            if(conteinerAntigo == null)
            {
                return null;
            }
            conteinerAntigo = null;
            this.dbContext.conteiner.Update(conteinerAtualizar);
            this.dbContext.SaveChanges();
            return conteinerAtualizar;
        }

        public async Task<Conteiner> CadastrarConteiner(Conteiner conteinerCadastrar)
        {
            this.dbContext.conteiner.Add(conteinerCadastrar);
            this.dbContext.SaveChanges();
            return await this.dbContext.conteiner.FindAsync(conteinerCadastrar.id);

        }

        public Conteiner ExcluirConteinerPorId(int idConteiner)
        {
            Conteiner conteinerDeletar = this.PesquisarConteinerPorId(idConteiner).Result;
            if(conteinerDeletar == null)
            {
                return null;
            }
            this.dbContext.conteiner.Remove(conteinerDeletar);
            this.dbContext.SaveChanges();
            return conteinerDeletar;
        }

        public Task<List<Conteiner>> ListarConteineres()
        {
            return this.dbContext.conteiner.ToListAsync();
        }

        public Task<Conteiner> PesquisarConteinerPorId(int idConteiner)
        {
            return this.dbContext.conteiner.AsNoTracking().FirstOrDefaultAsync(cont => cont.id == idConteiner);
        }
    }
}
