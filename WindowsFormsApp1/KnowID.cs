using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class KnowID : Form
    {
        public KnowID()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=Messager;Trusted_Connection=True;encrypt=false;";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select User_id from [dbo].[Users] where USER_NAME = @User_Name";
            cmd.Parameters.AddWithValue("@User_Name", txtUserName.Text.ToLower());
            txtUser_ID.Text = cmd.ExecuteScalar().ToString();
        }

        private void buttonFind_All_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=Messager;Trusted_Connection=True;encrypt=false;";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select User_id,User_name,Full_name,phone from [dbo].[Users] order by User_id asc";
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            rd.Close();
            grid.DataSource = dt;
            grid.Refresh();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void KnowID_Load(object sender, EventArgs e)
        {

        }
    }
}
