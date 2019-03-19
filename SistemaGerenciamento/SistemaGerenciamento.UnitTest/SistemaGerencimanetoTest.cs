using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

using SistemaGerenciamento.Application;
using SistemaGerenciamento.Domain.ComponentInterfaces;
using SistemaGerenciamento.Domain.Entities;

namespace SistemaGerenciamento.UnitTest
{
    [TestClass]
    public class SistemaGerencimanetoTest
    {
        private CompanyApplication companyApplication;
        private ProcessApplication processApplication;

        Mock<ICompanyContext> companyContext;
        Mock<ICompanyReadOnlyContext> companyReadOnlyContext;

        Mock<IProcessContext> processContext;
        Mock<IProcessReadOnlyContext> processReadOnlyContext;

        [TestInitialize]
        public void Initialize()
        {
            var companies = new List<Company>() {
                new Company() { Id = 1, Name = "Empresa A", CNPJ = "00000000000001", State = "Rio de Janeiro",
                    Processes = new List<Process>() {
                        new Process() { Id = 1, IdCompany = 1, Active = true, Number = "00001CIVELRJ", State = "Rio de Janeiro", Value = 200000M, CreationDate = new DateTime(2007, 10, 10) },
                        new Process() { Id = 2, IdCompany = 1, Active = true, Number = "00002CIVELSP", State = "São Paulo", Value = 100000M, CreationDate = new DateTime(2007, 10, 20) },
                        new Process() { Id = 3, IdCompany = 1, Active = false, Number = "00003TRABMG", State = "Minas Gerais", Value = 10000M, CreationDate = new DateTime(2007, 10, 30) },
                        new Process() { Id = 4, IdCompany = 1, Active = false, Number = "00004CIVELRJ", State = "Rio de Janeiro", Value = 20000M, CreationDate = new DateTime(2007, 11, 10) },
                        new Process() { Id = 5, IdCompany = 1, Active = true, Number = "00005CIVELSP", State = "São Paulo", Value = 35000M, CreationDate = new DateTime(2007, 11, 15) }
                    }
                },
                new Company() { Id = 2, Name = "Empresa B", CNPJ = "00000000000002", State = "São Paulo",
                    Processes = new List<Process>() {
                        new Process() { Id = 6, IdCompany = 2, Active = true, Number = "00006CIVELRJ", State = "Rio Janeiro", Value = 20000M, CreationDate = new DateTime(2007, 5, 1) },
                        new Process() { Id = 7, IdCompany = 2, Active = true, Number = "00007CIVELRJ", State = "Rio de Janeiro", Value = 700000M, CreationDate = new DateTime(2007, 6, 2) },
                        new Process() { Id = 8, IdCompany = 2, Active = false, Number = "00008CIVELSP", State = "São Paulo", Value = 500M, CreationDate = new DateTime(2007, 7, 3) },
                        new Process() { Id = 9, IdCompany = 2, Active = true, Number = "00009CIVELSP", State = "São Paulo", Value = 32000M, CreationDate = new DateTime(2007, 8, 4) },
                        new Process() { Id = 10, IdCompany = 2, Active = false, Number = "00010TRABAM", State = "Amazonas", Value = 1000M, CreationDate = new DateTime(2007, 9, 5) }
                    }
                }
            };
            var processes = new List<Process>() {
                new Process() { Id = 1, IdCompany = 1, Active = true, Number = "00001CIVELRJ", State = "Rio de Janeiro", Value = 200000M, CreationDate = new DateTime(2007, 10, 10), Company = new Company() { Id = 1, Name = "Empresa A", CNPJ = "00000000000001", State = "Rio de Janeiro" } },
                new Process() { Id = 2, IdCompany = 1, Active = true, Number = "00002CIVELSP", State = "São Paulo", Value = 100000M, CreationDate = new DateTime(2007, 10, 20), Company = new Company() { Id = 1, Name = "Empresa A", CNPJ = "00000000000001", State = "Rio de Janeiro" } },
                new Process() { Id = 3, IdCompany = 1, Active = false, Number = "00003TRABMG", State = "Minas Gerais", Value = 10000M, CreationDate = new DateTime(2007, 10, 30), Company = new Company() { Id = 1, Name = "Empresa A", CNPJ = "00000000000001", State = "Rio de Janeiro" } },
                new Process() { Id = 4, IdCompany = 1, Active = false, Number = "00004CIVELRJ", State = "Rio de Janeiro", Value = 20000M, CreationDate = new DateTime(2007, 11, 10), Company = new Company() { Id = 1, Name = "Empresa A", CNPJ = "00000000000001", State = "Rio de Janeiro" } },
                new Process() { Id = 5, IdCompany = 1, Active = true, Number = "00005CIVELSP", State = "São Paulo", Value = 35000M, CreationDate = new DateTime(2007, 11, 15), Company = new Company() { Id = 1, Name = "Empresa A", CNPJ = "00000000000001", State = "Rio de Janeiro" } },

                new Process() { Id = 6, IdCompany = 2, Active = true, Number = "00006CIVELRJ", State = "Rio Janeiro", Value = 20000M, CreationDate = new DateTime(2007, 5, 1), Company = new Company() { Id = 2, Name = "Empresa B", CNPJ = "00000000000002", State = "São Paulo" } },
                new Process() { Id = 7, IdCompany = 2, Active = true, Number = "00007CIVELRJ", State = "Rio de Janeiro", Value = 700000M, CreationDate = new DateTime(2007, 6, 2), Company = new Company() { Id = 2, Name = "Empresa B", CNPJ = "00000000000002", State = "São Paulo" } },
                new Process() { Id = 8, IdCompany = 2, Active = false, Number = "00008CIVELSP", State = "São Paulo", Value = 500M, CreationDate = new DateTime(2007, 7, 3), Company = new Company() { Id = 2, Name = "Empresa B", CNPJ = "00000000000002", State = "São Paulo" } },
                new Process() { Id = 9, IdCompany = 2, Active = true, Number = "00009CIVELSP", State = "São Paulo", Value = 32000M, CreationDate = new DateTime(2007, 8, 4), Company = new Company() { Id = 2, Name = "Empresa B", CNPJ = "00000000000002", State = "São Paulo" } },
                new Process() { Id = 10, IdCompany = 2, Active = false, Number = "00010TRABAM", State = "Amazonas", Value = 1000M, CreationDate = new DateTime(2007, 9, 5), Company = new Company() { Id = 2, Name = "Empresa B", CNPJ = "00000000000002", State = "São Paulo" } }
            };
            this.companyContext = new Mock<ICompanyContext>();
            this.companyReadOnlyContext = new Mock<ICompanyReadOnlyContext>();
            this.companyReadOnlyContext.Setup(companyReadOnlyContext => companyReadOnlyContext.GetCompanies())
                                       .Returns(companies);

            this.processContext = new Mock<IProcessContext>();
            this.processReadOnlyContext = new Mock<IProcessReadOnlyContext>();
            this.processReadOnlyContext.Setup(processReadOnlyContext => processReadOnlyContext.GetProcesses())
                                       .Returns(processes);

            this.companyApplication = new CompanyApplication(this.companyContext.Object, this.companyReadOnlyContext.Object);
            this.processApplication = new ProcessApplication(this.processContext.Object, this.processReadOnlyContext.Object);

        }

        [TestMethod]
        public void SumAllActiveProcess_ExpectedSuccess()
        {
            var expectedTotal = 1087000M;
            var total = this.processApplication.GetTotalActiveProcess();

            Assert.AreEqual(expectedTotal,total);
        }

        [TestMethod]
        public void CalculateAverage_ExpectedSuccess()
        {
            var expectedAverage = 110000M;
            var average = this.processApplication.GetAverage("Rio de Janeiro", "Empresa A");

            Assert.AreEqual(expectedAverage, average);
        }

        [TestMethod]
        public void CalculateNumberProcessOverValue_ExpectdSuccess()
        {
            var expectedQuantity = 2;
            var quantity = this.processApplication.GetQuantityProcessOverValue(100000M);

            Assert.AreEqual(expectedQuantity, quantity);
        }

        [TestMethod]
        public void GetListProcessByCreationDate_ExpectedSuccess()
        {
            var ExpectedList = new List<Process>()
            {
                new Process()
                {
                    Id = 10,
                    IdCompany = 2,
                    Active = false,
                    Number = "00010TRABAM",
                    State = "Amazonas",
                    Value = 1000M,
                    CreationDate = new DateTime(2007, 9, 5),
                    Company = new Company() { Id = 2, Name = "Empresa B", CNPJ = "00000000000002", State = "São Paulo" }
                }
            };
            var processList = this.processApplication.GetProcess(2007, 9).ToList();

            CollectionAssert.AreEqual(ExpectedList, processList);
        }

        [TestMethod]
        public void GetListCompanyProcessSameState_ExpectedSucess()
        {
            var expectedList = new List<Company>()
            {
                new Company() { Id = 1, Name = "Empresa A", CNPJ = "00000000000001", State = "Rio de Janeiro",
                    Processes = new List<Process>() {
                        new Process() { Id = 1, IdCompany = 1, Active = true, Number = "00001CIVELRJ", State = "Rio de Janeiro", Value = 200000M, CreationDate = new DateTime(2007, 10, 10) },
                        new Process() { Id = 4, IdCompany = 1, Active = false, Number = "00004CIVELRJ", State = "Rio de Janeiro", Value = 20000M, CreationDate = new DateTime(2007, 11, 10) }
                    }
                },
                new Company() { Id = 2, Name = "Empresa B", CNPJ = "00000000000002", State = "São Paulo",
                    Processes = new List<Process>() {
                        new Process() { Id = 8, IdCompany = 2, Active = false, Number = "00008CIVELSP", State = "São Paulo", Value = 500M, CreationDate = new DateTime(2007, 7, 3) },
                        new Process() { Id = 9, IdCompany = 2, Active = true, Number = "00009CIVELSP", State = "São Paulo", Value = 32000M, CreationDate = new DateTime(2007, 8, 4) }
                    }
                }
            };
            var list = this.companyApplication.GetProcessSameState();

            CollectionAssert.AreEqual(expectedList, list.ToList());
        }

        [TestMethod]
        public void GetListByPartNumber_ExpectedSucess()
        {
            var expectedList = new List<Process>()
            {
                new Process() { Id = 3, IdCompany = 1, Active = false, Number = "00003TRABMG", State = "Minas Gerais", Value = 10000M, CreationDate = new DateTime(2007, 10, 30) },
                new Process() { Id = 10, IdCompany = 2, Active = false, Number = "00010TRABAM", State = "Amazonas", Value = 1000M, CreationDate = new DateTime(2007, 9, 5) }
            };
            var list = this.processApplication.GetProcess("TRAB");

            CollectionAssert.AreEqual(expectedList, list.ToList());
        }
    }
}
