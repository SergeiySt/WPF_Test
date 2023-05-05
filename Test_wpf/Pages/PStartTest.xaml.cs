using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Test_wpf.Pages
{
    /// <summary>
    /// Interaction logic for PStartTest.xaml
    /// </summary>
    public partial class PStartTest : Page
    {
        public PStartTest()
        {
            InitializeComponent();
        }

        private void buttonBegin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(textBoxSurname.Text))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля!.", "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                CUsers user5 = new CUsers(textBoxName.Text, textBoxSurname.Text);
                NavigationService.Navigate(new PTest(user5));
            }
        }
    }
}
