using System.Collections.Generic;

using SistemaGerenciamento.Domain.Entities;

namespace SistemaGerenciamento.Domain.ComponentInterfaces
{
    public interface ICompanyReadOnlyContext
    {
        IEnumerable<Company> GetCompanies();
    }
}
