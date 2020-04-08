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
    public class FinesProcessDb : IFinesProcess
    {
        private readonly IFinesDao _finesDao;

        public FinesProcessDb()
        {
            _finesDao = DaoFactory.GetFinesDao();
        }

        public void Add(FinesDto fines)
        {
            _finesDao.Add(DtoConverter.Convert(fines));
        }

        public void Delete(int id)
        {
            _finesDao.Delete(id);
        }

        public FinesDto Get(int id)
        {
            return DtoConverter.Convert(_finesDao.Get(id));
        }

        public IList<FinesDto> GetList()
        {
            return DtoConverter.Convert(_finesDao.GetList());
        }

        public void Update(FinesDto fines)
        {
            _finesDao.Update(DtoConverter.Convert(fines));
        }
    }
}
