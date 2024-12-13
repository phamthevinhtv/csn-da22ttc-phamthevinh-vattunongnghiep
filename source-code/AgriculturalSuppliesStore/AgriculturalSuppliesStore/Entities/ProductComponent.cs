using AgriculturalSuppliesStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Entities
{
    internal class ProductComponent : IBaseEntity
    {
        private string id;
        private string productId;
        private string componentId;

        public string Id { get => this.id; set => this.id = value; }
        public string ProductId { get => this.productId; set => this.productId = value; }
        public string ComponentId { get => this.componentId; set => this.componentId = value; }

        public ProductComponent(string id, string productId, string componentId)
        {
            this.id = id;
            this.productId = productId;
            this.componentId = componentId;
        }

        public void Display()
        {
            Console.WriteLine($"| {this.id,-6} | {this.productId,-6} | {this.componentId,-6} |");
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductComponent other)
            {
                return this.productId == other.productId &&
                   this.componentId == other.componentId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.productId.GetHashCode();
            hash = hash * 23 + this.componentId.GetHashCode();
            return hash;
        }
    }
}
