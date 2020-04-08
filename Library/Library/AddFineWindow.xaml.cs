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
    /// Логика взаимодействия для AddFineWindow.xaml
    /// </summary>
    public partial class AddFineWindow : Window
    {
        private int _id;

        public AddFineWindow()
        {
            InitializeComponent();
        }

        public void Load(FinesDto fine)
        {
            if (fine == null)
                return;

            _id = fine.Id;
            tbFineDescription.Text = fine.FineDescription;
            tbFinePrice.Text = fine.FinePrice.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(tbFinePrice.Text == "")
            {
                MessageBox.Show("Введите цену штрафа!", "Проверка");
                return;
            }

            FinesDto fine = new FinesDto
            {
                FineDescription = tbFineDescription.Text,
                FinePrice = Convert.ToDouble(tbFinePrice.Text)
            };

            if(_id == 0)
            {
                ProcessFactory.GetFinesProcess().Add(fine);
            }
            else
            {
                fine.Id = _id;
                ProcessFactory.GetFinesProcess().Update(fine);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
