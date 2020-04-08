using Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess;
using Library.BusinessLayer.Converters;

namespace Library.BusinessLayer
{
    public class DiscountsProcessDb : IDiscountsProcess
    {
        private readonly IDiscountsDao _discountDao;

        public DiscountsProcessDb()
        {
            _discountDao = DaoFactory.GetDiscountsDao();
        }

        public void Add(DiscountsDto discount)
        {
            _discountDao.Add(DtoConverter.Convert(discount));
        }

        public void Delete(int id)
        {
            _discountDao.Delete(id);
        }

        public DiscountsDto Get(int id)
        {
            return DtoConverter.Convert(_discountDao.Get(id));
        }

        public IList<DiscountsDto> GetList()
        {
            return DtoConverter.Convert(_discountDao.GetList());
        }

        public void Update(DiscountsDto discount)
        {
            _discountDao.Update(DtoConverter.Convert(discount));
        }
    }
}
