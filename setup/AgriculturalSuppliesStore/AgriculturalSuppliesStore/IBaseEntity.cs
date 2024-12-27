using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore
{
    internal interface IBaseEntity
    {
        string Id { get; set; }

        void DisplayDetail();

        bool Equals(object obj);

        int GetHashCode();
    }
}
