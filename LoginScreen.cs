using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Globalization;

namespace C969_001340166
{
    public partial class LoginScreen : Form
    {
        private string loginError = "The username or password information was not entered correctly.";
        public LoginScreen()
        {
            InitializeComponent();
            lab_login_culture.Text = CultureInfo.CurrentCulture.DisplayName;
            if (CultureInfo.CurrentCulture.LCID == 1036)
            {
                loginError = "Le nom d'utilisateur ou le mot de passe n'a pas été saisi correctement.";
                lab_login_mainTitle.Text = "Rendez-vous";
                btn_login_login.Text = "Connexion";
                btn_login_cancel.Text = "Annuler";
                lab_login_username.Text = "Nom d'utilisateur";
                lab_login_password.Text = "Mot de passe";
            }
        }

        private void btn_login_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_login_login_Click(object sender, EventArgs e)
        {
            DBConn.startConnection();
            DataRowCollection loginSearch = DBConn.getDBData($"SELECT userID FROM user WHERE userName = '{tbox_login_username.Text.Trim()}' AND password = '{tbox_username_password.Text}';");
            if(loginSearch.Count != 0) {
                File.AppendAllText("log.txt", $"New Login~UserID,{loginSearch[0].ItemArray[0].ToString()};Username,{tbox_login_username.Text.Trim()};Time,{(DateTime.Now).ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}\n");
                Program.UserID = int.Parse(loginSearch[0].ItemArray[0].ToString());
                Program.Username = tbox_login_username.Text.Trim();
                Program.LoggedIn = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(loginError);
                return;
            }
        }
    }
}
