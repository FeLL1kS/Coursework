using Library.BusinessLayer;
using Library.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private ObservableCollection<ReportItemDto> collection = new ObservableCollection<ReportItemDto>();

        private readonly List<decimal> axisYDistribution = new List<decimal>();
        private readonly List<string> axisXData = new List<string>();

        public ReportWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chart.ChartAreas.Add(new ChartArea("Default"));

            chart.Series.Add(new Series("Выданные"));
            chart.Series["Выданные"].ChartArea = "Default";

            chart.Legends.Add(new Legend("Legend"));
            chart.Legends["Legend"].DockedToChartArea = "Default";
            chart.Series["Выданные"].Legend = "Legend";
            chart.Series["Выданные"].IsVisibleInLegend = false;

            IList<CardIndexDto> cardIndices = ProcessFactory.GetCardIndexProcess().GetList();
            datePicker1.Text = cardIndices[0].DateOfIssue.ToString();
            datePicker2.Text = cardIndices[cardIndices.Count - 1].DateOfIssue.ToString();
            btn_accept_Click(sender, e);
        }

        private void DateCompare()
        {
            if(datePicker1.SelectedDate >= datePicker2.SelectedDate)
            {
                MessageBox.Show("Дата окончания интервала запроса \n меньше либо равна дате начала");
            }
        }

        private void FillCollection()
        {
            axisYDistribution.Clear();
        
            if(radioDistribution.IsChecked != null && radioDistribution.IsChecked.Value)
            {
                if(radioDay.IsChecked != null && radioDay.IsChecked.Value)
                {
                    TimeSpan ts = ((DateTime)datePicker2.SelectedDate).Subtract((DateTime)datePicker2.SelectedDate);

                    if(ts.Days > 30)
                    {
                        MessageBox.Show("Выбранные период времени слишком велик! \n Максимальная длина перода - 30 дней");
                        datePicker2.SelectedDate = ((DateTime)datePicker1.SelectedDate).AddDays(30);
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess().GetDistribution("day", (DateTime)datePicker1.SelectedDate, (DateTime)datePicker2.SelectedDate);
                }
                if (radioMonth.IsChecked != null && radioMonth.IsChecked.Value)
                {
                    TimeSpan ts = ((DateTime)datePicker2.SelectedDate).Subtract((DateTime)datePicker2.SelectedDate);

                    if (ts.Days / 30 > 12)
                    {
                        MessageBox.Show("Выбранные период времени слишком велик! \n Максимальная длина перода - 12 месяцев");
                        datePicker2.SelectedDate = ((DateTime)datePicker1.SelectedDate).AddMonths(12);
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess().GetDistribution("month", (DateTime)datePicker1.SelectedDate, (DateTime)datePicker2.SelectedDate);
                }
                if (radioYear.IsChecked != null && radioYear.IsChecked.Value)
                {
                    TimeSpan ts = ((DateTime)datePicker2.SelectedDate).Subtract((DateTime)datePicker2.SelectedDate);

                    if (ts.Days / (30 * 12) > 10)
                    {
                        MessageBox.Show("Выбранные период времени слишком велик! \n Максимальная длина перода - 10 лет");
                        datePicker2.SelectedDate = ((DateTime)datePicker1.SelectedDate).AddYears(10);
                    }

                    collection.Clear();
                    collection = ProcessFactory.GetReportProcess().GetDistribution("year", (DateTime)datePicker1.SelectedDate, (DateTime)datePicker2.SelectedDate);
                }
                foreach(ReportItemDto item in collection)
                {
                    axisYDistribution.Add(item.Price);
                }
            }
        }

        private void GraphType()
        {
            if(radioGist.IsChecked != null && radioGist.IsChecked.Value)
            {
                chart.Series["Выданные"].ChartType = SeriesChartType.Column;
            }
            
            if(radioSpline.IsChecked != null && radioSpline.IsChecked.Value)
            {
                chart.Series["Выданные"].ChartType = SeriesChartType.Line;
            }
        }

        private void DrawGraph()
        {
            axisXData.Clear();
            chart.Series["Выданные"].Points.Clear();

            foreach(ReportItemDto item in collection)
            {
                axisXData.Add(item.Date);
            }

            if(axisYDistribution.Count != 0)
            {
                chart.Series["Выданные"].IsVisibleInLegend = true;
            }
            else
            {
                chart.Series["Выданные"].IsVisibleInLegend = false;
            }

            if(axisYDistribution.Count != 0)
            {
                chart.Series["Выданные"].Points.DataBindXY(axisXData, axisYDistribution);
            }
        }

        private void btn_accept_Click(object sender, RoutedEventArgs e)
        {
            DateCompare();
            FillCollection();
            GraphType();
            DrawGraph();
        }
    }
}
