using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.DataAccess.Interfaces;
using Library.DataAccess.Entities;
using System.Data.SqlClient;

namespace Library.DataAccess
{
    public class FinesDao : BaseDao, IFinesDao
    {
        public void Add(Fines fines)
        {
            using(var conn = GetConnection())
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Fines(FineDescription, FinePrice) VALUES (@FineDescription, @FinePrice)";
                    cmd.Parameters.AddWithValue("@FineDescription", fines.FineDescription);
                    cmd.Parameters.AddWithValue("@FinePrice", fines.FinePrice);
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
                    cmd.CommandText = "DELETE FROM Fines WHERE FineCode = @FineCode";
                    cmd.Parameters.AddWithValue("@FineCode", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Fines Get(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT FineCode, FineDescription, FinePrice FROM Fines WHERE FineCode = @FineCode";
                    cmd.Parameters.AddWithValue("@FineCode", id);
                    using(var dataReader = cmd.ExecuteReader())
                    {
                        return dataReader.Read() ? LoadFine(dataReader) : null;
                    }
                }
            }
        }

        public IList<Fines> GetList()
        {
            IList<Fines> fines = new List<Fines>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT FineCode, FineDescription, FinePrice FROM Fines";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            fines.Add(LoadFine(dataReader));
                        }

                        return fines;
                    }
                }
            }
        }

        public void Update(Fines fines)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Fines SET FineDescription = @FineDescription, FinePrice = @FinePrice WHERE FineCode = @FineCode";
                    cmd.Parameters.AddWithValue("@FineCode", fines.FineCode);
                    cmd.Parameters.AddWithValue("@FineDescription", fines.FineDescription);
                    cmd.Parameters.AddWithValue("@FinePrice", fines.FinePrice);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Fines> SearchFines(string PriceFrom, string PriceTo)
        {
            IList<Fines> fines = new List<Fines>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    if(PriceTo == "")
                    {
                        cmd.CommandText = "SELECT FineCode, FineDescription, FinePrice FROM Fines WHERE FinePrice > @PriceFrom";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT FineCode, FineDescription, FinePrice FROM Fines WHERE FinePrice > @PriceFrom and FinePrice < @PriceTo";
                        cmd.Parameters.AddWithValue("@PriceTo", PriceTo);
                    }
                    cmd.Parameters.AddWithValue("@PriceFrom", PriceFrom);

                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            fines.Add(LoadFine(dataReader));
                        }

                        return fines;
                    }
                }
            }
        }

        public Fines LoadFine(SqlDataReader dataReader)
        {
            Fines fine = new Fines
            {
                FineCode = dataReader.GetInt32(dataReader.GetOrdinal("FineCode")),
                FineDescription = dataReader.GetString(dataReader.GetOrdinal("FineDescription")),
                FinePrice = (double)dataReader.GetSqlMoney(dataReader.GetOrdinal("FinePrice")).Value
            };

            return fine;
        }
    }
}
