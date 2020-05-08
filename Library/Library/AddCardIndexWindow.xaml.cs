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
    /// Логика взаимодействия для AddCardIndexWindow.xaml
    /// </summary>
    public partial class AddCardIndexWindow : Window
    {
        private int _id;
        public string status;


        private readonly IList<BookDto> books = ProcessFactory.GetBookProcess().GetList();
        private readonly IList<ReaderDto> readers = ProcessFactory.GetReaderProcess().GetList();
        private readonly IList<FinesDto> fines = ProcessFactory.GetFinesProcess().GetList();

        public AddCardIndexWindow()
        {
            InitializeComponent();
            cbBook.ItemsSource = (from B in books orderby B.Title select B);
            cbFine.ItemsSource = (from F in fines orderby F.FinePrice select F);
            cbReader.ItemsSource = (from R in readers orderby R.SecondName select R);
        }

        public bool Load(CardIndexDto cardIndex)
        {
            if (status == "return" && cardIndex.TotalPrice != null)
            {
                return false;
            }

            if (cardIndex == null)
                return false;

            _id = cardIndex.Id;
            dpDateOfIssue.SelectedDate = cardIndex.DateOfIssue;
            dpReturnDate.SelectedDate = cardIndex.ReturnDate;

            foreach(BookDto book in books)
            {
                if(book.Id == cardIndex.Book.Id)
                {
                    cbBook.SelectedItem = book;
                    break;
                }
            }

            foreach (ReaderDto reader in readers)
            {
                if (reader.Id == cardIndex.Reader.Id)
                {
                    cbReader.SelectedItem = reader;
                    break;
                }
            }

            if(cardIndex.Fine != null)
            {
                foreach (FinesDto fine in fines)
                {
                    if (fine.Id == cardIndex.Fine.Id)
                    {
                        cbFine.SelectedItem = fine;
                        break;
                    }
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //if (dpDateOfIssue.SelectedDate == null || dpReturnDate.SelectedDate == null || cbBook.SelectedItem == null || cbFine.SelectedItem == null || cbReader == null)
            //{
            //    MessageBox.Show("Заполните все поля!", "Проверка");
            //    return;
            //}

            CardIndexDto cardIndex = new CardIndexDto
            {
                DateOfIssue = (DateTime)dpDateOfIssue.SelectedDate,
                Book = cbBook.SelectedItem as BookDto,
                Reader = cbReader.SelectedItem as ReaderDto
            };

            if(dpReturnDate.Text == "")
            {
                cardIndex.ReturnDate = null;
            }
            else
            {
                cardIndex.ReturnDate = (DateTime)dpReturnDate.SelectedDate;
            }

            if (cbFine.Text == "")
            {
                cardIndex.Fine = null;
            }
            else
            {
                cardIndex.Fine = cbFine.SelectedItem as FinesDto;
            }

            if (_id == 0)
            {
                ProcessFactory.GetCardIndexProcess().Add(cardIndex);
            }
            else
            {
                cardIndex.Id = _id;
                ProcessFactory.GetCardIndexProcess().Update(cardIndex);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(status == "issue")
            {
                dpReturnDate.IsEnabled = false;
                cbFine.IsEnabled = false;
            }
            if(status == "return")
            {
                dpDateOfIssue.IsEnabled = false;
                cbBook.IsEnabled = false;
                cbReader.IsEnabled = false;
            }
        }
    }
}
