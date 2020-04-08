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
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        private int _id;

        private readonly IList<AuthorDto> authors = ProcessFactory.GetAuthorProcess().GetList();

        public AddBookWindow()
        {
            InitializeComponent();
            cbAuthor.ItemsSource = (from A in authors orderby A.FullName select A);
        }

        public void Load(BookDto book)
        {
            if (book == null)
                return;

            _id = book.Id;

            tbTitle.Text = book.Title;
            tbGenre.Text = book.Genre;
            tbCostPerDay.Text = book.CostPerDay.ToString();
            tbCollateralValue.Text = book.CollateralValue.ToString();

            if(authors != null)
            {
                foreach(AuthorDto author in authors)
                {
                    if(author.Id == book.Author.Id)
                    {
                        this.cbAuthor.SelectedItem = author;
                        break;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(tbTitle.Text == "" || tbGenre.Text == "" || tbCostPerDay.Text == "" || tbCollateralValue.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Проверка");
                return;
            }

            BookDto book = new BookDto();

            book.Title = tbTitle.Text;
            book.Genre = tbGenre.Text;
            book.CostPerDay = Convert.ToDouble(tbCostPerDay.Text);
            book.CollateralValue = Convert.ToDouble(tbCollateralValue.Text);
            book.Author = cbAuthor.SelectedItem as AuthorDto;

            if(_id == 0)
            {
                ProcessFactory.GetBookProcess().Add(book);
            }
            else
            {
                book.Id = _id;
                ProcessFactory.GetBookProcess().Update(book);
            }
            Close();
        }
    }
}
