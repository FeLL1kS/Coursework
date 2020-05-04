using Library.DataAccess.Entities;
using Library.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Library.DataAccess
{
    public class ReportDao : BaseDao, IReportItemDao
    {
        private static Report LoadReport(SqlDataReader reader)
        {
            Report report = new Report
            {
                Price = reader.GetDecimal(reader.GetOrdinal("mysum")),
                Count = reader.GetInt32(reader.GetOrdinal("mycount"))
            };
            try
            {
                report.Date = reader.GetDateTime(reader.GetOrdinal("mydate"));
            }
            catch (Exception ex)
            {
                report.Date = DateTime.Now.Date;
            }
            return report;
        }

        public IList<Report> GetDistributionPerDay(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CONVERT(date, DateOfIssue, 105) as mydate, ISNULL(SUM(TotalPrice), 0.0) as mysum, ISNULL(COUNT(TotalPrice), 0.0) as mycount FROM CardIndex WHERE DateOfIssue BETWEEN '1.01.2020' and '1.05.2020' GROUP BY CONVERT(date, DateOfIssue, 105)";
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                        return reports;
                    }
                }
            }
        }

        public IList<Report> GetDistributionPerMonth(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CONVERT(date, DateOfIssue, 105) as mydate, ISNULL(SUM(TotalPrice), 0.0) as mysum, ISNULL(COUNT(TotalPrice), 0.0) as mycount FROM CardIndex WHERE DateOfIssue BETWEEN '1.01.2020' and '1.05.2020' GROUP BY CONVERT(date, DateOfIssue, 105)";
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                        return reports;
                    }
                }
            }
        }

        public IList<Report> GetDistributionPerYear(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT CONVERT(date, DateOfIssue, 105) as mydate, ISNULL(SUM(TotalPrice), 0.0) as mysum, ISNULL(COUNT(TotalPrice), 0.0) as mycount FROM CardIndex WHERE DATEPART(Year, DateOfIssue) BETWEEN DATEPART(Year, '1.01.2008') and DATEPART(Year, '1.01.2020') GROUP BY CONVERT(date, DateOfIssue, 105)";
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                        return reports;
                    }
                }
            }
        }
    }
}
