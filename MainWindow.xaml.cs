using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;
using System.Linq;

namespace USA_Killer
{

    public class SortItem
    {
        public string DisplayName { get; set; }
        public string PropertyName { get; set; }
        public bool Ascending { get; set; }
    }


    public partial class MainWindow : Window
    {
       Db.Ilin_TZEntities conn = new Db.Ilin_TZEntities(); 

        public static ObservableCollection<Db.Type> types { get; set; }
        public static ObservableCollection<Db.Shipment> shipments { get; set; }
        public static ObservableCollection<Db.Product> products { get; set; }
        public static ObservableCollection<Db.Agent> agents { get; set; }



        public ObservableCollection<SortItem> SortItem { get; set; } = new ObservableCollection<SortItem>()
        {
            new SortItem() { DisplayName =  "Нет сортировки", PropertyName = null, Ascending = true},
            new SortItem() { DisplayName =  "По возрастанию наименования", PropertyName = "name_agent", Ascending = true},
            new SortItem() { DisplayName =  "По убыванию наименования", PropertyName = "name_agent", Ascending = false},
            new SortItem() { DisplayName =  "По возрастанию остатка", PropertyName = "count_product", Ascending = true},
            new SortItem() { DisplayName =  "По убыванию остатка", PropertyName = "count_product", Ascending = false}
        };

       

        public MainWindow()
        {
            InitializeComponent();
            agents = new ObservableCollection<Db.Agent>(conn.Agent.ToList());
            DataContext = this;
        }

        private void _List_materials_SelectionChanged(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }


        //public void Search() 
        //{
        //    ICollectionView view = CollectionViewSource.GetDefaultView(_List_materials.ItemsSource);
        //    if (view == null) return;
        //    int viewCounter = 0;
        //    view.Filter = new System.Predicate<object>(obj => { bool isView = ((Db.Agent).obj) })
        //}

       

        private void cbSort_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var item = cbSort.SelectedItem as SortItem;

            var view = CollectionViewSource
                .GetDefaultView(_List_materials.ItemsSource);

            var direction = item.Ascending ?
                ListSortDirection.Ascending :
                ListSortDirection.Descending;

            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(item.PropertyName, direction));

        }
    }
}



