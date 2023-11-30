using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.BackEnd.Interfaces
{
    public interface IBookList<T> where T:Book
    {
        public void AddBook(T book);
        public T Find(string title);
        public bool RemoveBook(T book);
        public string RetrieveBookNames();
    }
}
