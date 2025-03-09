using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {

        public login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("please enter User_Name");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("please enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPassword.Focus();
                return;
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=Messager;Trusted_Connection=True;encrypt=false;";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select User_id from Users where User_name = @userName and password = @password";
            cmd.Parameters.AddWithValue("@userName",txtUserName.Text);
            cmd.Parameters.AddWithValue("@password",txtPassword.Text);
            string rd = cmd.ExecuteScalar()?.ToString();
            if (rd != null)
            {
                user.User_Name = txtUserName.Text;
                user.Password = txtPassword.Text;
                MessageBox.Show("welcome " + txtUserName.Text);
                this.BackColor = Color.LightGreen;
                Form_Main frmMain = new Form_Main();
                frmMain.Show();
            }
            else
            {
                this.BackColor = Color.Red;
                MessageBox.Show("Wrong User_Name or Password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register frmMain = new Register();
            frmMain.Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
    
    }
