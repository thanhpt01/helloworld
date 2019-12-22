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
using System.Windows.Markup;
using System.Data.Linq;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for view.xaml
    /// </summary>
    public partial class view : Window
    {
        public view()
        {
            InitializeComponent();

            //UI = "<Label Name=\"Label1\">This is COOL!</Label>";
            //this.Content = XamlReader.Load(UI.CreateReader());
            DataClasses1DataContext db = new DataClasses1DataContext();

            ISingleResult<ParametersSchema> abc = db.GetPARAMETERS("fs_GeneralJournal");
            

            //ISingleResult<TableSchema> abc = db.GetTableSchema("dmkh");

            

            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetValue(TextBlock.TextProperty, new Binding("PARAMETER_NAME")); // Here
            //textBlockFactory.SetValue(TextBlock.BackgroundProperty, Brushes.Red);
            //textBlockFactory.SetValue(TextBlock.ForegroundProperty, Brushes.Wheat);
            textBlockFactory.SetValue(TextBlock.FontSizeProperty, 18.0);

            var template = new DataTemplate();
            template.VisualTree = textBlockFactory;

            //lv.ItemTemplate = template;

            //StringBuilder sb = new StringBuilder();
            //sb.Append("<ListView.ItemTemplate><DataTemplate>");

            //foreach (ParametersSchema p in abc)
            //{
            //    sb.Append("<TextBlock Text=\"{Binding " + p.PARAMETER_NAME + "}\" />");
            //}

            lv.ItemsSource = abc;
            
        }

        public Style GetDatatemplateObject(ParametersSchema obj)
        {
            return null;
        }
    }

     
}
