namespace desingPatternsFinalProject
{
    partial class mainForm
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
            this.titleText = new System.Windows.Forms.Label();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnTestObserver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleText
            // 
            this.titleText.AutoSize = true;
            this.titleText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titleText.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.titleText.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleText.Location = new System.Drawing.Point(12, 9);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(271, 30);
            this.titleText.TabIndex = 0;
            this.titleText.Text = "Smart Delivery System";
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(300, 87);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(163, 70);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "Food";
            this.btn2.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(70, 87);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(163, 70);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "Coffee";
            this.btn1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(70, 186);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 63);
            this.button3.TabIndex = 3;
            this.button3.Text = "Pharmacy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(300, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 63);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnTestObserver
            // 
            this.btnTestObserver.Location = new System.Drawing.Point(478, 278);
            this.btnTestObserver.Name = "btnTestObserver";
            this.btnTestObserver.Size = new System.Drawing.Size(75, 23);
            this.btnTestObserver.TabIndex = 5;
            this.btnTestObserver.Text = "test";
            this.btnTestObserver.UseVisualStyleBackColor = true;
            this.btnTestObserver.Click += new System.EventHandler(this.btnTestObserver_Click_1);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 342);
            this.Controls.Add(this.btnTestObserver);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.titleText);
            this.Name = "mainForm";
            this.Text = "mainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnTestObserver;
    }
}