using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public class Customer
        {
            public string Name { get; set; }
            public string Phone { get; set; }
        }
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
            public Customer Customer { get; set; }
            public StoreCategory Category { get; set; }
            public string StoreName { get; set; }
            public List<OrderItem> Items { get; set; }
            public DateTime OrderDate { get; set; }

            public Order(Customer customer, StoreCategory category, string storeName)
            {
                Customer = customer;
                Category = category;
                StoreName = storeName;
                Items = new List<OrderItem>();
                OrderDate = DateTime.Now;
                OrderNumber = GenerateOrderNumber();
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
            public decimal CalculateTotal()
            {
                return Items.Sum(i => i.GetTotal());
            }
            public abstract string ProcessOrder();

            public override string ToString()
            {
                return $"#{OrderNumber} | {Category} | {CalculateTotal():C}";
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
