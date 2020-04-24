using Library.DataAccess.Entities;
using Library.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Library.DataAccess
{
    class AuthorDao : BaseDao, IAuthorDao
    {
        public void Add(Author author)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Author(FullName) VALUES(@FullName)";
                    cmd.Parameters.AddWithValue("@FullName", author.FullName);
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
                    cmd.CommandText = "DELETE FROM Author WHERE AuthorID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Author Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT AuthorID, FullName FROM Author WHERE AuthorID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return dataReader.Read() ? LoadAuthor(dataReader) : null;
                    }
                }
            }
        }

        public IList<Author> GetList()
        {
            IList<Author> authors = new List<Author>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT AuthorID, FullName FROM Author";

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            authors.Add(LoadAuthor(dataReader));
                        }

                        return authors;
                    }
                }
            }
        }

        public void Update(Author author)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Author SET FullName = @FullName WHERE AuthorID = @ID";
                    cmd.Parameters.AddWithValue("@ID", author.Id);
                    cmd.Parameters.AddWithValue("@FullName", author.FullName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Author> SearchAuthors(string Name)
        {
            IList<Author> authors = new List<Author>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT AuthorID, FullName FROM Author WHERE FullName LIKE @Name";
                    cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            authors.Add(LoadAuthor(dataReader));
                        }

                        return authors;
                    }
                }
            }
        }

        public Author LoadAuthor(SqlDataReader dataReader)
        {
            Author author = new Author
            {
                Id = dataReader.GetInt32(dataReader.GetOrdinal("AuthorID")),
                FullName = dataReader.GetString(dataReader.GetOrdinal("FullName"))
            };

            return author;
        }
    }
}
