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

namespace WindowsFormsApp1
{
    public partial class CreateGroup : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public CreateGroup()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)

        {
            con.ConnectionString = "server=.;database=Messager;Trusted_Connection=True;encrypt=false;";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [dbo].[Groups] ([Group_Name],[Group_Desc]) VALUES (@Group_Name,@Group_Desc)";
            cmd.Parameters.AddWithValue("@Group_Name", txtGroupName.Text.ToLower());
            cmd.Parameters.AddWithValue("@Group_Desc", txtdesc.Text);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select Group_id from [dbo].[Groups] where Group_Name = @groupName";
            cmd.Parameters.AddWithValue("@groupName", txtGroupName.Text.ToLower());
            string id = cmd.ExecuteScalar().ToString();
            MessageBox.Show("Done! your new group id is : "+id);
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [dbo].[user_group] (User_id,group_id)  VALUES (@userID,@groupID)";
            cmd.Parameters.AddWithValue("@userID", user.ID);
            cmd.Parameters.AddWithValue("@groupID", id);
            cmd.ExecuteNonQuery();
            Form.ActiveForm.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }
    }
}
