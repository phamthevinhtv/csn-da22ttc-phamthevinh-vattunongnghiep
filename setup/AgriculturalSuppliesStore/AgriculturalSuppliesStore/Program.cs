using AgriculturalSuppliesStore.Entities;
using AgriculturalSuppliesStore.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AgriculturalSuppliesStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\Repositories\Data.json";

            Repository<ProductGroup> productGroups = new Repository<ProductGroup>();
            Repository<Employee> employees = new Repository<Employee>();
            Repository<Brand> brands = new Repository<Brand>();
            Repository<Fertilizer> fertilizers = new Repository<Fertilizer>();
            Repository<Component> components = new Repository<Component>();
            Repository<Use> uses = new Repository<Use>();
            Repository<ProductComponent> productComponents = new Repository<ProductComponent>();
            Repository<ProductUse> productUses = new Repository<ProductUse>();

            RestoreData();

            Management();

            void Management()
            {
                bool exit = false;
                while (!exit)
                {
                    if (Console.CursorTop > 0)
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine($"+{new string('-', 50)}+");
                    Console.WriteLine("| Ứng dụng quản lý cửa hàng bán vật tư nông nghiệp |");
                    Console.WriteLine($"+{new string('-', 50)}+");
                    Console.WriteLine($"| {"",17}{"Menu quản lý",-31} |");
                    Console.WriteLine($"+{new string('-', 50)}+");
                    Console.WriteLine($"| {"[1] Quản lý danh mục nhóm sản phẩm",-48} |");
                    Console.WriteLine($"| {"[2] Quản lý danh mục sản phẩm",-48} |");
                    Console.WriteLine($"| {"[3] Quản lý danh mục thành phần",-48} |");
                    Console.WriteLine($"| {"[4] Quản lý danh mục công dụng",-48} |");
                    Console.WriteLine($"| {"[5] Quản lý danh mục thương hiệu",-48} |");
                    Console.WriteLine($"| {"[6] Quản lý danh mục nhân viên",-48} |");
                    Console.WriteLine($"| {"[7] Quản lý liên kết sản phẩm - thành phần",-48} |");
                    Console.WriteLine($"| {"[8] Quản lý liên kết sản phẩm - công dụng",-48} |");
                    Console.WriteLine($"| {"[0] Thoát",-48} |");
                    Console.WriteLine($"+{new string('-', 50)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            ProductGroupManagement();
                            break;
                        case "2":
                            ProductManagement();
                            break;
                        case "3":
                            ComponentManagement();
                            break;
                        case "4":
                            UseManagement();
                            break;
                        case "5":
                            BrandManagement();
                            break;
                        case "6":
                            EmployeeManagement();
                            break;
                        case "7":
                            ProductComponentManagement();                            
                            break;
                        case "8":
                            ProductUseManagement();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\nLựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }
            }

            // Quản lý nhóm sản phẩm
            void ProductGroupManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine($"+{new string('-', 43)}+");
                    Console.WriteLine($"| {"",5}{"Quản lý danh mục nhóm sản phẩm",-36} |");
                    Console.WriteLine($"+{new string('-', 43)}+");
                    Console.WriteLine($"| {"",13}{"Menu chức năng",-28} |");
                    Console.WriteLine($"+{new string('-', 43)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách nhóm sản phẩm",-41} |");
                    Console.WriteLine($"| {"[2] Xem chi tiết một nhóm sản phẩm",-41} |");
                    Console.WriteLine($"| {"[3] Thêm nhóm sản phẩm",-41} |");
                    Console.WriteLine($"| {"[4] Cập nhật nhóm sản phẩm",-41} |");
                    Console.WriteLine($"| {"[5] Xóa nhóm sản phẩm",-41} |");
                    Console.WriteLine($"| {"[6] Tìm nhóm sản phẩm theo mã",-41} |");
                    Console.WriteLine($"| {"[7] Tìm nhóm sản phẩm theo từ khóa",-41} |");
                    Console.WriteLine($"| [8] Xem danh sách sản phẩm trong một nhóm |");
                    Console.WriteLine($"| {"[0] Thoát",-41} |");
                    Console.WriteLine($"+{new string('-', 43)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DisplayAllProductGroup();
                            break;
                        case "2":
                            DisplayDetailProductGroup();
                            break;
                        case "3":
                            AddProductGroup();
                            break;
                        case "4":
                            UpdateProductGroup();
                            break;
                        case "5":
                            DeleteProductGroup();
                            break;
                        case "6":
                            SearchByIdProductGroup();
                            break;
                        case "7":
                            SearchByKeyWordProductGroup();
                            break;
                        case "8":
                            DisplayProductsInProductGroup();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                // Thêm nhóm sản phẩm
                void AddProductGroup()
                {
                    Console.WriteLine("\n--- Thêm nhóm sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = productGroups.List.Count == 0 ? "PG00001" : "PG" + (int.Parse(productGroups.List[productGroups.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    string name = CheckInput(1, "Nhập tên nhóm sản phẩm");
                    if (name == "=exit") return;

                    string description = CheckInput(0, "Nhập mô tả nhóm sản phẩm");
                    if (description == "=exit") return;

                    string employeeId;
                    do
                    {
                        employeeId =  CheckId(0, "Nhập mã nhân viên phụ trách nhóm sản phẩm");
                        if (employeeId == "=exit") return;
                        if (employeeId != "_")
                        {
                            Employee employee = employees.SearchById(employeeId);
                            if (employee == null)
                            {
                                Console.WriteLine($"Mã nhân viên phụ trách nhóm sản phẩm {employeeId} không tồn tại");
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (true);

                    productGroups.Add(new ProductGroup(id, UpperFirstChar(name), UpperFirstChar(description), employeeId));
                    BackupData();
                }

                // Cập nhật nhóm sản phẩm
                void UpdateProductGroup()
                {
                    Console.WriteLine("\n--- Cập nhật nhóm sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã nhóm sản phẩm cần cập nhật");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        ProductGroup productGroup = productGroups.SearchById(id);

                        if (productGroup != null)
                        {
                            string name = CheckInput(0, "Nhập tên mới cho nhóm sản phẩm");
                            if (name == "=exit") return;
                            if (name == "_") name = productGroup.ProductGroupName;

                            string description = CheckInput(0, "Nhập mô tả mới cho nhóm sản phẩm");
                            if (description == "=exit") return;
                            if (description == "_") description = productGroup.ProductGroupDescription;

                            string employeeId;
                            do
                            {
                                employeeId = CheckId(0, "Nhập mã nhân viên phụ trách mới cho nhóm sản phẩm");
                                if (employeeId == "=exit") return;
                                if (employeeId != "_")
                                {
                                    Employee employee = employees.SearchById(employeeId);
                                    if (employee == null)
                                    {
                                        Console.WriteLine($"Mã nhân viên phụ trách mới cho nhóm sản phẩm {employeeId} không tồn tại");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    employeeId = productGroup.EmployeeId;
                                    break;
                                }
                            }
                            while (true);

                            productGroups.Update(id, new ProductGroup(id, UpperFirstChar(name), UpperFirstChar(description), employeeId));
                            BackupData();
                        }
                        else
                        {
                            Console.WriteLine($"Không thể cập nhật - Không tồn tại nhóm sản phẩm có mã {id}");
                        }
                    }
                }

                // Xóa nhóm sản phẩm
                void DeleteProductGroup()
                {
                    Console.WriteLine("\n--- Xóa nhóm sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã nhóm sản phẩm cần xóa");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        productGroups.Delete(id);
                        BackupData();
                    }
                }

                // Tìm nhóm sản phẩm theo mã
                void SearchByIdProductGroup()
                {
                    Console.WriteLine("\n--- Tìm nhóm sản phẩm theo mã ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã nhóm sản phẩm cần tìm");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        ProductGroup productGroup = productGroups.SearchById(id);

                        if (productGroup != null)
                        {
                            productGroup.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm nhóm sản phẩm có mã {id}");
                        }
                    }
                }

                // Tìm nhóm sản phẩm theo từ khóa
                void SearchByKeyWordProductGroup()
                {
                    Console.WriteLine("\n--- Tìm nhóm sản phẩm theo từ khóa ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string keyWord = CheckInput(0, "Nhập từ khóa cần tìm");
                    if (keyWord == "=exit") return;
                    if (keyWord != "_")
                    {
                        Repository<ProductGroup> productGroupsWithKeyWord = new Repository<ProductGroup>();

                        List<ProductGroup> productGroupsSearch = productGroups.SearchByKeyWord(keyWord);

                        if (productGroupsSearch.Count > 0)
                        {
                            foreach (var item in productGroupsSearch)
                            {
                                productGroupsWithKeyWord.Add(item);
                            }
                            for (int i = 0; i < productGroupsSearch.Count; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            }
                            productGroupsWithKeyWord.DisplayAsTable();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy nhóm sản phẩm có từ khóa: {keyWord}");
                        }
                    }
                }

                // Hiển thị tất cả nhóm sản phẩm
                void DisplayAllProductGroup()
                {
                    Console.WriteLine("\n--- Xem danh sách nhóm sản phẩm ---");
                    productGroups.DisplayAsTable();
                }

                // Hiển thị chi tiết một nhóm sản phẩm
                void DisplayDetailProductGroup()
                {
                    Console.WriteLine("\n--- Xem chi tiết một nhóm sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã nhóm sản phẩm cần xem chi tiết");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        ProductGroup productGroup = productGroups.SearchById(id);

                        if (productGroup != null)
                        {
                            productGroup.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm nhóm sản phẩm có mã {id}");
                        }
                    }
                }

                // Hiển thị các sản phẩm trong một nhóm sản phẩm
                void DisplayProductsInProductGroup()
                {
                    Console.WriteLine("\n--- Xem danh sách sản phẩm trong một nhóm sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");
                    
                    string id = CheckId(0, "Nhập mã nhóm sản phẩm cần xem các sản phẩm");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        if (productGroups.SearchById(id) != null)
                        {
                            List<Fertilizer> fertilizersList = fertilizers.List.FindAll(item => item.GroupProductId == id.ToUpper());

                            Repository<Fertilizer> fertilizersInProductGroup = new Repository<Fertilizer>();

                            if (fertilizersList.Count > 0)
                            {
                                foreach (var item in fertilizersList)
                                {
                                    fertilizersInProductGroup.Add(item);
                                }
                                for (int i = 0; i < fertilizersList.Count; i++)
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                }
                                fertilizersInProductGroup.DisplayAsTable();
                            }
                            else
                            {
                                Console.WriteLine($"Nhóm sản phẩm có mã {id} không có sản phẩm nào.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Nhóm sản phẩm có mã {id} không tồn tại.");
                        }
                    }
                }
            }

            // Quản lý sản phẩm
            void ProductManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine($"+{new string('-', 47)}+");
                    Console.WriteLine($"| {"",10}{"Quản lý danh mục sản phẩm",-35} |");
                    Console.WriteLine($"+{new string('-', 47)}+");
                    Console.WriteLine($"| {"",15}{"Menu chức năng",-30} |");
                    Console.WriteLine($"+{new string('-', 47)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách sản phẩm",-45} |");
                    Console.WriteLine($"| {"[2] Xem chi tiết một sản phẩm",-45} |");
                    Console.WriteLine($"| {"[3] Thêm sản phẩm",-45} |");
                    Console.WriteLine($"| {"[4] Cập nhật sản phẩm",-45} |");
                    Console.WriteLine($"| {"[5] Xóa sản phẩm",-45} |");
                    Console.WriteLine($"| {"[6] Tìm sản phẩm theo mã",-45} |");
                    Console.WriteLine($"| {"[7] Tìm sản phẩm theo từ khóa",-45} |");
                    Console.WriteLine($"| {"[8] Xem danh sách công dụng của một sản phẩm",-45} |");
                    Console.WriteLine($"| {"[9] Xem danh sách thành phần của một sản phẩm",-45} |");
                    Console.WriteLine($"| {"[0] Thoát",-45} |");
                    Console.WriteLine($"+{new string('-', 47)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DisplayAllFertilizer();
                            break;
                        case "2":
                            DisplayDetailFertilizer();
                            break;
                        case "3":
                            AddFertilizer();
                            break;
                        case "4":
                            UpdateFertilizer();
                            break;
                        case "5":
                            DeleteFertilizer();
                            break;
                        case "6":
                            SearchByIdFertilizer();
                            break;
                        case "7":
                            SearchByKeyWordFertilizer();
                            break;
                        case "8":
                            DisplayUsesInProduct();
                            break;
                        case "9":
                            DisplayComponentsInProduct();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                // Thêm sản phẩm
                void AddFertilizer()
                {
                    Console.WriteLine("\n--- Thêm sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = fertilizers.List.Count == 0 ? "P00001" : "P" + (int.Parse(fertilizers.List[fertilizers.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    string name = CheckInput(1, "Nhập tên cho sản phẩm");
                    if (name == "=exit") return;

                    string price = CheckNumber(1, "float", "Nhập giá cho sản phẩm (Số nguyên hoặc số thực)");
                    if (price == "=exit") return;

                    string quantity = CheckNumber(1, "int", "Nhập số lượng cho sản phẩm (Số nguyên)");
                    if (quantity == "=exit") return;

                    string typePackaging = CheckInput(1, "Nhập kiểu đóng gói cho sản phẩm");
                    if (typePackaging == "=exit") return;

                    string manufacturingDate = CheckDate(1, "Nhập ngày sản xuất cho sản phẩm (dd/mm/yyyy)");
                    if (manufacturingDate == "=exit") return;

                    string expiryDate;
                    do
                    {
                        expiryDate = CheckDate(1, "Nhập ngày hết hạn cho sản phẩm (dd/mm/yyyy)");
                        if (expiryDate == "=exit") return;
                        if (DateTime.Parse(expiryDate) <= DateTime.Parse(manufacturingDate))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("Ngày hết hạn phải sau ngày sản xuất. Vui lòng nhập lại." + new string(' ', 50));
                        } else if(DateTime.Parse(expiryDate) <= DateTime.Now)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("Ngày hết hạn phải sau ngày hiện tại. Vui lòng nhập lại." + new string(' ', 50));
                        } else
                        {
                            break;
                        }
                    }
                    while (true);

                    string description = CheckInput(0, "Nhập mô tả cho sản phẩm");
                    if (description == "=exit") return;

                    string brandId;
                    do
                    {
                        brandId = CheckId(0, "Nhập mã thương hiệu cho sản phẩm (<B><Chuỗi năm số nguyên >= 0>)");
                        if (brandId == "=exit") return;
                        if (brandId != "_")
                        {
                            Brand brand = brands.SearchById(brandId);
                            if (brand == null)
                            {
                                Console.WriteLine($"Mã thương hiệu {brandId} không tồn tại");
                            }
                            else
                            {
                                break;
                            }
                        } else
                        {
                            break;
                        }
                    }
                    while (true);

                    string productGroupId;
                    do
                    {
                        productGroupId =  CheckId(0, "Nhập mã nhóm sản phẩm cho sản phẩm (<PG><Chuỗi năm số nguyên >= 0>)");
                        if (productGroupId == "=exit") return;
                        if (productGroupId != "_")
                        {
                            ProductGroup productGroup = productGroups.SearchById(productGroupId);
                            if (productGroup == null)
                            {
                                Console.WriteLine($"Mã nhóm sản phẩm {productGroupId} không tồn tại");
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (true);

                    fertilizers.Add(new Fertilizer(id, UpperFirstChar(name), float.Parse(price), int.Parse(quantity), UpperFirstChar(description), UpperFirstChar(typePackaging), DateTime.Parse(manufacturingDate), DateTime.Parse(expiryDate), brandId, productGroupId));
                    BackupData();
                }

                // Cập nhật sản phẩm
                void UpdateFertilizer()
                {
                    Console.WriteLine("\n--- Cập nhật nhóm sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã sản phẩm cần cập nhật");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Fertilizer fertilizer = fertilizers.SearchById(id);

                        if (fertilizer != null)
                        {
                            string name = CheckInput(0, "Nhập tên mới cho sản phẩm");
                            if (name == "=exit") return;
                            if (name == "_") name = fertilizer.ProductName;

                            string price = CheckNumber(0, "float", "Nhập giá mới cho sản phẩm");
                            if (price == "=exit") return;
                            if (price == "_") price = fertilizer.ProductPrice.ToString();

                            string quantity = CheckNumber(0, "int", "Nhập số lượng mới cho sản phẩm");
                            if (quantity == "=exit") return;
                            if (quantity == "_") quantity = fertilizer.ProductQuantity.ToString();

                            string typePackaging = CheckInput(0, "Nhập kiểu đóng gói mới cho sản phẩm");
                            if (typePackaging == "=exit") return;
                            if (typePackaging == "_") typePackaging = fertilizer.FertilizerPackagingType;

                            string manufacturingDate = CheckDate(0, "Nhập ngày sản xuất mới cho sản phẩm");
                            if (manufacturingDate == "=exit") return;
                            if (manufacturingDate == "_") manufacturingDate = fertilizer.FertilizerManufacturingDate.ToString();

                            string expiryDate;
                            do
                            {
                                expiryDate = CheckDate(0, "Nhập ngày hết hạn mới cho sản phẩm");
                                if (expiryDate == "=exit") return;
                                if (expiryDate != "_")
                                {
                                    if (DateTime.Parse(expiryDate) <= DateTime.Parse(manufacturingDate))
                                    {
                                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                                        Console.WriteLine("Ngày hết hạn mới phải sau ngày sản xuất. Vui lòng nhập lại." + new string(' ', 50));
                                    }
                                    else if (DateTime.Parse(expiryDate) <= DateTime.Now)
                                    {
                                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                                        Console.WriteLine("Ngày hết hạn mới phải sau ngày hiện tại. Vui lòng nhập lại." + new string(' ', 50));
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } else
                                {
                                    expiryDate = fertilizer.FertilizerExpiryDate.ToString();
                                    break;
                                }
                            }
                            while (true);

                            string description = CheckInput(0, "Nhập mô tả mới cho sản phẩm");
                            if (description == "=exit") return;
                            if (description == "_") description = fertilizer.ProductDescription;

                            string brandId;
                            do
                            {
                                brandId = CheckId(0, "Nhập mã thương hiệu mới cho sản phẩm");
                                if (brandId == "=exit") return;
                                if (brandId != "_")
                                {
                                    Brand brand = brands.SearchById(brandId);
                                    if (brand == null)
                                    {
                                        Console.WriteLine($"Mã thương hiệu mới {brandId} không tồn tại");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    brandId = fertilizer.BrandId;
                                    break;
                                }
                            }
                            while (true);

                            string productGroupId;
                            do
                            {
                                productGroupId = CheckId(0, "Nhập mã nhóm sản phẩm mới cho sản phẩm");
                                if (productGroupId == "=exit") return;
                                if (productGroupId != "_")
                                {
                                    ProductGroup productGroup = productGroups.SearchById(productGroupId);
                                    if (productGroup == null)
                                    {
                                        Console.WriteLine($"Mã nhóm sản phẩm mới {productGroupId} không tồn tại");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    productGroupId = fertilizer.GroupProductId;
                                    break;
                                }
                            }
                            while (true);

                            fertilizers.Update(id, new Fertilizer(id, UpperFirstChar(name), float.Parse(price), int.Parse(quantity), UpperFirstChar(description), typePackaging, DateTime.Parse(manufacturingDate), DateTime.Parse(expiryDate), brandId, productGroupId));
                            BackupData();
                        }
                        else
                        {
                            Console.WriteLine($"Không thể cập nhật - Không tồn tại sản phẩm có mã {id}");
                        }
                    }
                }

                // Xóa sản phẩm
                void DeleteFertilizer()
                {
                    Console.WriteLine("\n--- Xóa sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã sản phẩm cần xóa");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        fertilizers.Delete(id);
                        BackupData();
                    }
                }

                // Tìm sản phẩm theo mã
                void SearchByIdFertilizer()
                {
                    Console.WriteLine("\n--- Tìm sản phẩm theo mã ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã sản phẩm cần tìm");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Fertilizer fertilizer = fertilizers.SearchById(id);

                        if (fertilizer != null)
                        {
                            fertilizer.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy sản phẩm có mã {id}");
                        }
                    }
                }

                // Tìm sản phẩm theo từ khóa
                void SearchByKeyWordFertilizer()
                {
                    Console.WriteLine("\n--- Tìm sản phẩm theo từ khóa ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string keyWord = CheckInput(0, "Nhập từ khóa cần tìm");
                    if (keyWord == "=exit") return;
                    if (keyWord != "_")
                    {
                        Repository<Fertilizer> fertilizersWithKeyWord = new Repository<Fertilizer>();

                        List<Fertilizer> fertilizersSearch = fertilizers.SearchByKeyWord(keyWord);

                        if (fertilizersSearch.Count > 0)
                        {
                            foreach (var item in fertilizersSearch)
                            {
                                fertilizersWithKeyWord.Add(item);
                            }
                            for (int i = 0; i < fertilizersSearch.Count; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            }
                            fertilizersWithKeyWord.DisplayAsTable();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy sản phẩm có từ khóa: {keyWord}");
                        }
                    }
                }

                // Hiển thị tất cả sản phẩm
                void DisplayAllFertilizer()
                {
                    Console.WriteLine("\n--- Xem danh sách sản phẩm ---");
                    fertilizers.DisplayAsTable();
                }

                // Hiển thị chi tiết một sản phẩm
                void DisplayDetailFertilizer()
                {
                    Console.WriteLine("\n--- Xem chi tiết một sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã sản phẩm cần xem chi tiết");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Fertilizer fertilizer = fertilizers.SearchById(id);

                        if (fertilizer != null)
                        {
                            fertilizer.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy sản phẩm có mã {id}");
                        }
                    }
                }

                // Hiển thị các thành phần của một sản phẩm
                void DisplayComponentsInProduct()
                {
                    Console.WriteLine("\n--- Xem danh sách thành phần của một sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã sản phẩm cần xem các thành phần");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        if (fertilizers.SearchById(id) != null)
                        {
                            var componentsList = productComponents.List
                                                        .Where(pc => pc.ProductId == id.ToUpper())
                                                        .Join(components.List,
                                                            pc => pc.ComponentId,
                                                            c => c.Id,
                                                            (pc, c) => new
                                                            {
                                                                Id = c.Id,
                                                                ComponentName = c.ComponentName,
                                                                ComponentPercentage = pc.ComponentPercentage,
                                                                ComponentDescription = c.ComponentDescription
                                                            })
                                                        .ToList();

                            Repository<Component> componentsInProductGroup = new Repository<Component>();

                            if (componentsList.Count > 0)
                            {
                                var properties = componentsList[0].GetType().GetProperties();

                                Dictionary<string, string> columnNames = new Dictionary<string, string>();

                                int propertiesLength = properties.Length;

                                double windowWidth = Console.WindowWidth;

                                int columnWidth = Convert.ToInt16(Math.Floor((windowWidth - 10) / (propertiesLength - 1)));

                                foreach (var property in properties)
                                {
                                    if (property.Name == "Id") columnNames.Add(property.Name, "Mã");
                                    if (property.Name.Contains("Name")) columnNames.Add(property.Name, "Tên");
                                    if (property.Name.Contains("Description")) columnNames.Add(property.Name, "Mô tả");
                                    if (property.Name.Contains("Percentage")) columnNames.Add(property.Name, "Tỉ lệ");
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

                                string tableHeading = "Danh sách thành phần";

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

                                foreach (var item in componentsList)
                                {
                                    Console.Write("|");
                                    foreach (var property in properties)
                                    {
                                        var value = property.GetValue(item).ToString();

                                        if (property.Name == "Id")
                                        {
                                            Console.Write($" {value.PadRight(7)} |");
                                        }
                                        else if (value.Length <= columnWidth - 4)
                                        {
                                            Console.Write($" {value.PadRight(columnWidth - 4)} |");
                                        }
                                        else
                                        {
                                            Console.Write($" {value.Substring(0, columnWidth - 5)}… |");
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
                            }
                            else
                            {
                                Console.WriteLine($"Sản phẩm có mã {id} không có thành phần nào.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Sản phẩm có mã {id} không tồn tại.");
                        }
                    }
                }

                // Hiển thị các công dụng của một sản phẩm
                void DisplayUsesInProduct()
                {
                    Console.WriteLine("\n--- Xem danh sách công dụng của một sản phẩm ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã sản phầm cần xem các công dụng");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        if (fertilizers.SearchById(id) != null)
                        {
                            List<Use> usesList = productUses.List
                                                        .Where(pu => pu.ProductId == id.ToUpper())
                                                        .Join(uses.List,
                                                            pu => pu.UseId,
                                                            u => u.Id,
                                                            (pu, u) => u)
                                                        .ToList();

                            Repository<Use> usesInProductGroup = new Repository<Use>();

                            if (usesList.Count > 0)
                            {
                                foreach (var item in usesList)
                                {
                                    usesInProductGroup.Add(item);
                                }
                                for (int i = 0; i < usesList.Count; i++)
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                }
                                usesInProductGroup.DisplayAsTable();
                            }
                            else
                            {
                                Console.WriteLine($"Sản phẩm có mã {id} không có công dụng nào.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Sản phẩm có mã {id} không tồn tại.");
                        }
                    }
                }
            }

            // Quản lý thành phần
            void ComponentManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine($"+{new string('-', 33)}+");
                    Console.WriteLine($"| {"",2}{"Quản lý danh mục thành phần",-29} |");
                    Console.WriteLine($"+{new string('-', 33)}+");
                    Console.WriteLine($"| {"",8}{"Menu chức năng",-23} |");
                    Console.WriteLine($"+{new string('-', 33)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách thành phần",-31} |");
                    Console.WriteLine($"| {"[2] Xem chi tiết một thành phần",-31} |");
                    Console.WriteLine($"| {"[3] Thêm thành phần",-31} |");
                    Console.WriteLine($"| {"[4] Cập nhật thành phần",-31} |");
                    Console.WriteLine($"| {"[5] Xóa thành phần",-31} |");
                    Console.WriteLine($"| {"[6] Tìm thành phần theo mã",-31} |");
                    Console.WriteLine($"| {"[7] Tìm thành phần theo từ khóa",-31} |");
                    Console.WriteLine($"| {"[0] Thoát",-31} |");
                    Console.WriteLine($"+{new string('-', 33)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DisplayAllComponent();
                            break;
                        case "2":
                            DisplayDetailComponent();
                            break;
                        case "3":
                            AddComponent();
                            break;
                        case "4":
                            UpdateComponent();
                            break;
                        case "5":
                            DeleteComponent();
                            break;
                        case "6":
                            SearchByIdComponent();
                            break;
                        case "7":
                            SearchByKeyWordComponent();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                // Thêm thành phần
                void AddComponent()
                {
                    Console.WriteLine("\n--- Thêm thành phần ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = components.List.Count == 0 ? "C00001" : "C" + (int.Parse(components.List[components.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    string name = CheckInput(1, "Nhập tên cho thành phần");
                    if (name == "=exit") return;

                    string description = CheckInput(0, "Nhập mô tả cho thành phần");
                    if (description == "=exit") return;

                    components.Add(new Component(id, UpperFirstChar(name), UpperFirstChar(description)));
                    BackupData();
                }

                // Cập nhật thành phần
                void UpdateComponent()
                {
                    Console.WriteLine("\n--- Cập nhật thành phần ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã thành phần cần cập nhật");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Component component = components.SearchById(id);

                        if (component != null)
                        {
                            string name = CheckInput(0, "Nhập tên mới cho thành phần");
                            if (name == "=exit") return;
                            if (name == "_") name = component.ComponentName; 

                            string description = CheckInput(0, "Nhập mô tả mới cho thành phần");
                            if (description == "=exit") return;
                            if (description == "_") description = component.ComponentDescription;

                            components.Update(id, new Component(id, UpperFirstChar(name), UpperFirstChar(description)));
                            BackupData();
                        }
                        else
                        {
                            Console.WriteLine($"Không thể cập nhật - Không tồn tại thành phần có mã {id}");
                        }
                    }
                }

                // Xóa thành phần
                void DeleteComponent()
                {
                    Console.WriteLine("\n--- Xóa thành phần ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã thành phần cần xóa");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        components.Delete(id);
                        BackupData();
                    }
                }

                // Tìm thành phần theo mã
                void SearchByIdComponent()
                {
                    Console.WriteLine("\n--- Tìm thành phần theo mã ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã thành phần cần tìm");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Component component = components.SearchById(id);

                        if (component != null)
                        {
                            component.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy thành phần có mã {id}");
                        }
                    }
                }

                // Tìm thành phần theo từ khóa
                void SearchByKeyWordComponent()
                {
                    Console.WriteLine("\n--- Tìm thành phần theo từ khóa ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string keyWord = CheckInput(0, "Nhập từ khóa cần tìm");
                    if (keyWord == "=exit") return;
                    if (keyWord != "_")
                    {
                        Repository<Component> componentsWithKeyWord = new Repository<Component>();

                        List<Component> componentsSearch = components.SearchByKeyWord(keyWord);

                        if (componentsSearch.Count > 0)
                        {
                            foreach (var item in componentsSearch)
                            {
                                componentsWithKeyWord.Add(item);
                            }
                            for (int i = 0; i < componentsSearch.Count; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            }
                            componentsWithKeyWord.DisplayAsTable();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy thành phần có từ khóa: {keyWord}");
                        }
                    }
                }

                // Hiển thị tất cả thành phần
                void DisplayAllComponent()
                {
                    Console.WriteLine("\n--- Xem danh sách thành phần---");
                    components.DisplayAsTable();
                }

                // Hiển thị chi tiết một thành phần
                void DisplayDetailComponent()
                {
                    Console.WriteLine("\n--- Xem chi tiết một thành phần ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã thành phần cần xem chi tiết");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Component component = components.SearchById(id);

                        if (component != null)
                        {
                            component.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy thành phần có mã {id}");
                        }
                    }
                }
            }

            // Quản lý công dụng
            void UseManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine($"+{new string('-', 32)}+");
                    Console.WriteLine($"| {"",2}{"Quản lý danh mục công dụng",-28} |");
                    Console.WriteLine($"+{new string('-', 32)}+");
                    Console.WriteLine($"| {"",8}{"Menu chức năng",-22} |");
                    Console.WriteLine($"+{new string('-', 32)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách công dụng",-30} |");
                    Console.WriteLine($"| {"[2] Xem chi tiết một công dụng",-30} |");
                    Console.WriteLine($"| {"[3] Thêm công dụng",-30} |");
                    Console.WriteLine($"| {"[4] Cập nhật công dụng",-30} |");
                    Console.WriteLine($"| {"[5] Xóa công dụng",-30} |");
                    Console.WriteLine($"| {"[6] Tìm công dụng theo mã",-30} |");
                    Console.WriteLine($"| {"[7] Tìm công dụng theo từ khóa",-30} |");
                    Console.WriteLine($"| {"[0] Thoát",-30} |");
                    Console.WriteLine($"+{new string('-', 32)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DisplayAllUse();
                            break;
                        case "2":
                            DisplayDetailUse();
                            break;
                        case "3":
                            AddUse();
                            break;
                        case "4":
                            UpdateUse();
                            break;
                        case "5":
                            DeleteUse();
                            break;
                        case "6":
                            SearchByIdUse();
                            break;
                        case "7":
                            SearchByKeyWordUse();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                // Thêm công dụng
                void AddUse()
                {
                    Console.WriteLine("\n--- Thêm công dụng ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = uses.List.Count == 0 ? "U00001" : "U" + (int.Parse(uses.List[uses.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    string name = CheckInput(1, "Nhập tên cho công dụng");
                    if (name == "=exit") return;

                    string description = CheckInput(0, "Nhập mô tả cho công dụng");
                    if (description == "=exit") return;

                    uses.Add(new Use(id, UpperFirstChar(name), UpperFirstChar(description)));
                    BackupData();
                }

                // Cập nhật công dụng
                void UpdateUse()
                {
                    Console.WriteLine("\n--- Cập nhật công dụng ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã công dụng cần cập nhật");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Use use = uses.SearchById(id);

                        if (use != null)
                        {
                            string name = CheckInput(0, "Nhập tên mới cho công dụng");
                            if (name == "=exit") return;
                            if (name == "_") name = use.UseName;

                            string description = CheckInput(0, "Nhập mô tả mới cho công dụng");
                            if (description == "=exit") return;
                            if (description == "_") description = use.UseDescription;

                            uses.Update(id, new Use(id, UpperFirstChar(name), UpperFirstChar(description)));
                            BackupData();
                        }
                        else
                        {
                            Console.WriteLine($"Không thể cập nhật - Không tồn tại công dụng có mã {id}");
                        }
                    }
                }

                // Xóa công dụng
                void DeleteUse()
                {
                    Console.WriteLine("\n--- Xóa công dụng ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã công dụng cần xóa");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        uses.Delete(id);
                        BackupData();
                    }
                }

                // Tìm công dụng theo mã
                void SearchByIdUse()
                {
                    Console.WriteLine("\n--- Tìm công dụng theo mã ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã công dụng cần tìm");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Use use = uses.SearchById(id);

                        if (use != null)
                        {
                            use.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy công dụng có mã {id}");
                        }
                    }
                }

                // Tìm công dụng theo từ khóa
                void SearchByKeyWordUse()
                {
                    Console.WriteLine("\n--- Tìm công dụng theo từ khóa ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");
                    
                    string keyWord = CheckInput(0, "Nhập từ khóa cần tìm");
                    if (keyWord == "=exit") return;
                    if (keyWord != "_")
                    {
                        Repository<Use> usesWithKeyWord = new Repository<Use>();

                        List<Use> usesSearch = uses.SearchByKeyWord(keyWord);

                        if (usesSearch.Count > 0)
                        {
                            foreach (var item in usesSearch)
                            {
                                usesWithKeyWord.Add(item);
                            }
                            for (int i = 0; i < usesSearch.Count; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            }
                            usesWithKeyWord.DisplayAsTable();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy công dụng có từ khóa: {keyWord}");
                        }
                    }
                }

                // Hiển thị tất cả công dụng
                void DisplayAllUse()
                {
                    Console.WriteLine("\n--- Xem danh sách công dụng ---");
                    uses.DisplayAsTable();
                }

                // Hiển thị chi tiết một công dụng
                void DisplayDetailUse()
                {
                    Console.WriteLine("\n--- Xem chi tiết một công dụng ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã công dụng cần xem chi tiết");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Use use = uses.SearchById(id);

                        if (use != null)
                        {
                            use.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy công dụng có mã {id}");
                        }
                    }
                }
            }

            // Quản lý thương hiệu
            void BrandManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine($"+{new string('-', 48)}+");
                    Console.WriteLine($"| {"",9}{"Quản lý danh mục thương hiệu",-37} |");
                    Console.WriteLine($"+{new string('-', 48)}+");
                    Console.WriteLine($"| {"",16}{"Menu chức năng",-30} |");
                    Console.WriteLine($"+{new string('-', 48)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách thương hiệu",-46} |");
                    Console.WriteLine($"| {"[2] Xem chi tiết một thương hiệu",-46} |");
                    Console.WriteLine($"| {"[3] Thêm thương hiệu",-46} |");
                    Console.WriteLine($"| {"[4] Cập nhật thương hiệu",-46} |");
                    Console.WriteLine($"| {"[5] Xóa thương hiệu",-46} |");
                    Console.WriteLine($"| {"[6] Tìm thương hiệu theo mã",-46} |");
                    Console.WriteLine($"| {"[7] Tìm thương hiệu theo từ khóa",-46} |");
                    Console.WriteLine($"| [8] Xem danh sách sản phẩm của một thương hiệu |");
                    Console.WriteLine($"| {"[0] Thoát",-46} |");
                    Console.WriteLine($"+{new string('-', 48)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DisplayAllBrand();
                            break;
                        case "2":
                            DisplayDetailBrand();
                            break;
                        case "3":
                            AddBrand();
                            break;
                        case "4":
                            UpdateBrand();
                            break;
                        case "5":
                            DeleteBrand();
                            break;
                        case "6":
                            SearchByIdBrand();
                            break;
                        case "7":
                            SearchByKeyWordBrand();
                            break;
                        case "8":
                            DisplayProductsOfBrand();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                // Thêm thương hiệu
                void AddBrand()
                {
                    Console.WriteLine("\n--- Thêm thương hiệu ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = brands.List.Count == 0 ? "B00001" : "B" + (int.Parse(brands.List[brands.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    string name = CheckInput(1, "Nhập tên cho thương hiệu");
                    if (name == "=exit") return;

                    string email = CheckEmail(1, "Nhập email cho thương hiệu");
                    if (email == "=exit") return;

                    string phoneNumber = CheckPhoneNumber(1, "Nhập số điện thoại cho thương hiệu");
                    if (phoneNumber == "=exit") return;

                    string address = CheckInput(1, "Nhập địa chỉ cho thương hiệu");
                    if (address == "=exit") return;

                    string country = CheckInput(1, "Nhập tên quốc gia cho thương hiệu");
                    if (country == "=exit") return;

                    brands.Add(new Brand(id, UpperFirstChar(name), email, phoneNumber, UpperFirstChar(address), UpperFirstChar(country)));
                    BackupData();
                }

                // Cập nhật thương hiệu
                void UpdateBrand()
                {
                    Console.WriteLine("\n--- Cập nhật thương hiệu ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã thương hiệu cần cập nhật");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Brand brand = brands.SearchById(id);

                        if (brand != null)
                        {
                            string name = CheckInput(0, "Nhập tên mới cho thương hiệu");
                            if (name == "=exit") return;
                            if (name == "_") name = brand.BrandName;

                            string email = CheckEmail(0, "Nhập email mới cho thương hiệu");
                            if (email == "=exit") return;
                            if (email == "_") email = brand.BrandEmail;

                            string phoneNumber = CheckPhoneNumber(0, "Nhập số điện thoại mới cho thương hiệu");
                            if (phoneNumber == "=exit") return;
                            if (phoneNumber == "_") phoneNumber = brand.BrandPhoneNumber;

                            string address = CheckInput(0, "Nhập địa chỉ mới cho thương hiệu");
                            if (address == "=exit") return;
                            if (address == "_") address = brand.BrandAddress;

                            string country = CheckInput(0, "Nhập tên quốc gia mới cho thương hiệu");
                            if (country == "=exit") return;
                            if (country == "_") country = brand.BrandCountry;

                            brands.Update(id, new Brand(id, UpperFirstChar(name), email, phoneNumber, UpperFirstChar(address), UpperFirstChar(country)));
                            BackupData();
                        }
                        else
                        {
                            Console.WriteLine($"Không thể cập nhật - Không tồn tại thượng hiệu có mã {id}");
                        }
                    }
                }

                // Xóa thương hiệu
                void DeleteBrand()
                {
                    Console.WriteLine("\n--- Xóa thương hiệu ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã thương hiệu cần xóa");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        brands.Delete(id);
                        BackupData();
                    }
                }

                // Tìm thương hiệu theo mã
                void SearchByIdBrand()
                {
                    Console.WriteLine("\n--- Tìm thương hiệu theo mã ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã thương hiệu cần tìm");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Brand brand = brands.SearchById(id);

                        if (brand != null)
                        {
                            brand.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy thương hiệu có mã {id}");
                        }
                    }
                }

                // Tìm thương hiệu theo từ khóa
                void SearchByKeyWordBrand()
                {
                    Console.WriteLine("\n--- Tìm thương hiệu theo từ khóa ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string keyWord = CheckInput(0, "Nhập từ khóa cần tìm");
                    if (keyWord == "=exit") return;
                    if (keyWord != "_")
                    {
                        Repository<Brand> brandsWithKeyWord = new Repository<Brand>();

                        List<Brand> brandsSearch = brands.SearchByKeyWord(keyWord);

                        if (brandsSearch.Count > 0)
                        {
                            foreach (var item in brandsSearch)
                            {
                                brandsWithKeyWord.Add(item);
                            }
                            for (int i = 0; i < brandsSearch.Count; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            }
                            brandsWithKeyWord.DisplayAsTable();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy thương hiệu có từ khóa: {keyWord}");
                        }
                    }
                }

                // Hiển thị tất cả thương hiệu
                void DisplayAllBrand()
                {
                    Console.WriteLine("\n--- Xem danh sách thương hiệu ---");
                    brands.DisplayAsTable();
                }

                // Hiển thị chi tiết một thương hiệu
                void DisplayDetailBrand()
                {
                    Console.WriteLine("\n--- Xem chi tiết một thương hiệu ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã thương hiệu cần xem chi tiết");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Brand brand = brands.SearchById(id);

                        if (brand != null)
                        {
                            brand.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy thương hiệu có mã {id}");
                        }
                    }
                }

                // Hiển thị các sản phẩm của một thương hiệu
                void DisplayProductsOfBrand()
                {
                    Console.WriteLine("\n--- Xem danh sách sản phẩm của một thương hiệu ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã thương hiệu cần xem các sản phẩm");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        if (brands.SearchById(id) != null)
                        {
                            List<Fertilizer> fertilizersList = fertilizers.List.FindAll(item => item.BrandId == id.ToUpper());

                            Repository<Fertilizer> fertilizersOfBrand = new Repository<Fertilizer>();

                            if (fertilizersList.Count > 0)
                            {
                                foreach (var item in fertilizersList)
                                {
                                    fertilizersOfBrand.Add(item);
                                }
                                for (int i = 0; i < fertilizersList.Count; i++)
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                }
                                fertilizersOfBrand.DisplayAsTable();
                            }
                            else
                            {
                                Console.WriteLine($"Thương hiệu có mã {id} không có sản phẩm nào.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Thương hiệu có mã {id} không tồn tại.");
                        }
                    }
                }
            }

            // Quản lý nhân viên
            void EmployeeManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine($"+{new string('-', 61)}+");
                    Console.WriteLine($"| {"",16}{"Quản lý danh mục nhân viên",-43} |");
                    Console.WriteLine($"+{new string('-', 61)}+");
                    Console.WriteLine($"| {"",22}{"Menu chức năng",-37} |");
                    Console.WriteLine($"+{new string('-', 61)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách nhân viên",-59} |");
                    Console.WriteLine($"| {"[2] Xem chi tiết một nhân viên",-59} |");
                    Console.WriteLine($"| {"[3] Thêm nhân viên",-59} |");
                    Console.WriteLine($"| {"[4] Cập nhật nhân viên",-59} |");
                    Console.WriteLine($"| {"[5] Xóa nhân viên",-59} |");
                    Console.WriteLine($"| {"[6] Tìm nhân viên theo mã",-59} |");
                    Console.WriteLine($"| {"[7] Tìm nhân viên theo từ khóa",-59} |");
                    Console.WriteLine($"| [8] Xem danh sách nhóm sản phẩm phụ trách bởi một nhân viên |");
                    Console.WriteLine($"| {"[0] Thoát",-59} |");
                    Console.WriteLine($"+{new string('-', 61)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DisplayAllEmployee();
                            break;
                        case "2":
                            DisplayDetailEmployee();
                            break;
                        case "3":
                            AddEmployee();
                            break;
                        case "4":
                            UpdateEmployee();
                            break;
                        case "5":
                            DeleteEmployee();
                            break;
                        case "6":
                            SearchByIdEmployee();
                            break;
                        case "7":
                            SearchByKeyWordEmployee();
                            break;
                        case "8":
                            DisplayProductGroupsByEmployee();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                // Thêm nhân viên
                void AddEmployee()
                {
                    Console.WriteLine("\n--- Thêm nhân viên ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = employees.List.Count == 0 ? "E00001" : "E" + (int.Parse(employees.List[employees.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    string name = CheckInput(1, "Nhập tên cho nhân viên");
                    if (name == "=exit") return;

                    string gender = CheckInput(1, "Nhập giới tính cho nhân viên");
                    if (gender == "=exit") return;

                    string dateOfBirth;
                    do
                    {
                        dateOfBirth = CheckDate(1, "Nhập ngày sinh cho nhân viên");
                        if (dateOfBirth == "=exit") return;
                        if (DateTime.Parse(dateOfBirth).AddYears(18) > DateTime.Now)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("Ngày sinh không hợp lệ, nhân viên phải từ đủ 18 tuổi trở lên. Vui lòng nhập lại." + new string(' ', 50));
                        } else
                        {
                            break;
                        }
                    }
                    while (true);

                    string phoneNumber = CheckPhoneNumber(1, "Nhập số điện thoại cho nhân viên");
                    if (phoneNumber == "=exit") return;

                    string address = CheckInput(1, "Nhập địa chỉ cho nhân viên");
                    if (address == "=exit") return;

                    string position = CheckInput(0, "Nhập vị trí làm việc cho nhân viên");
                    if (position == "=exit") return;

                    employees.Add(new Employee(id, UpperFirstChar(name), UpperFirstChar(gender), DateTime.Parse(dateOfBirth), phoneNumber, UpperFirstChar(address), UpperFirstChar(position)));
                    BackupData();
                }

                // Cập nhật nhân viên
                void UpdateEmployee()
                {
                    Console.WriteLine("\n--- Cập nhật nhân viên ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã nhân viên cần cập nhật");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Employee employee = employees.SearchById(id);

                        if (employee != null)
                        {
                            string name = CheckInput(0, "Nhập tên mới cho nhân viên");
                            if (name == "=exit") return;
                            if (name == "_") name = employee.EmployeeName;

                            string gender = CheckInput(0, "Nhập tên mới cho nhân viên");
                            if (gender == "=exit") return;
                            if (gender == "_") gender = employee.EmployeeGender;

                            string dateOfBirth;
                            do
                            {
                                dateOfBirth = CheckDate(0, "Nhập ngày sinh mới cho nhân viên");
                                if (dateOfBirth == "=exit") return;
                                if (dateOfBirth != "_")
                                {
                                    if (DateTime.Parse(dateOfBirth).AddYears(18) > DateTime.Now)
                                    {
                                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                                        Console.WriteLine("Ngày sinh mới không hợp lệ, nhân viên phải từ đủ 18 tuổi trở lên. Vui lòng nhập lại." + new string(' ', 50));
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } else
                                {
                                    dateOfBirth = employee.EmployeeDateOfBirth.ToString();
                                    break;
                                }
                            }
                            while (true);

                            string phoneNumber = CheckPhoneNumber(0, "Nhập số điện thoại mới cho nhân viên");
                            if (phoneNumber == "=exit") return;
                            if (phoneNumber == "_") phoneNumber = employee.EmployeePhoneNumber;

                            string address = CheckInput(0, "Nhập địa chỉ mới cho nhân viên");
                            if (address == "=exit") return;
                            if (address == "_") address = employee.EmployeeAddress;

                            string position = CheckInput(0, "Nhập vị trí làm việc mới cho nhân viên");
                            if (position == "=exit") return;
                            if (position == "_") position = employee.EmployeePosition;

                            employees.Update(id, new Employee(id, UpperFirstChar(name), UpperFirstChar(gender), DateTime.Parse(dateOfBirth), phoneNumber, UpperFirstChar(address), UpperFirstChar(position)));
                            BackupData();
                        }
                        else
                        {
                            Console.WriteLine($"Không thể cập nhật - Không tồn tại nhân viên có mã {id}");
                        }
                    }
                }

                // Xóa nhân viên
                void DeleteEmployee()
                {
                    Console.WriteLine("\n--- Xóa nhân viên ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã nhân viên cần xóa");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        employees.Delete(id);
                        BackupData();
                    }
                }

                // Tìm nhân viên theo mã
                void SearchByIdEmployee()
                {
                    Console.WriteLine("\n--- Tìm nhân viên theo mã ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã nhân viên cần tìm");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Employee employee = employees.SearchById(id);

                        if (employee != null)
                        {
                            employee.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy nhân viên có mã {id}");
                        }
                    }
                }

                // Tìm nhân viên theo từ khóa
                void SearchByKeyWordEmployee()
                {
                    Console.WriteLine("\n--- Tìm nhân viên theo từ khóa ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string keyWord = CheckInput(0, "Nhập từ khóa cần tìm");
                    if (keyWord == "=exit") return;
                    if (keyWord != "_")
                    {
                        Repository<Employee> employeesWithKeyWord = new Repository<Employee>();

                        List<Employee> employeesSearch = employees.SearchByKeyWord(keyWord);

                        if (employeesSearch.Count > 0)
                        {
                            foreach (var item in employeesSearch)
                            {
                                employeesWithKeyWord.Add(item);
                            }
                            for (int i = 0; i < employeesSearch.Count; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            }
                            employeesWithKeyWord.DisplayAsTable();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy nhân viên có từ khóa: {keyWord}");
                        }
                    }
                }

                // Hiển thị tất cả nhân viên
                void DisplayAllEmployee()
                {
                    Console.WriteLine("\n--- Xem danh sách nhân viên ---");
                    employees.DisplayAsTable();
                }

                // Hiển thị chi tiết một nhân viên
                void DisplayDetailEmployee()
                {
                    Console.WriteLine("\n--- Xem chi tiết một nhân viên ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã nhân viên cần xem chi tiết");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        Employee employee = employees.SearchById(id);

                        if (employee != null)
                        {
                            employee.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy nhân viên có mã {id}");
                        }
                    }
                }

                // Hiển thị các nhóm sản phẩm phụ trách bởi một nhân viên
                void DisplayProductGroupsByEmployee()
                {
                    Console.WriteLine("\n--- Xem danh sách nhóm sản phẩm phụ trách bởi một nhân viên ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã nhân viên cần xem các nhóm sản phẩm đang phụ trách");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        if (employees.SearchById(id) != null)
                        {
                            List<ProductGroup> productGroupsList = productGroups.List.FindAll(item => item.EmployeeId == id.ToUpper());

                            Repository<ProductGroup> productGroupsOfBrand = new Repository<ProductGroup>();

                            if (productGroupsList.Count > 0)
                            {
                                foreach (var item in productGroupsList)
                                {
                                    productGroupsOfBrand.Add(item);
                                }
                                for (int i = 0; i < productGroupsList.Count; i++)
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                }
                                productGroupsOfBrand.DisplayAsTable();
                            }
                            else
                            {
                                Console.WriteLine($"Nhân viên có mã {id} không phụ trách sản phẩm nào.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Nhân viên có mã {id} không tồn tại.");
                        }
                    }
                }
            }

            // Quản lý liên kết sản phẩm - công dụng
            void ProductUseManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine($"+{new string('-', 39)}+");
                    Console.WriteLine($"| Quản lý liên kết sản phẩm - công dụng |");
                    Console.WriteLine($"+{new string('-', 39)}+");
                    Console.WriteLine($"| {"",11}{"Menu chức năng",-26} |");
                    Console.WriteLine($"+{new string('-', 39)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách liên kết",-37} |");
                    Console.WriteLine($"| {"[2] Xem chi tiết một liên kết",-37} |");
                    Console.WriteLine($"| {"[3] Thêm liên kết",-37} |");
                    Console.WriteLine($"| {"[4] Cập nhật liên kết",-37} |");
                    Console.WriteLine($"| {"[5] Xóa liên kết",-37} |");
                    Console.WriteLine($"| {"[6] Tìm liên kết theo mã",-37} |");
                    Console.WriteLine($"| {"[7] Tìm liên kết theo từ khóa",-37} |");
                    Console.WriteLine($"| {"[0] Thoát",-37} |");
                    Console.WriteLine($"+{new string('-', 39)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DisplayAllProductUse();
                            break;
                        case "2":
                            DisplayDetailProductUse();
                            break;
                        case "3":
                            AddProductUse();
                            break;
                        case "4":
                            UpdateProductUse();
                            break;
                        case "5":
                            DeleteProductUse();
                            break;
                        case "6":
                            SearchByIdProductUse();
                            break;
                        case "7":
                            SearchByKeyWordProductUse();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                // Thêm liên kết
                void AddProductUse()
                {
                    Console.WriteLine("\n--- Thêm liên kết ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = productUses.List.Count == 0 ? "PU00001" : "PU" + (int.Parse(productUses.List[productUses.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    string productId;
                    do
                    {
                        productId = CheckId(1, "Nhập mã sản phẩm cho liên kết");
                        if (productId == "=exit") return;
                        if (productId != "_")
                        {
                            Fertilizer fertilizer = fertilizers.SearchById(productId);
                            if (fertilizer == null)
                            {
                                Console.WriteLine($"Mã sản phẩm {productId} không tồn tại");
                            }
                            else
                            {
                                break;
                            }
                        } else
                        {
                            break;
                        }
                    }
                    while (true);

                    string useId;
                    do
                    {
                        useId = CheckId(1, "Nhập mã công dụng cho liên kết");
                        if (useId == "=exit") return;
                        if (useId != "_")
                        {
                            Use use = uses.SearchById(useId);
                            if (use == null)
                            {
                                Console.WriteLine($"Mã công dụng {useId} không tồn tại");
                            }
                            else
                            {
                                break;
                            }
                        } else
                        {
                            break;
                        }
                    }
                    while (true);

                    productUses.Add(new ProductUse(id, productId, useId));
                    BackupData();
                }

                // Cập nhật liên kết
                void UpdateProductUse()
                {
                    Console.WriteLine("\n--- Cập nhật liên kết ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã liên kết cần cập nhật");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        ProductUse productUse = productUses.SearchById(id);

                        if (productUse != null)
                        {
                            string productId;
                            do
                            {
                                productId = CheckId(0, "Nhập mã sản phẩm mới cho liên kết");
                                if (productId == "=exit") return;
                                if (productId != "_")
                                {
                                    Fertilizer fertilizer = fertilizers.SearchById(productId);
                                    if (fertilizer == null)
                                    {
                                        Console.WriteLine($"Mã sản phẩm mới {productId} không tồn tại");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    productId = productUse.ProductId;
                                    break;
                                }
                            }
                            while (true);

                            string useId;
                            do
                            {
                                useId = CheckId(0, "Nhập mã công dụng mới cho liên kết");
                                if (useId == "=exit") return;
                                if (useId != "_")
                                {
                                    Use use = uses.SearchById(useId);
                                    if (use == null)
                                    {
                                        Console.WriteLine($"Mã công dụng mới {useId} không tồn tại");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    useId = productUse.UseId;
                                    break;
                                }
                            }
                            while (true);

                            productUses.Update(id, new ProductUse(id, productId, useId));
                            BackupData();
                        }
                        else
                        {
                            Console.WriteLine($"Không thể cập nhật - Không tồn tại liên kết có mã {id}");
                        }
                    }
                }

                // Xóa liên kết
                void DeleteProductUse()
                {
                    Console.WriteLine("\n--- Xóa liên kết ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã liên kết cần xóa");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        productUses.Delete(id);
                        BackupData();
                    }
                }

                // Tìm liên kết theo mã
                void SearchByIdProductUse()
                {
                    Console.WriteLine("\n--- Tìm liên kết theo mã ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã liên kết cần tìm");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        ProductUse productUse = productUses.SearchById(id);

                        if (productUse != null)
                        {
                            productUse.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy liên kết có mã {id}");
                        }
                    }
                }

                // Tìm liên kết theo từ khóa
                void SearchByKeyWordProductUse()
                {
                    Console.WriteLine("\n--- Tìm liên kết theo từ khóa ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string keyWord = CheckInput(0, "Nhập từ khóa cần tìm");
                    if (keyWord == "=exit") return;
                    if (keyWord != "_")
                    {
                        Repository<ProductUse> productUsesWithKeyWord = new Repository<ProductUse>();

                        List<ProductUse> productUseSearch = productUses.SearchByKeyWord(keyWord);

                        if (productUseSearch.Count > 0)
                        {
                            foreach (var item in productUseSearch)
                            {
                                productUsesWithKeyWord.Add(item);
                            }
                            for (int i = 0; i < productUseSearch.Count; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            }
                            productUsesWithKeyWord.DisplayAsTable();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy liên kết có từ khóa: {keyWord}");
                        }
                    }
                }

                // Hiển thị tất cả liên kết
                void DisplayAllProductUse()
                {
                    Console.WriteLine("\n--- Xem danh sách liên kết ---");
                    productUses.DisplayAsTable();
                }

                // Hiển thị chi tiết một liên kết
                void DisplayDetailProductUse()
                {
                    Console.WriteLine("\n--- Xem chi tiết một liên kết ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã liên kết cần xem chi tiết");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        ProductUse productUse = productUses.SearchById(id);

                        if (productUse != null)
                        {
                            productUse.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy liên kết có mã {id}");
                        }
                    }
                }
            }

            // Quản lý liên kết sản phẩm - thành phần
            void ProductComponentManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine($"+{new string('-', 40)}+");
                    Console.WriteLine($"| Quản lý liên kết sản phẩm - thành phần |");
                    Console.WriteLine($"+{new string('-', 40)}+");
                    Console.WriteLine($"| {"",12}{"Menu chức năng",-26} |");
                    Console.WriteLine($"+{new string('-', 40)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách liên kết",-38} |");
                    Console.WriteLine($"| {"[2] Xem chi tiết một liên kết",-38} |");
                    Console.WriteLine($"| {"[3] Thêm liên kết",-38} |");
                    Console.WriteLine($"| {"[4] Cập nhật liên kết",-38} |");
                    Console.WriteLine($"| {"[5] Xóa liên kết",-38} |");
                    Console.WriteLine($"| {"[6] Tìm liên kết theo mã",-38} |");
                    Console.WriteLine($"| {"[7] Tìm liên kết theo từ khóa",-38} |");
                    Console.WriteLine($"| {"[0] Thoát",-38} |");
                    Console.WriteLine($"+{new string('-', 40)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DisplayAllProductComponent();
                            break;
                        case "2":
                            DisplayDetailProductComponent();
                            break;
                        case "3":
                            AddProductComponent();
                            break;
                        case "4":
                            UpdateProductComponent();
                            break;
                        case "5":
                            DeleteProductComponent();
                            break;
                        case "6":
                            SearchByIdProductComponent();
                            break;
                        case "7":
                            SearchByKeyWordProductComponent();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                // Thêm liên kết
                void AddProductComponent()
                {
                    Console.WriteLine("\n--- Thêm liên kết ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = productComponents.List.Count == 0 ? "PC00001" : "PC" + (int.Parse(productComponents.List[productComponents.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    string productId;
                    do
                    {
                        productId = CheckId(1, "Nhập mã sản phẩm cho liên kết");
                        if (productId == "=exit") return;
                        if (productId != "_")
                        {
                            Fertilizer fertilizer = fertilizers.SearchById(productId);
                            if (fertilizer == null)
                            {
                                Console.WriteLine($"Mã sản phẩm {productId} không tồn tại");
                            }
                            else
                            {
                                break;
                            }
                        } else
                        {
                            break;
                        }
                    }
                    while (true);

                    string componentId;
                    do
                    {
                        componentId = CheckId(1, "Nhập mã thành phần cho liên kết");
                        if (componentId == "=exit") return;
                        if (componentId != "_")
                        {
                            Component component = components.SearchById(componentId);
                            if (component == null)
                            {
                                Console.WriteLine($"Mã thành phần {componentId} không tồn tại");
                            }
                            else
                            {
                                break;
                            }
                        } else
                        {
                            break;
                        }
                    }
                    while (true);

                    string percentage = CheckInput(1, "Nhập tỉ lệ cho thành phần");
                    if (percentage == "=exit") return;

                    productComponents.Add(new ProductComponent(id, productId, componentId, percentage));
                    BackupData();
                }

                // Cập nhật liên kết
                void UpdateProductComponent()
                {
                    Console.WriteLine("\n--- Cập nhật liên kết ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã liên kết cần cập nhật");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        ProductComponent productComponent = productComponents.SearchById(id);

                        if (productComponent != null)
                        {
                            string productId;
                            do
                            {
                                productId = CheckId(0, "Nhập mã sản phẩm mới cho liên kết");
                                if (productId == "=exit") return;
                                if (productId != "_")
                                {
                                    Fertilizer fertilizer = fertilizers.SearchById(productId);
                                    if (fertilizer == null)
                                    {
                                        Console.WriteLine($"Mã sản phẩm mới {productId} không tồn tại");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    productId = productComponent.ProductId;
                                    break;
                                }
                            }
                            while (true);

                            string componentId;
                            do
                            {
                                componentId = CheckId(0, "Nhập mã thành phần mới cho liên kết");
                                if (componentId == "=exit") return;
                                if (componentId != "_")
                                {
                                    Component component = components.SearchById(componentId);
                                    if (component == null)
                                    {
                                        Console.WriteLine($"Mã thành phần mới {componentId} không tồn tại");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    componentId = productComponent.ComponentId;
                                    break;
                                }
                            }
                            while (true);

                            string percentage = CheckInput(0, "Nhập tỉ lệ mới cho thành phần");
                            if (percentage == "=exit") return;
                            if (percentage == "_") percentage = productComponent.ComponentPercentage;

                            productComponents.Update(id, new ProductComponent(id, productId, componentId, percentage));
                            BackupData();
                        }
                        else
                        {
                            Console.WriteLine($"Không thể cập nhật - Không tồn tại liên kết có mã {id}");
                        }
                    }
                }

                // Xóa liên kết
                void DeleteProductComponent()
                {
                    Console.WriteLine("\n--- Xóa liên kết ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã liên kết cần xóa");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        productComponents.Delete(id);
                        BackupData();
                    }
                }

                // Tìm liên kết theo mã
                void SearchByIdProductComponent()
                {
                    Console.WriteLine("\n--- Tìm liên kết theo mã ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã liên kết cần tìm");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        ProductComponent productComponent = productComponents.SearchById(id);

                        if (productComponent != null)
                        {
                            productComponent.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy liên kết có mã {id}");
                        }
                    }
                }

                // Tìm liên kết theo từ khóa
                void SearchByKeyWordProductComponent()
                {
                    Console.WriteLine("\n--- Tìm liên kết theo từ khóa ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string keyWord = CheckInput(0, "Nhập từ khóa cần tìm");
                    if (keyWord == "=exit") return;
                    if (keyWord != "_")
                    {
                        Repository<ProductComponent> productComponentWithKeyWord = new Repository<ProductComponent>();

                        List<ProductComponent> productComponentSearch = productComponents.SearchByKeyWord(keyWord);

                        if (productComponentSearch.Count > 0)
                        {
                            foreach (var item in productComponentSearch)
                            {
                                productComponentWithKeyWord.Add(item);
                            }
                            for (int i = 0; i < productComponentSearch.Count; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                            }
                            productComponentWithKeyWord.DisplayAsTable();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy liên kết có từ khóa: {keyWord}");
                        }
                    }
                }

                // Hiển thị tất cả liên kết
                void DisplayAllProductComponent()
                {
                    Console.WriteLine("\n--- Xem danh sách liên kết ---");
                    productComponents.DisplayAsTable();
                }

                // Hiển thị chi tiết một liên kết
                void DisplayDetailProductComponent()
                {
                    Console.WriteLine("\n--- Xem chi tiết một liên kết ---");
                    Console.WriteLine("Trường không đánh dấu (*) là trường không bắt buộc, có thể nhấn Enter để bỏ qua");
                    Console.WriteLine("Để thoát khỏi các trường nhập liệu, nhập lệnh =exit");

                    string id = CheckId(0, "Nhập mã liên kết cần xem chi tiết");
                    if (id == "=exit") return;
                    if (id != "_")
                    {
                        ProductComponent productComponent = productComponents.SearchById(id);

                        if (productComponent != null)
                        {
                            productComponent.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy liên kết có mã {id}");
                        }
                    }
                }
            }

            // Kiểm tra nhập
            string CheckInput(int type, string request)
            {
                string input;
                do
                {
                    Console.Write($"{request + (type == 1 ? " (*): " : ": ")}");
                    input = Console.ReadLine();
                    if (input == "=exit")
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine($"{request + (type == 1 ? " (*): Thoát" : ": Thoát")}");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        if (type == 0)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine($"{request}: Bỏ qua");
                            input = "_";
                        }
                        else
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            int index = request.IndexOf("(");
                            int length = index > 0 ? index - 7 : request.Length - 6;
                            Console.WriteLine($"{char.ToUpper(request[5]) + request.Substring(6, length)} là trường bắt buộc. Vui lòng nhập lại." + new string(' ', 50));
                        }
                    }
                } while (string.IsNullOrWhiteSpace(input));
                return input;
            }

            // Kiểm tra ngày
            string CheckDate(int type, string request)
            {
                string input;
                do
                {
                    input = CheckInput(type, request);
                    if (input != "=exit" && input != "_")
                    {
                        if (!DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            int index = request.IndexOf("(");
                            int length = index > 0 ? index - 7 : request.Length - 6;
                            Console.WriteLine($"{char.ToUpper(request[5]) + request.Substring(6, length)} không hợp lệ. Vui lòng nhập lại." + new string(' ', 50));
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        return input;
                    }
                } while (true);

                return input;
            }

            // Kiểm số điện thoại
            string CheckPhoneNumber(int type, string request)
            {
                string input;
                do
                {
                    input = CheckInput(type, request);
                    if (input != "=exit" && input != "_")
                    {
                        if (!Regex.IsMatch(input, @"^0\d{9}$|^\+(\d{1,4})\s{0,1}\d{6,15}$"))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            int index = request.IndexOf("(");
                            int length = index > 0 ? index - 7 : request.Length - 6;
                            Console.WriteLine($"{char.ToUpper(request[5]) + request.Substring(6, length)} không hợp lệ. Vui lòng nhập lại." + new string(' ', 50));
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        return input;
                    }
                } while (true);

                return input;
            }

            // Kiểm tra email
            string CheckEmail(int type, string request)
            {
                string input;
                do
                {
                    input = CheckInput(type, request);
                    if (input != "=exit" && input != "_")
                    {
                        if (!Regex.IsMatch(input, @"^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$"))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            int index = request.IndexOf("(");
                            int length = index > 0 ? index - 7 : request.Length - 6;
                            Console.WriteLine($"{char.ToUpper(request[5]) + request.Substring(6, length)} không hợp lệ. Vui lòng nhập lại." + new string(' ', 50));
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        return input;
                    }
                } while (true);

                return input;
            }

            // Kiểm tra mã
            string CheckId(int type, string request)
            {
                string input;
                do
                {
                    input = CheckInput(type, request);
                    if (input != "=exit" && input != "_")
                    {
                        if (!Regex.IsMatch(input, @"^[a-zA-Z]{1,2}\d{5}$"))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            int index = request.IndexOf("(");
                            int length = index > 0 ? index - 7 : request.Length - 6;
                            Console.WriteLine($"{char.ToUpper(request[5]) + request.Substring(6, length)} không hợp lệ. Vui lòng nhập lại." + new string(' ', 50));
                        }
                        else
                        {
                            input = input.ToUpper();
                            break;
                        }
                    }
                    else
                    {
                        return input;
                    }
                } while (true);

                return input;
            }

            // Kiểm tra số 
            string CheckNumber(int type, string typeNumber, string request)
            {
                string input;
                do
                {
                    input = CheckInput(type, request);
                    input = input.Contains('.') ? input.Replace('.', ',') : input;
                    if (input != "=exit" && input != "_")
                    {
                        if (typeNumber == "int")
                        {
                            if (!int.TryParse(input, out _))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                int index = request.IndexOf("(");
                                int length = index > 0 ? index - 7 : request.Length - 6;
                                Console.WriteLine($"{char.ToUpper(request[5]) + request.Substring(6, length)} không hợp lệ. Vui lòng nhập lại." + new string(' ', 50));
                            }
                            else
                            {
                                break;
                            }
                        } else
                        {
                            if (!float.TryParse(input, out _))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                int index = request.IndexOf("(");
                                int length = index > 0 ? index - 7 : request.Length - 6;
                                Console.WriteLine($"{char.ToUpper(request[5]) + request.Substring(6, length)} không hợp lệ. Vui lòng nhập lại." + new string(' ', 50));
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        return input;
                    }
                } while (true);

                return input;
            }

            // Viết hoa ký tự đầu
            string UpperFirstChar(string input)
            {
                return char.ToUpper(input[0]) + input.Substring(1);
            }

            // Sao lưu dữ liệu vào file Json
            void BackupData()
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("productGroups", productGroups.List);
                data.Add("fertilizers", fertilizers.List);
                data.Add("brands", brands.List);
                data.Add("employees", employees.List);
                data.Add("uses", uses.List);
                data.Add("components", components.List);
                data.Add("productComponents", productComponents.List);
                data.Add("productUses", productUses.List);

                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(path, json);
            }

            // Phục hồi dữ liệu từ file Json
            void RestoreData()
            {
                string fileContent = File.ReadAllText(path);

                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(fileContent);

                productGroups.List = JsonConvert.DeserializeObject<List<ProductGroup>>(data["productGroups"].ToString());
                fertilizers.List = JsonConvert.DeserializeObject<List<Fertilizer>>(data["fertilizers"].ToString());
                brands.List = JsonConvert.DeserializeObject<List<Brand>>(data["brands"].ToString());
                employees.List = JsonConvert.DeserializeObject<List<Employee>>(data["employees"].ToString());
                uses.List = JsonConvert.DeserializeObject<List<Use>>(data["uses"].ToString());
                components.List = JsonConvert.DeserializeObject<List<Component>>(data["components"].ToString());
                productComponents.List = JsonConvert.DeserializeObject<List<ProductComponent>>(data["productComponents"].ToString());
                productUses.List = JsonConvert.DeserializeObject<List<ProductUse>>(data["productUses"].ToString());
            }
        }
    }
}