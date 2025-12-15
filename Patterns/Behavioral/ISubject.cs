// 🚨 التعديل: تغيير النطاق ليطابق desingPatternsFinalProject.Behavioral
namespace desingPatternsFinalProject.Behavioral
{
    public interface ISubject
    {
        void Attach(IOrderObserver observer);
        void Detach(IOrderObserver observer);
        void NotifyObservers(string message);
    }
}