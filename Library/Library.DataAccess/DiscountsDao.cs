using Library.DataAccess.Interfaces;
using Library.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows;

namespace Library.DataAccess
{
    class DiscountsDao : BaseDao, IDiscountsDao
    {
        public void Add(Discounts discount)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Discounts(DiscountDescription, DiscountPercent) VALUES(@DiscountDescription, @DiscountPercent)";
                    cmd.Parameters.AddWithValue("@DiscountDescription", discount.DiscountDescription); 
                    cmd.Parameters.AddWithValue("@DiscountPercent", discount.DiscountPercent); 
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
                    cmd.CommandText = "DELETE FROM Discounts WHERE DiscountCode = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно удалить скидку, так как она используется", "Ошибка");
                    }
                }
            }
        }

        public Discounts Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT DiscountCode, DiscountDescription, DiscountPercent FROM Discounts WHERE DiscountCode = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    using(var dataReader = cmd.ExecuteReader())
                    {
                        return dataReader.Read() ? DiscountLoad(dataReader) : null;
                    }
                }
            }
        }

        public IList<Discounts> GetList()
        {
            IList<Discounts> discounts = new List<Discounts>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT DiscountCode, DiscountDescription, DiscountPercent FROM Discounts";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            discounts.Add(DiscountLoad(dataReader));
                        }

                        return discounts;
                    }
                }
            }
        }

        public void Update(Discounts discount)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Discounts SET DiscountDescription = @DiscountDescription, DiscountPercent = @DiscountPercent WHERE DiscountCode = @ID";
                    cmd.Parameters.AddWithValue("@ID", discount.DiscountCode);
                    cmd.Parameters.AddWithValue("@DiscountDescription", discount.DiscountDescription);
                    cmd.Parameters.AddWithValue("@DiscountPercent", discount.DiscountPercent);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Discounts DiscountLoad(SqlDataReader dataReader)
        {
            Discounts discount = new Discounts
            {
                DiscountCode = dataReader.GetInt32(dataReader.GetOrdinal("DiscountCode")),
                DiscountDescription = dataReader.GetString(dataReader.GetOrdinal("DiscountDescription")),
                DiscountPercent = dataReader.GetInt32(dataReader.GetOrdinal("DiscountPercent"))
            };

            return discount;
        }
    }
}
