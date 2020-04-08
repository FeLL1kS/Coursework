using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess.Interfaces;
using Library.DataAccess.Entities;
using System.Data.SqlClient;

namespace Library.DataAccess
{
    public class CardIndexDao : BaseDao, ICardIndexDao
    {
        public void Add(CardIndex cardIndex)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO CardIndex(DateOfIssue, ReturnDate, BookCode, ReaderCode, FineCode) VALUES (@DateOfIssue, @ReturnDate, @BookCode, @ReaderCode, @FineCode)";
                    cmd.Parameters.AddWithValue("@DateOfIssue", cardIndex.DateOfIssue);
                    cmd.Parameters.AddWithValue("@ReturnDate", cardIndex.ReturnDate);
                    cmd.Parameters.AddWithValue("@BookCode", cardIndex.BookCode);
                    cmd.Parameters.AddWithValue("@FineCode", cardIndex.FineCode);
                    cmd.Parameters.AddWithValue("@ReaderCode", cardIndex.ReaderCode);
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
                    cmd.CommandText = "DELETE FROM CardIndex WHERE IssuedBookID = @IssuedBookID";
                    cmd.Parameters.AddWithValue("@IssuedBookID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public CardIndex Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex WHERE IssuedBookID = @IssuedBookID";
                    cmd.Parameters.AddWithValue("@IssuedBookID", id);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return dataReader.Read() ? LoadCardIndex(dataReader) : null;
                    }
                }
            }
        }

        public IList<CardIndex> GetList()
        {
            IList<CardIndex> cardIndices = new List<CardIndex>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            cardIndices.Add(LoadCardIndex(dataReader));
                        }

                        return cardIndices;
                    }
                }
            }
        }

        public void Update(CardIndex cardIndex)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE CardIndex SET DateOfIssue = @DateOfIssue, ReturnDate = @ReturnDate, BookCode = @BookCode, ReaderCode = @ReaderCode, FineCode = @FineCode WHERE IssuedBookID = @IssuedBookID";
                    cmd.Parameters.AddWithValue("@IssuedBookID", cardIndex.IssuedBookID);
                    cmd.Parameters.AddWithValue("@DateOfIssue", cardIndex.DateOfIssue);
                    cmd.Parameters.AddWithValue("@ReturnDate", cardIndex.ReturnDate);
                    cmd.Parameters.AddWithValue("@BookCode", cardIndex.BookCode);
                    cmd.Parameters.AddWithValue("@FineCode", cardIndex.FineCode);
                    cmd.Parameters.AddWithValue("@ReaderCode", cardIndex.ReaderCode);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public CardIndex LoadCardIndex(SqlDataReader dataReader)
        {
            CardIndex cardIndex = new CardIndex
            {
                IssuedBookID = dataReader.GetInt32(dataReader.GetOrdinal("IssuedBookID")),
                DateOfIssue = dataReader.GetSqlDateTime(dataReader.GetOrdinal("DateOfIssue")).Value,
                ReturnDate = dataReader.GetSqlDateTime(dataReader.GetOrdinal("ReturnDate")).Value,
                TotalPrice = (double)dataReader.GetSqlMoney(dataReader.GetOrdinal("TotalPrice")).Value,
                BookCode = dataReader.GetInt32(dataReader.GetOrdinal("BookCode")),
                FineCode = dataReader.GetInt32(dataReader.GetOrdinal("FineCode")),
                ReaderCode = dataReader.GetInt32(dataReader.GetOrdinal("ReaderCode"))
            };

            return cardIndex;
        }
    }
}
