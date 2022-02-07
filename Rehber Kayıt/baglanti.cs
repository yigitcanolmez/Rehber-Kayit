using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Rehber_Kayıt
{
    class baglanti
    {
        public static SqlConnection bgl()
        {
            SqlConnection sql1 = new SqlConnection(@"Data Source=DESKTOP-EKQK6BH\SQLEXPRESS;Initial Catalog=DBRehber;Integrated Security=True");
            sql1.Open();
            return sql1;
        }
    }
}
