using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer.Interfaces
{
    public interface IReportGenerator
    {
        void FillExelTableByType(IEnumerable<object> grid, string status, FileInfo xlsxFile);
    }
}
