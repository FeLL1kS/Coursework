using Library.BusinessLayer.Converters;
using Library.DataAccess;
using Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer
{
    public class BookProcessDb : IBookProcess
    {
        private readonly IBookDao _bookDao;
        public BookProcessDb()
        {
            _bookDao = DaoFactory.GetBookDao();
        }

        public void Add(BookDto book)
        {
            _bookDao.Add(DtoConverter.Convert(book));
        }

        public void Delete(int id)
        {
            _bookDao.Delete(id);
        }

        public BookDto Get(int id)
        {
            return DtoConverter.Convert(_bookDao.Get(id));
        }

        public IList<BookDto> GetList()
        {
            return DtoConverter.Convert(_bookDao.GetList());
        }

        public void Update(BookDto book)
        {
            _bookDao.Update(DtoConverter.Convert(book));
        }
    }
}
