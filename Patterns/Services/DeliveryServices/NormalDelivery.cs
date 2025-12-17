using DeliverySystem.Patterns.Creational;
using desingPatternsFinalProject.Patterns.Creational;

namespace desingPatternsFinalProject.Behavioral.Strategy // 🔑 النطاق الصحيح
{
    public class NormalDelivery : IDeliveryStrategy
    {
        public string DeliveryType => "توصيل عادي (Normal)";
        private const decimal BaseCost = 5.0m;

        public decimal CalculateDeliveryCost(Order order)
        {
            // رسوم توصيل أساسية + 5% من إجمالي قيمة العناصر
            // نفترض وجود دالة CalculateItemsTotal في Order
            return BaseCost + (order.CalculateItemsTotal() * 0.05m);
        }

        public string GetDeliveryTimeEstimate(Order order)
        {
            return $"خلال 3 ساعات.";
        }
    }
}