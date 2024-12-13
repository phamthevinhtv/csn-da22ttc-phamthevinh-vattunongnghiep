using AgriculturalSuppliesStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Entities
{
    internal class ProductUse : IBaseEntity
    {
        private string id;
        private string productId;
        private string useId;

        public string Id { get => this.id; set => this.id = value; }
        public string ProductId { get => this.productId; set => this.productId = value; }
        public string UseId { get => this.useId; set => this.useId = value; }

        public ProductUse(string id, string productId, string useId)
        {
            this.id = id;
            this.productId = productId;
            this.useId = useId;
        }

        public void Display()
        {
            Console.WriteLine($"| {this.id,-6} | {this.productId,-6} | {this.useId,-6} |");
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductUse other)
            {
                return this.productId == other.productId &&
                    this.useId == other.useId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.productId.GetHashCode();
            hash = hash * 23 + this.useId.GetHashCode();
            return hash;
        }
    }
}
