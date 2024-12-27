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
        private string employeeGender;
        private DateTime employeeDateOfBirth;
        private string employeePhoneNumber;
        private string employeeAddress;
        private string employeePosition;

        public string Id { get => this.id; set => this.id = value; }
        public string EmployeeName { get => this.employeeName; set => this.employeeName = value; }
        public string EmployeeGender { get => this.employeeGender; set => this.employeeGender = value; }
        public DateTime EmployeeDateOfBirth { get => this.employeeDateOfBirth; set => this.employeeDateOfBirth = value; }
        public string EmployeePhoneNumber { get => this.employeePhoneNumber; set => this.employeePhoneNumber = value; }
        public string EmployeeAddress { get => this.employeeAddress; set => this.employeeAddress = value; }
        public string EmployeePosition { get => this.employeePosition; set => this.employeePosition = value; }

        public Employee(string id, string name, string gender, DateTime dateOfBirth, string phoneNumber, string address, string position)
        {
            this.id = id;
            this.employeeName = name;
            this.employeeGender = gender;
            this.employeeDateOfBirth = dateOfBirth;
            this.employeePhoneNumber = phoneNumber;
            this.employeeAddress = address;
            this.employeePosition = position;
        }

        public void DisplayDetail()
        {
            Console.WriteLine($"Mã nhân viên: {this.id}");
            Console.WriteLine($"Tên nhân viên: {this.employeeName}");
            Console.WriteLine($"Giới tính nhân viên: {this.employeeGender}");
            Console.WriteLine($"Ngày sinh nhân viên: {this.employeeDateOfBirth.ToShortDateString()}");
            Console.WriteLine($"Số điện thoại nhân viên: {this.employeePhoneNumber}");
            Console.WriteLine($"Địa chỉ nhân viên: {this.employeeAddress}");
            Console.WriteLine($"Vị trí làm việc của nhân viên: {this.employeePosition}");
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee other)
            {
                return this.employeeName == other.employeeName &&
                    this.employeeGender == other.employeeGender &&
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
            hash = hash * 23 + this.employeeGender.GetHashCode();
            hash = hash * 23 + this.employeeDateOfBirth.GetHashCode();
            hash = hash * 23 + this.employeePhoneNumber.GetHashCode();
            hash = hash * 23 + this.employeeAddress.GetHashCode();
            hash = hash * 23 + this.employeePosition.GetHashCode();
            return hash;
        }
    }
}
