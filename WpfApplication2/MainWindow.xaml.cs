using System.Linq;
using System.Windows;
using WpfApplication2.Connection;
using WPFAppPractice.domain;
using WPFAppPractice.WpfApplication2.Infrastructure;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UnitOfWork uow;

        public MainWindow()
        {
            InitializeComponent();
            this.uow = new UnitOfWork(new ProductDBContext());
        }

        private void cls_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void insert_btn_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addForm = new AddProduct(uow);
            addForm.Owner = this;
            addForm.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            productDataGrid.ItemsSource = uow.Products.GetAllEntries().ToList();
            System.Windows.Data.CollectionViewSource productViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // productViewSource.Source = [generic data source]
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (uow != null)
            {
                uow.Dispose();
            }
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            uow.Save();
            productDataGrid.ItemsSource = uow.Products.GetAllEntries().ToList();
        }

        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            int itemsCount = productDataGrid.SelectedItems.Count;
            if (itemsCount > 0)
            {
                for (int i = 0; i < itemsCount; i++)
                {
                    Product p = productDataGrid.SelectedItems[i] as Product;
                    if (p != null)
                    {
                        uow.Products.Delete(p);
                    }
                }
            }
            uow.Save();
            MessageBox.Show("Deleted "+itemsCount+" entries.");
            productDataGrid.ItemsSource = uow.Products.GetAllEntries().ToList();
        }
    }
}
