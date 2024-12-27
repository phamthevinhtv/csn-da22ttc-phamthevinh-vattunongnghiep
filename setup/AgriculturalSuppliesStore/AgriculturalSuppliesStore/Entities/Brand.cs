using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Entities
{
    internal class Brand : IBaseEntity
    {
        private string id;
        private string brandName;
        private string brandEmail;
        private string brandPhoneNumber;
        private string brandAddress;
        private string brandCountry;

        public string Id { get => this.id; set => this.id = value; }
        public string BrandName { get => this.brandName; set => this.brandName = value; }
        public string BrandEmail { get => this.brandEmail; set => this.brandEmail = value; }
        public string BrandPhoneNumber { get => this.brandPhoneNumber; set => this.brandPhoneNumber = value; }
        public string BrandAddress { get => this.brandAddress; set => this.brandAddress = value; }
        public string BrandCountry { get => this.brandCountry; set => this.brandCountry = value; }

        public Brand(string id, string name, string email, string phoneNumber, string address, string country)
        {
            this.id = id;
            this.brandName = name;
            this.brandEmail = email;
            this.brandPhoneNumber = phoneNumber;
            this.brandAddress = address;
            this.brandCountry = country;
        }

        public void DisplayDetail()
        {
            Console.WriteLine($"Mã thương hiệu: {this.id}");
            Console.WriteLine($"Tên thương hiệu: {this.brandName}");
            Console.WriteLine($"Email thương hiệu: {this.brandEmail}");
            Console.WriteLine($"Số điện thoại thương hiệu: {this.brandPhoneNumber}");
            Console.WriteLine($"Địa chỉ thương hiệu: {this.brandAddress}");
            Console.WriteLine($"Quốc gia thương hiệu: {this.brandCountry}");
        }

        public override bool Equals(object obj)
        {
            if (obj is Brand other)
            {
                return this.brandName == other.brandName &&
                    this.brandEmail == other.brandEmail &&
                    this.brandPhoneNumber == other.brandPhoneNumber &&
                    this.brandAddress == other.brandAddress &&
                    this.brandCountry == other.brandCountry;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.brandName.GetHashCode();
            hash = hash * 23 + this.brandEmail.GetHashCode();
            hash = hash * 23 + this.brandPhoneNumber.GetHashCode();
            hash = hash * 23 + this.brandAddress.GetHashCode();
            hash = hash * 23 + this.brandCountry.GetHashCode();
            return hash;
        }
    }
}
