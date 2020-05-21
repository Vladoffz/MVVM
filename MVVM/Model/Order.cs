using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Data;

namespace MVVM.Model
{
    class Order
    {
        public static List<Good> Goods = new List<Good>();
        public static List<Destination> Destinations = new List<Destination>();
        public static List<Transport> Transports = new List<Transport>();
        public static List<UserOrder> UserOrders = new List<UserOrder>();

        public static void LoadGoods()
        {

            List<Good> GoodsJson = Loader.LoadFromJson<Good>();

            foreach (Good G in GoodsJson)
            {
                Order.Goods.Add(G);
            }

        }

        public static List<string> GetGoods()
        {
            List<String> Goods = new List<String>();

            foreach (Good G in Order.Goods)
            {
                Goods.Add(G.Name);
            }

            return Goods;
        }

        public static void LoadTransports()
        {

            List<Transport> TransportsJson = Loader.LoadFromJson<Transport>();

            foreach (Transport T in TransportsJson)
            {
                Order.Transports.Add(T);
            }

        }

        public static List<string> GetTransports()
        {
            List<String> Transports = new List<String>();

            foreach (Transport T in Order.Transports)
            {
                Transports.Add(T.Name);
            }

            return Transports;
        }

        public static void LoadDestinations()
        {

            List<Destination> DestinationsJson = Loader.LoadFromJson<Destination>();

            foreach (Destination D in DestinationsJson)
            {
                Order.Destinations.Add(D);
            }

        }

        public static List<string> GetDestinations()
        {
            List<String> Destinations = new List<String>();

            foreach (Destination D in Order.Destinations)
            {
                Destinations.Add(D.Name);
            }

            return Destinations;
        }

        public static void AddOrder(string GoodName)
        {
            foreach (Good G in Order.Goods)
            {
                foreach (Destination D in Order.Destinations)
                {
                    foreach (Transport T in Order.Transports)
                    {
                        if (G.Name == GoodName)
                        {
                            UserOrder Order_N = new UserOrder();
                            Order_N.Good = G;
                            Order_N.Destination = D;
                            Order_N.Transport = T;
                            Order_N.Date = DateTime.Now;

                            Order.UserOrders.Add(Order_N);

                            break;
                        }

                    }
                }
            }
        }

    }
}
    

