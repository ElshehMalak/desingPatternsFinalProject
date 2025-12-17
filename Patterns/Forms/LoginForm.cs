using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using desingPatternsFinalProject.Patterns.Creational;

namespace desingPatternsFinalProject.Patterns
{
    public partial class LoginForm : Form
    {
        private IUserRepository _userRepo;
        public LoginForm()
        {
            InitializeComponent();
            _userRepo = new UserRepository();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter Email and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                User loggedInUser = _userRepo.Login(txtEmail.Text, txtPassword.Text);

                if (loggedInUser != null)
                {
                    if (loggedInUser is Driver driverData)
                    {
                        DeliveryManagementForm driverForm = new DeliveryManagementForm();
                        driverForm.Show();
                    }
                    else if (loggedInUser is Customer customerData)
                    {
                        CustomerMainForm customerForm = new CustomerMainForm();
                        customerForm.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Email or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        /*
        try
        {
            // 2. نسأل الداتا بيس: منو هذا؟
            // (ملاحظة: تأكدي إن دالة CheckUserType موجودة في DatabaseManager)
            string role = DatabaseManager.GetInstance().CheckUserType(txtEmail.Text, txtPassword.Text);

            if (role != null)
            {
                // 3. لقيناه! نحفظو بياناته في الذاكرة (Session)

                UserSession.CurrentEmail = txtEmail.Text;

                UserSession.CurrentRole = role;

                // 4. توجيه المستخدم حسب نوعه (Smart Routing)
                this.Hide(); // نخفي شاشة الدخول

                switch (role)
                {
                    case "Customer":
                        CustomerMainForm main = new CustomerMainForm();
                        main.Show();
                        this.Hide();
                        break;

                    case "Driver":
                        // 🚨🚨 إضافة كود فتح واجهة الدليفري هنا 🚨🚨
                        DeliveryManagementForm driverDeliveryForm = new DeliveryManagementForm();
                        driverDeliveryForm.Show();
                        // Optional:
                        MessageBox.Show("Welcome, Captain! 🚚");
                        break;


                    case "Admin":
                        // 🚨🚨 إضافة كود فتح واجهة الدليفري هنا أيضاً
                        DeliveryManagementForm adminDeliveryForm = new DeliveryManagementForm();
                        adminDeliveryForm.Show();
                        // Optional:
                        MessageBox.Show("Welcome, Boss! 👔");
                        break;

                    default:
                        MessageBox.Show("Unknown Role!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show(); // نرجعو نظهروها
                        break;
                }
            }
            else
            {
                // لو الداتا بيس رجعت null يعني الايميل او الباسورد غلط
                MessageBox.Show("Invalid Email or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        
        }
        */
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
