using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.BusinessLayer;
using Library.DTO;
using Microsoft.Win32;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string status;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDatabase_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case ("Authors"):
                    this.btnDeleteA_Click();
                    break;
                case ("Books"):
                    this.btnDeleteB_Click();
                    break;
                case ("Discounts"):
                    this.btnDeleleD_Click();
                    break;
                case ("Fines"):
                    this.btnDeleleF_Click();
                    break;
                case ("Readers"):
                    this.btnDeleleR_Click();
                    break;
                case ("CardIndecies"):
                    this.btnDeleleC_Click();
                    break;
            }

            if (status == null)
            {
                MessageBox.Show("Выберите таблицу!", "Проверка");
                return;
            }

            btnRefresh_Click(sender, e);
        }

        private void btnDeleleC_Click()
        {
            CardIndexDto cardIndex = dgCardIndecies.SelectedItem as CardIndexDto;

            if (cardIndex == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление записи в картотеке");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление записи в картотеке", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                return;

            ProcessFactory.GetCardIndexProcess().Delete(cardIndex.Id);
        }

        private void btnDeleleR_Click()
        {
            ReaderDto reader = dgReaders.SelectedItem as ReaderDto;

            if (reader == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление читателя");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить читателя " + reader.FirstName + " " + reader.SecondName + "?", "Удаление книги", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                return;

            ProcessFactory.GetReaderProcess().Delete(reader.Id);
        }

        private void btnDeleleF_Click()
        {
            FinesDto fine = dgFines.SelectedItem as FinesDto;

            if (fine == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление штрафа");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить штраф?", "Удаление штрафа", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                return;

            ProcessFactory.GetFinesProcess().Delete(fine.Id);
        }

        private void btnDeleleD_Click()
        {
            DiscountsDto discount = dgDiscounts.SelectedItem as DiscountsDto;

            if (discount == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление скидки");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить скидку?", "Удаление скидки", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                return;

            ProcessFactory.GetDiscountProcess().Delete(discount.Id);
        }

        private void btnDeleteB_Click()
        {
            BookDto book = dgBooks.SelectedItem as BookDto;

            if (book == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление книги");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить книгу " + book.Title + "?", "Удаление книги", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                return;

            ProcessFactory.GetBookProcess().Delete(book.Id);
        }

        private void btnDeleteA_Click()
        {
            AuthorDto author = dgAuthors.SelectedItem as AuthorDto;

            if (author == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление автора");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить автора " + author.FullName + "?", "Удаление автора", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                return;

            ProcessFactory.GetAuthorProcess().Delete(author.Id);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case ("Authors"):
                    this.btnAddA_Click();
                    break;
                case ("Books"):
                    this.btnAddB_Click();
                    break;
                case ("Discounts"):
                    this.btnAddD_Click();
                    break;
                case ("Fines"):
                    this.btnAddF_Click();
                    break;
                case ("Readers"):
                    this.btnAddR_Click();
                    break;
            }

            if (status == null)
            {
                MessageBox.Show("Выберите таблицу!", "Проверка");
                return;
            }

            btnRefresh_Click(sender, e);
        }

        private void btnAddR_Click()
        {
            AddReaderWindow window = new AddReaderWindow();
            window.ShowDialog();
        }

        private void btnAddF_Click()
        {
            AddFineWindow window = new AddFineWindow();
            window.ShowDialog();
        }

        private void btnAddD_Click()
        {
            AddDiscountWindow window = new AddDiscountWindow();
            window.ShowDialog();
        }

        private void btnAddB_Click()
        {
            AddBookWindow window = new AddBookWindow();
            window.ShowDialog();
        }

        private void btnAddA_Click()
        {
            AddAuthorWindow window = new AddAuthorWindow();
            window.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case ("Authors"):
                    this.btnEditA_Click();
                    break;
                case ("Books"):
                    this.btnEditB_Click();
                    break;
                case ("Discounts"):
                    this.btnEditD_Click();
                    break;
                case ("Fines"):
                    this.btnEditF_Click();
                    break;
                case ("Readers"):
                    this.btnEditR_Click();
                    break;
                case ("CardIndecies"):
                    this.btnEditC_Click();
                    break;
            }

            if (status == null)
            {
                MessageBox.Show("Выберите таблицу!", "Проверка");
                return;
            }

            btnRefresh_Click(sender, e);
        }

        private void btnEditC_Click()
        {
            CardIndexDto cardIndex = dgCardIndecies.SelectedItem as CardIndexDto;

            if (cardIndex == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование записи в картотеке");
                return;
            }

            AddCardIndexWindow window = new AddCardIndexWindow();
            window.Load(cardIndex);
            window.ShowDialog();
        }

        private void btnEditR_Click()
        {
            ReaderDto reader = dgReaders.SelectedItem as ReaderDto;

            if (reader == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование читателя");
                return;
            }

            AddReaderWindow window = new AddReaderWindow();
            window.Load(reader);
            window.ShowDialog();
        }

        private void btnEditF_Click()
        {
            FinesDto fine = dgFines.SelectedItem as FinesDto;

            if (fine == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование штрафа");
                return;
            }

            AddFineWindow window = new AddFineWindow();
            window.Load(fine);
            window.ShowDialog();
        }

        private void btnEditD_Click()
        {
            DiscountsDto discount = dgDiscounts.SelectedItem as DiscountsDto;

            if (discount == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование скидки");
                return;
            }

            AddDiscountWindow window = new AddDiscountWindow();
            window.Load(discount);
            window.ShowDialog();
        }

        private void btnEditB_Click()
        {
            BookDto book = dgBooks.SelectedItem as BookDto;

            if (book == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование книги");
                return;
            }

            AddBookWindow window = new AddBookWindow();
            window.Load(book);
            window.ShowDialog();
        }

        private void btnEditA_Click()
        {
            AuthorDto author = dgAuthors.SelectedItem as AuthorDto;

            if (author == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование автора");
                return;
            }

            AddAuthorWindow window = new AddAuthorWindow();
            window.Load(author);
            window.ShowDialog();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case ("Authors"):
                    this.btnRefreshA_Click();
                    break;
                case ("Books"):
                    this.btnRefreshB_Click();
                    break;
                case ("Discounts"):
                    this.btnRefreshD_Click();
                    break;
                case ("Fines"):
                    this.btnRefreshF_Click();
                    break;
                case ("Readers"):
                    this.btnRefreshR_Click();
                    break;
                case ("CardIndecies"):
                    this.btnRefreshC_Click();
                    break;
            }

            if (status == null)
            {
                MessageBox.Show("Выберите таблицу!", "Проверка");
                return;
            }
        }

        private void btnRefreshC_Click()
        {
            dgCardIndecies.ItemsSource = ProcessFactory.GetCardIndexProcess().GetList();
        }

        private void btnRefreshR_Click()
        {
            dgReaders.ItemsSource = ProcessFactory.GetReaderProcess().GetList();
        }

        private void btnRefreshF_Click()
        {
            dgFines.ItemsSource = ProcessFactory.GetFinesProcess().GetList();
        }

        private void btnRefreshD_Click()
        {
            dgDiscounts.ItemsSource = ProcessFactory.GetDiscountProcess().GetList();
        }

        private void btnRefreshB_Click()
        {
            dgBooks.ItemsSource = ProcessFactory.GetBookProcess().GetList();
        }

        private void btnRefreshA_Click()
        {
            dgAuthors.ItemsSource = ProcessFactory.GetAuthorProcess().GetList();
        }

        private void btnTable_Click(object sender, RoutedEventArgs e)
        {
            switch(((Button)sender).Name)
            {
                case ("btnDiscounts"):
                    dgAuthors.Visibility = Visibility.Hidden;
                    dgBooks.Visibility = Visibility.Hidden;
                    dgFines.Visibility = Visibility.Hidden;
                    dgCardIndecies.Visibility = Visibility.Hidden;
                    dgReaders.Visibility = Visibility.Hidden;
                    dgDiscounts.Visibility = Visibility.Visible;
                    Search.Visibility = Visibility.Collapsed;
                    btnAdd.Visibility = Visibility.Visible;
                    btnIssueBook.Visibility = Visibility.Collapsed;
                    btnReturnBook.Visibility = Visibility.Collapsed;
                    statusLabel.Content = "Работа с таблицей: Скидки";
                    status = "Discounts";
                    break;
                case ("btnBooks"):
                    dgAuthors.Visibility = Visibility.Hidden;
                    dgDiscounts.Visibility = Visibility.Hidden;
                    dgBooks.Visibility = Visibility.Visible;
                    dgFines.Visibility = Visibility.Hidden;
                    dgCardIndecies.Visibility = Visibility.Hidden;
                    dgReaders.Visibility = Visibility.Hidden;
                    Search.Visibility = Visibility.Visible;
                    btnAdd.Visibility = Visibility.Visible;
                    btnIssueBook.Visibility = Visibility.Collapsed;
                    btnReturnBook.Visibility = Visibility.Collapsed;
                    statusLabel.Content = "Работа с таблицей: Книги";
                    status = "Books";
                    break;
                case ("btnAuthors"):
                    dgDiscounts.Visibility = Visibility.Hidden;
                    dgBooks.Visibility = Visibility.Hidden;
                    dgAuthors.Visibility = Visibility.Visible;
                    dgFines.Visibility = Visibility.Hidden;
                    dgCardIndecies.Visibility = Visibility.Hidden;
                    dgReaders.Visibility = Visibility.Hidden;
                    Search.Visibility = Visibility.Visible;
                    btnAdd.Visibility = Visibility.Visible;
                    btnIssueBook.Visibility = Visibility.Collapsed;
                    btnReturnBook.Visibility = Visibility.Collapsed;
                    statusLabel.Content = "Работа с таблицей: Авторы";
                    status = "Authors";
                    break;
                case ("btnReaders"):
                    dgDiscounts.Visibility = Visibility.Hidden;
                    dgAuthors.Visibility = Visibility.Hidden;
                    dgBooks.Visibility = Visibility.Hidden;
                    dgFines.Visibility = Visibility.Hidden;
                    dgCardIndecies.Visibility = Visibility.Hidden;
                    dgReaders.Visibility = Visibility.Visible;
                    Search.Visibility = Visibility.Visible;
                    btnAdd.Visibility = Visibility.Visible;
                    btnIssueBook.Visibility = Visibility.Collapsed;
                    btnReturnBook.Visibility = Visibility.Collapsed;
                    statusLabel.Content = "Работа с таблицей: Читатели";
                    status = "Readers";
                    break;
                case ("btnFines"):
                    dgDiscounts.Visibility = Visibility.Hidden;
                    dgAuthors.Visibility = Visibility.Hidden;
                    dgBooks.Visibility = Visibility.Hidden;
                    dgCardIndecies.Visibility = Visibility.Hidden;
                    dgReaders.Visibility = Visibility.Hidden;
                    dgFines.Visibility = Visibility.Visible;
                    Search.Visibility = Visibility.Visible;
                    btnAdd.Visibility = Visibility.Visible;
                    btnIssueBook.Visibility = Visibility.Collapsed;
                    btnReturnBook.Visibility = Visibility.Collapsed;
                    statusLabel.Content = "Работа с таблицей: Штрафы";
                    status = "Fines";
                    break;
                case ("btnCardIndecies"):
                    dgDiscounts.Visibility = Visibility.Hidden;
                    dgAuthors.Visibility = Visibility.Hidden;
                    dgBooks.Visibility = Visibility.Hidden;
                    dgFines.Visibility = Visibility.Hidden;
                    dgReaders.Visibility = Visibility.Hidden;
                    dgCardIndecies.Visibility = Visibility.Visible;
                    Search.Visibility = Visibility.Visible;
                    btnAdd.Visibility = Visibility.Collapsed;
                    btnIssueBook.Visibility = Visibility.Visible;
                    btnReturnBook.Visibility = Visibility.Visible;
                    statusLabel.Content = "Работа с таблицей: Картотека";
                    status = "CardIndecies";
                    break;
            }

            btnRefresh_Click(sender, e);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow window = new SearchWindow(status);
            {
                switch(status)
                {
                    case "Authors":
                        window.ShowDialog();
                        if(window.exec)
                        {
                            dgAuthors.ItemsSource = window.FindedAuthors;
                        }
                        break;
                    case "Books":
                        window.ShowDialog();
                        if(window.exec)
                        {
                            dgBooks.ItemsSource = window.FindedBooks;
                        }
                        break;
                    case "Fines":
                        window.ShowDialog();
                        if(window.exec)
                        {
                            dgFines.ItemsSource = window.FindedFines;
                        }
                        break;
                    case "Readers":
                        window.ShowDialog();
                        if (window.exec)
                        {
                            dgReaders.ItemsSource = window.FindedReaders;
                        }
                        break;
                    case "CardIndecies":
                        window.ShowDialog();
                        if(window.exec)
                        {
                            dgCardIndecies.ItemsSource = window.FindedCardIndecies;
                        }
                        break;
                    default:
                        MessageBox.Show("Выберите таблицу для поиска!", "Ошибка");
                        break;
                }
            }
        }

        private void ExelExporterButton_Click(object sender, RoutedEventArgs e)
        {
            List<object> grid = null;

            switch(status)
            {
                case ("Authors"):
                    grid = dgAuthors.ItemsSource.Cast<object>().ToList();
                    break;
                case ("Books"):
                    grid = dgBooks.ItemsSource.Cast<object>().ToList();
                    break;
                case ("Discounts"):
                    grid = dgDiscounts.ItemsSource.Cast<object>().ToList();
                    break;
                case ("Fines"):
                    grid = dgFines.ItemsSource.Cast<object>().ToList();
                    break;
                case ("Readers"):
                    grid = dgReaders.ItemsSource.Cast<object>().ToList();
                    break;
                case ("CardIndecies"):
                    grid = dgCardIndecies.ItemsSource.Cast<object>().ToList();
                    break;
            }

            SaveFileDialog saveXlsxDialog = new SaveFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files (.xlsx)|*.xlsx",
                AddExtension = true,
                FileName = status
            };

            bool? result = saveXlsxDialog.ShowDialog();

            if(result == true)
            {
                FileInfo xlsxFile = new FileInfo(saveXlsxDialog.FileName);

                ProcessFactory.GetReportGenerator().FillExelTableByType(grid, status, xlsxFile);
            }
        }

        private void GraphReportButton_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow window = new ReportWindow();
            window.Show();
        }

        private void btnReturnBook_Click(object sender, RoutedEventArgs e)
        {
            CardIndexDto cardIndex = dgCardIndecies.SelectedItem as CardIndexDto;

            if (cardIndex == null)
            {
                MessageBox.Show("Выберите запись", "Возврат книги");
                return;
            }

            AddCardIndexWindow window = new AddCardIndexWindow { status = "return" };
            if(window.Load(cardIndex))
            {
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите корректную запись для оформления возврата книги", "Возврат книги");
            }
            btnRefresh_Click(sender, e);
        }

        private void btnIssueBook_Click(object sender, RoutedEventArgs e)
        {   
            AddCardIndexWindow window = new AddCardIndexWindow { status = "issue" };
            window.ShowDialog();
            btnRefresh_Click(sender, e);
        }
    }
}
