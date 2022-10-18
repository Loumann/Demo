using System.Collections.ObjectModel;
using System.Windows;


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
        public static Db.Ilin_TZEntities conn = new Db.Ilin_TZEntities(); 

        public static ObservableCollection<Db.Type> types { get; set; }
        public static ObservableCollection<Db.Shipment> shipments { get; set; }
        public static ObservableCollection<Db.Product> products { get; set; }
        public static ObservableCollection<Db.Agent> _agents { get; set; }



        public ObservableCollection<SortItem> SortItem { get; set; } = new ObservableCollection<SortItem>()
        {
            new SortItem() { DisplayName =  "Нет сортировки", PropertyName = null, Ascending = true},
            new SortItem() { DisplayName =  "По возрастанию наименования", PropertyName = "Name", Ascending = true},
            new SortItem() { DisplayName =  "По убыванию наименования", PropertyName = "Name", Ascending = false},
            new SortItem() { DisplayName =  "По возрастанию остатка", PropertyName = "CountInStock", Ascending = true},
            new SortItem() { DisplayName =  "По убыванию остатка", PropertyName = "CountInStock", Ascending = false}
        };

       

        public MainWindow()
        {
            InitializeComponent();
            _agents = new ObservableCollection<Db.Agent>();
        }

        private void _List_materials_SelectionChanged(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Remote remote = new Remote();
            MainFrame.NavigationService.Navigate(remote);
        }
    }
}



