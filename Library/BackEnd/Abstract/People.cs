using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BackEnd.Interfaces
{
    public abstract class People
    {
        public virtual string Name { get; set; }
		public virtual int BirthDate {  get; set; }
    }
}
