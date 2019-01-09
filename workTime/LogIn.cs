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

namespace workTime
{
    public partial class LogIn : Form
    {
        
        public LogIn ( )
        {
            InitializeComponent ( );
        }
         
        SqlConnection con = new SqlConnection ( "Data Source=.\\sqlexpress;Initial Catalog=Pontaj;Integrated Security=true;" );

       // public static object userNameBox { get; internal set; }

        private void button3_Click ( object sender, EventArgs e )
        {
            if (UserNameBox.Text == "" || PasswordBox.Text == "")
            {
                MessageBox.Show ( "Please provide UserName and Password" );
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection ( "Data Source=.\\sqlexpress;Initial Catalog=Pontaj;Integrated Security=true;" );
                SqlCommand cmd = new SqlCommand ( "Select * from users where UserName=@username and Password=@password", con );
                cmd.Parameters.AddWithValue ( "@username", UserNameBox.Text );
                cmd.Parameters.AddWithValue ( "@password", PasswordBox.Text );
                con.Open ( );
                SqlDataAdapter adapt = new SqlDataAdapter ( cmd );
                DataSet ds = new DataSet ( );
                adapt.Fill ( ds );
                con.Close ( );
                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {
                    MessageBox.Show ( "Login Successful!" );
                    this.Hide ( );
                    UserPage fm = new UserPage ( );
                    fm.Show ( );
                    Dispose ( );
                }
                else
                {
                    MessageBox.Show ( "Login Failed!" );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show ( ex.Message );
            }


        }

        private void button4_Click ( object sender, EventArgs e )
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            using (Form1 fb = new Form1 ( ))
            {
                fb.ShowDialog ( );
                this.Hide ( );
                Dispose ( );
            }
            
        }
    }
}
