using AgriculturalSuppliesStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Entities
{
    internal class Employee : IBaseEntity
    {
        private string id;
        private string employeeName;
        private DateTime employeeDateOfBirth;
        private string employeePhoneNumber;
        private string employeeAddress;
        private string employeePosition;

        public string Id { get => this.id; set => this.id = value; }
        public string EmployeeName { get => this.employeeName; set => this.employeeName = value; }
        public DateTime EmployeeDateOfBirth { get => this.employeeDateOfBirth; set => this.employeeDateOfBirth = value; }
        public string EmployeePhoneNumber { get => this.employeePhoneNumber; set => this.employeePhoneNumber = value; }
        public string EmployeeAddress { get => this.employeeAddress; set => this.employeeAddress = value; }
        public string EmployeePosition { get => this.employeePosition; set => this.employeePosition = value; }

        public Employee(string id, string name, DateTime dateOfBirth, string phoneNumber, string address, string position)
        {
            this.id = id;
            this.employeeName = name;
            this.employeeDateOfBirth = dateOfBirth;
            this.employeePhoneNumber = phoneNumber;
            this.employeeAddress = address;
            this.employeePosition = position;
        }

        public void Display()
        {
            Console.WriteLine($"| {this.id,-5} | {this.employeeName,-20} | {this.employeeDateOfBirth,-10:d} | {this.employeePhoneNumber,-13} | {this.employeeAddress,-30} | {this.employeePosition,-20} |");
            Console.WriteLine($"+{new string('-', 8)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee other)
            {
                return this.employeeName == other.employeeName &&
                    this.employeeDateOfBirth == other.employeeDateOfBirth &&
                    this.employeePhoneNumber == other.employeePhoneNumber &&
                    this.employeeAddress == other.employeeAddress &&
                    this.employeePosition == other.employeePosition;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.id.GetHashCode();
            hash = hash * 23 + this.employeeName.GetHashCode();
            hash = hash * 23 + this.employeeDateOfBirth.GetHashCode();
            hash = hash * 23 + this.employeePhoneNumber.GetHashCode();
            hash = hash * 23 + this.employeeAddress.GetHashCode();
            hash = hash * 23 + this.employeePosition.GetHashCode();
            return hash;
        }

    }
}
