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
            AuthorDto authorDto = new AuthorDto
            {
                Id = author.Id,
                FullName = author.FullName
            };
            return authorDto;
        }

        public static Author Convert(AuthorDto authorDto)
        {
            if (authorDto == null)
                return null;
            Author author = new Author
            {
                Id = authorDto.Id,
                FullName = authorDto.FullName
            };
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
            BookDto bookDto = new BookDto
            {
                Id = book.BookCode,
                Title = book.Title,
                Genre = book.Genre,
                CollateralValue = book.CollateralValue,
                CostPerDay = book.CostPerDay,
                Author = Convert(DaoFactory.GetAuthorDao().Get(book.AuthorId))
            };

            return bookDto;
        }

        public static Book Convert(BookDto bookDto)
        {
            if (bookDto == null)
                return null;
            Book book = new Book
            {
                BookCode = bookDto.Id,
                Title = bookDto.Title,
                Genre = bookDto.Genre,
                CollateralValue = bookDto.CollateralValue,
                CostPerDay = bookDto.CostPerDay,
                AuthorId = bookDto.Author.Id
            };
            return book;
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

        public static DiscountsDto Convert(Discounts discount)
        {
            if (discount == null)
                return null;

            DiscountsDto discountDto = new DiscountsDto
            {
                Id = discount.DiscountCode,
                DiscountDescription = discount.DiscountDescription,
                DiscountPercent = discount.DiscountPercent
            };

            return discountDto;
        }

        public static Discounts Convert(DiscountsDto discountDto)
        {
            if (discountDto == null)
                return null;

            Discounts discount = new Discounts
            {
                DiscountCode = discountDto.Id,
                DiscountDescription = discountDto.DiscountDescription,
                DiscountPercent = discountDto.DiscountPercent
            };

            return discount;
        }

        public static IList<DiscountsDto> Convert(IList<Discounts> discounts)
        {
            if (discounts == null)
                return null;

            IList<DiscountsDto> discountsDtos = new List<DiscountsDto>();
         
            foreach(Discounts discount in discounts)
            {
                discountsDtos.Add(Convert(discount));
            }

            return discountsDtos;
        }
    }
}
