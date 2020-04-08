using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess.Interfaces;
using Library.DataAccess.Entities;
using System.Data.SqlClient;

namespace Library.DataAccess
{
    public class ReaderDao : BaseDao, IReaderDao
    {
        public void Add(Reader reader)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Reader(FirstName, SecondName, Patronymic, Address, PhoneNumber, DiscountCode) VALUES(@FirstName, @SecondName, @Patronymic, @Address, @PhoneNumber, @DiscountCode)";
                    cmd.Parameters.AddWithValue("@FirstName", reader.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", reader.SecondName);
                    cmd.Parameters.AddWithValue("@Patronymic", reader.Patronymic);
                    cmd.Parameters.AddWithValue("@Address", reader.Address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", reader.PhoneNumber);
                    cmd.Parameters.AddWithValue("@DiscountCode", reader.DiscountCode);
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
                    cmd.CommandText = "DELETE FROM Reader WHERE ReaderCode = @ReaderCode";
                    cmd.Parameters.AddWithValue("@ReaderCode", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Reader Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ReaderCode, FirstName, SecondName, Patronymic, Address, PhoneNumber, DiscountCode FROM Reader WHERE ReaderCode = @ReaderCode";
                    cmd.Parameters.AddWithValue("@ReaderCode", id);
                    using(var dataReader = cmd.ExecuteReader())
                    {
                        return dataReader.Read() ? LoadReader(dataReader) : null;
                    }
                }
            }
        }

        public IList<Reader> GetList()
        {
            IList<Reader> readers = new List<Reader>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ReaderCode, FirstName, SecondName, Patronymic, Address, PhoneNumber, DiscountCode FROM Reader";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            readers.Add(LoadReader(dataReader));
                        }

                        return readers;
                    }
                }
            }
        }

        public void Update(Reader reader)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Reader SET FirstName = @FirstName, SecondName = @SecondName, Patronymic = @Patronymic, Address = @Address, PhoneNumber = @PhoneNumber, DiscountCode = @DiscountCode WHERE ReaderCode = @ReaderCode";
                    cmd.Parameters.AddWithValue("@ReaderCode", reader.ReaderCode);
                    cmd.Parameters.AddWithValue("@FirstName", reader.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", reader.SecondName);
                    cmd.Parameters.AddWithValue("@Patronymic", reader.Patronymic);
                    cmd.Parameters.AddWithValue("@Address", reader.Address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", reader.PhoneNumber);
                    cmd.Parameters.AddWithValue("@DiscountCode", reader.DiscountCode);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Reader LoadReader(SqlDataReader dataReader)
        {
            Reader reader = new Reader
            {
                ReaderCode = dataReader.GetInt32(dataReader.GetOrdinal("ReaderCode")),
                FirstName = dataReader.GetString(dataReader.GetOrdinal("FirstName")),
                SecondName = dataReader.GetString(dataReader.GetOrdinal("SecondName")),
                Patronymic = dataReader.GetString(dataReader.GetOrdinal("Patronymic")),
                Address = dataReader.GetString(dataReader.GetOrdinal("Address")),
                PhoneNumber = dataReader.GetString(dataReader.GetOrdinal("PhoneNumber")),
                DiscountCode = dataReader.GetInt32(dataReader.GetOrdinal("DiscountCode"))
            };

            return reader;
        }
    }
}
