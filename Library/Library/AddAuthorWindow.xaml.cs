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
    /// Логика взаимодействия для AddAuthorWindow.xaml
    /// </summary>
    public partial class AddAuthorWindow : Window
    {
        private int _id;

        public AddAuthorWindow()
        {
            InitializeComponent();
        }

        public void Load(AuthorDto author)
        {
            if (author == null)
                return;

            _id = author.Id;

            tbFullName.Text = author.FullName;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(tbFullName.Text == "")
            {
                MessageBox.Show("ФИО не должно быть пустым", "Проверка");
                return;
            }

            AuthorDto author = new AuthorDto();
            author.FullName = tbFullName.Text;

            if(_id == 0)
            {
                ProcessFactory.GetAuthorProcess().Add(author);
            }
            else
            {
                author.Id = _id;
                ProcessFactory.GetAuthorProcess().Update(author);
            }

            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
