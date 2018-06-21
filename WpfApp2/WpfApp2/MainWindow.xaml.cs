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
using System.Web;
using System.Data;



namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Record> RecordsArray;
        public MainWindow()
        {
            InitializeComponent();
            RecordsArray = new List<Record>();




            this.GridViewer.ItemsSource = RecordsArray;
            this.GridViewer.AutoGenerateColumns = false;
        }
        private void AddRecord(object sender, RoutedEventArgs e)
        {
            Record r = new Record();
            r.Autor = this.AutorTextBox.Text;
            r.ISBN = this.ISBNTextBox.Text;
            r.Wydawnictwo = this.WydawnictwoTextBox.Text;
            r.rokWydania = this.RokWydaniaTextBox.Text;
            r.Tytuł = this.TytułTextBox.Text;



            RecordsArray.Add(r);
            this.GridViewer.Items.Refresh();
        }
        private void EditRecord(object sender, RoutedEventArgs e)
        {
            int index = GridViewer.SelectedIndex;
            RecordsArray[index].Autor = this.AutorTextBox.Text;
            RecordsArray[index].ISBN = this.ISBNTextBox.Text;
            RecordsArray[index].Wydawnictwo = this.WydawnictwoTextBox.Text;
            RecordsArray[index].rokWydania = this.RokWydaniaTextBox.Text;
            RecordsArray[index].Tytuł = this.TytułTextBox.Text;

            this.GridViewer.Items.Refresh();
        }
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            
            table.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", SearchTextBox.Text);
        }
        private void GridViewer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = GridViewer.SelectedIndex;
            Record r = RecordsArray[index];
            
                this.AutorTextBox.Text = r.Autor;
                this.ISBNTextBox.Text = r.ISBN;
                this.WydawnictwoTextBox.Text = r.Wydawnictwo;
                this.RokWydaniaTextBox.Text = r.rokWydania;
                this.TytułTextBox.Text = r.Tytuł;
            

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

   
}
