using Library.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer.Interfaces
{
    public interface IReportItemProcess
    {
        ObservableCollection<ReportItemDto> GetDistribution(string period, DateTime start, DateTime end);
    }
}
