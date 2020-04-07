using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DTO;
using Library.DataAccess.Entities;

namespace Library.BusinessLayer.Converters
{
    public class DtoConverter
    {
        public static AuthorDto Convert(Author author)
        {
            if (author == null)
                return null;
            AuthorDto authorDto = new AuthorDto();
            authorDto.Id = author.Id;
            authorDto.FullName = author.FullName;
            return authorDto;
        }

        public static Author Convert(AuthorDto authorDto)
        {
            if (authorDto == null)
                return null;
            Author author = new Author();
            author.Id = authorDto.Id;
            author.FullName = authorDto.FullName;
            return author;
        }

        public static IList<AuthorDto> Convert(IList<Author> authors)
        {
            if (authors == null)
                return null;
            IList<AuthorDto> authorDtos = new List<AuthorDto>();
            foreach(Author author in authors)
            {
                authorDtos.Add(Convert(author));
            }
            return authorDtos;
        }
    }
}
