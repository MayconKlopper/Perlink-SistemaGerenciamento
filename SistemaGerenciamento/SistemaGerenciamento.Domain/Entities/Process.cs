using System;
using System.Collections.Generic;

namespace SistemaGerenciamento.Domain.Entities
{
    public class Process
    {
        public uint Id { get; set; }
        public uint IdCompany { get; set; }
        public bool Active { get; set; }
        public string Number { get; set; }
        public string State { get; set; }
        public decimal Value { get; set; }
        public DateTimeOffset CreationDate { get; set; }

        #region RelationShip

        public Company Company { get; set; }

        #endregion

        #region Equals

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Process process = obj as Process;
            if ((Process)process == null)
                return false;

            return this.Id == process.Id
                && this.IdCompany == process.IdCompany
                && this.Active == process.Active
                && this.Number == process.Number
                && this.State == process.State
                && this.Value == process.Value
                && this.CreationDate == process.CreationDate;
        }

        public override int GetHashCode()
        {
            var hashCode = 248613386;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + IdCompany.GetHashCode();
            hashCode = hashCode * -1521134295 + Active.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Number);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(State);
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(CreationDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<Company>.Default.GetHashCode(Company);
            return hashCode;
        }

        #endregion
    }
}
