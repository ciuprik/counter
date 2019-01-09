using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workTime
{
    public partial class NewUser : Form
    {
        SqlConnection con = new SqlConnection ( "Data Source=.\\sqlexpress;Initial Catalog=Pontaj;Integrated Security=true;" );
        SqlCommand cmd;
        public NewUser ( )
        {
            InitializeComponent ( );
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            Dispose ( );
        }

        private void button3_Click ( object sender, EventArgs e )
        {
            if (textBoxFirstName.Text != "" && textBoxLastName.Text != "" && textBoxUserName.Text != "" )
            {
                cmd = new SqlCommand ( "insert into Users(UserName, FirstName, LastName, Password) values(@UserName, @FirstName, @LastName,@Password)", con );

                con.Open ( );
                cmd.Parameters.AddWithValue ( "@LastName", textBoxFirstName.Text );
                cmd.Parameters.AddWithValue ( "@FirstName", textBoxLastName.Text );
                cmd.Parameters.AddWithValue ( "@UserName", textBoxUserName.Text );
                cmd.Parameters.AddWithValue ( "@Password", User.password);
                cmd.ExecuteNonQuery ( );
                con.Close ( );
                MessageBox.Show ( "Record Inserted Successfully" );

                //Dispose ( );
                if (textBoxUserName.Text != "")
                {
                    cmd = new SqlCommand ( "CREATE TABLE " + textBoxUserName.Text + "(userId int, startTime dateTime, endTime dateTime, timer time(7)) ", con );
                    con.Open ( );
                    cmd.ExecuteNonQuery ( );
                    con.Close ( );
                    MessageBox.Show ( "DataBase Created Successfully" );
                    Dispose ( );
                }


            }
            else
            {
                MessageBox.Show ( "Please Provide Details!" );
            }
        }

        private void button4_Click ( object sender, EventArgs e )
        {

            foreach (Control c in Controls )
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        
    }
}
