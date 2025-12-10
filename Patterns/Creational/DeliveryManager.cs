using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static desingPatternsFinalProject.Program;

using DeliverySystem.Patterns.Creational;

namespace DeliverySystem.Patterns.Creational
{
    public sealed class DeliveryManager
    {
        private static DeliveryManager _instance = null;
        public List<Order> OrdersDB { get; private set; }
        public List<Store> StoresDB { get; private set; }
        private DeliveryManager()
        {
            OrdersDB = new List<Order>();
            StoresDB = new List<Store>();

            var burgerKing = new Store("Burger King", StoreCategory.FoodAndCoffee);
            burgerKing.Menu.Add(new Product { Name = "Whopper Meal", Price = 25 });
            burgerKing.Menu.Add(new Product { Name = "Cheese Burger", Price = 15 });
            burgerKing.Menu.Add(new Product { Name = "Fries", Price = 8 });
            StoresDB.Add(burgerKing);

            var panda = new Store("Panda Hyper", StoreCategory.Supermarket);
            panda.Menu.Add(new Product { Name = "Milk 1L", Price = 6 });
            panda.Menu.Add(new Product { Name = "Bread", Price = 2 });
            panda.Menu.Add(new Product { Name = "Chocolate", Price = 5 });
            StoresDB.Add(panda);
        }

        public static DeliveryManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeliveryManager();
                }
                return _instance;
            }
        }

        public void AddOrder(Order orderDetails)
        {
            OrdersDB.Add(orderDetails);
        }
        public List<Order> GetAllOrders()
        {
            return OrdersDB;
        }
        public List<Store> SearchStores(StoreCategory category, string query)
        {
            return StoresDB
                .Where(s => s.Category == category && s.Name.ToLower().Contains(query.ToLower()))
                .ToList();
        }
    }
}
