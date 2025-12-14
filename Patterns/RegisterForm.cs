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
            if (DatabaseManager.GetInstance().IsEmailExists(txtEmail.Text))
            {
                MessageBox.Show("This email address is already registered!\nPlease login or use a different email.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtEmail.Focus();
                txtEmail.SelectAll();

                return; // وقف الكود
            }

            try
            {
              
                if (rbDriver.Checked)
                {
        
                    if (string.IsNullOrWhiteSpace(txtLicense.Text) || string.IsNullOrWhiteSpace(txtVehicle.Text))
                    {
                        MessageBox.Show("Driver details (License & Vehicle) are required!", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    UserFactory.RegisterDriver(
                        txtName.Text,
                        txtEmail.Text,
                        txtPhone.Text,
                        txtPassword.Text,
                        txtLicense.Text,
                        txtVehicle.Text
                    );

                    MessageBox.Show("Driver Account Created Successfully! 🚚");
                }
                else
                {
                
                    UserFactory.RegisterCustomer(
                        txtName.Text,
                        txtEmail.Text,
                        txtPhone.Text,
                        txtPassword.Text
                    );

                    MessageBox.Show("Customer Account Created Successfully! 🍔");
                }

                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
