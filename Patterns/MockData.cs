using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DeliverySystem.Patterns.Creational;


namespace desingPatternsFinalProject.Patterns
{ 
    public static class MockData
    {
        public static List<Store> AllStores = new List<Store>();

        public static void InitData()
        {
            Store pizzaStore = new Store("Pizza Hut", StoreCategory.FoodAndCoffee);

            pizzaStore.Menu.Add(new Product { Name = "Cheese Pizza", Price = 25 });
            pizzaStore.Menu.Add(new Product { Name = "Pepperoni", Price = 30 });
            pizzaStore.Menu.Add(new Product { Name = "Cola", Price = 3 });

            // 2. صنع مطعم برجر
            Store burgerStore = new Store("McDonalds", StoreCategory.FoodAndCoffee);

            burgerStore.Menu.Add(new Product { Name = "Big Mac", Price = 20 });
            burgerStore.Menu.Add(new Product { Name = "Fries", Price = 10 });

            AllStores.Add(pizzaStore);
            AllStores.Add(burgerStore);
        }
    }
}
