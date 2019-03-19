using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using SistemaGerenciamento.Domain.ApplicationInterfaces;
using SistemaGerenciamento.Domain.ComponentInterfaces;
using SistemaGerenciamento.Domain.Entities;

namespace SistemaGerenciamento.Application
{
    public class ProcessApplication : IProcessApplication
    {
        private IProcessContext processContext;
        private IProcessReadOnlyContext processReadOnlyContext;
        public ProcessApplication(IProcessContext processContext,
            IProcessReadOnlyContext processReadOnlyContext)
        {
            this.processContext = processContext;
            this.processReadOnlyContext = processReadOnlyContext;
        }

        public decimal GetAverage(string state, string companyName)
        {
            var processes = this.processReadOnlyContext.GetProcesses()
                                                       .Where(process => process.State.Contains(state) && process.Company.Name.Contains(companyName));

            return (processes.Sum(process => process.Value) / processes.Count());
        }

        public IEnumerable<Process> GetProcess(int year, int month)
        {
            return this.processReadOnlyContext.GetProcesses()
                                              .Where(process =>
                                                process.CreationDate.Year.Equals(year)
                                                &&
                                                process.CreationDate.Month.Equals(month)
                                              ); ;
        }

        public IEnumerable<Process> GetProcess(string partNumber)
        {
            return this.processReadOnlyContext.GetProcesses()
                                              .Where(process => process.Number.Contains(partNumber));
        }

        public int GetQuantityProcessOverValue(decimal value)
        {
            return this.processReadOnlyContext.GetProcesses()
                                              .Count(process => process.Value > value);
        }

        public decimal GetTotalActiveProcess()
        {
            return this.processReadOnlyContext.GetProcesses()
                                              .Where(process => process.Active)
                                              .Sum(process => process.Value);
        }

        public void Delete(Process process)
        {
            if (ReferenceEquals(process, null))
            {
                return;
            }

            this.processContext.Delete(process);
        }

        public void Delete(IEnumerable<Process> processes)
        {
            if (processes.Count() == 0 || ReferenceEquals(processes, null))
            {
                return;
            }

            this.processContext.Delete(processes);
        }

        public void Insert(Process process)
        {
            if (ReferenceEquals(process, null))
            {
                return;
            }

            this.processContext.Insert(process);
        }

        public void Insert(IEnumerable<Process> processes)
        {
            if (processes.Count() == 0 || ReferenceEquals(processes, null))
            {
                return;
            }

            this.processContext.Insert(processes);
        }

        public void Update(Process item, params Expression<Func<Process, object>>[] expressions)
        {
            if (ReferenceEquals(item, null))
            {
                return;
            }

            this.processContext.Update(item, expressions);
        }

        public void Update(Process process)
        {
            if (ReferenceEquals(process, null))
            {
                return;
            }

            this.processContext.Update(process);
        }

        public void Update(IEnumerable<Process> processes)
        {
            if (processes.Count() == 0 || ReferenceEquals(processes, null))
            {
                return;
            }

            this.processContext.Update(processes);
        }
    }
}
