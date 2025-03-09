using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Reader : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public Reader()
        {
            InitializeComponent();
        }

        private void Reader_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=Messager;Trusted_Connection=True;encrypt=false;";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Message_id,Sender_id,User_name,[Subject] , Body, Date_Sent from [dbo].[Messages] inner join [dbo].[Users] on Sender_id = User_id where Recipient_id = @id";
            cmd.Parameters.AddWithValue("@id", user.ID);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            rd.Close();
            grid.DataSource = dt;
            grid.Refresh();
            cmd.CommandText = "update [dbo].[Messages] set Is_Read = 1 where Recipient_id = @id";
            cmd.ExecuteNonQuery();
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }
    }
}
