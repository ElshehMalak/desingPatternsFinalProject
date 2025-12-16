using DeliverySystem.Patterns.Creational;
using desingPatternsFinalProject.Patterns.Creational;

namespace desingPatternsFinalProject.Behavioral.Strategy // 🔑 النطاق الصحيح
{
    // استراتيجية التوصيل السريع
    public class ExpressDelivery : IDeliveryStrategy
    {
        public string DeliveryType => "توصيل سريع (Express)";

        // تكلفة أساسية عالية
        private const decimal BaseCost = 15.0m;

        public decimal CalculateDeliveryCost(Order order)
        {
            // نستخدم تكلفة ثابتة مرتفعة بغض النظر عن إجمالي الطلب
            return BaseCost;
        }

        public string GetDeliveryTimeEstimate(Order order)
        {
            // وقت تقديري قصير
            return $"خلال 45 دقيقة.";
        }
    }
}