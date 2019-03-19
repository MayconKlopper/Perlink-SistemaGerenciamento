using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using SistemaGerenciamento.Domain.Entities;

namespace SistemaGerenciamento.Domain.ApplicationInterfaces
{
    public interface IProcessApplication
    {
        void Insert(Process process);

        void Insert(IEnumerable<Process> processes);

        void Update(Process item, params Expression<Func<Process, object>>[] expressions);

        void Update(Process process);

        void Update(IEnumerable<Process> processes);

        void Delete(Process process);

        void Delete(IEnumerable<Process> processes);

        /// <summary>
        /// Recupera uma lista de processos
        /// que contenham a mesma data de criação
        /// </summary>
        /// <returns>
        /// Lista de processos
        /// </returns>
        IEnumerable<Process> GetProcess(int year, int month);

        /// <summary>
        /// Recupera uma lista de processos
        /// quer contenham uma parte do número informado
        /// </summary>
        /// <param name="partNumber"> parte do número </param>
        /// <returns>
        /// Lista de processos
        /// </returns>
        IEnumerable<Process> GetProcess(string partNumber);

        decimal GetTotalActiveProcess();

        decimal GetAverage(string state, string CompanyName);

        int GetQuantityProcessOverValue(decimal Value);
    }
}
