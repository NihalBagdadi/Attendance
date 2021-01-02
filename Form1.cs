using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeAttendance
{
    public partial class Form1 : Form
    {
        CommonMethods cm = new CommonMethods();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            cm.iud("insert into Login_Table values('"+txtUsername.Text+"','"+txtPassword.Text+"','"+cbType.SelectedItem+"')");
            MessageBox.Show("Registration Successfully Completed");

            txtUsername.Text = "";
            txtPassword.Text = "";
            cbType.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
