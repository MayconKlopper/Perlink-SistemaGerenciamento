using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using SistemaGerenciamento.Domain.ComponentInterfaces;
using SistemaGerenciamento.Domain.Entities;
using SistemaGerenciamento.EntityFramework.Conections;

namespace SistemaGerenciamento.EntityFramework.Persistence
{
    public class ProcessContext : BaseContext<Process>, IProcessContext, IProcessReadOnlyContext
    {
        public ProcessContext(Conection conection) : base(conection)
        {

        }

        public IEnumerable<Process> GetProcesses()
        {
            return conection.Processes
                            .Include(process => process.Company);
        }
    }
}
