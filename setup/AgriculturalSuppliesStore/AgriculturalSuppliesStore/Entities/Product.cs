using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Entities
{
    internal class Product : IBaseEntity
    {
        protected string id;
        protected string productName;
        protected float productPrice;
        protected int productQuantity;
        protected string productDescription;
        protected string brandId;
        protected string groupProductId;

        public virtual string Id { get => this.id; set => this.id = value; }
        public virtual string ProductName { get => this.productName; set => this.productName = value; }
        public virtual float ProductPrice { get => this.productPrice; set => this.productPrice = value; }
        public virtual int ProductQuantity { get => this.productQuantity; set => this.productQuantity = value; }
        public virtual string ProductDescription { get => this.productDescription; set => this.productDescription = value; }
        public virtual string BrandId { get => this.brandId; set => this.brandId = value; }
        public virtual string GroupProductId { get => this.groupProductId; set => this.groupProductId = value; }

        public Product(string id, string name, float price, int quantity, string description, string brandId, string groupProductId)
        {
            this.id = id;
            this.productName = name;
            this.productPrice = price;
            this.productQuantity = quantity;
            this.productDescription = description;
            this.brandId = brandId;
            this.groupProductId = groupProductId;
        }

        public virtual void DisplayDetail()
        {
            Console.WriteLine($"Mã sản phẩm: {this.id}");
            Console.WriteLine($"Tên sản phẩm: {this.productName}");
            Console.WriteLine($"Giá sản phẩm: {this.productPrice}");
            Console.WriteLine($"Số lượng sản phẩm: {this.productQuantity}");
            Console.WriteLine($"Mô tả sản phẩm: {this.productDescription}");
            Console.WriteLine($"Mã thương hiệu: {this.brandId}");
            Console.WriteLine($"Mã nhóm sản phẩm: {this.groupProductId}");
        }

        public override bool Equals(object obj)
        {
            if (obj is Product other)
            {
                return this.productName == other.productName &&
                    this.productPrice == other.productPrice &&
                    this.productQuantity == other.productQuantity &&
                    this.productDescription == other.productDescription &&
                    this.brandId == other.brandId &&
                    this.groupProductId == other.groupProductId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.productName.GetHashCode();
            hash = hash * 23 + this.productPrice.GetHashCode();
            hash = hash * 23 + this.productQuantity.GetHashCode();
            hash = hash * 23 + this.productDescription.GetHashCode();
            hash = hash * 23 + this.brandId.GetHashCode();
            hash = hash * 23 + this.groupProductId.GetHashCode();
            return hash;
        }
    }
}
