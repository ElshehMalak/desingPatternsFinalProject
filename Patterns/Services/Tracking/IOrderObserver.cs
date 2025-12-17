using System;

namespace desingPatternsFinalProject.Behavioral
{
    // 🚨 التعديل: تغيير اسم الواجهة لتصبح أكثر دلالة (IOrderObserver)
    public interface IOrderObserver
    {
        // 🚨 التعديل: يجب أن تستقبل رقم الطلب ورسالة التحديث
        // لكي يتمكن المراقب (OrderTrackingForm) من التحقق ما إذا كان هذا التحديث يخصه.
        void Update(int updatedOrderId, string statusMessage);
    }
}