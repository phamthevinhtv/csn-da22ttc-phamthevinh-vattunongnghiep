using AgriculturalSuppliesStore.Entities;
using AgriculturalSuppliesStore.Interfaces;
using AgriculturalSuppliesStore.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repo<GroupProduct> repoGroupProduct = new Repo<GroupProduct>();
            Repo<Employee> repoEmployee = new Repo<Employee>();
            Repo<Brand> repoBrand = new Repo<Brand>();
            Repo<Fertilizer> repoFertilizer = new Repo<Fertilizer>();
            Repo<Component> repoComponent = new Repo<Component>();
            Repo<Use> repoUse = new Repo<Use>();
            Repo<ProductComponent> repoProductComponent = new Repo<ProductComponent>();
            Repo<ProductUse> repoProductUse = new Repo<ProductUse>();

            //Dữ liệu thử
            repoGroupProduct.Add(new GroupProduct("GP00001", "Phân bón hữu cơ", "Cải tạo đất, thân thiện môi trường", "E00002"));
            repoGroupProduct.Add(new GroupProduct("GP00002", "Phân bón NPK 16-16-8", "Cân đối dinh dưỡng cây trồng", "E00003"));
            repoGroupProduct.Add(new GroupProduct("GP00003", "Phân đạm Urea", "Tăng năng suất, dễ sử dụng", "E00002"));

            repoEmployee.Add(new Employee("E00001", "Nguyễn Văn A", new DateTime(1985, 5, 20), "0912345678", "Hà Nội", "Nhân viên kỹ thuật"));
            repoEmployee.Add(new Employee("E00002", "Trần Thị B", new DateTime(1990, 7, 15), "0987654321", "TP. Hồ Chí Minh", "Nhân viên bán hàng"));
            repoEmployee.Add(new Employee("E00003", "Lê Văn C", new DateTime(1995, 3, 10), "0901234567", "Đà Nẵng", "Nhân viên bán hàng"));

            repoFertilizer.Add(new Fertilizer("F00001", "Phân bón hữu cơ", 150000, 100, "Cải tạo đất, thân thiện môi trường", "Bao 25kg", new DateTime(2023, 1, 15), new DateTime(2025, 1, 15), "B00001", "GP00001"));
            repoFertilizer.Add(new Fertilizer("F00002", "Phân bón NPK 16-16-8", 250000, 200, "Cân đối dinh dưỡng cây trồng", "Bao 50kg", new DateTime(2023, 6, 10), new DateTime(2025, 6, 10), "B00002", "GP00002"));
            repoFertilizer.Add(new Fertilizer("F00003", "Phân đạm Urea", 220000, 150, "Tăng năng suất, dễ sử dụng", "Bao 50kg", new DateTime(2023, 3, 5), new DateTime(2025, 3, 5), "B00003", "GP00003"));

            repoComponent.Add(new Component("C00001", "Đạm (Nitơ)", 16.0f, "Giúp cây phát triển thân, lá."));
            repoComponent.Add(new Component("C00002", "Lân (Phốt pho)", 8.0f, "Thúc đẩy ra hoa và kết trái."));
            repoComponent.Add(new Component("C00003", "Kali (K)", 16.0f, "Cải thiện khả năng chịu hạn, sâu bệnh."));

            repoUse.Add(new Use("U00001", "Thúc đẩy sinh trưởng", "Tăng trưởng nhanh, phát triển toàn diện."));
            repoUse.Add(new Use("U00002", "Ra hoa, kết trái", "Thúc đẩy ra hoa đều, quả chắc, ít rụng."));
            repoUse.Add(new Use("U00003", "Cải thiện đất", "Cải thiện kết cấu đất, tăng độ phì nhiêu."));

            repoBrand.Add(new Brand("B00001", "Việt Nga", "contact@vietnga.com", "0241234567", "Hà Nội, Việt Nam", "Việt Nam"));
            repoBrand.Add(new Brand("B00002", "Phân Bón Hữu Cơ ABC", "support@phanonhucabc.com", "0287654321", "TP. Hồ Chí Minh, Việt Nam", "Việt Nam"));
            repoBrand.Add(new Brand("B00003", "AgroChem", "info@agrochem.com", "0298765432", "Đà Nẵng, Việt Nam", "Việt Nam"));

            repoProductUse.Add(new ProductUse("PU00001", "F00001", "U00001"));
            repoProductUse.Add(new ProductUse("PU00002", "F00002", "U00002"));
            repoProductUse.Add(new ProductUse("PU00003", "F00003", "U00003"));

            repoProductComponent.Add(new ProductComponent("PC00001", "F00001", "C00001"));
            repoProductComponent.Add(new ProductComponent("PC00001", "F00002", "C00002"));
            repoProductComponent.Add(new ProductComponent("PC00001", "F00003", "C00003"));

            Console.Clear();

            Management();

            void Management()
            {
                bool exit = false;
                while (!exit)
                {
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
                    Console.WriteLine($"| {"[0] Thoát",-48} |");
                    Console.WriteLine($"+{new string('-', 50)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            GroupProductManagement();
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
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\n\u274C Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }
            }

            //GroupProductManagement
            void GroupProductManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine($"+{new string('-', 43)}+");
                    Console.WriteLine($"| {"",5}{"Quản lý danh mục nhóm sản phẩm",-36} |");
                    Console.WriteLine($"+{new string('-', 43)}+");
                    Console.WriteLine($"| {"",13}{"Menu chức năng",-28} |");
                    Console.WriteLine($"+{new string('-', 43)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách nhóm sản phẩm",-41} |");
                    Console.WriteLine($"| {"[2] Thêm nhóm sản phẩm",-41} |");
                    Console.WriteLine($"| {"[3] Cập nhật nhóm sản phẩm",-41} |");
                    Console.WriteLine($"| {"[4] Xóa nhóm sản phẩm",-41} |");
                    Console.WriteLine($"| {"[5] Tìm nhóm sản phẩm theo mã",-41} |");
                    Console.WriteLine($"| {"[6] Tìm nhóm sản phẩm theo từ khóa",-41} |");
                    Console.WriteLine($"| [7] Xem danh sách sản phẩm trong một nhóm |");
                    Console.WriteLine($"| {"[0] Thoát",-41} |");
                    Console.WriteLine($"+{new string('-', 43)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DisplayAllGroupProduct();
                            break;
                        case "2":
                            AddGroupProduct();
                            break;
                        case "3":
                            UpdateGroupProduct();
                            break;
                        case "4":
                            DeleteGroupProduct();
                            break;
                        case "5":
                            SearchByIdGroupProduct();
                            break;
                        case "6":
                            SearchByKeyWordGroupProduct();
                            break;
                        case "7":
                            DisplayProductsInGroupProduct();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\n\u274C Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                //AddGroupProduct
                void AddGroupProduct()
                {
                    string id = repoGroupProduct.List.Count == 0 ? "GP00001" : "GP" + (int.Parse(repoGroupProduct.List[repoGroupProduct.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    Console.Write("Nhập tên nhóm sản phẩm: ");
                    string name = Console.ReadLine();

                    Console.Write("Nhập mô tả nhóm sản phẩm: ");
                    string description = Console.ReadLine();

                    Console.Write("Nhập mã nhân viên phụ trách nhóm sản phẩm này: ");
                    string employeeId = Console.ReadLine();

                    repoGroupProduct.Add(new GroupProduct(id, name, description, employeeId));
                }


                //UpdateGroupProduct
                void UpdateGroupProduct()
                {
                    Console.Write("Nhập mã nhóm sản phẩm cần cập nhật: ");
                    string id = Console.ReadLine();

                    GroupProduct groupProduct = repoGroupProduct.SearchById(id);

                    if (groupProduct != null)
                    {
                        Console.Write("Nhập tên mới của nhóm sản phẩm: ");
                        groupProduct.GroupProductName = Console.ReadLine();

                        Console.Write("Nhập mô tả mới của nhóm sản phẩm: ");
                        groupProduct.GroupProductDescription = Console.ReadLine();

                        Console.Write("Nhập mã nhân viên mới phụ trách nhóm sản phẩm này: ");
                        groupProduct.EmployeeId = Console.ReadLine();

                        repoGroupProduct.Update(id, groupProduct);
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không thể cập nhật. Không tồn tại mã: {id}.");
                    }
                }


                //DeleteGroupProduct
                void DeleteGroupProduct()
                {
                    Console.Write("Nhập mã nhóm sản phẩm cần xóa: ");
                    string id = Console.ReadLine();

                    repoGroupProduct.Delete(id);
                }

                //SearchByIdGroupProduct
                void SearchByIdGroupProduct()
                {
                    Console.Write("Nhập mã nhóm sản phẩm cần tìm: ");
                    string id = Console.ReadLine();

                    GroupProduct groupProduct = repoGroupProduct.SearchById(id);
                    if (groupProduct != null)
                    {
                        Console.WriteLine($"+{new string('-', 80)}+");
                        Console.WriteLine($"|{"",29}{"Kết quả tìm nhóm theo mã",-51}|");
                        Console.WriteLine($"+{new string('-', 9)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 14)}+");
                        Console.WriteLine($"| {"Mã nhóm",-7} | {"",9}{"Tên",-11} | {"",13}{"Mô tả",-17} | {"Mã nhân viên",-12} |");
                        Console.WriteLine($"+{new string('-', 9)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 14)}+");
                        groupProduct.Display();
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm nhóm sản phẩm có mã {id}");
                    }
                }

                //SearchByKeyWordGroupProduct
                void SearchByKeyWordGroupProduct()
                {
                    Console.Write("Nhập từ khóa cần tìm: ");
                    string keyWord = Console.ReadLine();
                    
                    List<GroupProduct> groupProducts = repoGroupProduct.SearchByKeyWord(keyWord);
                    if (groupProducts.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 80)}+");
                        Console.WriteLine($"|{"",27}{"Kết quả tìm nhóm theo từ khóa",-53}|");
                        Console.WriteLine($"+{new string('-', 9)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 14)}+");
                        Console.WriteLine($"| {"Mã nhóm",-7} | {"",9}{"Tên",-11} | {"",13}{"Mô tả",-17} | {"Mã nhân viên",-12} |");
                        Console.WriteLine($"+{new string('-', 9)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 14)}+");
                        groupProducts.ForEach(groupProduct => groupProduct.Display());
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy đối tượng có từ khóa: {keyWord}");
                    }
                }

                //DisplayAllGroupProduct
                void DisplayAllGroupProduct()
                {
                    if (repoGroupProduct.List.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 103)}+");
                        Console.WriteLine($"|{"",40}{"Danh sách nhóm sản phẩm",-63}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+{new string('-', 14)}+");
                        Console.WriteLine($"|{"",5}{"Mã",-6} | {"",9}{"Tên",-11} | {"",23}{"Mô tả",-27} | {"Mã nhân viên",-12} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+{new string('-', 14)}+");
                        repoGroupProduct.DisplayAll();
                    }
                    else
                    {
                        Console.WriteLine("\nDanh sách rỗng.");
                    }
                }

                //DisplayProductsInGroupProduct
                void DisplayProductsInGroupProduct()
                {
                    Console.Write("Nhập mã nhóm cần xem các sản phẩm: ");
                    string id = Console.ReadLine();
                    
                    if (repoGroupProduct.SearchById(id) != null)
                    {
                        List<Fertilizer> fertilizers = repoFertilizer.List.FindAll(item => item.GroupProductId == id.ToUpper());

                        if (fertilizers.Count > 0)
                        {
                            Console.WriteLine($"+{new string('-', 199)}+");
                            Console.WriteLine($"|{"",78}{"Danh sách sản phẩm thuộc nhóm có mã " + id.ToUpper(),-121}|");
                            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
                            Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"",4}{"Giá",-6} | {"",1}{"Số lượng",-9} | {"",23}{"Mô tả",-27} | {"",4}{"Kiểu đóng gói",-17} | Ngày sản xuất | Ngày hết hạn | {"",1}{"Mã nhóm",-9} | Mã thương hiệu |");
                            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
                            fertilizers.ForEach(fertilizer => fertilizer.Display());
                        }
                        else
                        {
                            Console.WriteLine($"Nhóm sản phẩm có mã {id} không chứa sản phẩm nào.");
                        }
                    } else
                    {
                        Console.WriteLine($"Nhóm sản phẩm có mã {id} không tồn tại.");
                    }
                }
            }

            //ProductManagement
            void ProductManagement() 
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine($"+{new string('-', 49)}+");
                    Console.WriteLine($"| {"",10}{"Quản lý danh mục sản phẩm",-37} |");
                    Console.WriteLine($"+{new string('-', 49)}+");
                    Console.WriteLine($"| {"",15}{"Menu chức năng",-32} |");
                    Console.WriteLine($"+{new string('-', 49)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách sản phẩm",-47} |");
                    Console.WriteLine($"| {"[2] Thêm sản phẩm",-47} |");
                    Console.WriteLine($"| {"[3] Cập nhật sản phẩm",-47} |");
                    Console.WriteLine($"| {"[4] Xóa sản phẩm",-47} |");
                    Console.WriteLine($"| {"[5] Tìm sản phẩm theo mã",-47} |");
                    Console.WriteLine($"| {"[6] Tìm sản phẩm theo từ khóa",-47} |");
                    Console.WriteLine($"| {"[7] Thêm công dụng cho sản phẩm",-47} |");
                    Console.WriteLine($"| {"[8] Thêm thành phần cho sản phẩm",-47} |");
                    Console.WriteLine($"| {"[9] Xem danh sách thành phần trong một sản phẩm",-47} |");
                    Console.WriteLine($"| {"[10] Xem danh sách công dụng của một sản phẩm",-47} |");
                    Console.WriteLine($"| {"[0] Thoát",-47} |");
                    Console.WriteLine($"+{new string('-', 49)}+");
                    Console.Write("Vui lòng nhập số tương ứng với một trong các tùy chọn trên: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            DisplayAllFertilizer();
                            break;
                        case "2":
                            AddFertilizer();
                            break;
                        case "3":
                            UpdateFertilizer();
                            break;
                        case "4":
                            DeleteFertilizer();
                            break;
                        case "5":
                            SearchByIdFertilizer();
                            break;
                        case "6":
                            SearchByKeyWordFertilizer();
                            break;
                        case "7":
                            AddProductUse();
                            break;
                        case "8":
                            AddProductComponent();
                            break;
                        case "9":
                            DisplayComponentInProduct();
                            break;
                        case "10":
                            DisplayUseOfProduct();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\n\u274C Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }
                //AddFertilizer
                void AddFertilizer()
                {
                    string id = repoFertilizer.List.Count == 0 ? "P00001" : "P" + (int.Parse(repoFertilizer.List[repoFertilizer.List.Count - 1].Id.Substring(1)) + 1).ToString().PadLeft(5, '0');

                    Console.Write("Nhập tên sản phẩm: ");
                    string name = Console.ReadLine();

                    Console.Write("Nhập giá sản phẩm: ");
                    float price = float.Parse(Console.ReadLine());

                    Console.Write("Nhập số lượng sản phẩm: ");
                    int quantity = int.Parse(Console.ReadLine());

                    Console.Write("Nhập mô tả sản phẩm: ");
                    string description = Console.ReadLine();

                    Console.Write("Nhập kiểu đóng gói sản phẩm: ");
                    string packagingType = Console.ReadLine();

                    Console.Write("Nhập ngày sản xuất của sản phẩm: ");
                    DateTime manufacturingDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                    Console.Write("Nhập ngày hết hạn của sản phẩm: ");
                    DateTime expiryDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                    Console.Write("Nhập mã thương hiệu của sản phẩm: ");
                    string brandId = Console.ReadLine();

                    Console.Write("Nhập mã nhóm của sản phẩm: ");
                    string groupProductId = Console.ReadLine();

                    repoFertilizer.Add(new Fertilizer(id, name, price, quantity, description, packagingType, manufacturingDate, expiryDate, brandId.ToUpper(), groupProductId.ToUpper()));
                }


                //UpdateFertilizer
                void UpdateFertilizer()
                {
                    Console.Write("Nhập mã sản phẩm cần cập nhật: ");
                    string id = Console.ReadLine();

                    Fertilizer fertilizer = repoFertilizer.SearchById(id);

                    if (fertilizer != null)
                    {
                        Console.Write("Nhập tên mới cho sản phẩm: ");
                        string name = Console.ReadLine();
                        fertilizer.ProductName = name;

                        Console.Write("Nhập giá mới cho sản phẩm: ");
                        float price = float.Parse(Console.ReadLine());
                        fertilizer.ProductPrice = price;

                        Console.Write("Nhập số lượng mới cho sản phẩm: ");
                        int quantity = int.Parse(Console.ReadLine());
                        fertilizer.ProductQuantity = quantity;

                        Console.Write("Nhập mô tả mới cho sản phẩm: ");
                        string description = Console.ReadLine();
                        fertilizer.ProductDescription = description;

                        Console.Write("Nhập kiểu đóng gói mới cho sản phẩm: ");
                        string packagingType = Console.ReadLine();
                        fertilizer.FertilizerPackagingType = packagingType;

                        Console.Write("Nhập ngày sản xuất mới cho sản phẩm (dd/MM/yyyy): ");
                        DateTime manufacturingDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        fertilizer.FertilizerManufacturingDate = manufacturingDate;

                        Console.Write("Nhập ngày hết hạn mới cho sản phẩm (dd/MM/yyyy): ");
                        DateTime expiryDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        fertilizer.FertilizerExpiryDate = expiryDate;

                        Console.Write("Nhập mã thương hiệu mới cho sản phẩm: ");
                        string brandId = Console.ReadLine();
                        fertilizer.BrandId = brandId.ToUpper();

                        Console.Write("Nhập mã nhóm mới cho sản phẩm: ");
                        string groupProductId = Console.ReadLine();
                        fertilizer.GroupProductId = groupProductId.ToUpper();

                        repoFertilizer.Update(id, fertilizer);
                    }
                    else
                    {
                        Console.WriteLine($"Không thể cập nhật. Không tồn tại mã sản phẩm: {id}.");
                    }
                }

                //DeleteFertilizer
                void DeleteFertilizer()
                {
                    Console.Write("Nhập mã sản phẩm cần xóa: ");
                    string id = Console.ReadLine();

                    repoFertilizer.Delete(id);
                }

                //SearchByIdFertilizer
                void SearchByIdFertilizer()
                {
                    Console.Write("Nhập mã sản phẩm cần tìm: ");
                    string id = Console.ReadLine();

                    Fertilizer fertilizer = repoFertilizer.SearchById(id);
                    if (fertilizer != null)
                    {
                        Console.WriteLine($"+{new string('-', 199)}+");
                        Console.WriteLine($"|{"",90}{"Kết quả tìm sản phầm theo mã",-109}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
                        Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"",4}{"Giá",-6} | {"",1}{"Số lượng",-9} | {"",23}{"Mô tả",-27} | {"",4}{"Kiểu đóng gói",-17} | Ngày sản xuất | Ngày hết hạn | {"",1}{"Mã nhóm",-9} | Mã thương hiệu |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
                        fertilizer.Display();
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy mã sản phẩm: {id}");
                    }
                }

                //SearchByKeyWordFertilizer
                void SearchByKeyWordFertilizer()
                {
                    Console.Write("Nhập từ khóa cần tìm: ");
                    string keyWord = Console.ReadLine();

                    List<Fertilizer> fertilizers = repoFertilizer.SearchByKeyWord(keyWord);
                    if (fertilizers.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 199)}+");
                        Console.WriteLine($"|{"",90}{"Kết quả tìm sản phẩm theo từ khóa",-109}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
                        Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"",4}{"Giá",-6} | {"",1}{"Số lượng",-9} | {"",23}{"Mô tả",-27} | {"",4}{"Kiểu đóng gói",-17} | Ngày sản xuất | Ngày hết hạn | {"",1}{"Mã nhóm",-9} | Mã thương hiệu |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
                        fertilizers.ForEach(fertilizer => fertilizer.Display());
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy từ khóa: {keyWord}");
                    }
                }

                //AddProductComponent
                void AddProductComponent()
                {
                    string id = repoProductComponent.List.Count == 0 ? "PC00001" : "PC" + (int.Parse(repoProductComponent.List[repoProductComponent.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    Console.Write("Nhập mã sản phẩm: ");
                    string productId = Console.ReadLine();

                    Console.Write("Nhập mã thành phần: ");
                    string componentId = Console.ReadLine();

                    repoProductComponent.Add(new ProductComponent(id, productId.ToUpper(), componentId.ToUpper()));
                }


                //AddProductUse
                void AddProductUse()
                {
                    string id = repoProductUse.List.Count == 0 ? "PU00001" : "PU" + (int.Parse(repoProductUse.List[repoProductUse.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    Console.Write("Nhập mã sản phẩm: ");
                    string productId = Console.ReadLine();

                    Console.Write("Nhập mã công dụng: ");
                    string useId = Console.ReadLine();

                    repoProductUse.Add(new ProductUse(id, productId.ToUpper(), useId.ToUpper()));
                }

                //DisplayAllFertilizer
                void DisplayAllFertilizer()
                {
                    if (repoFertilizer.List.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 199)}+");
                        Console.WriteLine($"|{"",90}{"Danh sách sản phẩm",-109}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
                        Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"",4}{"Giá",-6} | {"",1}{"Số lượng",-9} | {"",23}{"Mô tả",-27} | {"",4}{"Kiểu đóng gói",-17} | Ngày sản xuất | Ngày hết hạn | {"",1}{"Mã nhóm",-9} | Mã thương hiệu |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
                        repoFertilizer.DisplayAll();
                    }
                    else
                    {
                        Console.WriteLine("\nDanh sách rỗng.");
                    }
                }

                // DisplayComponentInProduct
                void DisplayComponentInProduct() 
                {
                    Console.Write("Nhập mã sản phẩm cần xem thành phần: ");
                    string id = Console.ReadLine();

                    List<Component> components = repoProductComponent.List
                    .Where(pc => pc.ProductId == id.ToUpper()) 
                    .Join(repoComponent.List, 
                        pc => pc.ComponentId,
                        c => c.Id, 
                        (pc, c) => c)
                    .ToList();

                    if (components.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 101)}+");
                        Console.WriteLine($"|{"",25}{"Danh sách thành phần trong sản phẩm có mã " + id.ToUpper(),-76}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 52)}+");
                        Console.WriteLine($"|{"",5}{"Mã",-6} | {"",9}{"Tên",-11} | {"",0}{"Tỉ lệ (%)",-10} | {"",20}{"Mô tả",-30} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 52)}+");
                        components.ForEach(component => component.Display());
                    }
                    else
                    {
                        Console.WriteLine("Sản phẩm chưa có thành phần nào.");
                    }
                }

                // DisplayUseOfProduct
                void DisplayUseOfProduct() 
                {
                    Console.Write("Nhập mã sản phẩm cần xem thành phần: ");
                    string id = Console.ReadLine();

                    List<Use> uses = repoProductUse.List
                    .Where(pc => pc.ProductId == id.ToUpper()) 
                    .Join(repoUse.List, 
                        pc => pc.UseId,
                        c => c.Id, 
                        (pc, c) => c)
                    .ToList();

                    if (uses.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 88)}+");
                        Console.WriteLine($"|{"",22}{"Danh sách công dụng của sản phẩm có mã " + id.ToUpper(),-66}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+");
                        Console.WriteLine($"|{"",5}{"Mã",-6} | {"",9}{"Tên",-11} | {"",20}{"Mô tả",-30} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+");
                        uses.ForEach(use => use.Display());
                    }
                    else
                    {
                        Console.WriteLine("Sản phẩm chưa có công dụng nào.");
                    }
                }
            }

            //ComponentManagement
            void ComponentManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine($"+{new string('-', 33)}+");
                    Console.WriteLine($"| {"",2}{"Quản lý danh mục thành phần",-29} |");
                    Console.WriteLine($"+{new string('-', 33)}+");
                    Console.WriteLine($"| {"",8}{"Menu chức năng",-23} |");
                    Console.WriteLine($"+{new string('-', 33)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách thành phần",-31} |");
                    Console.WriteLine($"| {"[2] Thêm thành phần",-31} |");
                    Console.WriteLine($"| {"[3] Cập nhật thành phần",-31} |");
                    Console.WriteLine($"| {"[4] Xóa thành phần",-31} |");
                    Console.WriteLine($"| {"[5] Tìm thành phần theo mã",-31} |");
                    Console.WriteLine($"| {"[6] Tìm thành phần theo từ khóa",-31} |");
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
                            AddComponent();
                            break;
                        case "3":
                            UpdateComponent();
                            break;
                        case "4":
                            DeleteComponent();
                            break;
                        case "5":
                            SearchByIdComponent();
                            break;
                        case "6":
                            SearchByKeyWordComponent();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\n\u274C Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                //AddComponent
                void AddComponent()
                {
                    string id = repoComponent.List.Count == 0 ? "C00001" : "C" + (int.Parse(repoComponent.List[repoComponent.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    Console.Write("Nhập tên thành phần: ");
                    string name = Console.ReadLine();

                    Console.Write("Nhập tỉ lệ thành phần (%): ");
                    float percentage = float.Parse(Console.ReadLine());

                    Console.Write("Nhập mô tả thành phần: ");
                    string description = Console.ReadLine();

                    repoComponent.Add(new Component(id, name, percentage, description));
                }

                //UpdateComponent
                void UpdateComponent()
                {
                    Console.Write("Nhập mã thành phần cần cập nhật: ");
                    string id = Console.ReadLine();

                    Component component = repoComponent.SearchById(id);

                    if (component != null)
                    {
                        Console.Write("Nhập tên mới cho thành phần: ");
                        component.ComponentName = Console.ReadLine();

                        Console.Write("Nhập tỉ lệ mới cho thành phần (%): ");
                        component.ComponentPercentage = float.Parse(Console.ReadLine());

                        Console.Write("Nhập mô tả thành phần: ");
                        component.ComponentDescription = Console.ReadLine();

                        repoComponent.Update(id, component);
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không thể cập nhật. Không tồn tại mã: {id}.");
                    }
                }

                //DeleteComponent
                void DeleteComponent()
                {
                    Console.Write("Nhập mã thành phần cần xóa: ");
                    string id = Console.ReadLine();
                    
                    repoComponent.Delete(id);
                }

                //SearchByIdComponent
                void SearchByIdComponent()
                {
                    Console.Write("Nhập mã thành phần cần tìm: ");
                    string id = Console.ReadLine();

                    Component component = repoComponent.SearchById(id);
                    if (component != null)
                    {
                            
                        Console.WriteLine($"+{new string('-', 101)}+");
                        Console.WriteLine($"|{"",36}{"Kết quả tìm thành phần theo mã",-65}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 52)}+");
                        Console.WriteLine($"|{"",5}{"Mã",-6} | {"",9}{"Tên",-11} | {"",0}{"Tỉ lệ (%)",-10} | {"",20}{"Mô tả",-30} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 52)}+");
                        component.Display();
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy mã thành phần: {id}");
                    }
                }

                //SearchByKeyWordComponent
                void SearchByKeyWordComponent()
                {
                    Console.Write("Nhập từ khóa cần tìm: ");
                    string keyWord = Console.ReadLine();

                    List<Component> components = repoComponent.SearchByKeyWord(keyWord);
                    if (components.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 101)}+");
                        Console.WriteLine($"|{"",35}{"Kết quả tìm thành phần theo từ khóa",-66}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 52)}+");
                        Console.WriteLine($"|{"",5}{"Mã",-6} | {"",9}{"Tên",-11} | {"",0}{"Tỉ lệ (%)",-10} | {"",20}{"Mô tả",-30} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 52)}+");
                        components.ForEach(component => component.Display());
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy từ khóa: {keyWord}");
                    }
                }

                //DisplayAllComponent
                void DisplayAllComponent()
                {
                    if (repoComponent.List.Count > 0)
                    {
                        Console.WriteLine($"+{new string('-', 101)}+");
                        Console.WriteLine($"|{"",40}{"Danh sách thành phần",-61}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 52)}+");
                        Console.WriteLine($"|{"",5}{"Mã",-6} | {"",9}{"Tên",-11} | {"",0}{"Tỉ lệ (%)",-10} | {"",20}{"Mô tả",-30} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 52)}+");
                        repoComponent.DisplayAll();
                    } else
                    {
                        Console.WriteLine("\nDanh sách rỗng.");
                    }
                }
            }

            //UseManagement
            void UseManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine($"+{new string('-', 32)}+");
                    Console.WriteLine($"| {"",2}{"Quản lý danh mục công dụng",-28} |");
                    Console.WriteLine($"+{new string('-', 32)}+");
                    Console.WriteLine($"| {"",7}{"Menu chức năng",-23} |");
                    Console.WriteLine($"+{new string('-', 32)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách công dụng",-30} |");
                    Console.WriteLine($"| {"[2] Thêm công dụng",-30} |");
                    Console.WriteLine($"| {"[3] Cập nhật công dụng",-30} |");
                    Console.WriteLine($"| {"[4] Xóa công dụng",-30} |");
                    Console.WriteLine($"| {"[5] Tìm công dụng theo mã",-30} |");
                    Console.WriteLine($"| {"[6] Tìm công dụng theo từ khóa",-30} |");
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
                            AddUse();
                            break;
                        case "3":
                            UpdateUse();
                            break;
                        case "4":
                            DeleteUse();
                            break;
                        case "5":
                            SearchByIdUse();
                            break;
                        case "6":
                            SearchByKeyWordUse();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\n\u274C Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                //AddUse
                void AddUse()
                {
                    string id = repoUse.List.Count == 0 ? "U00001" : "U" + (int.Parse(repoUse.List[repoUse.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    Console.Write("Nhập tên công dụng: ");
                    string name = Console.ReadLine();

                    Console.Write("Nhập mô tả công dụng: ");
                    string description = Console.ReadLine();

                    repoUse.Add(new Use(id, name, description));
                }

                //UpdateUse
                void UpdateUse()
                {
                    Console.Write("Nhập mã công dụng cần cập nhật: ");
                    string id = Console.ReadLine();

                    Use use = repoUse.SearchById(id);

                    if (use != null)
                    {
                        Console.Write("Nhập tên mới cho công dụng: ");
                        use.UseName = Console.ReadLine();

                        Console.Write("Nhập mô tả mới cho công dụng: ");
                        use.UseDescription = Console.ReadLine();

                        repoUse.Update(id, use);
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không thể cập nhật. Không tồn tại mã: {id}.");
                    }
                }

                //DeleteUse
                void DeleteUse()
                {
                    Console.Write("Nhập mã công dụng cần xóa: ");
                    string id = Console.ReadLine();

                    repoUse.Delete(id);
                }

                //SearchByIdUse
                void SearchByIdUse()
                {
                    Console.Write("Nhập mã công dụng cần tìm: ");
                    string id = Console.ReadLine();

                    Use use = repoUse.SearchById(id);
                    if (use != null)
                    {
                        Console.WriteLine($"+{new string('-', 88)}+");
                        Console.WriteLine($"|{"",30}{"Kết quả tìm công dụng theo mã",-58}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+");
                        Console.WriteLine($"|{"",5}{"Mã",-6} | {"",9}{"Tên",-11} | {"",20}{"Mô tả",-30} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+");
                        use.Display();
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy mã công dụng: {id}");
                    }
                }

                //SearchByKeyWordUse
                void SearchByKeyWordUse()
                {
                    Console.Write("Nhập từ khóa cần tìm: ");
                    string keyWord = Console.ReadLine();

                    List<Use> uses = repoUse.SearchByKeyWord(keyWord);
                    if (uses.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 88)}+");
                        Console.WriteLine($"|{"",27}{"Kết quả tìm công dụng theo từ khóa",-61}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+");
                        Console.WriteLine($"|{"",5}{"Mã",-6} | {"",9}{"Tên",-11} | {"",20}{"Mô tả",-30} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+");
                        uses.ForEach(use => use.Display());
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy từ khóa: {keyWord}");
                    }
                }

                //DisplayAllUse
                void DisplayAllUse()
                {
                    if (repoUse.List.Count > 0)
                    {
                        Console.WriteLine($"+{new string('-', 88)}+");
                        Console.WriteLine($"|{"",35}{"Danh sách công dụng",-53}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+");
                        Console.WriteLine($"|{"",5}{"Mã",-6} | {"",9}{"Tên",-11} | {"",20}{"Mô tả",-30} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+");
                        repoUse.DisplayAll();
                    }
                    else
                    {
                        Console.WriteLine("\nDanh sách rỗng.");
                    }
                }
            }
            
            //BrandManagement
            void BrandManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine($"+{new string('-', 48)}+");
                    Console.WriteLine($"| {"",8}{"Quản lý danh mục thương hiệu",-38} |");
                    Console.WriteLine($"+{new string('-', 48)}+");
                    Console.WriteLine($"| {"",15}{"Menu chức năng",-31} |");
                    Console.WriteLine($"+{new string('-', 48)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách thương hiệu",-46} |");
                    Console.WriteLine($"| {"[2] Thêm thương hiệu",-46} |");
                    Console.WriteLine($"| {"[3] Cập nhật thương hiệu",-46} |");
                    Console.WriteLine($"| {"[4] Xóa thương hiệu",-46} |");
                    Console.WriteLine($"| {"[5] Tìm thương hiệu theo mã",-46} |");
                    Console.WriteLine($"| {"[6] Tìm thương hiệu theo từ khóa",-46} |");
                    Console.WriteLine($"| [7] Xem danh sách sản phẩm của một thương hiệu |");
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
                            AddBrand();
                            break;
                        case "3":
                            UpdateBrand();
                            break;
                        case "4":
                            DeleteBrand();
                            break;
                        case "5":
                            SearchByIdBrand();
                            break;
                        case "6":
                            SearchByKeyWordBrand();
                            break;
                        case "7":
                            DisplayProductsOfBrand();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\n\u274C Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                // AddBrand
                void AddBrand()
                {
                    string id = repoBrand.List.Count == 0 ? "B00001" : "B" + (int.Parse(repoBrand.List[repoBrand.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    Console.Write("Nhập tên thương hiệu: ");
                    string name = Console.ReadLine();

                    Console.Write("Nhập email thương hiệu: ");
                    string email = Console.ReadLine();

                    Console.Write("Nhập số điện thoại thương hiệu: ");
                    string phoneNumber = Console.ReadLine();

                    Console.Write("Nhập địa chỉ thương hiệu: ");
                    string address = Console.ReadLine();

                    Console.Write("Nhập quốc gia thương hiệu: ");
                    string country = Console.ReadLine();

                    repoBrand.Add(new Brand(id, name, email, phoneNumber, address, country));
                }

                // UpdateBrand
                void UpdateBrand()
                {
                    Console.Write("Nhập mã thương hiệu cần cập nhật: ");
                    string id = Console.ReadLine();

                    Brand brand = repoBrand.SearchById(id);

                    if (brand != null)
                    {
                        Console.Write("Nhập tên mới cho thương hiệu: ");
                        brand.BrandName = Console.ReadLine();

                        Console.Write("Nhập email mới cho thương hiệu: ");
                        brand.BrandEmail = Console.ReadLine();

                        Console.Write("Nhập số điện thoại mới cho thương hiệu: ");
                        brand.BrandPhoneNumber = Console.ReadLine();

                        Console.Write("Nhập địa chỉ mới cho thương hiệu: ");
                        brand.BrandAddress = Console.ReadLine();

                        Console.Write("Nhập quốc gia mới cho thương hiệu: ");
                        brand.BrandCountry = Console.ReadLine();

                        repoBrand.Update(id, brand);
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không thể cập nhật. Không tồn tại mã: {id}.");
                    }
                }


                // DeleteBrand
                void DeleteBrand () 
                {
                    Console.Write("Nhập mã thương hiệu cần xóa: ");
                    string id = Console.ReadLine();

                    repoEmployee.Delete(id);
                }

                // SearchByIdBrand
                void SearchByIdBrand () 
                {
                    Console.Write("Nhập mã thương hiệu cần tìm: ");
                    string id = Console.ReadLine();

                    Brand brand = repoBrand.SearchById(id);
                    if (brand != null)
                    {
                        Console.WriteLine($"+{new string('-', 140)}+");
                        Console.WriteLine($"|{"",55}{"Kết quả tìm thương hiệu theo mã",-85}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"",12}{"Email",-18} | {"Số điện thoại",-12} | {"",11}{"Địa chỉ",-19} | {"",2}{"Quốc gia",-18} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        brand.Display();
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy mã thương hiệu: {id}");
                    }
                }

                // SearchByKeyWordBrand
                void SearchByKeyWordBrand () 
                {
                    Console.Write("Nhập từ khóa cần tìm: ");
                    string keyWord = Console.ReadLine();

                    List<Brand> brands = repoBrand.SearchByKeyWord(keyWord);
                    if (brands.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 140)}+");
                        Console.WriteLine($"|{"",53}{"Kết quả tìm thương hiệu theo từ khóa",-87}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"",12}{"Email",-18} | {"Số điện thoại",-12} | {"",11}{"Địa chỉ",-19} | {"",2}{"Quốc gia",-18} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        brands.ForEach(brand => brand.Display());
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy từ khóa: {keyWord}");
                    }
                }

                // DisplayAllBrand
                void DisplayAllBrand () 
                {
                    if (repoBrand.List.Count > 0) 
                    {
                        Console.WriteLine($"+{new string('-', 140)}+");
                        Console.WriteLine($"|{"",60}{"Danh sách thương hiệu",-80}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"",12}{"Email",-18} | {"Số điện thoại",-12} | {"",11}{"Địa chỉ",-19} | {"",2}{"Quốc gia",-18} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 32)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        repoBrand.DisplayAll();
                    } else {
                          Console.WriteLine("\nDanh sách rỗng.");
                    }
                }

                // DisplayProductsOfBrand
                void DisplayProductsOfBrand () 
                {
                   Console.Write("Nhập mã thương hiệu cần xem các sản phẩm: ");
                    string id = Console.ReadLine();

                    if (repoBrand.SearchById(id) != null)
                    {
                        List<Fertilizer> fertilizers = repoFertilizer.List.FindAll(item => item.BrandId == id.ToUpper());

                        if (fertilizers.Count > 0)
                        {
                            Console.WriteLine($"+{new string('-', 199)}+");
                            Console.WriteLine($"|{"",74}{"Danh sách sản phẩm thuộc thương hiệu có mã " + id.ToUpper(),-125}|");
                            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
                            Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"",4}{"Giá",-6} | {"",1}{"Số lượng",-9} | {"",23}{"Mô tả",-27} | {"",4}{"Kiểu đóng gói",-17} | Ngày sản xuất | Ngày hết hạn | {"",1}{"Mã nhóm",-9} | Mã thương hiệu |");
                            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 12)}+{new string('-', 52)}+{new string('-', 23)}+{new string('-', 15)}+{new string('-', 14)}+{new string('-', 12)}+{new string('-', 16)}+");
                            fertilizers.ForEach(fertilizer => fertilizer.Display());
                        }
                        else
                        {
                            Console.WriteLine($"Thương hiệu có mã {id} không có sản phẩm nào.");
                        }
                    } else
                    {
                        Console.WriteLine($"Thương hiệu có mã {id} không tồn tại.");
                    }
                }

            }

            //EmployeeManagement
            void EmployeeManagement()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine($"+{new string('-', 61)}+");
                    Console.WriteLine($"| {"",16}{"Quản lý danh mục nhân viên",-43} |");
                    Console.WriteLine($"+{new string('-', 61)}+");
                    Console.WriteLine($"| {"",22}{"Menu chức năng",-37} |");
                    Console.WriteLine($"+{new string('-', 61)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách nhân viên",-59} |");
                    Console.WriteLine($"| {"[2] Thêm nhân viên",-59} |");
                    Console.WriteLine($"| {"[3] Cập nhật nhân viên",-59} |");
                    Console.WriteLine($"| {"[4] Xóa nhân viên",-59} |");
                    Console.WriteLine($"| {"[5] Tìm nhân viên theo mã",-59} |");
                    Console.WriteLine($"| {"[6] Tìm nhân viên theo từ khóa",-59} |");
                    Console.WriteLine($"| [7] Xem danh sách nhóm sản phẩm phụ trách bởi một nhân viên |");
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
                            AddEmployee();
                            break;
                        case "3":
                            UpdateEmployee();
                            break;
                        case "4":
                            DeleteEmployee();
                            break;
                        case "5":
                            SearchByIdEmployee();
                            break;
                        case "6":
                            SearchByKeyWordEmployee();
                            break;
                        case "7":
                            DisplayGroupProductsByEmployee();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\n\u274C Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }

                // AddEmployee
                void AddEmployee () 
                {
                    string id = repoEmployee.List.Count == 0 ? "E00001" : "E" + (int.Parse(repoEmployee.List[repoEmployee.List.Count - 1].Id.Substring(2)) + 1).ToString().PadLeft(5, '0');

                    Console.Write("Nhập tên: ");
                    string name = Console.ReadLine();

                    Console.Write("Nhập ngày sinh (yyyy-MM-dd): ");
                    DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

                    Console.Write("Nhập số điện thoại: ");
                    string phoneNumber = Console.ReadLine();

                    Console.Write("Nhập địa chỉ: ");
                    string address = Console.ReadLine();

                    Console.Write("Nhập vị trí công việc: ");
                    string position = Console.ReadLine();

                    repoEmployee.Add(new Employee(id, name, dateOfBirth, phoneNumber, address, position));
                }

                //UpdateEmployee
                void UpdateEmployee()
                {
                    Console.Write("Nhập mã nhân viên cần cập nhật: ");
                    string id = Console.ReadLine();

                    Employee employee = repoEmployee.SearchById(id);

                    if (employee != null)
                    {
                        Console.Write("Nhập tên mới: ");
                        employee.EmployeeName = Console.ReadLine();

                        Console.Write("Nhập ngày sinh mới (dd/mm/yyyy): ");
                        employee.EmployeeDateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                        Console.Write("Nhập số điện thoại mới: ");
                        employee.EmployeePhoneNumber = Console.ReadLine();

                        Console.Write("Nhập địa chỉ mới: ");
                        employee.EmployeeAddress = Console.ReadLine();

                        Console.Write("Nhập vị trí công việc mới: ");
                        employee.EmployeePosition = Console.ReadLine();

                        repoEmployee.Update(id, employee);
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không thể cập nhật. Không tồn tại mã: {id}.");
                    }
                }

                // DeleteEmployee
                void DeleteEmployee () 
                {
                    Console.Write("Nhập mã nhân viên cần xóa: ");
                    string id = Console.ReadLine();

                    repoEmployee.Delete(id);
                }

                // SearchByIdEmployee
                void SearchByIdEmployee () 
                {
                    Console.Write("Nhập mã nhân viên cần tìm: ");
                    string id = Console.ReadLine();

                    Employee employee = repoEmployee.SearchById(id);
                    if (employee != null)
                    {
                        Console.WriteLine($"+{new string('-', 120)}+");
                        Console.WriteLine($"|{"",46}{"Kết quả tìm nhân viên theo mã",-74}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"Ngày sinh",-10} | {"Số điện thoại",-12} | {"",11}{"Địa chỉ",-19} | {"",2}{"Vị trí việc làm",-18} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        employee.Display();
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy mã nhân viên: {id}");
                    }
                }
                
                // SearchByKeyWordEmployee
                void SearchByKeyWordEmployee () 
                {
                    Console.Write("Nhập từ khóa cần tìm: ");
                    string keyWord = Console.ReadLine();

                    List<Employee> employees = repoEmployee.SearchByKeyWord(keyWord);
                    if (employees.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 120)}+");
                        Console.WriteLine($"|{"",43}{"Kết quả tìm nhân viên theo từ khóa",-77}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"Ngày sinh",-10} | {"Số điện thoại",-12} | {"",11}{"Địa chỉ",-19} | {"",2}{"Vị trí việc làm",-18} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        employees.ForEach(employee => employee.Display());
                    }
                    else
                    {
                        Console.WriteLine($"\u274C Không tìm thấy từ khóa: {keyWord}");
                    }
                }
                
                // DisplayAllEmployee
                void DisplayAllEmployee () 
                {
                    if (repoEmployee.List.Count != 0)
                    {
                        Console.WriteLine($"+{new string('-', 120)}+");
                        Console.WriteLine($"|{"",52}{"Danh sách nhân viên",-68}|");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        Console.WriteLine($"| {"",4}{"Mã",-6} | {"",8}{"Tên",-12} | {"Ngày sinh",-10} | {"Số điện thoại",-12} | {"",11}{"Địa chỉ",-19} | {"",2}{"Vị trí việc làm",-18} |");
                        Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 12)}+{new string('-', 15)}+{new string('-', 32)}+{new string('-', 22)}+");
                        repoEmployee.DisplayAll();
                    }
                else
                {
                    Console.WriteLine("\nDanh sách rỗng.");
                }
                }
                
                // DisplayProductsOfEmployee
                void DisplayGroupProductsByEmployee () 
                {
                    Console.Write("Nhập mã nhân viên cần xem các nhóm sản phẩm đang phụ trách: ");
                    string id = Console.ReadLine();

                    if (repoEmployee.SearchById(id) != null)
                    {
                        List<GroupProduct> groupProducts = repoGroupProduct.List.FindAll(item => item.EmployeeId == id.ToUpper());

                        if (groupProducts.Count > 0)
                        {
                            Console.WriteLine($"+{new string('-', 103)}+");
                            Console.WriteLine($"|{"",26}{"Danh sách nhóm sản phẩm phụ trách bởi nhân viên có mã " + id.ToUpper(),-77}|");
                            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+{new string('-', 14)}+");
                            Console.WriteLine($"|{"",5}{"Mã",-6} | {"",9}{"Tên",-11} | {"",23}{"Mô tả",-27} | {"Mã nhân viên",-12} |");
                            Console.WriteLine($"+{new string('-', 12)}+{new string('-', 22)}+{new string('-', 52)}+{new string('-', 14)}+");
                            groupProducts.ForEach(groupProduct => groupProduct.Display());
                        }
                        else
                        {
                            Console.WriteLine($"Nhân viên sản phẩm có mã {id} chưa phụ trách sản phẩm nào.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Nhân viên có mã {id} không tồn tại.");
                    }
                }
                
            }
        }
    }
}
