using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Entities
{
    internal class ProductGroup : IBaseEntity
    {
        private string id;
        private string productGroupName;
        private string productGroupDescription;
        private string employeeId;

        public string Id { get => this.id; set => this.id = value; }
        public string ProductGroupName { get => this.productGroupName; set => this.productGroupName = value; }
        public string ProductGroupDescription { get => this.productGroupDescription; set => this.productGroupDescription = value; }
        public string EmployeeId { get => this.employeeId; set => this.employeeId = value; }

        public ProductGroup(string id, string name, string description, string employeeId)
        {
            this.id = id;
            this.productGroupName = name;
            this.productGroupDescription = description;
            this.employeeId = employeeId;
        }

        public void DisplayDetail()
        {
            Console.WriteLine($"Mã nhóm sản phẩm: {this.id}");
            Console.WriteLine($"Tên nhóm sản phẩm: {this.productGroupName}");
            Console.WriteLine($"Mô tả nhóm sản phẩm: {this.productGroupDescription}");
            Console.WriteLine($"Mã nhân viên phụ trách: {this.employeeId}");
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductGroup other)
            {
                return this.productGroupName == other.productGroupName &&
                    this.productGroupDescription == other.productGroupDescription &&
                    this.employeeId == other.employeeId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.productGroupName.GetHashCode();
            hash = hash * 23 + this.productGroupDescription.GetHashCode();
            hash = hash * 23 + this.employeeId.GetHashCode();
            return hash;
        }
    }
}
