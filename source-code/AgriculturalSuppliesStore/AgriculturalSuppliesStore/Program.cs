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

            // Thêm dữ liệu mẫu cho repoGroupProduct
            repoGroupProduct.Add(new GroupProduct("GP00001", "Phân bón hữu cơ", "Sản phẩm phân bón từ thiên nhiên", "E001"));
            repoGroupProduct.Add(new GroupProduct("GP00002", "Phân bón hóa học", "Phân bón cung cấp chất dinh dưỡng nhanh", "E002"));
            repoGroupProduct.Add(new GroupProduct("GP00003", "Thuốc trừ sâu", "Sản phẩm bảo vệ thực vật", "E003"));
            repoGroupProduct.Add(new GroupProduct("GP00004", "Hạt giống", "Cung cấp hạt giống chất lượng", "E004"));
            repoGroupProduct.Add(new GroupProduct("GP00005", "Công cụ làm vườn", "Các công cụ hỗ trợ làm vườn", "E005"));

            // Thêm dữ liệu mẫu cho repoFertilizer
            repoFertilizer.Add(new Fertilizer("F00001", "Phân hữu cơ xanh", 50000, 100, "Phân bón thân thiện môi trường", "Bao",
                new DateTime(2023, 1, 15), new DateTime(2025, 1, 15), "B001", "GP00001"));
            repoFertilizer.Add(new Fertilizer("F00002", "Phân NPK 16-16-8", 60000, 200, "Phân NPK hỗn hợp", "Túi",
                new DateTime(2023, 3, 10), new DateTime(2025, 3, 10), "B002", "GP00002"));
            repoFertilizer.Add(new Fertilizer("F00003", "Phân Kali", 70000, 150, "Phân Kali tăng cường sức đề kháng", "Bao",
                new DateTime(2023, 5, 20), new DateTime(2026, 5, 20), "B003", "GP00002"));
            repoFertilizer.Add(new Fertilizer("F00004", "Phân Ure", 80000, 120, "Phân Ure cung cấp đạm", "Túi",
                new DateTime(2023, 6, 25), new DateTime(2024, 6, 25), "B004", "GP00002"));
            repoFertilizer.Add(new Fertilizer("F00005", "Phân hữu cơ vi sinh", 90000, 80, "Phân hữu cơ cải tạo đất", "Thùng",
                new DateTime(2022, 11, 5), new DateTime(2024, 11, 5), "B005", "GP00001"));


            Management();

            void Management()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine($"+{new string('-', 50)}+");
                    Console.WriteLine("| Ứng dụng quản lý cửa hàng bán vật tư nông nghiệp |");
                    Console.WriteLine($"+{new string('-', 50)}+");
                    Console.WriteLine($"| {"",18}{"Menu quản lý",-30} |");
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

                            break;
                        case "6":

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
                    string id;
                    if (repoGroupProduct.List.Count == 0)
                    {
                        id = "GP00001";
                    }
                    else
                    {
                        string lastId = repoGroupProduct.List[repoGroupProduct.List.Count - 1].Id;
                        int idToNum = int.Parse(lastId.Substring(2)) + 1;
                        id = "GP" + idToNum.ToString().PadLeft(5, '0');
                    }

                    string name;
                    do
                    {
                        Console.Write("Nhập tên nhóm sản phẩm: ");
                        name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Tên nhóm không thể để trống. Vui lòng nhập lại.");
                        }
                    } while (string.IsNullOrWhiteSpace(name));

                    Console.Write("Nhập mô tả nhóm sản phẩm: ");
                    string description = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(description))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mô tả nhóm sản phẩm: Trống.");
                        description = "Trống";
                    }

                    string employeeId;
                    bool exitEmployeeId = false;
                    do
                    {
                        Console.Write("Nhập mã nhân viên phụ trách nhóm sản phẩm này: ");
                        employeeId = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(employeeId))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("Nhập mã nhân viên phụ trách nhóm sản phẩm này: Trống.");
                            employeeId = "Trống";
                            exitEmployeeId = true;
                        }
                        else
                        {
                            if (repoEmployee.SearchById(employeeId) == null)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("\u26A0 Mã nhân viên không tồn tại. Vui lòng nhập lại.");
                            } else
                            {
                                exitEmployeeId = true;
                            }
                        }
                    } while (!exitEmployeeId);

                    repoGroupProduct.Add(new GroupProduct(id, name, description, employeeId));
                }

                //UpdateGroupProduct
                void UpdateGroupProduct()
                {
                    Console.Write("Nhập mã nhóm sản phẩm cần cập nhật: ");
                    string id = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mã nhóm sản phẩm cần cập nhật: Trống.");
                    }
                    else
                    {
                        GroupProduct groupProduct = repoGroupProduct.SearchById(id);

                        if (groupProduct != null)
                        {
                            Console.Write("Nhập tên mới của nhóm sản phẩm: ");
                            string name = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập tên mới của nhóm sản phẩm: Trống.");
                            }
                            else
                            {
                                groupProduct.GroupProductName = name;
                            }

                            Console.Write("Nhập mô tả mới của nhóm sản phẩm: ");
                            string description = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(description))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập mô tả mới của nhóm sản phẩm: Trống.");
                            }
                            else
                            {
                                groupProduct.GroupProductDescription = description;
                            }

                            string employeeId;
                            bool exitEmployeeId = false;
                            do
                            {
                                Console.Write("Nhập mã nhân viên mới phụ trách nhóm sản phẩm này: ");
                                employeeId = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(employeeId))
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    Console.WriteLine("Nhập mã nhân viên mới phụ trách nhóm sản phẩm này: Trống.");
                                    employeeId = "Trống";
                                    exitEmployeeId = true;
                                }
                                else
                                {
                                    if (repoEmployee.SearchById(employeeId) == null)
                                    {
                                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                                        Console.WriteLine("\u26A0 Mã nhân viên không tồn tại. Vui lòng nhập lại.");
                                    }
                                    else
                                    {
                                        exitEmployeeId = true;
                                        groupProduct.EmployeeId = employeeId;
                                    }
                                }
                            } while (!exitEmployeeId);

                            repoGroupProduct.Update(id, groupProduct);
                        }
                        else
                        {
                            Console.WriteLine($"\u274C Không thể cập nhật. Không tồn tại mã: {id}.");
                        }
                    }
                }

                //DeleteGroupProduct
                void DeleteGroupProduct()
                {
                    Console.Write("Nhập mã nhóm sản phẩm cần xóa: ");
                    string id = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mã nhóm sản phẩm cần xóa: Trống.");
                    }
                    else
                    {
                        repoGroupProduct.Delete(id);
                    }
                }

                //SearchByIdGroupProduct
                void SearchByIdGroupProduct()
                {
                    Console.Write("Nhập mã nhóm sản phẩm cần tìm: ");
                    string id = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mã nhóm sản phẩm cần tìm: Trống.");
                    }
                    else
                    {
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
                }

                //SearchByKeyWordGroupProduct
                void SearchByKeyWordGroupProduct()
                {
                    Console.Write("Nhập từ khóa cần tìm: ");
                    string keyWord = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(keyWord))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập từ khóa cần tìm: Trống.");
                    }
                    else
                    {
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
                        Console.WriteLine("Danh sách rỗng.");
                    }
                }

                //DisplayProductsInGroupProduct
                void DisplayProductsInGroupProduct()
                {
                    Console.Write("Nhập mã nhóm cần xem các sản phẩm: ");
                    string id = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mã nhóm cần xem các sản phẩm: Trống.");
                    }
                    else
                    {
                        if (repoGroupProduct.SearchById(id) != null)
                        {
                            List<Fertilizer> fertilizers = repoFertilizer.List.FindAll(item => item.GroupProductId == id.ToUpper());

                            if (fertilizers.Count > 0)
                            {
                                Console.WriteLine($"+{new string('-', 199)}+");
                                Console.WriteLine($"|{"",78}{"Danh sách sản phẩm thuộc nhóm có mã " + id,-121}|");
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
            }

            //ProductManagement
            void ProductManagement() 
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine($"+{new string('-', 34)}+");
                    Console.WriteLine($"| {"",3}{"Quản lý danh mục sản phẩm",-29} |");
                    Console.WriteLine($"+{new string('-', 34)}+");
                    Console.WriteLine($"| {"",8}{"Menu chức năng",-24} |");
                    Console.WriteLine($"+{new string('-', 34)}+");
                    Console.WriteLine($"| {"[1] Xem danh sách sản phẩm",-32} |");
                    Console.WriteLine($"| {"[2] Thêm sản phẩm",-32} |");
                    Console.WriteLine($"| {"[3] Cập nhật sản phẩm",-32} |");
                    Console.WriteLine($"| {"[4] Xóa sản phẩm",-32} |");
                    Console.WriteLine($"| {"[5] Tìm sản phẩm theo mã",-32} |");
                    Console.WriteLine($"| {"[6] Tìm sản phẩm theo từ khóa",-32} |");
                    Console.WriteLine($"| {"[7] Thêm công dụng cho sản phẩm",-32} |");
                    Console.WriteLine($"| {"[8] Thêm thành phần cho sản phẩm",-32} |");
                    Console.WriteLine($"| {"[0] Thoát",-32} |");
                    Console.WriteLine($"+{new string('-', 34)}+");
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
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\n\u274C Lựa chọn không hợp lệ, vui lòng thử lại.");
                            break;
                    }
                }
            }

            //AddFertilizer
            void AddFertilizer()
            {
                string id;
                if (repoGroupProduct.List.Count == 0)
                {
                    id = "P00001";
                }
                else
                {
                    string lastId = repoGroupProduct.List[repoGroupProduct.List.Count - 1].Id;
                    int idToNum = int.Parse(lastId.Substring(2)) + 1;
                    id = "P" + idToNum.ToString().PadLeft(5, '0');
                }

                string name;
                do
                {
                    Console.Write("Nhập tên sản phẩm: ");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Tên sản phẩm không thể để trống. Vui lòng nhập lại.");
                    }
                } while (string.IsNullOrWhiteSpace(name));

                float price = 0;
                string priceString;
                bool exitPrice = false;
                do
                {
                    Console.Write("Nhập giá sản phẩm: ");
                    priceString = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(priceString))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Giá sản phẩm không thể để trống. Vui lòng nhập lại.");
                    } else
                    {
                        if(!float.TryParse(priceString, out price))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Giá sản phẩm không hợp lệ. Vui lòng nhập lại.");
                        } else
                        {
                            exitPrice = true;
                        }
                    }
                } while (!exitPrice);

                int quantity = 0;
                string quantityString;
                bool exitQuantity = false;
                do
                {
                    Console.Write("Nhập số lượng sản phẩm: ");
                    quantityString = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(quantityString))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Số lượng sản phẩm không thể để trống. Vui lòng nhập lại.");
                    }
                    else
                    {
                        if (!int.TryParse(quantityString, out quantity))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Số lượng sản phẩm không hợp lệ. Vui lòng nhập lại.");
                        }
                        else
                        {
                            exitQuantity = true;
                        }
                    }
                } while (!exitQuantity);

                Console.Write("Nhập mô tả sản phẩm: ");
                string description = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("Nhập mô tả sản phẩm: Trống.");
                    description = "Trống";
                }

                string packagingType;
                do
                {
                    Console.Write("Nhập kiểu đóng gói sản phẩm: ");
                    packagingType = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(packagingType))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Kiểu đóng gói sản phẩm không thể để trống. Vui lòng nhập lại.");
                    }
                } while (string.IsNullOrWhiteSpace(packagingType));

                DateTime manufacturingDate = DateTime.Now;
                string manufacturingDateString;
                bool exitManufacturingDate = false;
                do
                {
                    Console.Write("Nhập ngày sản xuất của sản phẩm: ");
                    manufacturingDateString = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(manufacturingDateString))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Ngày sản xuất không thể để trống. Vui lòng nhập lại.");
                    }
                    else
                    {
                        if (!DateTime.TryParseExact(manufacturingDateString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out manufacturingDate))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Ngày sản xuất không đúng định dạng. Vui lòng nhập lại.");
                        }
                        else
                        {
                            if (manufacturingDate > DateTime.Now)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("\u26A0 Ngày sản xuất phải bằng hoặc trước ngày hiện tại. Vui lòng nhập lại.");
                            } else
                            {
                                exitManufacturingDate = true;
                            }
                        }
                    }
                } while (!exitManufacturingDate);

                DateTime expiryDate = DateTime.Now;
                string expiryDateString;
                bool exitExpiryDate = false;
                do
                {
                    Console.Write("Nhập ngày hết hạn của sản phẩm: ");
                    expiryDateString = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(expiryDateString))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Ngày hết hạn không thể để trống. Vui lòng nhập lại.");
                    }
                    else
                    {
                        if (!DateTime.TryParseExact(expiryDateString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out expiryDate))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Ngày hết hạn không đúng định dạng. Vui lòng nhập lại.");
                        }
                        else
                        {
                            if (expiryDate <= manufacturingDate)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("\u26A0 Ngày hết hạn phải sau ngày sản xuất. Vui lòng nhập lại.");
                            }
                            else
                            {
                                exitExpiryDate = true;
                            }
                        }
                    }
                } while (!exitExpiryDate);

                string brandId;
                bool exitBrandId = false;
                do
                {
                    Console.Write("Nhập mã thương hiệu của sản phẩm: ");
                    brandId = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(brandId))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Mã thương hiệu không thể để trống. Vui lòng nhập lại.");
                    }
                    else
                    {
                        if (repoBrand.SearchById(brandId) == null)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Mã thương hiệu không tồn tại. Vui lòng nhập lại.");
                        }
                        else
                        {
                            exitBrandId = true;
                        }
                    }
                } while (!exitBrandId);

                string groupProductId;
                bool exitGroupProductId = false;
                do
                {
                    Console.Write("Nhập mã nhóm của sản phẩm: ");
                    groupProductId = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(groupProductId))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Mã nhóm không thể để trống. Vui lòng nhập lại.");
                    }
                    else
                    {
                        if (repoGroupProduct.SearchById(groupProductId) == null)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Mã nhóm không tồn tại. Vui lòng nhập lại.");
                        }
                        else
                        {
                            exitGroupProductId = true;
                        }
                    }
                } while (!exitGroupProductId);

                repoFertilizer.Add(new Fertilizer(id, name, price, quantity, description, packagingType, manufacturingDate, expiryDate, brandId, groupProductId));
            }

            //UpdateFertilizer
            void UpdateFertilizer()
            {
                Console.Write("Nhập mã sản phẩm cần cập nhật: ");
                string id = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(id))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("Nhập mã sản phẩm cần cập nhật: Trống.");
                }
                else
                {
                    Fertilizer fertilizer = repoFertilizer.SearchById(id);

                    if (fertilizer != null)
                    {
                        Console.Write("Nhập tên mới cho sản phẩm: ");
                        string name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("Nhập tên mới cho sản phẩm: Trống.");
                        }
                        else
                        {
                            fertilizer.ProductName = name;
                        }

                        float price = 0;
                        string priceString;
                        bool exitPrice = false;
                        do
                        {
                            Console.Write("Nhập giá mới cho sản phẩm: ");
                            priceString = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(priceString))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập giá mới cho sản phẩm: Trống.");
                                exitPrice = true;
                            }
                            else
                            {
                                if (!float.TryParse(priceString, out price))
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    Console.WriteLine("\u26A0 Giá sản phẩm không hợp lệ. Vui lòng nhập lại.");
                                }
                                else
                                {
                                    fertilizer.ProductPrice = price;
                                    exitPrice = true;
                                }
                            }
                        } while (!exitPrice);

                        int quantity = 0;
                        string quantityString;
                        bool exitQuantity = false;
                        do
                        {
                            Console.Write("Nhập số lượng mới cho sản phẩm: ");
                            quantityString = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(quantityString))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập số lượng mới cho sản phẩm: Trống.");
                                exitQuantity = true;
                            }
                            else
                            {
                                if (!int.TryParse(quantityString, out quantity))
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    Console.WriteLine("\u26A0 Số lượng sản phẩm không hợp lệ. Vui lòng nhập lại.");
                                }
                                else
                                {
                                    fertilizer.ProductQuantity = quantity;
                                    exitQuantity = true;
                                }
                            }
                        } while (!exitQuantity);

                        Console.Write("Nhập mô tả mới cho sản phẩm: ");
                        string description = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(description))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("Nhập mô tả mới cho sản phẩm: Trống.");
                        }
                        else
                        {
                            fertilizer.ProductDescription = description;
                        }

                        string packagingType;
                        do
                        {
                            Console.Write("Nhập kiểu đóng gói mới cho sản phẩm: ");
                            packagingType = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(packagingType))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập kiểu đóng gói mới cho sản phẩm: Trống.");
                            }
                            else
                            {
                                fertilizer.FertilizerPackagingType = packagingType;
                            }
                        } while (string.IsNullOrWhiteSpace(packagingType));

                        DateTime manufacturingDate = DateTime.Now;
                        string manufacturingDateString;
                        bool exitManufacturingDate = false;
                        do
                        {
                            Console.Write("Nhập ngày sản xuất mới cho sản phẩm: ");
                            manufacturingDateString = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(manufacturingDateString))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập ngày sản xuất mới cho sản phẩm: Trống.");
                                exitManufacturingDate = true;
                            }
                            else
                            {
                                if (!DateTime.TryParseExact(manufacturingDateString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out manufacturingDate))
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    Console.WriteLine("\u26A0 Ngày sản xuất không đúng định dạng. Vui lòng nhập lại.");
                                }
                                else
                                {
                                    if (manufacturingDate > DateTime.Now)
                                    {
                                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                                        Console.WriteLine("\u26A0 Ngày sản xuất phải bằng hoặc trước ngày hiện tại. Vui lòng nhập lại.");
                                    }
                                    else
                                    {
                                        fertilizer.FertilizerManufacturingDate = manufacturingDate;
                                        exitManufacturingDate = true;
                                    }
                                }
                            }
                        } while (!exitManufacturingDate);

                        DateTime expiryDate = DateTime.Now;
                        string expiryDateString;
                        bool exitExpiryDate = false;
                        do
                        {
                            Console.Write("Nhập ngày hết hạn mới cho sản phẩm: ");
                            expiryDateString = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(expiryDateString))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập ngày hết hạn mới cho sản phẩm: Trống.");
                                exitExpiryDate = true;
                            }
                            else
                            {
                                if (!DateTime.TryParseExact(expiryDateString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out expiryDate))
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    Console.WriteLine("\u26A0 Ngày hết hạn không đúng định dạng. Vui lòng nhập lại.");
                                }
                                else
                                {
                                    if (expiryDate <= manufacturingDate)
                                    {
                                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                                        Console.WriteLine("\u26A0 Ngày hết hạn phải sau ngày sản xuất. Vui lòng nhập lại.");
                                    }
                                    else
                                    {
                                        fertilizer.FertilizerExpiryDate = expiryDate;
                                        exitExpiryDate = true;
                                    }
                                }
                            }
                        } while (!exitExpiryDate);

                        string brandId;
                        bool exitBrandId = false;
                        do
                        {
                            Console.Write("Nhập mã thương hiệu mới cho sản phẩm: ");
                            brandId = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(brandId))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập mã thương hiệu mới cho sản phẩm: Trống.");
                                exitBrandId = true;
                            }
                            else
                            {
                                if (repoBrand.SearchById(brandId) == null)
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    Console.WriteLine("\u26A0 Mã thương hiệu không tồn tại. Vui lòng nhập lại.");
                                }
                                else
                                {
                                    fertilizer.BrandId = brandId;
                                    exitBrandId = true;
                                }
                            }
                        } while (!exitBrandId);

                        string groupProductId;
                        bool exitGroupProductId = false;
                        do
                        {
                            Console.Write("Nhập mã nhóm mới cho sản phẩm: ");
                            groupProductId = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(groupProductId))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập mã nhóm mới cho sản phẩm: Trống.");
                                exitGroupProductId = true;
                            }
                            else
                            {
                                if (repoGroupProduct.SearchById(groupProductId) == null)
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    Console.WriteLine("\u26A0 Mã nhóm không tồn tại. Vui lòng nhập lại.");
                                }
                                else
                                {
                                    fertilizer.GroupProductId = groupProductId;
                                    exitGroupProductId = true;
                                }
                            }
                        } while (!exitGroupProductId);

                        repoFertilizer.Update(id, fertilizer);
                    } else
                    {
                        Console.WriteLine($"\u274C Không thể cập nhật. Không tồn tại mã: {id}.");
                    }
                }
            }

            //DeleteFertilizer
            void DeleteFertilizer()
            {
                Console.Write("Nhập mã sản phẩm cần xóa: ");
                string id = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(id))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("Nhập mã sản phẩm cần xóa: Trống.");
                }
                else
                {
                    repoFertilizer.Delete(id);
                }
            }

            //SearchByIdFertilizer
            void SearchByIdFertilizer()
            {
                Console.Write("Nhập mã sản phẩm cần tìm: ");
                string id = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(id))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("Nhập mã sản phẩm cần tìm: Trống.");
                }
                else
                {
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
            }

            //SearchByKeyWordFertilizer
            void SearchByKeyWordFertilizer()
            {
                Console.Write("Nhập từ khóa cần tìm: ");
                string keyWord = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(keyWord))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("Nhập từ khóa cần tìm: Trống.");
                }
                else
                {
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
            }

            //AddProductComponent
            void AddProductComponent() 
            {
                string id;
                if (repoGroupProduct.List.Count == 0)
                {
                    id = "PC00001";
                }
                else
                {
                    string lastId = repoGroupProduct.List[repoGroupProduct.List.Count - 1].Id;
                    int idToNum = int.Parse(lastId.Substring(2)) + 1;
                    id = "PC" + idToNum.ToString().PadLeft(5, '0');
                }

                string productId;
                bool exitProductId = false;
                do
                {
                    Console.Write("Nhập mã sản phẩm: ");
                    productId = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(productId))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Mã sản phẩm không thể để trống. Vui lòng nhập lại.");
                    }
                    else
                    {
                        if (repoFertilizer.SearchById(productId) == null)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Mã sản phẩm không tồn tại. Vui lòng nhập lại.");
                        }
                        else
                        {
                            exitProductId = true;
                        }
                    }
                } while (!exitProductId);

                string componentId;
                bool exitComponentId = false;
                do
                {
                    Console.Write("Nhập mã thành phần: ");
                    componentId = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(componentId))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Mã thành phần không thể để trống. Vui lòng nhập lại.");
                    }
                    else
                    {
                        if (repoComponent.SearchById(componentId) == null)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Mã thành phần không tồn tại. Vui lòng nhập lại.");
                        }
                        else
                        {
                            exitComponentId = true;
                        }
                    }
                } while (!exitComponentId);

                repoProductComponent.Add(new ProductComponent(id, productId, componentId));
            }

            //AddProductUse
            void AddProductUse()
            {
                string id;
                if (repoGroupProduct.List.Count == 0)
                {
                    id = "PU00001";
                }
                else
                {
                    string lastId = repoGroupProduct.List[repoGroupProduct.List.Count - 1].Id;
                    int idToNum = int.Parse(lastId.Substring(2)) + 1;
                    id = "PU" + idToNum.ToString().PadLeft(5, '0');
                }

                string productId;
                bool exitProductId = false;
                do
                {
                    Console.Write("Nhập mã sản phẩm: ");
                    productId = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(productId))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Mã sản phẩm không thể để trống. Vui lòng nhập lại.");
                    }
                    else
                    {
                        if (repoFertilizer.SearchById(productId) == null)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Mã sản phẩm không tồn tại. Vui lòng nhập lại.");
                        }
                        else
                        {
                            exitProductId = true;
                        }
                    }
                } while (!exitProductId);

                string useId;
                bool exitUseId = false;
                do
                {
                    Console.Write("Nhập mã công dụng: ");
                    useId = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(useId))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\u26A0 Mã công dụng không thể để trống. Vui lòng nhập lại.");
                    }
                    else
                    {
                        if (repoUse.SearchById(useId) == null)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Mã công dụng không tồn tại. Vui lòng nhập lại.");
                        }
                        else
                        {
                            exitUseId = true;
                        }
                    }
                } while (!exitUseId);

                repoProductUse.Add(new ProductUse(id, productId, useId));
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
                    Console.WriteLine("Danh sách rỗng.");
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
                    string id;
                    if (repoComponent.List.Count == 0)
                    {
                        id = "C00001";
                    }
                    else
                    {
                        string lastId = repoGroupProduct.List[repoGroupProduct.List.Count - 1].Id;
                        int idToNum = int.Parse(lastId.Substring(2)) + 1;
                        id = "C" + idToNum.ToString().PadLeft(5, '0');
                    }

                    string name;
                    do
                    {
                        Console.Write("Nhập tên thành phần: ");
                        name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Tên thành phần không thể để trống. Vui lòng nhập lại.");
                        }
                    } while (string.IsNullOrWhiteSpace(name));

                    float percentage = 0;
                    string percentageString;
                    bool exitPercentage = false;
                    do
                    {
                        Console.Write("Nhập tỉ lệ thành phần (%): ");
                        percentageString = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(percentageString))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Tỉ lệ thành phần không thể để trống. Vui lòng nhập lại.");
                        } else
                        {
                            if (!float.TryParse(percentageString, out percentage) || percentage > 100) 
                            {
                                Console.WriteLine("\u26A0 Tỉ lệ thành phần không hợp lệ. Vui lòng nhập lại.");
                            } else {
                                exitPercentage = true;
                            }
                        }
                    } while (!exitPercentage);

                    Console.Write("Nhập mô tả thành phần: ");
                    string description = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(description))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mô tả thành phần: Trống.");
                        description = "Trống";
                    }

                    repoComponent.Add(new Component(id, name, percentage, description));
                }

                //UpdateComponent
                void UpdateComponent()
                {
                    Console.Write("Nhập mã thành phần cần cập nhật: ");
                    string id = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mã thành phần cần cập nhật: Trống.");
                    }
                    else
                    {
                        Component component = repoComponent.SearchById(id);

                        if (component != null)
                        {
                            Console.Write("Nhập tên mới cho thành phần: ");
                            string name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập tên mới cho thành phần: Trống");
                            } else {
                                component.ComponentName = name;
                            }

                            float percentage = 0;
                            string percentageString;
                            bool exitPercentage = false;
                            do
                            {
                                Console.Write("Nhập tỉ lệ mới cho thành phần (%): ");
                                percentageString = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(percentageString))
                                {
                                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                                    Console.WriteLine("Nhập tỉ lệ mới cho thành phần (%): Trống.");
                                    exitPercentage = true;
                                } else
                                {
                                    if (!float.TryParse(percentageString, out percentage) || percentage > 100) 
                                    {
                                        Console.WriteLine("\u26A0 Tỉ lệ thành phần không hợp lệ. Vui lòng nhập lại.");
                                    } else 
                                    {
                                        component.ComponentPercentage = percentage;
                                        exitPercentage = true;
                                    }
                                }
                            } while (!exitPercentage);

                            Console.Write("Nhập mô tả thành phần: ");
                            string description = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(description))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập mô tả thành phần: Trống.");
                            }

                            repoComponent.Update(id, component);
                        }
                        else
                        {
                            Console.WriteLine($"\u274C Không thể cập nhật. Không tồn tại mã: {id}.");
                        }
                    }
                }

                //DeleteComponent
                void DeleteComponent()
                {
                    Console.Write("Nhập mã thành phần cần xóa: ");
                    string id = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mã thành phần cần xóa: Trống.");
                    }
                    else
                    {
                        repoComponent.Delete(id);
                    }
                }

                //SearchByIdComponent
                void SearchByIdComponent()
                {
                    Console.Write("Nhập mã thành phần cần tìm: ");
                    string id = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mã thành phần cần tìm: Trống.");
                    }
                    else
                    {
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
                }

                //SearchByKeyWordComponent
                void SearchByKeyWordComponent()
                {
                    Console.Write("Nhập từ khóa cần tìm: ");
                    string keyWord = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(keyWord))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập từ khóa cần tìm: Trống.");
                    }
                    else
                    {
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
                        Console.WriteLine("Danh sách rỗng.");
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
                    string id;
                    if (repoUse.List.Count == 0)
                    {
                        id = "U00001";
                    }
                    else
                    {
                        string lastId = repoGroupProduct.List[repoGroupProduct.List.Count - 1].Id;
                        int idToNum = int.Parse(lastId.Substring(2)) + 1;
                        id = "U" + idToNum.ToString().PadLeft(5, '0');
                    }

                    string name;
                    do
                    {
                        Console.Write("Nhập tên công dụng: ");
                        name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.WriteLine("\u26A0 Tên công dụng không thể để trống. Vui lòng nhập lại.");
                        }
                    } while (string.IsNullOrWhiteSpace(name));

                    Console.Write("Nhập mô tả công dụng: ");
                    string description = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(description))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mô tả công dụng: Trống.");
                        description = "Trống";
                    }

                    repoUse.Add(new Use(id, name, description));
                }

                //UpdateUse
                void UpdateUse()
                {
                    Console.Write("Nhập mã công dụng cần cập nhật: ");
                    string id = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mã công dụng cần cập nhật: Trống.");
                    }
                    else
                    {
                        Use use = repoUse.SearchById(id);

                        if (use != null)
                        {
                            Console.Write("Nhập tên mới cho công dụng: ");
                            string name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập tên mới cho công dụng: Trống");
                            }
                            else
                            {
                                use.UseName = name;
                            }

                            Console.Write("Nhập mô tả mới cho công dụng: ");
                            string description = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(description))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                Console.WriteLine("Nhập mô tả mới cho công dụng: Trống");
                            }
                            else
                            {
                                use.UseDescription = description;
                            }

                            repoUse.Update(id, use);
                        }
                        else
                        {
                            Console.WriteLine($"\u274C Không thể cập nhật. Không tồn tại mã: {id}.");
                        }
                    }
                }

                //DeleteUse
                void DeleteUse()
                {
                    Console.Write("Nhập mã công dụng cần xóa: ");
                    string id = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mã công dụng cần xóa: Trống.");
                    }
                    else
                    {
                        repoUse.Delete(id);
                    }
                }

                //SearchByIdUse
                void SearchByIdUse()
                {
                    Console.Write("Nhập mã công dụng cần tìm: ");
                    string id = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập mã công dụng cần tìm: Trống.");
                    }
                    else
                    {
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
                }

                //SearchByKeyWordUse
                void SearchByKeyWordUse()
                {
                    Console.Write("Nhập từ khóa cần tìm: ");
                    string keyWord = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(keyWord))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("Nhập từ khóa cần tìm: Trống.");
                    }
                    else
                    {
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
                        Console.WriteLine("Danh sách rỗng.");
                    }
                }
            }
        }
    }
}
