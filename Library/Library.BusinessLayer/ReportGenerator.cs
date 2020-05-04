using Library.BusinessLayer.Interfaces;
using Library.DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace Library.BusinessLayer
{
    public class ReportGenerator : IReportGenerator
    {
        public void FillExelTableByType(IEnumerable<object> grid, string status, FileInfo xlsxFile)
        {
            if (grid != null)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage pck = new ExcelPackage(xlsxFile);
                var excel = pck.Workbook.Worksheets.Add(status);
                int x = 1, y = 1;

                CultureInfo cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                excel.Cells[1, 1, 1, 15].Style.Font.Bold = true;
                excel.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                excel.Cells.Style.Numberformat.Format = "General";

                Object dto = new Object();

                switch (status)
                {
                    case ("Authors"):
                        dto = new AuthorDto();
                        break;
                    case ("Books"):
                        dto = new BookDto();
                        break;
                    case ("Discounts"):
                        dto = new DiscountsDto();
                        break;
                    case ("Fines"):
                        dto = new FinesDto();
                        break;
                    case ("Readers"):
                        dto = new ReaderDto();
                        break;
                    case ("CardIndecies"):
                        dto = new CardIndexDto();
                        break;
                }

                foreach (var prop in dto.GetType().GetProperties())
                {
                    excel.Cells[y, x].Value = prop.Name.Trim();
                    x++;
                }

                foreach (var item in grid)
                {
                    y++;
                    Object itemObj = item;
                    x = 1;
                    foreach (var prop in itemObj.GetType().GetProperties())
                    {
                        object t = prop.GetValue(itemObj, null);
                        object val;

                        if (t == null)
                        {
                            val = "";
                        }
                        else
                        {
                            val = t.ToString();
                            if (t is AuthorDto)
                            {
                                val = ((AuthorDto)t).FullName;
                            }
                            if (t is BookDto)
                            {
                                val = ((BookDto)t).Title;
                            }
                            if (t is FinesDto)
                            {
                                val = ((FinesDto)t).FineDescription;
                            }
                            if (t is ReaderDto)
                            {
                                val = ((ReaderDto)t).FirstName;
                            }
                            if (t is DiscountsDto)
                            {
                                val = ((DiscountsDto)t).DiscountDescription;
                            }
                        }
                        excel.Cells[y, x].Value = val;
                        x++;
                    }
                }
                excel.Cells.AutoFitColumns();
                pck.Save();
            }
            else
            {
                MessageBox.Show("Данные не загружены!");
            }
        }
    }
}
