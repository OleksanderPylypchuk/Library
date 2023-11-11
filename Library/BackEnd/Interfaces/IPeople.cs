using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BackEnd.Interfaces
{
    public interface IPeople
    {
        string Name { get; set; }
        int BirthDate {  get; set; }
    }
}
