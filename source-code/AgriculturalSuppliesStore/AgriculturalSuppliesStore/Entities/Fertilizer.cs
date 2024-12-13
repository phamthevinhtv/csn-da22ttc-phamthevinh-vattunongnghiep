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

        public string FertilizerPackagingType { get => this.fertilizerPackagingType; set => this.fertilizerPackagingType = value; }
        public DateTime FertilizerManufacturingDate { get => this.fertilizerManufacturingDate; set => this.fertilizerManufacturingDate = value; }
        public DateTime FertilizerExpiryDate { get => this.fertilizerExpiryDate; set => this.fertilizerExpiryDate = value; }

        public Fertilizer(string id, string name, float price, int quantity, string description, string packagingType, DateTime manufacturingDate, DateTime expiryDate, string brandId, string groupProductId) : base(id, name, price, quantity, description, brandId, groupProductId)
        {
            this.fertilizerPackagingType = packagingType;
            this.fertilizerManufacturingDate = manufacturingDate;
            this.fertilizerExpiryDate = expiryDate;
        }

        public override void Display()
        {
            base.Display();
            Console.SetCursorPosition(115, Console.CursorTop - 1);
            Console.WriteLine($"| {fertilizerPackagingType,-21} | {fertilizerManufacturingDate,-13:d} | {fertilizerExpiryDate,-12:d} | {base.GroupProductId, -10} | {base.BrandId,-14} |");
            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
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
                    base.groupProductId == other.groupProductId &&
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
            hash = hash * 23 + base.groupProductId.GetHashCode();
            hash = hash * 23 + this.fertilizerPackagingType.GetHashCode();
            hash = hash * 23 + this.fertilizerManufacturingDate.GetHashCode();
            hash = hash * 23 + this.fertilizerExpiryDate.GetHashCode();
            return hash;
        }

    }
}
