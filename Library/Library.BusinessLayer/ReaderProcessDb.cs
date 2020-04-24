using Library.BusinessLayer.Converters;
using Library.BusinessLayer.Interfaces;
using Library.DataAccess;
using Library.DataAccess.Interfaces;
using Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer
{
    class ReaderProcessDb : IReaderProcess
    {
        private readonly IReaderDao _readerDao;

        public ReaderProcessDb()
        {
            _readerDao = DaoFactory.GetReaderDao();
        }

        public void Add(ReaderDto reader)
        {
            _readerDao.Add(DtoConverter.Convert(reader));
        }

        public void Delete(int id)
        {
            _readerDao.Delete(id);
        }

        public ReaderDto Get(int id)
        {
            return DtoConverter.Convert(_readerDao.Get(id));
        }

        public IList<ReaderDto> GetList()
        {
            return DtoConverter.Convert(_readerDao.GetList());
        }

        public void Update(ReaderDto reader)
        {
            _readerDao.Update(DtoConverter.Convert(reader));
        }

        public IList<ReaderDto> SearchReaders(string FirstName, string SecondName, string Patronymic, string DiscountID)
        {
            return DtoConverter.Convert(_readerDao.SearchReaders(FirstName, SecondName, Patronymic, DiscountID));
        }
    }
}
