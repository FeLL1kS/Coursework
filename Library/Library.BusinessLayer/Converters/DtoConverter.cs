using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DTO;
using Library.DataAccess.Entities;
using Library.DataAccess;

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

        internal static Book Convert(BookDto bookDto)
        {
            if (bookDto == null)
                return null;
            Book book = new Book();
            book.BookCode = bookDto.Id;
            book.Title = bookDto.Title;
            book.Genre = bookDto.Genre;
            book.CollateralValue = bookDto.CollateralValue;
            book.CostPerDay = bookDto.CostPerDay;
            book.AuthorId = bookDto.Author.Id;
            return book;
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

        public static BookDto Convert(Book book)
        {
            if (book == null)
                return null;
            BookDto bookDto = new BookDto();
            bookDto.Id = book.BookCode;
            bookDto.Title = book.Title;
            bookDto.Genre = book.Genre;
            bookDto.CollateralValue = book.CollateralValue;
            bookDto.CostPerDay = book.CostPerDay;
            bookDto.Author = Convert(DaoFactory.GetAuthorDao().Get(book.AuthorId));
            return bookDto;
        }

        public static IList<BookDto> Convert(IList<Book> books)
        {
            IList<BookDto> bookDtos = new List<BookDto>();
            if (books == null)
                return null;
            foreach(Book book in books)
            {
                bookDtos.Add(Convert(book));
            }
            return bookDtos;
        }
    }
}
