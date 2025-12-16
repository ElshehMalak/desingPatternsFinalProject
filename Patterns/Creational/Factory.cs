using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  desingPatternsFinalProject.Behavioral;
using DeliverySystem.Patterns.Creational;
using desingPatternsFinalProject.Patterns.Creational;

using desingPatternsFinalProject.Behavioral.Strategy;
namespace DeliverySystem.Patterns.Creational
{
        public enum StoreCategory
        {
            FoodAndCoffee,   
            Shop,          
            Supermarket,    
            SpecialDelivery 
        }

        public class Store
        {
            public string Name { get; set; }
            public StoreCategory Category { get; set; }
            public List<Product> Menu { get; set; }
            public Store(string name, StoreCategory category)
            {
                Name = name;
                Category = category;
                Menu = new List<Product>();
            }
        }
    /*
        public class Customer
        {
            public string Name { get; set; }
            public string Phone { get; set; }
        }
    */
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        public class OrderItem
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
            public OrderItem(Product p, int q) { Product = p; Quantity = q; }
            public decimal GetTotal() => Product.Price * Quantity;
        }
        public abstract class Order
        {
            public string OrderNumber { get; set; }
            public User Customer { get; set; }
            public StoreCategory Category { get; set; }
            public string StoreName { get; set; }
            public List<OrderItem> Items { get; set; }
            public IOrderState CurrentState { get; set; }
            public DateTime OrderDate { get; set; }

        // =========================================================
        // 🔑 إضافة نمط Strategy (الـ Context)
        // =========================================================
        public IDeliveryStrategy DeliveryStrategy { get; private set; }
        public Order(Customer customer, StoreCategory category, string storeName)
            {
               this.Customer = customer as User;
                Category = category;
                StoreName = storeName;
                Items = new List<OrderItem>();
                OrderDate = DateTime.Now;
                OrderNumber = GenerateOrderNumber();
            // 💡 تعيين استراتيجية توصيل افتراضية (Normal) عند إنشاء الطلب
            SetDeliveryStrategy(new NormalDelivery());
            CurrentState = new PendingState();
            }
        // =========================================================
        // دوال Strategy
        // =========================================================

        public void SetDeliveryStrategy(IDeliveryStrategy strategy)
        {
            DeliveryStrategy = strategy;
        }

        // 💡 الدالة المساعدة لحساب إجمالي قيمة العناصر فقط
        public decimal CalculateItemsTotal()
        {
            return Items.Sum(i => i.GetTotal());
        }
        // 🔑 تعديل دالة CalculateTotal لاستخدام الاستراتيجية
        public decimal CalculateTotal()
        {
            decimal itemsTotal = CalculateItemsTotal();
            decimal deliveryCost = 0.0m;

            // استخدام الاستراتيجية لحساب التكلفة بناءً على النوع المختار
            if (DeliveryStrategy != null)
            {
                deliveryCost = DeliveryStrategy.CalculateDeliveryCost(this);
            }
            // إذا كان null، سيتم استخدام 0.0m لتكلفة التوصيل (نحن وضعنا Default في Constructor)

            return itemsTotal + deliveryCost;
        }

        // دالة لعرض نوع التوصيل
        public string GetDeliveryType()
        {
            return DeliveryStrategy?.DeliveryType ?? "غير محدد";
        }

        // دالة لعرض الوقت المقدر للتوصيل
        public string GetDeliveryEstimate()
        {
            return DeliveryStrategy?.GetDeliveryTimeEstimate(this) ?? "لم يتم تحديد وقت مقدر.";
        }
        private string GenerateOrderNumber()
            {
                // to simplify search in the database , we use category prefix + timestamp

                string prefix = Category.ToString().Substring(0, 2).ToUpper();
                return $"{prefix}-{DateTime.Now:MMdd-HHmm}";
            }
            public void AddItem(Product product, int quantity)
            {
                Items.Add(new OrderItem(product, quantity));
            }
             
            public abstract string ProcessOrder();

        public override string ToString()
        {
            // 🔑 إضافة استدعاء GetDeliveryType()
            return $"#{OrderNumber} | {Category} | {GetDeliveryType()} | {CalculateTotal():C}";
        }

        // 2. 🔑 الدالة المفقودة: لتعيين الحالة الأولية أو تغييرها
        public void SetState(IOrderState newState)
        {
            this.CurrentState = newState;
        }
        public void NextState()
            {
                CurrentState.Proceed(this);
            }
            public string GetStatusString()
            {
                return CurrentState.GetStatusName();
            }
    }
        public class FoodAndCoffeeOrder : Order
        {
            public FoodAndCoffeeOrder(Customer customer, string storeName) : base(customer, StoreCategory.FoodAndCoffee, storeName) { }

            public override string ProcessOrder()
            {
                return "👨‍🍳 المطعم/المقهى: جاري التحضير وتغليف الحرارة للحفاظ على الطعم.";
            }
        }
        public class ShopOrder : Order
        {
            public ShopOrder(Customer customer, string storeName) : base(customer, StoreCategory.Shop , storeName) { }

            public override string ProcessOrder()
            {
                return "🛍️ المتجر: جاري تجهيز القطع ووضعها في أكياس التسوق الأنيقة.";
            }
        }
        public class SupermarketOrder : Order
        {
            public SupermarketOrder(Customer customer, string storeName) : base(customer, StoreCategory.Supermarket, storeName) { }

            public override string ProcessOrder()
            {
                return "🛒 السوبرماركت: الموظف يقوم بجمع المنتجات من الرفوف (Picking).";
            }
        }
        public class SpecialDeliveryOrder : Order
        {
            public SpecialDeliveryOrder(Customer customer, string storeName) : base(customer, StoreCategory.SpecialDelivery , storeName) { }

            public override string ProcessOrder()
            {
                return "📦 مندوب خاص: التوجه لموقع الاستلام لاستلام الطرد وتسليمه للعميل.";
            }
        }
        public class OrderFactory
        {
            public static Order CreateOrder(StoreCategory category, Customer customer, string storeName)
            {
                switch (category)
                {
                    case StoreCategory.FoodAndCoffee:
                        return new FoodAndCoffeeOrder(customer , storeName);

                    case StoreCategory.Shop:
                        return new ShopOrder(customer, storeName);

                    case StoreCategory.Supermarket:
                        return new SupermarketOrder(customer, storeName);

                    case StoreCategory.SpecialDelivery:
                        return new SpecialDeliveryOrder(customer, storeName);

                    default:
                        throw new Exception("نوع طلب غير مدعوم");
                }
            }
        }
}
