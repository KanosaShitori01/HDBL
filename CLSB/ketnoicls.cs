using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace CLSB
{
    public class ketnoicls
    {
        public static SqlConnection conn = new SqlConnection(@"Server=DESKTOP-MC\SQLEXPRESS;Database=QL_BANHANG;Integrated Security=true");
    }
}
