using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Entities
{
    internal class Use : IBaseEntity
    {
        private string id;
        private string useName;
        private string useDescription;

        public string Id { get => this.id; set => this.id = value; }
        public string UseName { get => this.useName; set => this.useName = value; }
        public string UseDescription { get => this.useDescription; set => this.useDescription = value; }

        public Use(string id, string name, string description)
        {
            this.id = id;
            this.useName = name;
            this.useDescription = description;
        }

        public void DisplayDetail()
        {
            Console.WriteLine($"Mã công dụng: {this.id}");
            Console.WriteLine($"Tên công dụng: {this.useName}");
            Console.WriteLine($"Mô tả công dụng: {this.useDescription}");
        }

        public override bool Equals(object obj)
        {
            if (obj is Use other)
            {
                return this.useName == other.useName &&
                    this.useDescription == other.useDescription;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.useName.GetHashCode();
            hash = hash * 23 + this.useDescription.GetHashCode();
            return hash;
        }
    }
}
