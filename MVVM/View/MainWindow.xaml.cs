using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
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
using MVVM.Model;
using MVVM.ViewModel;

namespace MVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
        //List<Good> Goods = new List<Good>();
        //List<Destination> Destinations = new List<Destination>();
        //List<Transport> Transports = new List<Transport>();
        //Goods.Add(new Good{Height = 12, Name = "asdaad",Weight = 3123123, Width = 123123});
        //Goods.Add(new Good{Height = 10, Name = "asdasdasdaad",Weight = 131123123, Width = 123123});
        //Goods.Add(new Good{Height = 14, Name = "xcxvvxcasdaad",Weight = 3123123, Width = 123123});
        //Goods.Add(new Good{Height = 16, Name = "123123asdaad",Weight = 31232223, Width = 123123});
        //JsonSerialization<List<Good>> serializationGoods = new JsonSerialization<List<Good>>(@"C:\Users\vladg\source\repos\MVVM\MVVM\Goods.json", Goods);
        //serializationGoods.Serialize();
           // JsonSerialization<List<Destination>> serializationDestinations = new JsonSerialization<List<Destination>>();
           // JsonSerialization<List<Transport>> serializationTransports = new JsonSerialization<List<Transport>>();
            InitializeComponent();
            this.DataContext = new Base();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            Good good = new Good{Height = Int32.Parse(HeightTextBox.Text), Name = NameTextBox.Text, Weight = 0, Width = 0};
            a(good);
            MessageBox.Show("Order added");
        }

        public void a(Good good)
        {
            JsonSerialization<List<Good>> serializationGoods =
                new JsonSerialization<List<Good>>(@"C:\Users\vladg\source\repos\MVVM\MVVM\Goods.json", null);
            List<Good> goods = serializationGoods.Deserialize();
            File.Delete(@"C:\Users\vladg\source\repos\MVVM\MVVM\Goods.json");
            goods.Add(good);
            JsonSerialization<List<Good>> serializationGood = new JsonSerialization<List<Good>>(@"C:\Users\vladg\source\repos\MVVM\MVVM\Goods.json", goods);
            serializationGood.Serialize();
        }

    }
    public class JsonSerialization<T>
{
    public string path { get; set; }
    public T obj { get; set; }
    DataContractJsonSerializer jsonFormatter;
    public JsonSerialization(string path, T obj)
    {
        this.path = path;
        this.obj = obj;

        jsonFormatter = new DataContractJsonSerializer(typeof(T));
    }
    public bool Serialize()
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            jsonFormatter.WriteObject(fs, obj);
            return true;
        }
    }
    public T Deserialize()
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            T newObject = (T)jsonFormatter.ReadObject(fs);
            return newObject;
        }
    }
}
}
