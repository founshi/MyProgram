using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class LoginUserPwd
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string Login_UserName { get; set; }

        public string Login_Pwd { get; set; }

        public DateTime Login_Time { get; set; }
    }
}
