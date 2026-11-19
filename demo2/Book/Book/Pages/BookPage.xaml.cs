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
using VariableLibrary.Services;

namespace Book.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        VariableLibrary.Models.Book context;
        public BookPage(VariableLibrary.Models.Book selectedBook)
        {
            InitializeComponent();
            context = selectedBook;
            DataContext = context;
            LVBooks.ItemsSource = DBService.Instance.GetModelData<VariableLibrary.Models.Book>().Where(x => x.GenreId == context.GenreId && x.Id != context.Id).ToList();
        }


        private void LVBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedBook = LVBooks.SelectedItem as VariableLibrary.Models.Book;
            if (selectedBook != null)
            {
                NavigationService.Navigate(new BookPage(selectedBook));
            }
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
