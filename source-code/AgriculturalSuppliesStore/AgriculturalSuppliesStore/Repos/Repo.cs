using AgriculturalSuppliesStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Repos
{
    internal class Repo<T> : IRepo<T> where T : IBaseEntity
    {
        private List<T> list { get; set; }
        public List<T> List { get => list; set => this.list = value; }

        public Repo() {
            list = new List<T>();
        }

        public void Add(T obj) 
        {
            string itemId = "";
            bool exists = list.Any(item =>
            {
                if (item.Equals(obj))
                {
                    itemId = item.Id;
                    return true;
                }
                return false;
            });

            if (!exists)
            {
                list.Add(obj);
                Console.WriteLine($"\u2705 Thêm thành công - Đối tượng có mã {obj.Id}");
            } else
            {
                Console.WriteLine($"\u274C Thêm thất bại - Đối tượng đang tồn tại có mã {itemId}");
            }
        }

        public void Update(string id, T obj) 
        {
            id = id.ToUpper();
            int itemIndex = list.FindIndex(item => item.Id == id);
            if (itemIndex >= 0)
            {
                list[itemIndex] = obj;
                Console.WriteLine($"\u2705 Cập nhật thành công - Đối tượng có mã {id}");
            }
        }

        public void Delete(string id) 
        {
            id = id.ToUpper();
            T itemDelete = list.Find(item => item.Id == id);
            if (itemDelete != null)
            {
                list.Remove(itemDelete);
                Console.WriteLine($"\u2705 Xóa thành công. Đối tượng có mã {id}.");
            }
            else
            {
                Console.WriteLine($"\u274C Xóa thất bại. Đối tượng có mã {id} không tồn tại.");
            }
        }

        public T SearchById(string id) 
        {
            id = id.ToUpper();
            return list.Find(item => item.Id == id);
        }

        public List<T> SearchByKeyWord(string keyWord) 
        {
            return list.FindAll(item =>
            {
                return item.GetType().GetProperties().Any(property =>
                {
                    var value = property.GetValue(item)?.ToString();
                    return value.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0;
                });
            });
        }

        public void DisplayAll() 
        {
            if (list.Count != 0)
            {
                list.ForEach(item => item.Display());
            }
        }
    }
}
