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
                    if(cardIndex.ReturnDate != null)
                    {
                        cmd.Parameters.AddWithValue("@ReturnDate", cardIndex.ReturnDate);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ReturnDate", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@BookCode", cardIndex.BookCode);
                    if (cardIndex.FineCode != null)
                    {
                        cmd.Parameters.AddWithValue("@FineCode", cardIndex.FineCode);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FineCode", DBNull.Value);
                    }
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
        
        public IList<CardIndex> SearchCardIndices(string ReturnDateFrom, string ReturnDateTo, string DateOfIssueFrom, string DateOfIssueTo, string TotalPrice, string ReaderCode, string BookCode, string FineCode)
        {
            IList<CardIndex> cardIndices = new List<CardIndex>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    if(DateOfIssueFrom != "" && ReturnDateFrom != "")
                    {
                        if(DateOfIssueTo != "" && ReturnDateTo != "")
                        {
                            cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex WHERE TotalPrice LIKE @TotalPrice and BookCode LIKE @BookCode and FineCode LIKE @FineCode and ReaderCode LIKE @ReaderCode and DateOfIssue > @DateOfIssueFrom and DateOfIssue < @DateOfIssueTo and ReturnDate > @ReturnDateFrom and ReturnDate < @ReturnDateTo";
                            cmd.Parameters.AddWithValue("@DateOfIssueFrom", DateOfIssueFrom);
                            cmd.Parameters.AddWithValue("@DateOfIssueTo", DateOfIssueTo);
                            cmd.Parameters.AddWithValue("@ReturnDateFrom", ReturnDateFrom);
                            cmd.Parameters.AddWithValue("@ReturnDateTo", ReturnDateTo);
                        }
                        else if(DateOfIssueTo != "")
                        {
                            cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex WHERE TotalPrice LIKE @TotalPrice and BookCode LIKE @BookCode and FineCode LIKE @FineCode and ReaderCode LIKE @ReaderCode and DateOfIssue > @DateOfIssueFrom and DateOfIssue < @DateOfIssueTo and ReturnDate > @ReturnDateFrom";
                            cmd.Parameters.AddWithValue("@DateOfIssueFrom", DateOfIssueFrom);
                            cmd.Parameters.AddWithValue("@DateOfIssueTo", DateOfIssueTo);
                            cmd.Parameters.AddWithValue("@ReturnDateFrom", ReturnDateFrom);
                        }
                        else if(ReturnDateTo != "")
                        {
                            cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex WHERE TotalPrice LIKE @TotalPrice and BookCode LIKE @BookCode and FineCode LIKE @FineCode and ReaderCode LIKE @ReaderCode and DateOfIssue > @DateOfIssueFrom and ReturnDate > @ReturnDateFrom and ReturnDate < @ReturnDateTo";
                            cmd.Parameters.AddWithValue("@DateOfIssueFrom", DateOfIssueFrom);
                            cmd.Parameters.AddWithValue("@ReturnDateFrom", ReturnDateFrom);
                            cmd.Parameters.AddWithValue("@ReturnDateTo", ReturnDateTo);
                        }
                        else
                        {
                            cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex WHERE TotalPrice LIKE @TotalPrice and BookCode LIKE @BookCode and FineCode LIKE @FineCode and ReaderCode LIKE @ReaderCode and DateOfIssue > @DateOfIssueFrom and ReturnDate > @ReturnDateFrom";
                            cmd.Parameters.AddWithValue("@DateOfIssueFrom", DateOfIssueFrom);
                            cmd.Parameters.AddWithValue("@ReturnDateFrom", ReturnDateFrom);
                        }
                    }
                    else if(DateOfIssueFrom != "")
                    {
                        if(DateOfIssueTo != "")
                        {
                            cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex WHERE TotalPrice LIKE @TotalPrice and BookCode LIKE @BookCode and FineCode LIKE @FineCode and ReaderCode LIKE @ReaderCode and DateOfIssue > @DateOfIssueFrom and DateOfIssue < @DateOfIssueTo";
                            cmd.Parameters.AddWithValue("@DateOfIssueFrom", DateOfIssueFrom);
                            cmd.Parameters.AddWithValue("@DateOfIssueTo", DateOfIssueTo);
                        }
                        else
                        {
                            cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex WHERE TotalPrice LIKE @TotalPrice and BookCode LIKE @BookCode and FineCode LIKE @FineCode and ReaderCode LIKE @ReaderCode and DateOfIssue > @DateOfIssueFrom";
                            cmd.Parameters.AddWithValue("@DateOfIssueFrom", DateOfIssueFrom);
                        }
                    }
                    else if(ReturnDateFrom != "")
                    {
                        if(ReturnDateTo != "")
                        {
                            cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex WHERE TotalPrice LIKE @TotalPrice and BookCode LIKE @BookCode and FineCode LIKE @FineCode and ReaderCode LIKE @ReaderCode and ReturnDate > @ReturnDateFrom and ReturnDate < @ReturnDateTo";
                            cmd.Parameters.AddWithValue("@ReturnDateFrom", ReturnDateFrom);
                            cmd.Parameters.AddWithValue("@ReturnDateTo", ReturnDateTo);
                        }
                        else
                        {
                            cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex WHERE TotalPrice LIKE @TotalPrice and BookCode LIKE @BookCode and FineCode LIKE @FineCode and ReaderCode LIKE @ReaderCode and ReturnDate > @ReturnDateFrom";
                            cmd.Parameters.AddWithValue("@ReturnDateFrom", ReturnDateFrom);
                        }
                    }
                    else
                    {
                        cmd.CommandText = "SELECT IssuedBookID, DateOfIssue, ReturnDate, TotalPrice, BookCode, FineCode, ReaderCode FROM CardIndex WHERE TotalPrice LIKE @TotalPrice and BookCode LIKE @BookCode and FineCode LIKE @FineCode and ReaderCode LIKE @ReaderCode";
                    }

                    cmd.Parameters.AddWithValue("@TotalPrice", "%" + TotalPrice + "%");
                    cmd.Parameters.AddWithValue("@BookCode", "%" + BookCode);
                    cmd.Parameters.AddWithValue("@FineCode", "%" + FineCode);
                    cmd.Parameters.AddWithValue("@ReaderCode", "%" + ReaderCode);
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

        public CardIndex LoadCardIndex(SqlDataReader dataReader)
        {
            CardIndex cardIndex = new CardIndex
            {
                IssuedBookID = dataReader.GetInt32(dataReader.GetOrdinal("IssuedBookID")),
                DateOfIssue = dataReader.GetSqlDateTime(dataReader.GetOrdinal("DateOfIssue")).Value,
                BookCode = dataReader.GetInt32(dataReader.GetOrdinal("BookCode")),
                ReaderCode = dataReader.GetInt32(dataReader.GetOrdinal("ReaderCode"))
            };

            object ReturnDate = dataReader["ReturnDate"];
            if(ReturnDate != DBNull.Value)
            {
                cardIndex.ReturnDate = dataReader.GetSqlDateTime(dataReader.GetOrdinal("ReturnDate")).Value;
            }
            object FineCode = dataReader["FineCode"];
            if (FineCode != DBNull.Value)
            {
                cardIndex.FineCode = dataReader.GetInt32(dataReader.GetOrdinal("FineCode"));
            }
            object TotalPrice = dataReader["TotalPrice"];
            if (TotalPrice != DBNull.Value)
            {
                cardIndex.TotalPrice = (double)dataReader.GetSqlMoney(dataReader.GetOrdinal("TotalPrice")).Value;
            }


            return cardIndex;
        }

    }
}
