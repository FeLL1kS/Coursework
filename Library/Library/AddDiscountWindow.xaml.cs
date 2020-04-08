using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library.DTO;
using Library.BusinessLayer;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для AddDiscountWindow.xaml
    /// </summary>
    public partial class AddDiscountWindow : Window
    {
        private int _id;

        public AddDiscountWindow()
        {
            InitializeComponent();
        }

        public void Load(DiscountsDto discount)
        {
            if (discount == null)
                return;

            _id = discount.Id;
            tbDiscountDescription.Text = discount.DiscountDescription;
            tbDiscountPercent.Text = discount.DiscountPercent.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(tbDiscountPercent.Text == "")
            {
                MessageBox.Show("Процент скидки не может быть пустым!", "Проверка");
                return;
            }

            DiscountsDto discount = new DiscountsDto
            {
                DiscountDescription = tbDiscountDescription.Text,
                DiscountPercent = Convert.ToInt32(tbDiscountPercent.Text)
            };

            if(_id == 0)
            {
                ProcessFactory.GetDiscountProcess().Add(discount);
            }
            else
            {
                discount.Id = _id;
                ProcessFactory.GetDiscountProcess().Update(discount);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
