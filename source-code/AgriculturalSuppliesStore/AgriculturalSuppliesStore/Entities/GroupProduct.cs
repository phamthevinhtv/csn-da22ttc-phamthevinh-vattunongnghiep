using AgriculturalSuppliesStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Entities
{
    internal class GroupProduct : IBaseEntity
    {
        private string id;
        private string groupProductName;
        private string groupProductDescription;
        private string employeeId;

        public string Id { get => this.id; set => this.id = value; }
        public string GroupProductName { get => this.groupProductName; set => this.groupProductName = value; }
        public string GroupProductDescription { get => this.groupProductDescription; set => this.groupProductDescription = value; }
        public string EmployeeId { get => this.employeeId; set => this.employeeId = value; }

        public GroupProduct(string id, string name, string description, string employeeId)
        {
            this.id = id;
            this.groupProductName = name;
            this.groupProductDescription = description;
            this.employeeId = employeeId;
        }

        public void Display()
        {
            Console.WriteLine($"| {this.id,-10} | {this.groupProductName,-20} | {this.groupProductDescription,-50} | {this.employeeId,-12} |");
            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+{new string('-', 14)}+");
        }

        public override bool Equals(object obj)
        {
            if (obj is GroupProduct other)
            {
                return this.groupProductName == other.groupProductName &&
                    this.groupProductDescription == other.groupProductDescription &&
                    this.employeeId == other.employeeId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.groupProductName.GetHashCode();
            hash = hash * 23 + this.groupProductDescription.GetHashCode();
            hash = hash * 23 + this.employeeId.GetHashCode();
            return hash;
        }

    }
}
