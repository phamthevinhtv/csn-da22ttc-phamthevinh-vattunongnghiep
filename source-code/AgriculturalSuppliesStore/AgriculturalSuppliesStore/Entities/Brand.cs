using AgriculturalSuppliesStore.Interfaces;
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

        public void Display()
        {
            Console.WriteLine($"| {this.id,-10} | {this.brandName,-20} | {this.brandEmail,-30} | {this.brandPhoneNumber,-13} | {this.brandAddress,-30} | {this.brandCountry,-20} |");
            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
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
