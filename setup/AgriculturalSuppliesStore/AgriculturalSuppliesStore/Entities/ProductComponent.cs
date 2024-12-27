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
        private string componentPercentage;

        public string Id { get => this.id; set => this.id = value; }
        public string ProductId { get => this.productId; set => this.productId = value; }
        public string ComponentId { get => this.componentId; set => this.componentId = value; }
        public string ComponentPercentage { get => this.componentPercentage; set => this.componentPercentage = value; }

        public ProductComponent(string id, string productId, string componentId, string percentage)
        {
            this.id = id;
            this.productId = productId;
            this.componentId = componentId;
            this.componentPercentage = percentage;
        }

        public void DisplayDetail()
        {
            Console.WriteLine($"Mã sản phẩm - thành phần: {this.id}");
            Console.WriteLine($"Mã sản phẩm: {this.productId}");
            Console.WriteLine($"Mã thành phần: {this.componentId}");
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductComponent other)
            {
                return this.productId == other.productId &&
                   this.componentId == other.componentId &&
                   this.componentPercentage == other.componentPercentage;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.productId.GetHashCode();
            hash = hash * 23 + this.componentId.GetHashCode();
            hash = hash * 23 + this.componentPercentage.GetHashCode();
            return hash;
        }
    }
}
