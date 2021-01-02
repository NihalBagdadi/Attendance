using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;

namespace EmployeeAttendance
{
    public partial class DailyAttendanceForm : Form
    {
        CommonMethods cm = new CommonMethods();
        public DailyAttendanceForm()
        {
            InitializeComponent();
        }

        private void DailyAttendanceForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            lblName.Text = Login.user.ToString();
            ExistingRecord();


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string query;
            cm.populatedt("select * from empAttendance where Emp_name='"+lblName.Text+"' and Dt='"+lblDate.Text+"'",dt);
            if (dt.Rows.Count > 0)
            {
                query = "update empAttendance set ";
                if (comboBox1.SelectedItem.ToString() == "IN")
                {
                    query += "IN_Time='" + dateTimePicker1.Text + "'";
                }
                else
                {
         //           TimeSpan totalHr = DateTime.Parse(dt.Rows[0]["IN_Time"].ToString()) - DateTime.Parse(dt.Rows[0]["OUT_Time"].ToString());
                   
                    query += "OUT_Time='" + dateTimePicker1.Text + "'";
                }
                query += " where Emp_name='" + lblName.Text + "'";
               
            }
            else {
                if (comboBox1.SelectedItem.ToString() == "IN")
                {
                    query = "insert into empAttendance(Emp_name,Dt,IN_Time) values('" + lblName.Text + "','" + lblDate.Text + "','" + dateTimePicker1.Text + "')";
                }
                else {
                    query = "insert into empAttendance(Emp_name,Dt,OUT_Time) values('" + lblName.Text + "','" + lblDate.Text + "','" + dateTimePicker1.Text + "')";
                }
                
            }
            cm.iud(query);
            dt = new DataTable();
            cm.populatedt("select * from empAttendance where Emp_name='" + lblName.Text + "' and Dt='"+lblDate.Text+"'", dt);
            if (dt.Rows.Count > 0 && comboBox1.SelectedItem.ToString() == "OUT")
            {
                TimeSpan totalHr =  Convert.ToDateTime(dt.Rows[0]["OUT_Time"].ToString()) - Convert.ToDateTime(dt.Rows[0]["IN_Time"].ToString()) ;
                cm.iud("update empAttendance set TotalHr='"+totalHr+ "' where Emp_name='"+lblName.Text+"'");
            }

            
            
      
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
            MessageBox.Show("Record Saved");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void ExistingRecord()
        {
            using (SqlConnection con = new SqlConnection(cm.dbconnectiom())) {
                DataTable dtexist = new DataTable();
                cm.populatedt("select id, Emp_name, Dt, IN_Time, OUT_Time FROM empAttendance where Emp_name='"+lblName.Text+"' and Dt='"+lblDate.Text+"'",dtexist);
                if (dtexist.Rows.Count>0) {
                    comboBox1.Items.Remove("IN");
                } 
            } 
        }
    }
}
