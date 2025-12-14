using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desingPatternsFinalProject.Patterns.Creational
{
        public class DatabaseManager
        {
            private static DatabaseManager _instance;

            // 2. نص الاتصال (هذا عنوان السيرفر متاعك)
            // ملاحظة: غيري ServerName لاسم جهازك
            public static string ConnectionString = @"Data Source=.;Initial Catalog=DeliveryProDB;Integrated Security=True";

            // كائن الاتصال
            private SqlConnection _connection;

            // 3. الكونستركتور (Private) - عشان نمنع أي حد يقول new DatabaseManager()
            private DatabaseManager()
            {
                _connection = new SqlConnection(ConnectionString);
            }

            // 4. الدالة اللي ترجع النسخة الوحيدة (Singleton Pattern)
            public static DatabaseManager GetInstance()
            {
                if (_instance == null)
                {
                    _instance = new DatabaseManager();
                }
                return _instance;
            }

            // دالة ترجع الاتصال مفتوح (يستعملوها باقي الكلاسات)
            public SqlConnection GetConnection()
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                return _connection;
            }

            // دالة لإغلاق الاتصال (النظافة مهمة)
            public void CloseConnection()
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            // دالة تنفذ أمر (Insert, Update, Delete) وترجع هل نجح ولا لا
            public void ExecuteQuery(string query)
            {
                try
                {
                    GetConnection();
                    SqlCommand cmd = new SqlCommand(query, _connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("خطأ في قاعدة البيانات: " + ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
            }

            // دالة تنفذ استعلام وترجع قيمة واحدة (تستخدم للبحث أو Login)
            public object ExecuteScalar(string query)
            {
                object result = null;
                try
                {
                    GetConnection();
                    SqlCommand cmd = new SqlCommand(query, _connection);
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("خطأ في جلب البيانات: " + ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
                return result;
            }

            // دالة التحقق من تسجيل الدخول (اللي طلبناها بدري)
            // ترجع UserType لو البيانات صح، وترجع null لو غلط
            public string CheckUserType(string email, string password)
            {
                string type = null;
                string query = $"SELECT UserType FROM Users WHERE Email = '{email}' AND PasswordHash = '{password}'";

                // استخدمنا الدالة اللي فوق عشان نختصر الكود
                object result = ExecuteScalar(query);

                if (result != null)
                {
                    type = result.ToString();
                }
                return type;
            }
        public bool IsEmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar(); // ترجع عدد مرات ظهور الايميل

                    if (count > 0)
                        return true; // موجود
                    else
                        return false; // مش موجود
                }
                catch (Exception)
                {
                    return false; // لو صار خطأ نعتبره مش موجود عشان ما يوقفش البرنامج (أو نعالجوه)
                }
            }
        }
    }
 
}
