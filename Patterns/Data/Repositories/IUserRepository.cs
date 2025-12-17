using desingPatternsFinalProject.Patterns.Creational;

namespace desingPatternsFinalProject.Patterns
{
    public interface IUserRepository
    {
        // وظيفة للتسجيل (ترجع true لو نجحت)
        bool Register(User user);

        // وظيفة للدخول (ترجع بيانات المستخدم لو صح، و null لو غلط)
        User Login(string email, string password);

        // وظيفة تتأكد لو الرقم موجود من قبل (عشان ما يتكررش)
        bool IsPhoneExist(string phone);
        bool IsEmailExist(string text);
    }
}