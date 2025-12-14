namespace desingPatternsFinalProject
{
    partial class CustomerMainForm
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
            this.btnOpenStore = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnRestaurants = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnSupermarket = new System.Windows.Forms.Button();
            this.btnCourierService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenStore
            // 
            this.btnOpenStore.Location = new System.Drawing.Point(160, 341);
            this.btnOpenStore.Name = "btnOpenStore";
            this.btnOpenStore.Size = new System.Drawing.Size(211, 37);
            this.btnOpenStore.TabIndex = 6;
            this.btnOpenStore.Text = "Open Store";
            this.btnOpenStore.UseVisualStyleBackColor = true;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(12, 81);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(228, 24);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "What would you like?";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(65, 16);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(442, 20);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(87, 35);
            this.btnLogOut.TabIndex = 10;
            this.btnLogOut.Text = "LogOut";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnRestaurants
            // 
            this.btnRestaurants.Location = new System.Drawing.Point(68, 122);
            this.btnRestaurants.Name = "btnRestaurants";
            this.btnRestaurants.Size = new System.Drawing.Size(160, 83);
            this.btnRestaurants.TabIndex = 11;
            this.btnRestaurants.Text = "Restaurants & Cafes";
            this.btnRestaurants.UseVisualStyleBackColor = true;
            this.btnRestaurants.Click += new System.EventHandler(this.btnRestaurants_Click);
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(305, 122);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(158, 83);
            this.btnStore.TabIndex = 12;
            this.btnStore.Text = "Stores 🛍️";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnSupermarket
            // 
            this.btnSupermarket.Location = new System.Drawing.Point(68, 223);
            this.btnSupermarket.Name = "btnSupermarket";
            this.btnSupermarket.Size = new System.Drawing.Size(160, 81);
            this.btnSupermarket.TabIndex = 13;
            this.btnSupermarket.Text = "Supermarket 🛒";
            this.btnSupermarket.UseVisualStyleBackColor = true;
            this.btnSupermarket.Click += new System.EventHandler(this.btnSupermarket_Click);
            // 
            // btnCourierService
            // 
            this.btnCourierService.Location = new System.Drawing.Point(305, 223);
            this.btnCourierService.Name = "btnCourierService";
            this.btnCourierService.Size = new System.Drawing.Size(158, 81);
            this.btnCourierService.TabIndex = 14;
            this.btnCourierService.Text = "Courier Service 📦";
            this.btnCourierService.UseVisualStyleBackColor = true;
            this.btnCourierService.Click += new System.EventHandler(this.btnCourierService_Click);
            // 
            // CustomerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 408);
            this.Controls.Add(this.btnCourierService);
            this.Controls.Add(this.btnSupermarket);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.btnRestaurants);
            this.Controls.Add(this.btnOpenStore);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblWelcome);
            this.Name = "CustomerMainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnOpenStore;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnRestaurants;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnSupermarket;
        private System.Windows.Forms.Button btnCourierService;
    }
}

