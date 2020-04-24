using Library.BusinessLayer.Interfaces;
using Library.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess;
using Library.DTO;
using Library.BusinessLayer.Converters;

namespace Library.BusinessLayer
{
    public class AuthorProcessDb : IAuthorProcess
    {
        private readonly IAuthorDao _authorDao;
        public AuthorProcessDb()
        {
            _authorDao = DaoFactory.GetAuthorDao();
        }

        public void Add(AuthorDto author)
        {
            _authorDao.Add(DtoConverter.Convert(author));
        }

        public void Delete(int id)
        {
            _authorDao.Delete(id);
        }

        public AuthorDto Get(int id)
        {
            return DtoConverter.Convert(_authorDao.Get(id));
        }

        public IList<AuthorDto> GetList()
        {
            return DtoConverter.Convert(_authorDao.GetList());
        }

        public IList<AuthorDto> SearchAuthors(string Name)
        {
            return DtoConverter.Convert(_authorDao.SearchAuthors(Name));
        }

        public void Update(AuthorDto author)
        {
            _authorDao.Update(DtoConverter.Convert(author));
        }
    }
}
