namespace desingPatternsFinalProject
{
    partial class DeliveryManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnStartCooking = new System.Windows.Forms.Button();
            this.btnShipOrder = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.btnRefreshAdmin = new System.Windows.Forms.Button();
            this.btnOpenTrackerTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.BackgroundColor = System.Drawing.Color.Azure;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.GridColor = System.Drawing.SystemColors.ControlText;
            this.dgvOrders.Location = new System.Drawing.Point(12, 41);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 26;
            this.dgvOrders.Size = new System.Drawing.Size(565, 182);
            this.dgvOrders.TabIndex = 0;
            // 
            // btnStartCooking
            // 
            this.btnStartCooking.Location = new System.Drawing.Point(87, 330);
            this.btnStartCooking.Name = "btnStartCooking";
            this.btnStartCooking.Size = new System.Drawing.Size(126, 53);
            this.btnStartCooking.TabIndex = 1;
            this.btnStartCooking.Text = "بدء التحضير 🧑‍🍳";
            this.btnStartCooking.UseVisualStyleBackColor = true;
            // 
            // btnShipOrder
            // 
            this.btnShipOrder.Location = new System.Drawing.Point(301, 330);
            this.btnShipOrder.Name = "btnShipOrder";
            this.btnShipOrder.Size = new System.Drawing.Size(146, 53);
            this.btnShipOrder.TabIndex = 2;
            this.btnShipOrder.Text = "بدء الشحن 🚚";
            this.btnShipOrder.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnCompleteOrder
            // 
            this.btnCompleteOrder.Location = new System.Drawing.Point(521, 330);
            this.btnCompleteOrder.Name = "btnCompleteOrder";
            this.btnCompleteOrder.Size = new System.Drawing.Size(129, 53);
            this.btnCompleteOrder.TabIndex = 4;
            this.btnCompleteOrder.Text = "تم التسليم ✅";
            this.btnCompleteOrder.UseVisualStyleBackColor = true;
            // 
            // btnRefreshAdmin
            // 
            this.btnRefreshAdmin.Location = new System.Drawing.Point(583, 121);
            this.btnRefreshAdmin.Name = "btnRefreshAdmin";
            this.btnRefreshAdmin.Size = new System.Drawing.Size(176, 34);
            this.btnRefreshAdmin.TabIndex = 5;
            this.btnRefreshAdmin.Text = "تحديث القائمة 🔄";
            this.btnRefreshAdmin.UseVisualStyleBackColor = true;
            this.btnRefreshAdmin.Click += new System.EventHandler(this.btnRefreshAdmin_Click_1);
            // 
            // btnOpenTrackerTest
            // 
            this.btnOpenTrackerTest.Location = new System.Drawing.Point(583, 194);
            this.btnOpenTrackerTest.Name = "btnOpenTrackerTest";
            this.btnOpenTrackerTest.Size = new System.Drawing.Size(196, 65);
            this.btnOpenTrackerTest.TabIndex = 6;
            this.btnOpenTrackerTest.Text = "فتح نافذة التتبع (اختبار)";
            this.btnOpenTrackerTest.UseVisualStyleBackColor = true;
            this.btnOpenTrackerTest.Click += new System.EventHandler(this.btnOpenTrackerTest_Click);
            // 
            // DeliveryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOpenTrackerTest);
            this.Controls.Add(this.btnRefreshAdmin);
            this.Controls.Add(this.btnCompleteOrder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnShipOrder);
            this.Controls.Add(this.btnStartCooking);
            this.Controls.Add(this.dgvOrders);
            this.Name = "DeliveryManagementForm";
            this.Text = "DeliveryManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnStartCooking;
        private System.Windows.Forms.Button btnShipOrder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCompleteOrder;
        private System.Windows.Forms.Button btnRefreshAdmin;
        private System.Windows.Forms.Button btnOpenTrackerTest;
    }
}