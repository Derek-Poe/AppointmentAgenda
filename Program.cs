using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace C969_001340166
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
 
        public static bool LoggedIn = false;
        public static int UserID;
        public static string Username;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());
            if (LoggedIn)
            {
                Application.Run(new MainScreen(UserID, Username));
            }
        }
    }
}
