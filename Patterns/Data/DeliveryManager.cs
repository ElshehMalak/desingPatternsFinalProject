using desingPatternsFinalProject.Patterns;
using System.Collections.Generic;
using System.Linq;
using desingPatternsFinalProject.Behavioral;
using DeliverySystem.Patterns.Creational;
// 🚨 يجب إضافة مساحة الاسم الخاصة بالـ State Pattern هنا لتجنب خطأ NextState()
using desingPatternsFinalProject.Patterns;
// 🔑 يجب التأكد من مساحة اسم OrderFactory، أفترض أنها في:
using DeliverySystem.Patterns.Creational;
using static DeliverySystem.Patterns.Creational.ShopOrder;


namespace desingPatternsFinalProject.Patterns.Creational
{
    public sealed class DeliveryManager
    {
        private static DeliveryManager _instance = null;
        //🔑 أضيفي هذا العداد لضمان فرادة وأمان رقم الطلب
    private int _nextOrderNumber = 1003;
        public List<Order> OrdersDB { get; private set; } = new List<Order>();
        public List<Store> StoresDB { get; private set; } = new List<Store>();
        private Dictionary<int, List<IOrderObserver>> _orderObservers;


        private DeliveryManager()
        {
           
            OrdersDB = new List<Order>();
            StoresDB = new List<Store>();
            _orderObservers = new Dictionary<int, List<IOrderObserver>>();
/*
            // تهيئة بيانات المتاجر
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

            // 🔑 الاستدعاء يحدث هنا:
            InitializeDummyOrders();
            */
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

        // =========================================================
        // دالة إضافة البيانات التجريبية (تم تصحيح مشكلة عدم ظهور الطلبات)
        // =========================================================
        private void InitializeDummyOrders()
        {
            // ❌ تم إزالة: if (OrdersDB.Count > 0) return;
            // 🔑 التصحيح: مسح القائمة لضمان إعادة تعبئتها في كل مرة
            OrdersDB.Clear();
            /*
            Customer customer1 = new Customer { FullName = "أحمد محمد", Phone = "091xxxxxxx" };
            Customer customer2 = new Customer { FullName = "فاطمة علي", Phone = "092xxxxxxx" };

            // الطلب رقم 1: حالة قيد التحضير (Cooking)
            Order order1 = OrderFactory.CreateOrder(customer1, "مطعم الوجبة السريعة");
            order1.AddItem(new Product { Name = "بيتزا", Price = 15.0m }, 1);
            order1.AddItem(new Product { Name = "مشروب غازي", Price = 2.0m }, 2);
            order1.OrderNumber = "1001";

            order1.NextState();
            order1.NextState();

            OrdersDB.Add(order1);


            // الطلب رقم 2: حالة في الطريق (OnTheWay)
            Order order2 = OrderFactory.CreateOrder(StoreCategory.Supermarket, customer2, "سوبر ماركت الإسراء");
            order2.AddItem(new Product { Name = "خبز", Price = 1.0m }, 3);
            order2.OrderNumber = "1002";

            order2.NextState();
            order2.NextState();
            order2.NextState();

            OrdersDB.Add(order2);
            */
        }

        // =========================================================
        // دوال Observer Pattern
        // =========================================================

        public void AddOrder(Order orderDetails)
        {
            // 1. توليد رقم طلب فريد وزيادة العداد
            // سنقوم بالتحويل إلى string لأن خاصية OrderNumber لديك هي string
            string newOrderNum = _nextOrderNumber++.ToString();

            // 2. تعيين رقم الطلب للكائن (لحل System.FormatException)
            orderDetails.OrderNumber = newOrderNum;

            // 3. تعيين الحالة الأولية (Pending) إذا لم يتم تعيينها مسبقاً
            // (لضمان أن الطلب الجديد يبدأ من البداية)
            if (orderDetails.CurrentState == null)
            {
                // 🚨 يجب التأكد أن لديكِ كلاس اسمه PendingState في مساحة الاسم الصحيحة
                // if (desingPatternsFinalProject.Patterns.PendingState != null)
                orderDetails.SetState(new PendingState());
            }

            // 4. إضافة الطلب
            OrdersDB.Add(orderDetails);
            
            // ملاحظة: لا حاجة لإشعار المراقبين هنا؛ سيتم الإشعار عند تغيير الحالة لاحقاً
        }

        public void Attach(IOrderObserver observer, int orderId)
        {
            if (!_orderObservers.ContainsKey(orderId))
            {
                _orderObservers[orderId] = new List<IOrderObserver>();
            }

            if (!_orderObservers[orderId].Contains(observer))
            {
                _orderObservers[orderId].Add(observer);
            }
        }

        public void Detach(IOrderObserver observer, int orderId)
        {
            if (_orderObservers.ContainsKey(orderId))
            {
                _orderObservers[orderId].Remove(observer);
                if (_orderObservers[orderId].Count == 0)
                {
                    _orderObservers.Remove(orderId);
                }
            }
        }

        public void NotifyObservers(int orderId, string message)
        {
            if (_orderObservers.ContainsKey(orderId))
            {
                foreach (var observer in _orderObservers[orderId].ToList())
                {
                    observer.Update(orderId, message);
                }
            }
        }

        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            NotifyObservers(orderId, newStatus);
        }
    }
}