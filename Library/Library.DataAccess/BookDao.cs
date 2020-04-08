using Library.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Library.DataAccess
{
    class BookDao : BaseDao, IBookDao
    {
        public void Add(Book book)
        {
            using(var conn = GetConnection())
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Book(Title, Genre, AuthorID, CollateralValue, CostPerDay) VALUES(@Title, @Genre, @AuthorID, @CollateralValue, @CostPerDay)";
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Genre", book.Genre);
                    cmd.Parameters.AddWithValue("@AuthorID", book.AuthorId);
                    cmd.Parameters.AddWithValue("@CollateralValue", book.CollateralValue);
                    cmd.Parameters.AddWithValue("@CostPerDay", book.CostPerDay);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Book WHERE BookCode = @BookCode";
                    cmd.Parameters.AddWithValue("@BookCode", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Book Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Title, Genre, AuthorID, CollateralValue, CostPerDay FROM Book WHERE BookCode = @BookCode";
                    cmd.Parameters.AddWithValue("@BookCode", id);
                    using(var dataReader = cmd.ExecuteReader())
                    {
                        return dataReader.Read() ? LoadBook(dataReader) : null;
                    }
                }
            }
        }

        public IList<Book> GetList()
        {
            IList<Book> books = new List<Book>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT BookCode, Title, Genre, AuthorID, CollateralValue, CostPerDay FROM Book";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            books.Add(LoadBook(dataReader));
                        }

                        return books;
                    }
                }
            }
        }

        public void Update(Book book)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Book SET Title = @Title, Genre = @Genre, AuthorID = @AuthorID, CollateralValue = @CollateralValue, CostPerDay = @CostPerDay WHERE BookCode = @BookCode";
                    cmd.Parameters.AddWithValue("@BookCode", book.BookCode);
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Genre", book.Genre);
                    cmd.Parameters.AddWithValue("@AuthorID", book.AuthorId);
                    cmd.Parameters.AddWithValue("@CollateralValue", book.CollateralValue);
                    cmd.Parameters.AddWithValue("@CostPerDay", book.CostPerDay);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Book LoadBook(SqlDataReader dataReader)
        {
            Book book = new Book();

            book.BookCode = dataReader.GetInt32(dataReader.GetOrdinal("BookCode"));
            book.Title = dataReader.GetString(dataReader.GetOrdinal("Title"));
            book.Genre = dataReader.GetString(dataReader.GetOrdinal("Genre"));
            book.AuthorId = dataReader.GetInt32(dataReader.GetOrdinal("AuthorID"));
            book.CollateralValue = Convert.ToDouble(dataReader.GetSqlMoney(dataReader.GetOrdinal("CollateralValue")).Value);
            book.CostPerDay = Convert.ToDouble(dataReader.GetSqlMoney(dataReader.GetOrdinal("CostPerDay")).Value);

            return book;
        }
    }
}
