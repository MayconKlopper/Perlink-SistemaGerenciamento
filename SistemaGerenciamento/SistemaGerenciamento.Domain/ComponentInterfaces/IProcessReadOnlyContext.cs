using System;
using System.Collections.Generic;

using SistemaGerenciamento.Domain.Entities;

namespace SistemaGerenciamento.Domain.ComponentInterfaces
{
    public interface IProcessReadOnlyContext
    {
        IEnumerable<Process> GetProcesses();
    }
}
