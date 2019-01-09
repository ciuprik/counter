using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workTime
{
    public partial class UserPage : Form
    {
        SqlConnection con = new SqlConnection ( "Data Source=.\\sqlexpress;Initial Catalog=Pontaj;Integrated Security=true;" );
        SqlCommand cmd;
        SqlDataAdapter adapt;

        int sec, min, ore;

        public UserPage ( )
        {
            InitializeComponent ( );
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            Dispose ( );
        }

        private void timer1_Tick ( object sender, EventArgs e )
        {

            sec++;
            if (sec == 59)
            {
                min++;
                sec = 0;
                if (min == 59)
                {
                    ore++;
                    min = 0;
                }
            }
            label1.Text = ore.ToString ( ).PadLeft ( 2, '0' )+":" + min.ToString ( ).PadLeft ( 1, '0' ) + ":" + sec.ToString ( ).PadLeft ( 0, '0' );

        }

        private void label1_Click ( object sender, EventArgs e )
        {
           
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            timer1.Enabled = true;
            timer1.Start ( );
           
            //timer2.Start ( );
            cmd = new SqlCommand ( "insert into mihnea(startTime) values (@startTime) ", con );

            con.Open ( );
            cmd.Parameters.AddWithValue ( "@startTime", timer1.Enabled );
            cmd.ExecuteNonQuery ( );
            con.Close ( );
            MessageBox.Show ( "Have a nice day" );
        }

        private void button3_Click ( object sender, EventArgs e )
        {
            timer1.Stop ( );
            cmd = new SqlCommand ( "insert into mihnea(endTime) values (@endTime) ", con );

            con.Open ( );
            cmd.Parameters.AddWithValue ( "@endTime", timer1.Enabled );
            cmd.ExecuteNonQuery ( );
            con.Close ( );
            MessageBox.Show ( "See you tomorow" );
        }
    }
}
