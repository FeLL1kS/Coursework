using Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer
{
    public class BookProcess : IBookProcess
    {
        private static readonly IDictionary<int, BookDto> Books = new Dictionary<int, BookDto>();
        public void Add(BookDto book)
        {
            int newId = Books.Keys.Count == 0 ? 1 : Books.Keys.Max(p => p) + 1;
            book.Id = newId;
            Books.Add(newId, book);
        }

        public void Delete(int id)
        {
            if(Books.ContainsKey(id))
                Books.Remove(id);
        }

        public BookDto Get(int id)
        {
            return Books.ContainsKey(id) ? Books[id] : null;
        }

        public IList<BookDto> GetList()
        {
            return new List<BookDto>(Books.Values);
        }

        public void Update(BookDto book)
        {
            if (Books.ContainsKey(book.Id))
                Books[book.Id] = book;
        }
    }
}
