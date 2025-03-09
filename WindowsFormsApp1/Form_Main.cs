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
    public partial class Form_Main : Form
    {
        SqlCommand cmd = new SqlCommand();
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=Messager;Trusted_Connection=True;encrypt=false;";
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            
            cmd.CommandText = "select User_id from [dbo].[Users] where USER_NAME = @User_Name";
            cmd.Parameters.AddWithValue("@User_Name",user.User_Name);

            txtID.Text = cmd.ExecuteScalar().ToString();
            user.ID = txtID.Text;

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Sender frmMain = new Sender();
            frmMain.Show();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            Reader frmMain = new Reader();
            frmMain.Show();
        }

        private void buttonKnowID_Click(object sender, EventArgs e)
        {
            KnowID frmMain = new KnowID();
            frmMain.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonJoinGroup_Click(object sender, EventArgs e)
        {
            Join_Group FrmMain = new Join_Group();
            FrmMain.Show();
        }
    }
}

