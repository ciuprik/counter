using System;
using System.Data.SqlClient;
using System.Timers;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workTime
{
    public class orar 
    {
        
        SqlConnection con = new SqlConnection ( "Data Source=.\\sqlexpress;Initial Catalog=Pontaj;Integrated Security=true;" );
        SqlCommand cmd;

        public static string timer2_Tick
        {
            get
            {
                int hh = DateTime.Now.Hour;
                int mm = DateTime.Now.Minute;
                int ss = DateTime.Now.Second;

                //string time = DateTime.Now.ToString ( "HH:mm:ss" );

                string time = "";
                if (hh < 10)
                {
                    time += "0" + hh;
                }
                else
                {
                    time += hh;
                }
                time += ":";
                if (mm < 10)
                {
                    time += "0" + mm;
                }
                else
                {
                    time += mm;
                }
                time += ":";
                if (ss < 10)
                {
                    time += "0" + ss;
                }
                else
                {
                    time += ss;
                }
                return time;
            }
            set { }

        }

        public string orarStart
        {
            get
            {
                cmd = new SqlCommand ( "insert into Mihnea(startTime,) values(@startTime)", con );

                con.Open ( );
                cmd.Parameters.AddWithValue ( "@startTime", timer2_Tick );
                cmd.ExecuteNonQuery ( );
                con.Close ( );
                return  "Record Inserted Successfully" ;
            }

            set { }
        }
        
    }
}
