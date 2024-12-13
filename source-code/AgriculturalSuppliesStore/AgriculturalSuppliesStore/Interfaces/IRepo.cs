using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Interfaces
{
    internal interface IRepo<T>
    {
        List<T> List { get; set; }

        void Add(T item);
        void Update(string id, T item);
        void Delete(string id);
        T SearchById(string id);
        List<T> SearchByKeyWord(string keyWord);
        void DisplayAll();
    }
}
