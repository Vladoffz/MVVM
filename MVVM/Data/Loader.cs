using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Data
{
    public class Loader
    {
        public static List<T> LoadFromJson<T>()
        {
            //var path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var path = @"C:\Users\vladg\source\repos\MVVM\MVVM\Goods.json";
            List<T> _List = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            return _List;
        }
    }
}
