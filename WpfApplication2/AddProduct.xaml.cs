using System;
using System.Linq;
using System.Windows;
using WPFAppPractice.domain;
using WPFAppPractice.WpfApplication2.Infrastructure;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private UnitOfWork uow;

        public AddProduct(UnitOfWork uow)
        {
            InitializeComponent();
            this.uow = uow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cat_cb.ItemsSource = uow.Categories.GetAllEntries().ToList();
            cat_cb.DisplayMemberPath = "Name";
            cat_cb.SelectedValuePath = "Id";
        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            if (name_tb.Text.Length == 0 || qty_tb.Text.Length == 0 || price_tb.Text.Length == 0 || cat_cb.Text.Length == 0)
            {
                MessageBox.Show("All fields are required for filling");
                return;
            }

            Product p = new Product();
            p.Name = name_tb.Text;
            p.Qty = Convert.ToInt32(qty_tb.Text);
            p.Price = Convert.ToDecimal(price_tb.Text);
            p.Category = (Category) cat_cb.SelectedItem;

            uow.Products.Insert(p);
            uow.Save();

            MessageBox.Show("New product added.");
            this.Hide();
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
