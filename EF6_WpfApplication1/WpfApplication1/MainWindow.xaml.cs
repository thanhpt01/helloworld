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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            sKetNoiDatabase db = new sKetNoiDatabase();

            var query = from p in db.dmkhoes
                        select p;

            lstProducts.ItemsSource = query;

            DataSet1 ds = new DataSet1();
            DataSet1TableAdapters.QueriesTableAdapter da = new DataSet1TableAdapters.QueriesTableAdapter();
            
        }
    }
}
