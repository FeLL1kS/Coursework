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

        public static FinesDto Convert(Fines fine)
        {
            if (fine == null)
                return null;

            FinesDto fineDto = new FinesDto
            {
                Id = fine.FineCode,
                FineDescription = fine.FineDescription,
                FinePrice = fine.FinePrice
            };

            return fineDto;
        }

        public static Fines Convert(FinesDto fineDto)
        {
            if (fineDto == null)
                return null;

            Fines fine = new Fines
            {
                FineCode = fineDto.Id,
                FineDescription = fineDto.FineDescription,
                FinePrice = fineDto.FinePrice
            };

            return fine;
        }

        public static IList<FinesDto> Convert(IList<Fines> fines)
        {
            if (fines == null)
                return null;

            IList<FinesDto> fineDtos = new List<FinesDto>();

            foreach(Fines fine in fines)
            {
                fineDtos.Add(Convert(fine));
            }

            return fineDtos;
        }

        public static ReaderDto Convert(Reader reader)
        {
            if (reader == null)
                return null;

            ReaderDto readerDto = new ReaderDto
            {
                Id = reader.ReaderCode,
                FirstName = reader.FirstName,
                SecondName = reader.SecondName,
                Patronymic = reader.Patronymic,
                Address = reader.Address,
                PhoneNumber = reader.PhoneNumber,
                Discount = ProcessFactory.GetDiscountProcess().Get(reader.DiscountCode)
            };

            return readerDto;
        }

        public static Reader Convert(ReaderDto readerDto)
        {
            if (readerDto == null)
                return null;

            Reader reader = new Reader
            {
                ReaderCode = readerDto.Id,
                FirstName = readerDto.FirstName,
                SecondName = readerDto.SecondName,
                Patronymic = readerDto.Patronymic,
                Address = readerDto.Address,
                PhoneNumber = readerDto.PhoneNumber,
                DiscountCode = readerDto.Discount.Id
            };

            return reader;
        }

        public static IList<ReaderDto> Convert(IList<Reader> readers)
        {
            if (readers == null)
                return null;

            IList<ReaderDto> readerDtos = new List<ReaderDto>();

            foreach (Reader reader in readers)
            {
                readerDtos.Add(Convert(reader));
            }

            return readerDtos;
        }

        public static CardIndexDto Convert(CardIndex cardIndex)
        {
            if (cardIndex == null)
                return null;

            CardIndexDto cardIndexDto = new CardIndexDto
            {
                Id = cardIndex.IssuedBookID,
                DateOfIssue = cardIndex.DateOfIssue,
                ReturnDate = cardIndex.ReturnDate,
                TotalPrice = cardIndex.TotalPrice,
                Book = ProcessFactory.GetBookProcess().Get(cardIndex.BookCode),
                Fine = ProcessFactory.GetFinesProcess().Get(cardIndex.FineCode),
                Reader = ProcessFactory.GetReaderProcess().Get(cardIndex.ReaderCode)
            };
            
            return cardIndexDto;
        }

        public static CardIndex Convert(CardIndexDto cardIndexDto)
        {
            if (cardIndexDto == null)
                return null;

            CardIndex cardIndex = new CardIndex
            {
                IssuedBookID = cardIndexDto.Id,
                DateOfIssue = cardIndexDto.DateOfIssue,
                ReturnDate = cardIndexDto.ReturnDate,
                TotalPrice = cardIndexDto.TotalPrice,
                BookCode = cardIndexDto.Book.Id,
                FineCode = cardIndexDto.Fine.Id,
                ReaderCode = cardIndexDto.Reader.Id
            };

            return cardIndex;
        }

        public static IList<CardIndexDto> Convert(IList<CardIndex> cardIndices)
        {
            if (cardIndices == null)
                return null;

            IList<CardIndexDto> cardIndexDtos = new List<CardIndexDto>();

            foreach(CardIndex cardIndex in cardIndices)
            {
                cardIndexDtos.Add(Convert(cardIndex));
            }

            return cardIndexDtos;
        }

        public static ReportItemDto Convert(Report report)
        {
            if (report == null)
                return null;
            ReportItemDto reportDto = new ReportItemDto()
            {
                Date = report.Date.ToString(),
                Count = report.Count,
                Price = report.Price
            };
            return reportDto;
        }

        internal static IList<ReportItemDto> Convert(IList<Report> reports)
        {
            IList<ReportItemDto> reportDtos = new List<ReportItemDto>();
            foreach (Report report in reports)
            {
                reportDtos.Add(Convert(report));
            }
            return reportDtos;
        }
    }
}
