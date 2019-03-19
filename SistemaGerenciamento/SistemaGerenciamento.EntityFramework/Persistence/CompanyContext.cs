using System.Collections.Generic;

using SistemaGerenciamento.Domain.Entities;
using SistemaGerenciamento.Domain.ComponentInterfaces;
using SistemaGerenciamento.EntityFramework.Conections;

namespace SistemaGerenciamento.EntityFramework.Persistence
{
    public class CompanyContext : BaseContext<Company>, ICompanyContext, ICompanyReadOnlyContext
    {
        public CompanyContext(Conection conection) : base(conection)
        {

        }

        public IEnumerable<Company> GetCompanies()
        {
            return conection.Companies;
        }
    }
}
