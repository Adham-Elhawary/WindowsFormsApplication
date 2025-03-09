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
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public Register()
        {
            InitializeComponent();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if(txtUser_name.Text == "")
            {
                MessageBox.Show("please enter User_Name");
                txtUser_name.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("please enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPassword.Focus();
                return;
            }
            if (txtConformPassword.Text == "")
            {
                MessageBox.Show("please enter Conform Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtConformPassword.Focus();
                return;
            }
            if (txtFullNmae.Text == "")
            {
                MessageBox.Show("please enter Full Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtFullNmae.Focus();
                return;
            }
            if (txtPhone.Text == "")
            {
                MessageBox.Show("please enter Phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPhone.Focus();
                return;
            }
            if (txtPassword.Text == txtConformPassword.Text)
            {
                using (SqlConnection con = new SqlConnection("your_connection_string"))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO [dbo].[Users]([User_name],[password],[Full_name],[phone]) VALUES(@UserName, @Password, @FullName, @Phone)";
                        cmd.Parameters.AddWithValue("@UserName", txtUser_name.Text.ToLower());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@FullName", txtFullNmae.Text.ToLower());
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Done");
                        Form.ActiveForm.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            else
            {
                MessageBox.Show("Password and Conform Password not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
