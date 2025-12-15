using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliverySystem.Patterns.Creational;
// 🔑 أضيفي مساحة الاسم حيث يوجد كلاس DeliveryManager
using desingPatternsFinalProject.Patterns.Creational;


namespace desingPatternsFinalProject
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void btnTestObserver_Click(object sender, EventArgs e)
        {
            // الآن سيتم التعرف على DeliveryManager
            DeliveryManager.Instance.UpdateOrderStatus(
        orderId: 101,
        newStatus: "جاري الطبخ والتحضير"
      );

            MessageBox.Show("تم إطلاق إشعار الاختبار بنجاح. تحقق من شاشة العميل.", "إطلاق الإشعار");
        }

        private void btnTestObserver_Click_1(object sender, EventArgs e)
        {

            // الآن سيتم التعرف على DeliveryManager
            DeliveryManager.Instance.UpdateOrderStatus(
        orderId: 101,
        newStatus: "جاري الطبخ والتحضير"
      );

            MessageBox.Show("تم إطلاق إشعار الاختبار بنجاح. تحقق من شاشة العميل.", "إطلاق الإشعار");
        }
    }
}