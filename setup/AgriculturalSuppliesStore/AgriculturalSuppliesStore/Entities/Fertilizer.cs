using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Entities
{
    internal class Fertilizer : Product
    {
        private string fertilizerPackagingType;
        private DateTime fertilizerManufacturingDate;
        private DateTime fertilizerExpiryDate;

        public override string Id { get => base.id; set => base.id = value; }
        public override string ProductName { get => base.productName; set => base.productName = value; }
        public override float ProductPrice { get => base.productPrice; set => base.productPrice = value; }
        public override int ProductQuantity { get => base.productQuantity; set => base.productQuantity = value; }
        public string FertilizerPackagingType { get => this.fertilizerPackagingType; set => this.fertilizerPackagingType = value; }
        public DateTime FertilizerManufacturingDate { get => this.fertilizerManufacturingDate; set => this.fertilizerManufacturingDate = value; }
        public DateTime FertilizerExpiryDate { get => this.fertilizerExpiryDate; set => this.fertilizerExpiryDate = value; }
        public override string ProductDescription { get => base.productDescription; set => base.productDescription = value; }
        public override string BrandId { get => base.brandId; set => base.brandId = value; }
        public override string ProductGroupId { get => base.productGroupId; set => base.productGroupId = value; }

        public Fertilizer(string id, string name, float price, int quantity, string description, string packagingType, DateTime manufacturingDate, DateTime expiryDate, string brandId, string productGroupId) : base(id, name, price, quantity, description, brandId, productGroupId)
        {
            this.fertilizerPackagingType = packagingType;
            this.fertilizerManufacturingDate = manufacturingDate;
            this.fertilizerExpiryDate = expiryDate;
        }

        public override void DisplayDetail()
        {
            base.DisplayDetail(); 
            Console.WriteLine($"Kiểu đóng gói sản phẩm: {this.fertilizerPackagingType}");
            Console.WriteLine($"Ngày sản xuất sản phẩm: {this.fertilizerManufacturingDate.ToShortDateString()}");
            Console.WriteLine($"Ngày hết hạn sản phẩm: {this.FertilizerExpiryDate.ToShortDateString()}");
        }

        public override bool Equals(object obj)
        {
            if (obj is Fertilizer other)
            {
                return base.productName == other.productName &&
                    base.productPrice == other.productPrice &&
                    base.productQuantity == other.productQuantity &&
                    base.productDescription == other.productDescription &&
                    base.brandId == other.brandId &&
                    base.productGroupId == other.productGroupId &&
                    this.fertilizerPackagingType == other.fertilizerPackagingType &&
                    this.fertilizerManufacturingDate == other.fertilizerManufacturingDate &&
                    this.fertilizerExpiryDate == other.fertilizerExpiryDate;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + base.id.GetHashCode();
            hash = hash * 23 + base.productName.GetHashCode();
            hash = hash * 23 + base.productPrice.GetHashCode();
            hash = hash * 23 + base.productQuantity.GetHashCode();
            hash = hash * 23 + base.productDescription.GetHashCode();
            hash = hash * 23 + base.brandId.GetHashCode();
            hash = hash * 23 + base.productGroupId.GetHashCode();
            hash = hash * 23 + this.fertilizerPackagingType.GetHashCode();
            hash = hash * 23 + this.fertilizerManufacturingDate.GetHashCode();
            hash = hash * 23 + this.fertilizerExpiryDate.GetHashCode();
            return hash;
        }
    }
}
