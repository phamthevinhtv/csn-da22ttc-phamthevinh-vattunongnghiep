using AgriculturalSuppliesStore.Interfaces;
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
        private float componentPercentage;
        private string componentDescription;

        public string Id { get => this.id; set => this.id = value; }
        public string ComponentName { get => this.componentName; set => this.componentName = value; }
        public float ComponentPercentage { get => this.componentPercentage; set => this.componentPercentage = value; }
        public string ComponentDescription { get => this.componentDescription; set => this.componentDescription = value; }

        public Component(string id, string name, float percentage, string description)
        {
            this.id = id;
            this.componentName = name;
            this.componentPercentage = percentage;
            this.componentDescription = description;
        }

        public void Display()
        {
            Console.WriteLine($"| {this.id,-10} | {this.componentName,-20} | {this.componentPercentage,-10} | {this.componentDescription,-50} |");
            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 52)}+");
        }

        public override bool Equals(object obj)
        {
            if (obj is Component other)
            {
                return this.componentName == other.componentName &&
                    this.componentDescription == other.componentDescription &&
                    this.componentPercentage == other.componentPercentage;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.componentName.GetHashCode();
            hash = hash * 23 + this.componentDescription.GetHashCode();
            hash = hash * 23 + this.componentPercentage.GetHashCode();
            return hash;
        }
    }
}
