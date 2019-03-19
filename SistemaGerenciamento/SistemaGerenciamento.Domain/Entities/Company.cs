using System.Collections.Generic;

namespace SistemaGerenciamento.Domain.Entities
{
    public class Company
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string State { get; set; }

        #region RelationShip

        public IEnumerable<Process> Processes { get; set; }

        #endregion

        #region Equals

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Company company = obj as Company;
            if ((Company)company == null)
                return false;

            return this.Id == company.Id
                && this.Name == company.Name
                && this.CNPJ == company.CNPJ
                && this.State == company.State;
        }

        public override int GetHashCode()
        {
            var hashCode = 641959112;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CNPJ);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(State);
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<Process>>.Default.GetHashCode(Processes);
            return hashCode;
        }

        #endregion
    }
}
