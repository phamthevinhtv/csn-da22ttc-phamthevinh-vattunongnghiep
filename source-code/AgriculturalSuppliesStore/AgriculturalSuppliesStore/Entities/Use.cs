using AgriculturalSuppliesStore.Interfaces;
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

        public void Display()
        {
            Console.WriteLine($"| {this.id,-10} | {this.useName,-20} | {this.useDescription,-50} |");
            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+");
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
