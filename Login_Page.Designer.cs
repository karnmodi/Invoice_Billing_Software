namespace Invoice_Billing_Software
{
    partial class Login_Page
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Page));
            this.Date_Label = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Time_Label = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Business_Logo = new System.Windows.Forms.PictureBox();
            this.Lbl_Business_Line = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.curved_Rectangle1 = new Invoice_Billing_Software.Curved_Ractangle.Curved_Rectangle();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.Lbl_Password = new System.Windows.Forms.Label();
            this.Lbl_Username = new System.Windows.Forms.Label();
            this.Lbl_Login = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Business_Logo)).BeginInit();
            this.curved_Rectangle1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Date_Label
            // 
            this.Date_Label.AutoSize = true;
            this.Date_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_Label.Location = new System.Drawing.Point(1142, 104);
            this.Date_Label.Name = "Date_Label";
            this.Date_Label.Size = new System.Drawing.Size(264, 42);
            this.Date_Label.TabIndex = 5;
            this.Date_Label.Text = "DD/MM/YYYY";
            // 
            // Time_Label
            // 
            this.Time_Label.AutoSize = true;
            this.Time_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_Label.Location = new System.Drawing.Point(1137, 171);
            this.Time_Label.Name = "Time_Label";
            this.Time_Label.Size = new System.Drawing.Size(235, 42);
            this.Time_Label.TabIndex = 4;
            this.Time_Label.Text = "00:00:00 YY";
            // 
            // Business_Logo
            // 
            this.Business_Logo.Image = ((System.Drawing.Image)(resources.GetObject("Business_Logo.Image")));
            this.Business_Logo.Location = new System.Drawing.Point(441, 69);
            this.Business_Logo.Name = "Business_Logo";
            this.Business_Logo.Size = new System.Drawing.Size(347, 250);
            this.Business_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Business_Logo.TabIndex = 7;
            this.Business_Logo.TabStop = false;
            // 
            // Lbl_Business_Line
            // 
            this.Lbl_Business_Line.AutoSize = true;
            this.Lbl_Business_Line.Font = new System.Drawing.Font("Rasa", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Business_Line.ForeColor = System.Drawing.Color.DimGray;
            this.Lbl_Business_Line.Location = new System.Drawing.Point(980, 245);
            this.Lbl_Business_Line.Name = "Lbl_Business_Line";
            this.Lbl_Business_Line.Size = new System.Drawing.Size(558, 57);
            this.Lbl_Business_Line.TabIndex = 8;
            this.Lbl_Business_Line.Text = "Let\'s Simplify your Business";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // curved_Rectangle1
            // 
            this.curved_Rectangle1.BackColor = System.Drawing.Color.White;
            this.curved_Rectangle1.BorderRadius = 30;
            this.curved_Rectangle1.Controls.Add(this.Btn_Login);
            this.curved_Rectangle1.Controls.Add(this.txt_Password);
            this.curved_Rectangle1.Controls.Add(this.txt_UserName);
            this.curved_Rectangle1.Controls.Add(this.Lbl_Password);
            this.curved_Rectangle1.Controls.Add(this.Lbl_Username);
            this.curved_Rectangle1.Controls.Add(this.Lbl_Login);
            this.curved_Rectangle1.ForeColor = System.Drawing.Color.Black;
            this.curved_Rectangle1.GradientAngle = 90F;
            this.curved_Rectangle1.GradientBottomColor = System.Drawing.Color.Transparent;
            this.curved_Rectangle1.GradientTopColor = System.Drawing.Color.Transparent;
            this.curved_Rectangle1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.curved_Rectangle1.Location = new System.Drawing.Point(510, 385);
            this.curved_Rectangle1.Name = "curved_Rectangle1";
            this.curved_Rectangle1.Size = new System.Drawing.Size(989, 526);
            this.curved_Rectangle1.TabIndex = 6;
            // 
            // Btn_Login
            // 
            this.Btn_Login.BackColor = System.Drawing.Color.Gainsboro;
            this.Btn_Login.Font = new System.Drawing.Font("Rasa", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.Location = new System.Drawing.Point(722, 437);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(180, 54);
            this.Btn_Login.TabIndex = 13;
            this.Btn_Login.Text = "LOGIN";
            this.Btn_Login.UseVisualStyleBackColor = false;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(42, 325);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '•';
            this.txt_Password.Size = new System.Drawing.Size(913, 38);
            this.txt_Password.TabIndex = 12;
            // 
            // txt_UserName
            // 
            this.txt_UserName.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserName.Location = new System.Drawing.Point(42, 220);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(913, 38);
            this.txt_UserName.TabIndex = 11;
            // 
            // Lbl_Password
            // 
            this.Lbl_Password.AutoSize = true;
            this.Lbl_Password.Font = new System.Drawing.Font("Rasa", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Password.Location = new System.Drawing.Point(36, 286);
            this.Lbl_Password.Name = "Lbl_Password";
            this.Lbl_Password.Size = new System.Drawing.Size(150, 36);
            this.Lbl_Password.TabIndex = 10;
            this.Lbl_Password.Text = "Password : ";
            // 
            // Lbl_Username
            // 
            this.Lbl_Username.AutoSize = true;
            this.Lbl_Username.Font = new System.Drawing.Font("Rasa", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Username.Location = new System.Drawing.Point(36, 181);
            this.Lbl_Username.Name = "Lbl_Username";
            this.Lbl_Username.Size = new System.Drawing.Size(150, 36);
            this.Lbl_Username.TabIndex = 9;
            this.Lbl_Username.Text = "Username :";
            // 
            // Lbl_Login
            // 
            this.Lbl_Login.AutoSize = true;
            this.Lbl_Login.Font = new System.Drawing.Font("Rasa", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Login.Location = new System.Drawing.Point(383, 58);
            this.Lbl_Login.Name = "Lbl_Login";
            this.Lbl_Login.Size = new System.Drawing.Size(227, 98);
            this.Lbl_Login.TabIndex = 0;
            this.Lbl_Login.Text = "Login";
            // 
            // Login_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1902, 973);
            this.Controls.Add(this.Lbl_Business_Line);
            this.Controls.Add(this.Business_Logo);
            this.Controls.Add(this.curved_Rectangle1);
            this.Controls.Add(this.Date_Label);
            this.Controls.Add(this.Time_Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login_Page";
            this.Text = "Login Page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.Business_Logo)).EndInit();
            this.curved_Rectangle1.ResumeLayout(false);
            this.curved_Rectangle1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel Date_Label;
        private Bunifu.Framework.UI.BunifuCustomLabel Time_Label;
        private Curved_Ractangle.Curved_Rectangle curved_Rectangle1;
        private System.Windows.Forms.PictureBox Business_Logo;
        private System.Windows.Forms.Label Lbl_Business_Line;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Lbl_Login;
        private System.Windows.Forms.Label Lbl_Password;
        private System.Windows.Forms.Label Lbl_Username;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Button Btn_Login;
    }
}