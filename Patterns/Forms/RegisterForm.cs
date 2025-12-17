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
    public partial class RegisterForm : Form
    {
        private IUserRepository _userRepo;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rbDriver_CheckedChanged(object sender, EventArgs e)
        {
            grpDriverDetails.Visible = rbDriver.Checked;
        }

        private void rbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            grpDriverDetails.Visible = !rbCustomer.Checked;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all basic fields.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // فحص رقم الهاتف
            if (_userRepo.IsPhoneExist(txtPhone.Text))
            {
                MessageBox.Show("This Phone Number is already registered!\nPlease login.", "Duplicate Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // فحص الإيميل (تأكدي أن دالة IsEmailExist موجودة في الريبوزيتوري)
            if (_userRepo.IsEmailExist(txtEmail.Text))
            {
                MessageBox.Show("This Email Address is already registered!", "Duplicate Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3️⃣ تجهيز البيانات (Factory Pattern)
            string type = rbDriver.Checked ? "Driver" : "Customer";

            try
            {
                User newUser = UserFactory.CreateUser(type, txtName.Text, txtEmail.Text, txtPhone.Text, txtPassword.Text);

                if (newUser is Driver driver)
                {
                    if (string.IsNullOrWhiteSpace(txtLicense.Text) || string.IsNullOrWhiteSpace(txtVehicle.Text))
                    {
                        MessageBox.Show("Please fill in License and Vehicle details for Drivers.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    driver.LicenseNumber = txtLicense.Text;
                    driver.VehicleType = txtVehicle.Text;
                }

                //  الحفظ في قاعدة البيانات (Repository Pattern)
                bool isSuccess = _userRepo.Register(newUser);

                if (isSuccess)
                {
                    MessageBox.Show("Account Created Successfully! 🎉", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // الانتقال لشاشة الدخول
                    LoginForm login = new LoginForm();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Registration Failed! Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}
