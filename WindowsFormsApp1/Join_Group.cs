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
    public partial class Join_Group : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public Join_Group()
        {
            InitializeComponent();
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [dbo].[user_group] (User_id,group_id)  VALUES (@userID,@groupID)";
            cmd.Parameters.AddWithValue("@userID", user.ID);
            cmd.Parameters.AddWithValue("@groupID", txtGroupID.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Done");
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CreateGroup frm = new CreateGroup();
            frm.Show();
        }

        private void Join_Group_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=Messager;Trusted_Connection=True;encrypt=false;";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select g.Group_id, Group_Name  from [dbo].[Groups]g inner join [dbo].[user_group]ug on g.Group_id = ug.group_id where ug.User_id = @id";
            cmd.Parameters.AddWithValue("@id", user.ID);
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
    }
}
