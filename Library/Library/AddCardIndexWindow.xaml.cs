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

        public void Load(CardIndexDto cardIndex)
        {
            if (cardIndex == null)
                return;

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

            foreach (FinesDto fine in fines)
            {
                if (fine.Id == cardIndex.Fine.Id)
                {
                    cbFine.SelectedItem = fine;
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (dpDateOfIssue.SelectedDate == null || dpReturnDate.SelectedDate == null || cbBook.SelectedItem == null || cbFine.SelectedItem == null || cbReader == null)
            {
                MessageBox.Show("Заполните все поля!", "Проверка");
                return;
            }

            CardIndexDto cardIndex = new CardIndexDto
            {
                DateOfIssue = (DateTime)dpDateOfIssue.SelectedDate,
                ReturnDate = (DateTime)dpReturnDate.SelectedDate,
                Book = cbBook.SelectedItem as BookDto,
                Fine = cbFine.SelectedItem as FinesDto,
                Reader = cbReader.SelectedItem as ReaderDto
            };

            if(_id == 0)
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
    }
}
