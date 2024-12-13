using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalSuppliesStore.Interfaces
{
    internal interface IBaseEntity
    {
        string Id { get; set; }

        void Display();
    }
}
