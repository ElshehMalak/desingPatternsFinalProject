using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desingPatternsFinalProject.Patterns.Creational
{
    // 1. الكلاس الأب (Abstract: يعني ما نقدروش نصنعو يوزر حاف، لازم يكون يا زبون يا سائق)
    public abstract class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; } // "Customer" or "Driver"
        public object Password { get; internal set; }
    }

    // 2. كلاس الزبون (يرث من User)
    public class Customer : User
    {
        public int LoyaltyPoints { get; set; }
        public Customer()
        {
            UserType = "Customer"; // نحدد النوع تلقائياً
        }
    }

    // 3. كلاس السائق (يرث من User)
    public class Driver : User
    {
        public string LicenseNumber { get; set; }
        public string VehicleType { get; set; }
        public string PlateNumber { get; set; }
        public string CurrentStatus { get; set; } // Available, Offline
    }

    //Factory Pattern - كلاس المصنع لإنشاء المستخدمين
    public static class UserFactory
    {
        public static User CreateUser(string type, string name, string email, string phone, string password)
        {
            // 1. لو طلبنا زبون
            if (type == "Customer")
            {
                return new Customer
                {
                    FullName = name,
                    Email = email,
                    Phone = phone,
                    Password = password,
                    UserType = "Customer"
                    // LoyaltyPoints حتقعد 0 افتراضياً
                };
            }
            // 2. لو طلبنا سائق
            else if (type == "Driver")
            {
                return new Driver
                {
                    FullName = name,
                    Email = email,
                    Phone = phone,
                    Password = password,
                    UserType = "Driver"
                    // بيانات السيارة والرخصة نعبوها بعدين في الفورم
                };
            }
            // 3. لو نوع غير معروف
            else
            {
                return null;
                // أو تقدري تديري: throw new Exception("نوع المستخدم غير معروف");
            }
        }
    }
}
        /*
        public static void RegisterCustomer(string name, string email, string phone, string pass)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseManager.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. إدخال في جدول Users
                    string sqlUser = @"INSERT INTO Users (FullName, Email, Phone, PasswordHash, UserType) 
                                   VALUES (@Name, @Email, @Phone, @Pass, 'Customer'); 
                                   SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdUser = new SqlCommand(sqlUser, conn, transaction);
                    cmdUser.Parameters.AddWithValue("@Name", name);
                    cmdUser.Parameters.AddWithValue("@Email", email);
                    cmdUser.Parameters.AddWithValue("@Phone", phone);
                    cmdUser.Parameters.AddWithValue("@Pass", pass);

                    int newID = Convert.ToInt32(cmdUser.ExecuteScalar());

                    // 2. إدخال في جدول Customers
                    string sqlCust = @"INSERT INTO Customers (CustomerID, LoyaltyPoints) 
                                   VALUES (@ID, 0)";

                    SqlCommand cmdCust = new SqlCommand(sqlCust, conn, transaction);
                    cmdCust.Parameters.AddWithValue("@ID", newID);

                    cmdCust.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
        */