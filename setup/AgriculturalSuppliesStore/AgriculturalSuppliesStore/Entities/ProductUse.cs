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

        public void DisplayDetail()
        {
            Console.WriteLine($"Mã sản phẩm - công dụng: {this.id}");
            Console.WriteLine($"Mã sản phẩm: {this.productId}");
            Console.WriteLine($"Mã công dụng: {this.useId}");
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
