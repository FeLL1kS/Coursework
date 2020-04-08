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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.BusinessLayer;
using Library.DTO;

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
            switch(status)
            {
                case ("Authors"):
                    this.btnDeleteA_Click();
                    break;
                case ("Books"):
                    this.btnDeleteB_Click();
                    break;
            }

            if (status == null)
            {
                MessageBox.Show("Выберите таблицу!", "Проверка");
                return;
            }

            btnRefresh_Click(sender, e);
        }

        private void btnDeleteB_Click()
        {
            BookDto book = dgBooks.SelectedItem as BookDto;

            if(book == null)
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

            if(author == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление автора");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить автора " + author.FullName + "?", "Удаление автора", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if(result == MessageBoxResult.No)
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
            }

            if (status == null)
            {
                MessageBox.Show("Выберите таблицу!", "Проверка");
                return;
            }

            btnRefresh_Click(sender, e);
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
            }

            if (status == null)
            {
                MessageBox.Show("Выберите таблицу!", "Проверка");
                return;
            }

            btnRefresh_Click(sender, e);
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
            }

            if (status == null)
            {
                MessageBox.Show("Выберите таблицу!", "Проверка");
                return;
            }
        }

        private void btnRefreshB_Click()
        {
            IList<BookDto> books = ProcessFactory.GetBookProcess().GetList();
            dgBooks.ItemsSource = books;
        }

        private void btnRefreshA_Click()
        {
            IList<AuthorDto> authors = ProcessFactory.GetAuthorProcess().GetList();
            dgAuthors.ItemsSource = authors;
        }

        private void btnAuthors_Click(object sender, RoutedEventArgs e)
        {
            switch(status)
            {
                case ("Books"):
                    dgBooks.Visibility = Visibility.Hidden;
                    break;
            }

            dgAuthors.Visibility = Visibility.Visible;
            statusLabel.Content = "Работа с таблицей: Авторы";
            status = "Authors";
            btnRefresh_Click(sender, e);
        }

        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case ("Authors"):
                    dgAuthors.Visibility = Visibility.Hidden;
                    break;
            }

            dgBooks.Visibility = Visibility.Visible;
            statusLabel.Content = "Работа с таблицей: Книги";
            status = "Books";
            btnRefresh_Click(sender, e);
        }
    }
}
