namespace MC2_Sales_and_Inventory_System
{
    partial class RegisterFormRazer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterFormRazer));
            this.label3 = new System.Windows.Forms.Label();
            this.cboQuestion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tmDateTime = new System.Windows.Forms.Timer(this.components);
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblSignIn = new System.Windows.Forms.LinkLabel();
            this.chbAgree = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(115, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username :";
            // 
            // cboQuestion
            // 
            this.cboQuestion.BackColor = System.Drawing.Color.Black;
            this.cboQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuestion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cboQuestion.FormattingEnabled = true;
            this.cboQuestion.Items.AddRange(new object[] {
            "What is your mothers maiden name?",
            "What is your fathers middle name?",
            "What city were you born in?",
            "What is name of your primary school?",
            "What is the name of your first pet?",
            "Who was your childhood hero?",
            "What is your favorite past-time?",
            "What is your all-time favorite sports team?",
            "Where did you first meet your spouse?",
            "Who is your favorite actor/actress?"});
            this.cboQuestion.Location = new System.Drawing.Point(232, 184);
            this.cboQuestion.Name = "cboQuestion";
            this.cboQuestion.Size = new System.Drawing.Size(296, 25);
            this.cboQuestion.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(259, 525);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 19);
            this.label5.TabIndex = 107;
            this.label5.Text = "Already have an Account?";
            // 
            // tmDateTime
            // 
            this.tmDateTime.Tick += new System.EventHandler(this.tmDateTime_Tick);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.Black;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(232, 139);
            this.txtConfirmPassword.MaxLength = 15;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(194, 25);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtAnswer
            // 
            this.txtAnswer.BackColor = System.Drawing.Color.Black;
            this.txtAnswer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtAnswer.Location = new System.Drawing.Point(232, 228);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(295, 25);
            this.txtAnswer.TabIndex = 94;
            // 
            // lblSignIn
            // 
            this.lblSignIn.ActiveLinkColor = System.Drawing.Color.Yellow;
            this.lblSignIn.AutoSize = true;
            this.lblSignIn.BackColor = System.Drawing.Color.Transparent;
            this.lblSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSignIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblSignIn.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblSignIn.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblSignIn.Location = new System.Drawing.Point(489, 524);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(60, 19);
            this.lblSignIn.TabIndex = 108;
            this.lblSignIn.TabStop = true;
            this.lblSignIn.Text = "Sign In";
            this.lblSignIn.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSignIn_LinkClicked_1);
            // 
            // chbAgree
            // 
            this.chbAgree.AutoSize = true;
            this.chbAgree.BackColor = System.Drawing.Color.Transparent;
            this.chbAgree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbAgree.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAgree.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chbAgree.Location = new System.Drawing.Point(106, 270);
            this.chbAgree.Name = "chbAgree";
            this.chbAgree.Size = new System.Drawing.Size(428, 21);
            this.chbAgree.TabIndex = 89;
            this.chbAgree.Text = "By clicking Register, You must agree to our Sales and Inventory System. ";
            this.chbAgree.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.txtConfirmPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboQuestion);
            this.groupBox1.Controls.Add(this.txtAnswer);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.chbAgree);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 375);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sign Up";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(120, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(85, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 25);
            this.label7.TabIndex = 93;
            this.label7.Text = "Secret Answer :";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.Black;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtUsername.Location = new System.Drawing.Point(232, 48);
            this.txtUsername.MaxLength = 15;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(194, 25);
            this.txtUsername.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(72, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 25);
            this.label8.TabIndex = 92;
            this.label8.Text = "Select Question :";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Black;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPassword.Location = new System.Drawing.Point(232, 94);
            this.txtPassword.MaxLength = 15;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(194, 25);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(49, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Confirm Password :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BackgroundImage = global::MC2_Sales_and_Inventory_System.Properties.Resources.Razer_Logo;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(99, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 387);
            this.panel1.TabIndex = 110;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::MC2_Sales_and_Inventory_System.Properties.Resources.Title_Design;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 98);
            this.pictureBox1.TabIndex = 109;
            this.pictureBox1.TabStop = false;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.Black;
            this.btnRegister.Image = ((System.Drawing.Image)(resources.GetObject("btnRegister.Image")));
            this.btnRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegister.Location = new System.Drawing.Point(239, 317);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(113, 26);
            this.btnRegister.TabIndex = 30;
            this.btnRegister.Text = "Register";
            this.btnRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // RegisterFormRazer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MC2_Sales_and_Inventory_System.Properties.Resources.razer_hd_wallpaper_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(786, 563);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSignIn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterFormRazer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterFormRazer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboQuestion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer tmDateTime;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.LinkLabel lblSignIn;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.CheckBox chbAgree;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}