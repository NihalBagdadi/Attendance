using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAttendance
{
    public partial class Login : Form
    {
        public static string user = "";
        public static string pass = "";
        public static string type = "";
        CommonMethods cm = new CommonMethods();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
           
            user = cm.populatestring("select Username from Login_Table where Username='" + txtUsername.Text + "'", user);
            pass = cm.populatestring("select User_password from Login_Table where Username='" + txtUsername.Text + "'", pass);
            type = cm.populatestring("select User_Type from Login_Table where Username='" + txtUsername.Text + "'", type);
            if (user != "" && pass != "")
            {
                MDIParent1 md = new MDIParent1();
                md.Show();
            }
            else {
                MessageBox.Show("Invalid Username or Password");
            }
            
        }

        private void lblPasword_Click(object sender, EventArgs e)
        {

        }
    }
}
