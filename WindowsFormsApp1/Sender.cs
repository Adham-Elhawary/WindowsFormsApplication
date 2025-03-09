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
    public partial class Sender : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public Sender()
        {
            InitializeComponent();
        }

        private void Sender_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=Messager;Trusted_Connection=True;encrypt=false;";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Message_id,Recipient_id,User_name,[Subject], Date_Sent ,Is_Read from [dbo].[Messages] inner join [dbo].[Users] on Recipient_id = User_id where Sender_id = @id order by Message_id desc";
            cmd.Parameters.AddWithValue("@id", user.ID);
            SqlDataReader rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            rd.Close();
            grid.DataSource = dt;
            grid.Refresh();

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [dbo].[Messages]([Sender_id],[Recipient_id],[Subject],[Body],[Is_Read]) VALUES (@Sender_id, @Recipient_id, @Subject, @Body, 0)";
            cmd.Parameters.AddWithValue("@Sender_id", user.ID);
            cmd.Parameters.AddWithValue("@Recipient_id", txtSendToID.Text);
            cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
            cmd.Parameters.AddWithValue("@Body", txtBody.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Done");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            TextBox t = new TextBox();
            foreach (var v in this.Controls)
            {
                if (v is TextBox txt)
                {
                    txt.Text = "";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    

}
