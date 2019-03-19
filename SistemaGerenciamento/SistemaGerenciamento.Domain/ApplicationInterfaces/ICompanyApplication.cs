using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using SistemaGerenciamento.Domain.Entities;

namespace SistemaGerenciamento.Domain.ApplicationInterfaces
{
    public interface ICompanyApplication
    {
        void Insert(Company company);

        void Insert(IEnumerable<Company> companies);

        void Update(Company item, params Expression<Func<Company, object>>[] expressions);

        void Update(Company company);

        void Update(IEnumerable<Company> companies);

        void Delete(Company company);

        void Delete(IEnumerable<Company> companies);

        IEnumerable<Company> GetProcessSameState();
    }
}
