using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DuongThuanQuang_Tuan8
{
    public class Connect
    {
        private string conStr;

        public string ConStr
        {
            get { return conStr; }
            set { conStr = value; }
        }
        public Connect()
        {
            conStr = "Data Source = A209PC38; database = QLSV; Integrated Security = true";
        }
    }
}
