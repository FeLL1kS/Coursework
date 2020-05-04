using Library.BusinessLayer.Converters;
using Library.BusinessLayer.Interfaces;
using Library.DataAccess;
using Library.DataAccess.Interfaces;
using Library.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer
{
    public class ReportItemProcess : IReportItemProcess
    {
        private readonly IReportItemDao _reportDao;

        public ReportItemProcess()
        {
            _reportDao = DaoFactory.GetReport();
        }

        private ObservableCollection<ReportItemDto> GetCollection(IList<ReportItemDto> items, string period, DateTime start, DateTime end)
        {
            ObservableCollection<ReportItemDto> Collection = new ObservableCollection<ReportItemDto>();
            if(items == null)
            {
                return null;
            }

            switch(period)
            {
                case "day":
                    {
                        DateTime d = start;
                        while (d <= end)
                        {
                            ReportItemDto repItem = new ReportItemDto
                            {
                                Date = d.Date.ToString("dd.MM.yyyy"),
                                Count = 0,
                                Price = 0
                            };
                            foreach (ReportItemDto item in items)
                            {
                                if (Convert.ToDateTime(item.Date).Date == d)
                                {
                                    repItem.Price += item.Price;
                                    repItem.Count += item.Count;
                                }
                            }
                            Collection.Add(repItem);

                            d = d.AddDays(1);
                        }
                        break;
                    }
                case "month":
                    {
                        DateTime d = start;
                        while (d <= end)
                        {
                            ReportItemDto repItem = new ReportItemDto
                            {
                                Date = d.Date.ToString("Y"),
                                Count = 0,
                                Price = 0
                            };
                            foreach (ReportItemDto item in items)
                            {
                                if ((Convert.ToDateTime(item.Date).Month == d.Month) && (Convert.ToDateTime(item.Date).Year == d.Year))
                                {
                                    repItem.Price += item.Price;
                                    repItem.Count += item.Count;
                                }
                            }
                            Collection.Add(repItem);

                            d = d.AddMonths(1);
                        }
                        break;
                    }
                case "year":
                    {
                        DateTime d = start;
                        while (d <= end)
                        {
                            ReportItemDto repItem = new ReportItemDto
                            {
                                Date = d.Date.ToString(),
                                Count = 0,
                                Price = 0
                            };
                            foreach (ReportItemDto item in items)
                            {
                                if (Convert.ToDateTime(item.Date).Year == d.Year)
                                {
                                    repItem.Price += item.Price;
                                    repItem.Count += item.Count;
                                }
                            }
                            Collection.Add(repItem);

                            d = d.AddYears(1);
                        }
                        break;
                    }
            }
            return Collection;
        }

        public ObservableCollection<ReportItemDto> GetDistribution(string period, DateTime start, DateTime end)
        {
            IList<ReportItemDto> ReportList;

            switch(period)
            {
                case "day":
                    ReportList = DtoConverter.Convert(_reportDao.GetDistributionPerDay(start, end));
                    break;
                case "month":
                    ReportList = DtoConverter.Convert(_reportDao.GetDistributionPerMonth(start, end));
                    break;
                case "year":
                    ReportList = DtoConverter.Convert(_reportDao.GetDistributionPerYear(start, end));
                    break;
                default:
                    ReportList = null;
                    break;
            }
            return GetCollection(ReportList, period, start, end);
        }
    }
}
