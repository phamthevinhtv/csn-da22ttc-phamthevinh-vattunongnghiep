using AgriculturalSuppliesStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Repositories
{
    internal class Repository<T> where T : IBaseEntity
    {
        private List<T> list;

        public List<T> List { get => this.list; set => this.list = value; }

        public Repository()
        {
            this.list = new List<T>();
        }

        public void Add(T obj)
        {
            var matchItem = this.list.FirstOrDefault(item => item.Equals(obj));

            if (matchItem != null)
            {
                Console.WriteLine($"Thêm thất bại - Đối tượng đang tồn tại có mã {matchItem.Id}");
            }
            else
            {
                this.list.Add(obj);
                Console.WriteLine($"Thêm thành công - Đối tượng có mã {obj.Id}");
            }
        }

        public void Update(string id, T obj)
        {
            var matchItem = this.list.FirstOrDefault(item => item.Equals(obj));

            if (matchItem != null)
            {
                Console.WriteLine($"Cập nhật thất bại - Đối tượng đang tồn tại có mã {matchItem.Id}");
            }
            else
            {
                int itemIndex = list.FindIndex(item => item.Id == id);
                if (itemIndex >= 0)
                {
                    list[itemIndex] = obj;
                    Console.WriteLine($"Cập nhật thành công - Đối tượng có mã {id}");
                }
            }
        }

        public void Delete(string id)
        {
            T item = SearchById(id);
            if (item != null)
            {
                list.Remove(item);
                Console.WriteLine($"Xóa thành công - Đối tượng có mã {id}.");
            }
            else
            {
                Console.WriteLine($"Xóa thất bại - Đối tượng có mã {id} không tồn tại.");
            }
        }

        public T SearchById(string id)
        {
            return this.list.Find(item => item.Id == id);
        }

        public List<T> SearchByKeyWord(string keyWord)
        {
            return this.list.FindAll(item =>
            {
                return item.GetType().GetProperties().Any(property =>
                {
                    var value = property.GetValue(item)?.ToString();
                    return value.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0;
                });
            });
        }

        public void DisplayAsTable()
        {
            if (list.Count > 0)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();

                Dictionary<string, string> columnNames = new Dictionary<string, string>();

                int propertiesLength = properties.Length;

                double windowWidth = Console.WindowWidth;

                int columnWidth = Convert.ToInt16(Math.Floor((windowWidth - 10) / (propertiesLength - 1)));

                foreach (var property in properties)
                {
                    if (property.Name == "Id") columnNames.Add(property.Name, "Mã");
                    if (property.Name.Contains("Name")) columnNames.Add(property.Name, "Tên");
                    if (property.Name.Contains("Gender")) columnNames.Add(property.Name, "Giới tính");
                    if (property.Name.Contains("DateOfBirth")) columnNames.Add(property.Name, "Ngày sinh");
                    if (property.Name.Contains("PhoneNumber")) columnNames.Add(property.Name, "Số điện thoại");
                    if (property.Name.Contains("Address")) columnNames.Add(property.Name, "Địa chỉ");
                    if (property.Name.Contains("Position")) columnNames.Add(property.Name, "Vị trí việc làm");
                    if (property.Name.Contains("Country")) columnNames.Add(property.Name, "Quốc gia");
                    if (property.Name.Contains("Email")) columnNames.Add(property.Name, "Email");
                    if (property.Name.Contains("Description")) columnNames.Add(property.Name, "Mô tả");
                    if (property.Name.Contains("Price")) columnNames.Add(property.Name, "Giá");
                    if (property.Name.Contains("Quantity")) columnNames.Add(property.Name, "Số lượng");
                    if (property.Name.Contains("Percentage")) columnNames.Add(property.Name, "Tỉ lệ");
                    if (property.Name.Contains("PackagingType")) columnNames.Add(property.Name, "Kiểu đóng gói");
                    if (property.Name.Contains("ManufacturingDate")) columnNames.Add(property.Name, "Ngày sản xuất");
                    if (property.Name.Contains("ExpiryDate")) columnNames.Add(property.Name, "Ngày hết hạn");
                    if (property.Name.Contains("EmployeeId")) columnNames.Add(property.Name, "Mã nhân viên");
                    if (property.Name.Contains("BrandId")) columnNames.Add(property.Name, "Mã thương hiệu");
                    if (property.Name.Contains("ProductGroupId")) columnNames.Add(property.Name, "Mã nhóm");
                    if (property.Name.Contains("ProductId")) columnNames.Add(property.Name, "Mã sản phẩm");
                    if (property.Name.Contains("UseId")) columnNames.Add(property.Name, "Mã công dụng");
                    if (property.Name.Contains("ComponentId")) columnNames.Add(property.Name, "Mã thành phần");
                }

                int countWidthTable = 0;

                Console.Write("+");
                for (int i = 0; i < propertiesLength; i++)
                {
                    Console.Write(new string('-', i == 0 ? 9 : columnWidth - 1));
                    countWidthTable += i == 0 ? 9 : columnWidth - 1;
                }
                Console.Write("+");

                Console.WriteLine();

                string tableHeading = "";

                if (typeof(T) == typeof(Product) || typeof(T) == typeof(Fertilizer)) tableHeading = "Danh sách sản phẩm";
                if (typeof(T) == typeof(ProductGroup)) tableHeading = "Danh sách nhóm sản phẩm";
                if (typeof(T) == typeof(Brand)) tableHeading = "Danh sách thương hiệu";
                if (typeof(T) == typeof(Employee)) tableHeading = "Danh sách nhân viên";
                if (typeof(T) == typeof(Component)) tableHeading = "Danh sách thành phần";
                if (typeof(T) == typeof(Use)) tableHeading = "Danh sách công dụng";
                if (typeof(T) == typeof(ProductUse)) tableHeading = "Danh sách sản phẩm - công dụng";
                if (typeof(T) == typeof(ProductComponent)) tableHeading = "Danh sách sản phẩm - thành phần";

                int padLeftTableHeadingToCenter = (countWidthTable - tableHeading.Length) / 2 - 1;

                Console.WriteLine($"| {"".PadLeft(padLeftTableHeadingToCenter)}{tableHeading.PadRight(countWidthTable - 2 - padLeftTableHeadingToCenter)} |");

                for (int i = 0; i < propertiesLength; i++)
                {
                    Console.Write("+");
                    Console.Write(new string('-', i == 0 ? 9 : columnWidth - 2));
                }
                Console.Write("+");

                Console.WriteLine();

                Console.Write("|");
                foreach (var property in properties)
                {
                    string name = property.Name;
                    if (name == "Id")
                    {
                        Console.Write($" {"",2}{columnNames[name].PadRight(5)} |");
                    }
                    else if (columnNames[name].Length <= columnWidth - 4)
                    {
                        int padLeftToCenter = Convert.ToInt16((columnWidth - columnNames[name].Length) / 2 - 2);
                        Console.Write($" {"".PadLeft(padLeftToCenter)}{columnNames[name].PadRight(columnWidth - 4 - padLeftToCenter)} |");
                    }
                    else
                    {
                        Console.Write($" {columnNames[name].Substring(0, columnWidth - 5)}… |");
                    }
                }

                Console.WriteLine();

                for (int i = 0; i < propertiesLength; i++)
                {
                    Console.Write("+");
                    Console.Write(new string('-', i == 0 ? 9 : columnWidth - 2));
                }
                Console.Write("+");

                Console.WriteLine();

                foreach (var item in this.list)
                {
                    Console.Write("|");
                    foreach (var property in properties)
                    {
                        var value = property.GetValue(item);
                        string valueString = "";
                        if (value.GetType() == typeof(DateTime))
                        {
                            valueString = ((DateTime)value).ToString("dd/MM/yyyy");
                        } else
                        {
                            valueString = value.ToString(); 
                        }

                        if (property.Name == "Id")
                        {
                            Console.Write($" {valueString.PadRight(7)} |");
                        }
                        else if (valueString.Length <= columnWidth - 4)
                        {
                            Console.Write($" {valueString.PadRight(columnWidth - 4)} |");
                        }
                        else
                        {
                            Console.Write($" {valueString.Substring(0, columnWidth - 5)}… |");
                        }
                    }

                    Console.WriteLine();

                    for (int i = 0; i < propertiesLength; i++)
                    {
                        Console.Write("+");
                        Console.Write(new string('-', i == 0 ? 9 : columnWidth - 2));
                    }
                    Console.Write("+");

                    Console.WriteLine();
                }
            } else
            {
                Console.WriteLine("Danh sách rỗng");
            }
        }
    }
}
