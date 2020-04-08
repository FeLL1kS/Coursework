using Library.BusinessLayer;
using Library.DTO;
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

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для AddReaderWindow.xaml
    /// </summary>
    public partial class AddReaderWindow : Window
    {
        private int _id;

        private readonly IList<DiscountsDto> discounts = ProcessFactory.GetDiscountProcess().GetList();

        public AddReaderWindow()
        {
            InitializeComponent();
            cbDiscount.ItemsSource = (from D in discounts orderby D.DiscountPercent select D);
        }

        public void Load(ReaderDto reader)
        {
            if (reader == null)
                return;

            _id = reader.Id;
            tbFirstName.Text = reader.FirstName;
            tbSecondName.Text = reader.SecondName;
            tbPatronymic.Text = reader.Patronymic;
            tbAddress.Text = reader.Address;
            tbPhoneNumber.Text = reader.PhoneNumber;

            foreach(DiscountsDto discount in discounts)
            {
                if(discount.Id == reader.Discount.Id)
                {
                    cbDiscount.SelectedItem = discount;
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(tbFirstName.Text == "" || tbSecondName.Text == "" ||  tbAddress.Text == "" || tbPhoneNumber.Text == "" || cbDiscount.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Проверка");
                return;
            }

            ReaderDto reader = new ReaderDto
            {
                FirstName = tbFirstName.Text,
                SecondName = tbSecondName.Text,
                Patronymic = tbPatronymic.Text,
                Address = tbAddress.Text,
                PhoneNumber = tbPhoneNumber.Text,
                Discount = cbDiscount.SelectedItem as DiscountsDto
            };

            if(_id == 0)
            {
                ProcessFactory.GetReaderProcess().Add(reader);
            }
            else
            {
                reader.Id = _id;
                ProcessFactory.GetReaderProcess().Update(reader);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
