using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using SistemaGerenciamento.Domain.ApplicationInterfaces;
using SistemaGerenciamento.Domain.ComponentInterfaces;
using SistemaGerenciamento.Domain.Entities;

namespace SistemaGerenciamento.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        private readonly ICompanyContext companyContext;
        private readonly ICompanyReadOnlyContext companyReadOnlyContext;

        public CompanyApplication(ICompanyContext companyContext,
            ICompanyReadOnlyContext companyReadOnlyContext)
        {
            this.companyContext = companyContext;
            this.companyReadOnlyContext = companyReadOnlyContext;
        }

        public IEnumerable<Company> GetProcessSameState()
        {
            return this.companyReadOnlyContext.GetCompanies().Select(
                company => new Company()
                {
                    Id = company.Id,
                    CNPJ = company.CNPJ,
                    Name = company.Name,
                    State = company.State,
                    Processes = company.Processes.Where(process => process.State.Equals(company.State))
                }
            ).Where(company => company.Processes.Count() > 0);
        }

        public void Delete(Company company)
        {
            if (ReferenceEquals(company, null))
            {
                return;
            }

            this.companyContext.Delete(company);
        }

        public void Delete(IEnumerable<Company> companies)
        {
            if (companies.Count() == 0 || ReferenceEquals(companies, null))
            {
                return;
            }

            this.companyContext.Delete(companies);
        }

        public void Insert(Company company)
        {
            if (ReferenceEquals(company, null))
            {
                return;
            }

            this.companyContext.Insert(company);
        }

        public void Insert(IEnumerable<Company> companies)
        {
            if (companies.Count() == 0 || ReferenceEquals(companies, null))
            {
                return;
            }

            this.companyContext.Insert(companies);
        }

        public void Update(Company item, params Expression<Func<Company, object>>[] expressions)
        {
            if (ReferenceEquals(item, null))
            {
                return;
            }

            this.companyContext.Update(item, expressions);
        }

        public void Update(Company company)
        {
            if (ReferenceEquals(company, null))
            {
                return;
            }

            this.companyContext.Update(company);
        }

        public void Update(IEnumerable<Company> companies)
        {
            if (companies.Count() == 0 || ReferenceEquals(companies, null))
            {
                return;
            }

            this.companyContext.Update(companies);
        }
    }
}
