
namespace C969_001340166
{
    partial class LoginScreen
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
            this.lab_login_mainTitle = new System.Windows.Forms.Label();
            this.lab_login_username = new System.Windows.Forms.Label();
            this.lab_login_password = new System.Windows.Forms.Label();
            this.tbox_login_username = new System.Windows.Forms.TextBox();
            this.tbox_username_password = new System.Windows.Forms.TextBox();
            this.btn_login_login = new System.Windows.Forms.Button();
            this.btn_login_cancel = new System.Windows.Forms.Button();
            this.lab_login_culture = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_login_mainTitle
            // 
            this.lab_login_mainTitle.AutoSize = true;
            this.lab_login_mainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lab_login_mainTitle.Location = new System.Drawing.Point(88, 9);
            this.lab_login_mainTitle.Name = "lab_login_mainTitle";
            this.lab_login_mainTitle.Size = new System.Drawing.Size(126, 24);
            this.lab_login_mainTitle.TabIndex = 0;
            this.lab_login_mainTitle.Text = "Appointments";
            // 
            // lab_login_username
            // 
            this.lab_login_username.AutoSize = true;
            this.lab_login_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lab_login_username.Location = new System.Drawing.Point(22, 56);
            this.lab_login_username.Name = "lab_login_username";
            this.lab_login_username.Size = new System.Drawing.Size(77, 17);
            this.lab_login_username.TabIndex = 1;
            this.lab_login_username.Text = "Username:";
            // 
            // lab_login_password
            // 
            this.lab_login_password.AutoSize = true;
            this.lab_login_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lab_login_password.Location = new System.Drawing.Point(25, 88);
            this.lab_login_password.Name = "lab_login_password";
            this.lab_login_password.Size = new System.Drawing.Size(73, 17);
            this.lab_login_password.TabIndex = 2;
            this.lab_login_password.Text = "Password:";
            // 
            // tbox_login_username
            // 
            this.tbox_login_username.Location = new System.Drawing.Point(119, 56);
            this.tbox_login_username.Name = "tbox_login_username";
            this.tbox_login_username.Size = new System.Drawing.Size(161, 22);
            this.tbox_login_username.TabIndex = 3;
            // 
            // tbox_username_password
            // 
            this.tbox_username_password.Location = new System.Drawing.Point(119, 88);
            this.tbox_username_password.Name = "tbox_username_password";
            this.tbox_username_password.PasswordChar = '*';
            this.tbox_username_password.Size = new System.Drawing.Size(161, 22);
            this.tbox_username_password.TabIndex = 4;
            // 
            // btn_login_login
            // 
            this.btn_login_login.Location = new System.Drawing.Point(64, 134);
            this.btn_login_login.Name = "btn_login_login";
            this.btn_login_login.Size = new System.Drawing.Size(75, 27);
            this.btn_login_login.TabIndex = 5;
            this.btn_login_login.Text = "Login";
            this.btn_login_login.UseVisualStyleBackColor = true;
            this.btn_login_login.Click += new System.EventHandler(this.btn_login_login_Click);
            // 
            // btn_login_cancel
            // 
            this.btn_login_cancel.Location = new System.Drawing.Point(164, 134);
            this.btn_login_cancel.Name = "btn_login_cancel";
            this.btn_login_cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_login_cancel.TabIndex = 6;
            this.btn_login_cancel.Text = "Cancel";
            this.btn_login_cancel.UseVisualStyleBackColor = true;
            this.btn_login_cancel.Click += new System.EventHandler(this.btn_login_cancel_Click);
            // 
            // lab_login_culture
            // 
            this.lab_login_culture.AutoSize = true;
            this.lab_login_culture.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lab_login_culture.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lab_login_culture.Location = new System.Drawing.Point(12, 179);
            this.lab_login_culture.Name = "lab_login_culture";
            this.lab_login_culture.Size = new System.Drawing.Size(0, 13);
            this.lab_login_culture.TabIndex = 7;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 204);
            this.Controls.Add(this.lab_login_culture);
            this.Controls.Add(this.btn_login_cancel);
            this.Controls.Add(this.btn_login_login);
            this.Controls.Add(this.tbox_username_password);
            this.Controls.Add(this.tbox_login_username);
            this.Controls.Add(this.lab_login_password);
            this.Controls.Add(this.lab_login_username);
            this.Controls.Add(this.lab_login_mainTitle);
            this.Name = "LoginScreen";
            this.Text = "Login Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_login_mainTitle;
        private System.Windows.Forms.Label lab_login_username;
        private System.Windows.Forms.Label lab_login_password;
        private System.Windows.Forms.TextBox tbox_login_username;
        private System.Windows.Forms.TextBox tbox_username_password;
        private System.Windows.Forms.Button btn_login_login;
        private System.Windows.Forms.Button btn_login_cancel;
        private System.Windows.Forms.Label lab_login_culture;
    }
}