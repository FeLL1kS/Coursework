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
    class CardIndexProcessDb : ICardIndexProcess
    {
        private readonly ICardIndexDao _cardIndexDao;

        public CardIndexProcessDb()
        {
            _cardIndexDao = DaoFactory.GetCardIndexDao();
        }

        public void Add(CardIndexDto cardIndex)
        {
            _cardIndexDao.Add(DtoConverter.Convert(cardIndex));
        }

        public void Delete(int id)
        {
            _cardIndexDao.Delete(id);
        }

        public CardIndexDto Get(int id)
        {
            return DtoConverter.Convert(_cardIndexDao.Get(id));
        }

        public IList<CardIndexDto> GetList()
        {
            return DtoConverter.Convert(_cardIndexDao.GetList());
        }

        public IList<CardIndexDto> SearchCardIndices(string ReturnDateFrom, string ReturnDateTo, string DateOfIssueFrom, string DateOfIssueTo, string TotalPriceFrom, string TotalPriceTo, string ReaderCode, string BookCode, string FineCode)
        {
            return DtoConverter.Convert(_cardIndexDao.SearchCardIndices(ReturnDateFrom, ReturnDateTo, DateOfIssueFrom, DateOfIssueTo, TotalPriceFrom, TotalPriceTo, ReaderCode, BookCode, FineCode));
        }

        public void Update(CardIndexDto cardIndex)
        {
            _cardIndexDao.Update(DtoConverter.Convert(cardIndex));
        }
    }
}
