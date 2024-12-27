using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Entities
{
    internal class Component : IBaseEntity
    {
        private string id;
        private string componentName;
        private string componentDescription;

        public string Id { get => this.id; set => this.id = value; }
        public string ComponentName { get => this.componentName; set => this.componentName = value; }
        public string ComponentDescription { get => this.componentDescription; set => this.componentDescription = value; }

        public Component(string id, string name, string description)
        {
            this.id = id;
            this.componentName = name;
            this.componentDescription = description;
        }

        public void DisplayDetail()
        {
            Console.WriteLine($"Mã thành phần: {this.id}");
            Console.WriteLine($"Tên thành phần: {this.componentName}");
            Console.WriteLine($"Mô tả thành phần: {this.componentDescription}");
        }

        public override bool Equals(object obj)
        {
            if (obj is Component other)
            {
                return this.componentName == other.componentName &&
                    this.componentDescription == other.componentDescription;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.componentName.GetHashCode();
            hash = hash * 23 + this.componentDescription.GetHashCode();
            return hash;
        }
    }
}
