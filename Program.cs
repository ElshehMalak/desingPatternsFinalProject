using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static desingPatternsFinalProject.Program;

namespace desingPatternsFinalProject
{
    internal static class Program
    {
        public enum StoreCategory { Food, Grocery, Pharmacy, Coffee }
        /*
        public class Store
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public StoreCategory Category { get; set; }
            public double Rating { get; set; }
            public int AvgDeliveryMinutes { get; set; }
            public decimal DeliveryFee { get; set; }
            public bool IsOpen { get; set; }
            public string[] PaymentMethods { get; set; }
            public string[] Offers { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }

            public override string ToString()
            {
                return $"{Name} ({Category}) - {Rating}★ - {AvgDeliveryMinutes} min - {DeliveryFee:C}";
            }


            public Store()
            {
                // Default constructor  
            }
            public string GetDisplayText()
            {
                string status = IsOpen ? "🟢 مفتوح" : "🔴 مغلق";
                return $"{Name} - {Category} - {Rating}★ - {AvgDeliveryMinutes} دقيقة - {DeliveryFee:C} - {status}";
            }
        }
        
            public class Order
            {
            public string OrderNumber { get; set; }
            public Customer Customer { get; set; }
            public List<OrderItem> Items { get; set; }
            public DateTime OrderDate { get; set; }

            public Order(Customer customer)
            {
                OrderNumber = GenerateOrderNumber();
                Customer = customer;
                Items = new List<OrderItem>();
                OrderDate = DateTime.Now;
            }

            private string GenerateOrderNumber()
            {
                return $"ORD-{DateTime.Now:yyyyMMdd-HHmmss}";
            }

            public void AddItem(Product product, int quantity)
            {
                var item = new OrderItem(product, quantity);
                Items.Add(item);
            }

            public decimal CalculateTotal()
            {
                return Items.Sum(item => item.GetTotal());
            }

            public void DisplayOrder()
            {
                Console.WriteLine("\n🧾 فاتورة الطلب");
                Console.WriteLine("========================");
                Console.WriteLine($"رقم الطلب: {OrderNumber}");
                Console.WriteLine($"التاريخ: {OrderDate:yyyy-MM-dd HH:mm}");

                Customer.DisplayInfo();

                Console.WriteLine("\n📦 المنتجات:");
                Console.WriteLine("------------------------");
                foreach (var item in Items)
                {
                    item.DisplayInfo();
                }

                Console.WriteLine("------------------------");
                Console.WriteLine($"💰 الإجمالي: {CalculateTotal():C}");
                Console.WriteLine("========================");
            }
        }

        public class StoreManager
        {
            // Singleton Pattern
            private static StoreManager _instance;
            private List<Store> _stores;
            private int _nextStoreId = 1;

            private StoreManager()
            {
                _stores = new List<Store>();
                InitializeSampleStores();
            }

            public static StoreManager Instance
            {
                get
                {
                    if (_instance == null)
                        _instance = new StoreManager();
                    return _instance;
                }
            }

            private void InitializeSampleStores()
            {
                AddStore(new Store
                {
                    Name = "مطعم بيتزا",
                    Category = StoreCategory.Food,
                    Rating = 4.5,
                    AvgDeliveryMinutes = 30,
                    DeliveryFee = 5.00m,
                    IsOpen = true,
                    PaymentMethods = new[] { "نقدي", "بطاقة ائتمان", "STC Pay" },
                    Offers = new[] { "خصم 20% على الطلبات الأولى", "توصيل مجاني فوق 100 ريال" }
                });

                AddStore(new Store
                {
                    Name = "سوبرماركت التوفير",
                    Category = StoreCategory.Grocery,
                    Rating = 4.2,
                    AvgDeliveryMinutes = 45,
                    DeliveryFee = 7.00m,
                    IsOpen = true,
                    PaymentMethods = new[] { "نقدي", "بطاقة ائتمان" },
                    Offers = new[] { "خصم 10% على منتجات الألبان" }
                });

                AddStore(new Store
                {
                    Name = "صيدلية الدواء",
                    Category = StoreCategory.Pharmacy,
                    Rating = 4.8,
                    AvgDeliveryMinutes = 25,
                    DeliveryFee = 3.00m,
                    IsOpen = true,
                    PaymentMethods = new[] { "نقدي", "بطاقة تأمين" },
                    Offers = new string[] { }
                });
            }

            // ===== CRUD Operations =====

            // Create
            public Store AddStore(Store store)
            {
                store.Id = _nextStoreId++;
                _stores.Add(store);
                Console.WriteLine($"✅ تم إضافة متجر: {store.Name}");
                return store;
            }

            // Read All
            public List<Store> GetAllStores()
            {
                return _stores;
            }

            // Read by ID
            public Store GetStoreById(int id)
            {
                return _stores.FirstOrDefault(s => s.Id == id);
            }

            // Read by Category
            public List<Store> GetStoresByCategory(StoreCategory category)
            {
                return _stores.Where(s => s.Category == category).ToList();
            }

            // Read Open Stores
            public List<Store> GetOpenStores()
            {
                return _stores.Where(s => s.IsOpen).ToList();
            }

            // Update
            public bool UpdateStore(int id, Action<Store> updateAction)
            {
                var store = GetStoreById(id);
                if (store != null)
                {
                    updateAction(store);
                    Console.WriteLine($"✏️ تم تحديث متجر: {store.Name}");
                    return true;
                }
                return false;
            }

            // Delete
            public bool DeleteStore(int id)
            {
                var store = GetStoreById(id);
                if (store != null)
                {
                    _stores.Remove(store);
                    Console.WriteLine($"🗑️ تم حذف متجر: {store.Name}");
                    return true;
                }
                return false;
            }

            // Search
            
            public List<Store> SearchStores(string keyword)
            {
                return _stores.Where(store =>
                store.Name.ToLower().Contains(keyword) ||
                store.Category.ToString().ToLower().Contains(keyword))
                .ToList();
            }
            
            // Filter by multiple criteria
            public List<Store> FilterStores(
                StoreCategory? category = null,
                double? minRating = null,
                int? maxDeliveryTime = null,
                decimal? maxDeliveryFee = null,
                bool? isOpen = null)
            {
                var query = _stores.AsQueryable();

                if (category.HasValue)
                    query = query.Where(s => s.Category == category.Value);

                if (minRating.HasValue)
                    query = query.Where(s => s.Rating >= minRating.Value);

                if (maxDeliveryTime.HasValue)
                    query = query.Where(s => s.AvgDeliveryMinutes <= maxDeliveryTime.Value);

                if (maxDeliveryFee.HasValue)
                    query = query.Where(s => s.DeliveryFee <= maxDeliveryFee.Value);

                if (isOpen.HasValue)
                    query = query.Where(s => s.IsOpen == isOpen.Value);

                return query.ToList();
            }

            // Statistics
            public void PrintStoreStatistics()
            {
                Console.WriteLine("\n📊 ===== إحصائيات المتاجر =====");
                Console.WriteLine($"عدد المتاجر الإجمالي: {_stores.Count}");
                Console.WriteLine($"المتاجر المفتوحة: {_stores.Count(s => s.IsOpen)}");
                Console.WriteLine($"المتاجر المغلقة: {_stores.Count(s => !s.IsOpen)}");

                foreach (StoreCategory category in Enum.GetValues(typeof(StoreCategory)))
                {
                    var categoryStores = GetStoresByCategory(category);
                    Console.WriteLine($"\n{category}: {categoryStores.Count} متجر");
                    if (categoryStores.Any())
                    {
                        Console.WriteLine($"   - متوسط التقييم: {categoryStores.Average(s => s.Rating):F1}");
                        Console.WriteLine($"   - متوسط وقت التوصيل: {categoryStores.Average(s => s.AvgDeliveryMinutes)} دقيقة");
                    }
                }
                Console.WriteLine("===============================\n");
            }
        }
    /*
    public sealed class OrderManager
    {

        private static OrderManager _instance;

        private static readonly object _lock = new object();

        // 3. البيانات الداخلية
        private List<Order> _orders;
        //private Dictionary<string, Order> _orderLookup;
        private int _orderCounter;

        // 4. Constructor خاص (private) لمنع الإنشاء من الخارج
        private OrderManager()
        {
            _orders = new List<Order>();
            //_orderLookup = new Dictionary<string, Order>();
            _orderCounter = 1;
            Console.WriteLine("OrderManager initialized!");
        }

        // 5. الخاصية التي تعيد النسخة الوحيدة
        public static OrderManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new OrderManager();
                        }
                    }
                }
                return _instance;
            }
        }
        public Order CreateOrder(Customer customerName)
        {
            var newOrder = new Order(customerName);

            _orders.Add(newOrder);
            Console.WriteLine($"OrderManager: تم إنشاء طلب جديد رقم {newOrder.OrderNumber} للعميل {customerName}");

            return newOrder;
        }
        public bool AddProductToOrder(string orderNumber, Product product, int quantity)
        {
            Order order = GetOrder(orderNumber);
            if (order != null)
            {
                order.AddItem(product, quantity);
                Console.WriteLine($"➕ تم إضافة {quantity} من {product.Name} للطلب {orderNumber}");
                return true;
            }

            Console.WriteLine($"❌ الطلب {orderNumber} غير موجود");
            return false;
        }
    }
    
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }

            // Constructor
            public Customer(int id, string name, string phone)
            {
                Id = id;
                Name = name;
                Phone = phone;
            }

            // طريقة لعرض معلومات العميل
            public void DisplayInfo()
            {
                Console.WriteLine($"👤 العميل: {Name}");
                Console.WriteLine($"📞 الهاتف: {Phone}");
            }
        }
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }

            public Product(int id, string name, decimal price, string category)
            {
                Id = id;
                Name = name;
                Price = price;
                Category = category;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"🏷️ {Name} - {Price:C} ({Category})");
            }
        }
        

        public class OrderItem
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }

            public OrderItem(Product product, int quantity)
            {
                Product = product;
                Quantity = quantity;
            }

            public decimal GetTotal()
            {
                return Product.Price * Quantity;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"{Product.Name} × {Quantity} = {GetTotal():C}");
            }
        }
        */
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /*
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("🚀 نظام توصيل الطلبات - الإصدار الأول");
            Console.WriteLine("=======================================\n");

            
            Console.WriteLine("📝 إنشاء عميل جديد:");
            Customer customer = new Customer(1, "Malak Elsheh", "0501234567");
            customer.DisplayInfo();

            Console.WriteLine("\n" + new string('-', 40));

            // 2. إنشاء منتجات
            Console.WriteLine("🏷️ المنتجات المتوفرة:");
            Product pizza = new Product(1, "بيتزا كبيرة", 45.0m, "طعام");
            Product drink = new Product(2, "مشروب غازي", 8.0m, "مشروبات");
            Product burger = new Product(3, "برجر دجاج", 30.0m, "طعام");

            pizza.DisplayInfo();
            drink.DisplayInfo();
            burger.DisplayInfo();

            Console.WriteLine("\n" + new string('-', 40));

            // 3. إنشاء طلب
            Console.WriteLine("🛒 إنشاء طلب جديد:");
            Order order = new Order(customer);

            // إضافة منتجات للطلب
            order.AddItem(pizza, 2);    
            order.AddItem(drink, 3);    // 3 مشروبات
            order.AddItem(burger, 1);   // 1 برجر

            // 4. عرض تفاصيل الطلب
            order.DisplayOrder();

            Console.WriteLine("\n🎉 تم إنشاء الطلب بنجاح!");
            Console.WriteLine("\nPress any key to exit...");
            //Console.ReadKey();
            */
        }
    }
}
