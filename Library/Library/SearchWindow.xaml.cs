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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public bool exec;
        public IList<AuthorDto> FindedAuthors;
        public IList<BookDto> FindedBooks;
        public IList<FinesDto> FindedFines;
        public IList<ReaderDto> FindedReaders;
        public IList<CardIndexDto> FindedCardIndecies;

        public IList<AuthorDto> AllowAuthors;
        public IList<DiscountsDto> AllowDiscounts;
        public IList<ReaderDto> AllowReaders;
        public IList<BookDto> AllowBooks;
        public IList<FinesDto> AllowFines;

        public SearchWindow(string status)
        {
            InitializeComponent();

            switch(status)
            {
                case "Authors":
                    SearchTab.SelectedIndex = 0;
                    sBook.Visibility = Visibility.Collapsed;
                    sFine.Visibility = Visibility.Collapsed;
                    sReader.Visibility = Visibility.Collapsed;
                    break;
                case "Books":
                    SearchTab.SelectedIndex = 1;
                    sAuthor.Visibility = Visibility.Collapsed;
                    sFine.Visibility = Visibility.Collapsed;
                    sReader.Visibility = Visibility.Collapsed;
                    
                    AllowAuthors = ProcessFactory.GetAuthorProcess().GetList();
                    cbAllowAuthors.ItemsSource = AllowAuthors;
                    break;
                case "Fines":
                    SearchTab.SelectedIndex = 2;
                    sAuthor.Visibility = Visibility.Collapsed;
                    sBook.Visibility = Visibility.Collapsed;
                    sReader.Visibility = Visibility.Collapsed;
                    break;
                case "Readers":
                    SearchTab.SelectedIndex = 3;
                    sAuthor.Visibility = Visibility.Collapsed;
                    sBook.Visibility = Visibility.Collapsed;
                    sFine.Visibility = Visibility.Collapsed;
                    
                    AllowDiscounts = ProcessFactory.GetDiscountProcess().GetList();
                    cbAllowsDiscount.ItemsSource = AllowDiscounts;
                    break;
                case "CardIndecies":
                    SearchTab.SelectedIndex = 4;
                    sAuthor.Visibility = Visibility.Collapsed;
                    sBook.Visibility = Visibility.Collapsed;
                    sFine.Visibility = Visibility.Collapsed;
                    sReader.Visibility = Visibility.Collapsed;

                    AllowBooks = ProcessFactory.GetBookProcess().GetList();
                    AllowFines = ProcessFactory.GetFinesProcess().GetList();
                    AllowReaders = ProcessFactory.GetReaderProcess().GetList();
                    cbAllowBooks.ItemsSource = AllowBooks;
                    cbAllowFines.ItemsSource = AllowFines;
                    cbAllowReaders.ItemsSource = AllowReaders;
                    break;
            }
        }

        public void CloseForm(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void SearchArtist(object sender, RoutedEventArgs e)
        {
            FindedAuthors = ProcessFactory.GetAuthorProcess().SearchAuthors(tbAuthorName.Text);
            exec = true;
            Close();
        }

        public void SearchBook(object sender, RoutedEventArgs e)
        {
            string AuthorID = "";

            if(cbAllowAuthors.Text != "")
            {
                foreach(AuthorDto author in AllowAuthors)
                {
                    if(cbAllowAuthors.Text == author.FullName)
                    {
                        AuthorID = author.Id.ToString();
                        break;
                    }
                }
            }

            FindedBooks = ProcessFactory.GetBookProcess().SearchBooks(tbBookTitle.Text, tbBookGenre.Text, AuthorID);
            exec = true;
            Close();
        }

        public void SearchFine(object sender, RoutedEventArgs e)
        {
            if(tbFinePriceFrom.Text == "" && tbFinePriceTo.Text != "")
            {
                MessageBox.Show("Необходимо ввести так же \"Цена от\"", "Ошибка");
                return;
            }

            FindedFines = ProcessFactory.GetFinesProcess().SearchFines(tbFinePriceFrom.Text, tbFinePriceTo.Text);
            exec = true;
            Close();
        }

        public void SearchReader(object sender, RoutedEventArgs e)
        {
            string DiscountCode = "";

            if(cbAllowsDiscount.Text != "")
            {
                foreach(DiscountsDto discount in AllowDiscounts)
                {
                    if(discount.DiscountPercent.ToString() == cbAllowsDiscount.Text)
                    {
                        DiscountCode = discount.Id.ToString();
                    }
                }
            }

            FindedReaders = ProcessFactory.GetReaderProcess().SearchReaders(tbReaderFirstName.Text, tbReaderSecondName.Text, tbReaderPatronymic.Text, DiscountCode);
            exec = true;
            Close();
        }

        public void SearchCardIndex(object sender, RoutedEventArgs e)
        {
            BookDto selectedBook = cbAllowBooks.SelectedItem as BookDto;
            FinesDto selectedFine = cbAllowFines.SelectedItem as FinesDto;
            ReaderDto selectedReader = cbAllowReaders.SelectedItem as ReaderDto;

            string BookID = "";
            string FineID = "";
            string ReaderID = "";

            if(cbAllowBooks.Text != "")
            {
                foreach(BookDto book in AllowBooks)
                {
                    if(book.Id == selectedBook.Id)
                    {
                        BookID = book.Id.ToString();
                        break;
                    }
                }
            }

            if(cbAllowReaders.Text != "")
            {
                foreach(ReaderDto reader in AllowReaders)
                {
                    if(reader.Id == selectedReader.Id)
                    {
                        ReaderID = reader.Id.ToString();
                        break;
                    }
                }
            }

            if(cbAllowFines.Text != "")
            {
                foreach(FinesDto fine in AllowFines)
                {
                    if(fine.Id == selectedFine.Id)
                    {
                        FineID = fine.Id.ToString();
                        break;
                    }
                }
            }

            if(dpReturnDateFrom.Text == "" && dpReturnDateTo.Text != "")
            {
                MessageBox.Show("Необходимо заполнить так же \"Дата возврата от\"", "Ошибка");
                return;
            }

            if(dpDateOfIssueFrom.Text == "" && dpDateOfIssueTo.Text != "")
            {
                MessageBox.Show("Необходимо заполнить так же \"Дата выдачи от\"", "Ошибка");
                return;
            }

            FindedCardIndecies = ProcessFactory.GetCardIndexProcess().SearchCardIndices(dpReturnDateFrom.Text, dpReturnDateTo.Text, dpDateOfIssueFrom.Text, dpDateOfIssueTo.Text, tbTotalPrice.Text, ReaderID, BookID, FineID);
            exec = true;
            Close();
        }
    }
}
