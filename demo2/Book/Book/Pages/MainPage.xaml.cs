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
using VariableLibrary.Models;
using VariableLibrary.Services;

namespace Book.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            CBGenres.ItemsSource = DBService.Instance.GetModelData<BookGenre>().ToList();
            CBAuthors.ItemsSource = DBService.Instance.GetModelData<Author>().ToList();
        }
        private void LVBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedBook = LVBooks.SelectedItem as VariableLibrary.Models.Book;
            if (selectedBook != null)
            {
                NavigationService.Navigate(new BookPage(selectedBook));
            }
        }

        private void Refresh()
        {
            var filtred = DBService.Instance.GetModelData<VariableLibrary.Models.Book>().ToList();
            var searchText = TBSearch.Text.ToLower();
            var selectedGenre = CBGenres.SelectedItem as BookGenre;
            var selectedAuthor = CBAuthors.SelectedItem as Author;
            if (string.IsNullOrWhiteSpace(searchText) == false)
                filtred = filtred.Where(x => x.Title.ToLower().Contains(searchText) ||
                   x.Description.ToLower().Contains(searchText)).ToList();
            if (selectedGenre != null)
                filtred = filtred.Where(x => x.GenreId == selectedGenre.Id).ToList();
            if (selectedAuthor != null)
                filtred = filtred.Where(x => x.AuthorId == selectedAuthor.Id).ToList();

            LVBooks.ItemsSource = filtred.ToList();
        }

        private void Page_Loaded(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CBGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CBAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        
    }
}
