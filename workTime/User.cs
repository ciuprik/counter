using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace workTime
{
    public class User
    {
        public static object password
        {
            get
            {
                Random Random = new Random ( );
                int number = Random.Next ( 10000, 99999 );
                var Password = (number);
                return Password;
            }
            set
            {

            }
        }

        public static string UserNameBox
        {
            get
            {
                UserNameBox = "@userName";
                return UserNameBox ;
            }
             protected set
            {

            }
        }
    }
}
