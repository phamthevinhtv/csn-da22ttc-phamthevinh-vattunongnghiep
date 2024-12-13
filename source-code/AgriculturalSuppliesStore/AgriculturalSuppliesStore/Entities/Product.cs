using AgriculturalSuppliesStore.Interfaces;
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

        public string Id { get => this.id; set => this.id = value; }
        public string ProductName { get => this.productName; set => this.productName = value; }
        public float ProductPrice { get => this.productPrice; set => this.productPrice = value; }
        public int ProductQuantity { get => this.productQuantity; set => this.productQuantity = value; }
        public string ProductDescription { get => this.productDescription; set => this.productDescription = value; }
        public string BrandId { get => this.brandId; set => this.brandId = value; }
        public string GroupProductId { get => this.groupProductId; set => this.groupProductId = value; }

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

        public virtual void Display()
        {
            Console.WriteLine($"| {this.id,-10} | {this.productName,-20} | {this.productPrice,-10} | {this.productQuantity,-10} | {this.productDescription,-50}");
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
