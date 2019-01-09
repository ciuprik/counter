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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection ( "Data Source=.\\sqlexpress;Initial Catalog=Pontaj;Integrated Security=true;" );
        
        public Form1 ( )
        {
            InitializeComponent ( );
            
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            Dispose ( );
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            using (NewUser fb = new NewUser ( ))
            {
                fb.ShowDialog ( );
                this.Hide ( );
            }
            
        }

        private void button3_Click ( object sender, EventArgs e )
        {
            using (LogIn pg = new LogIn ( ))
            {
                pg.ShowDialog ( );
                var ee = pg;
                this.Hide ( );
                
            }
            
        }
        
    }
}
