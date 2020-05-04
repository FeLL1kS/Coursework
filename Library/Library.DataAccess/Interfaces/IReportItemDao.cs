using Library.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DataAccess.Interfaces
{
    public interface IReportItemDao
    {
        IList<Report> GetDistributionPerDay(DateTime start, DateTime end);
        IList<Report> GetDistributionPerMonth(DateTime start, DateTime end);
        IList<Report> GetDistributionPerYear(DateTime start, DateTime end);
    }
}
