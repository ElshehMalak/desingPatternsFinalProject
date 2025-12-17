using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using desingPatternsFinalProject.Patterns.Creational;
 
namespace desingPatternsFinalProject.Patterns.Repository
{
    public class UserRepository : IUserRepository
    {
        // 1️⃣ دالة التسجيل (The Transaction Logic)
        // عدلناها عشان تسجل في جدول Users وبعدين تسجل في Customer أو Driver
        public bool Register(User user)
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                conn.Open();
                // الـ Transaction زي "العهد": يا يتنفذ كل شي يا نلغوا كل شي
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // أ. إضافة المستخدم العام
                    string queryUser = @"INSERT INTO Users (FullName, Phone, Email, Password, UserType) 
                                     VALUES (@Name, @Phone, @Email, @Pass, @Type);
                                     SELECT SCOPE_IDENTITY();"; // رجعلي الـ ID الجديد

                    SqlCommand cmdUser = new SqlCommand(queryUser, conn, transaction);
                    cmdUser.Parameters.AddWithValue("@Name", user.FullName);
                    cmdUser.Parameters.AddWithValue("@Phone", user.Phone);
                    cmdUser.Parameters.AddWithValue("@Email", user.Email);
                    cmdUser.Parameters.AddWithValue("@Pass", user.Password);
                    cmdUser.Parameters.AddWithValue("@Type", user.UserType);

                    int newId = Convert.ToInt32(cmdUser.ExecuteScalar());

                    // ب. إضافة التفاصيل حسب النوع
                    if (user is Driver driver)
                    {
                        string queryDriver = @"INSERT INTO Drivers (DriverID, LicenseNumber, VehicleModel) 
                                           VALUES (@ID, @License, @Vehicle)";
                        SqlCommand cmdDriver = new SqlCommand(queryDriver, conn, transaction);
                        cmdDriver.Parameters.AddWithValue("@ID", newId);
                        // نتأكد إن البيانات مش فارغة
                        cmdDriver.Parameters.AddWithValue("@License", driver.LicenseNumber ?? "");
                        cmdDriver.Parameters.AddWithValue("@Vehicle", driver.VehicleType ?? "");
                        cmdDriver.ExecuteNonQuery();
                    }
                    else if (user is Customer customer)
                    {
                        string queryCust = @"INSERT INTO Customers (CustomerID, LoyaltyPoints) VALUES (@ID, 0)";
                        SqlCommand cmdCust = new SqlCommand(queryCust, conn, transaction);
                        cmdCust.Parameters.AddWithValue("@ID", newId);
                        cmdCust.ExecuteNonQuery();
                    }

                    transaction.Commit(); // اعتمد التسجيل
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // الغي العملية لو صار خطأ
                    return false;
                }
            }
        }

        public User Login(string email, string password)
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE Email = @Email AND PasswordHash = @Pass";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Pass", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string type = reader["UserType"].ToString();
                    User user = null;

                    if (type == "Customer") user = new Customer();
                    else if (type == "Driver") user = new Driver();
                    else return null;

                    user.ID = (int)reader["UserID"];
                    user.FullName = reader["FullName"].ToString();
                    user.Phone = reader["Phone"].ToString(); 
                    user.Email = reader["Email"].ToString();
                    user.UserType = type;

                    return user;
                }

                return null;
            }
        }
        public bool IsPhoneExist(string phone)
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                // تصحيح بسيط: ExecuteScalar يرجع object، لازم تحويل دقيق
                string query = "SELECT COUNT(1) FROM Users WHERE Phone = @Phone";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Phone", phone);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public bool IsEmailExist(string email)
        {
            using (SqlConnection conn = DatabaseManager.GetConnection())
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
