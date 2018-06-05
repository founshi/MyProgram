using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Server
{
    public class ReadConnString
    {
        public static readonly string Connstring = ConfigurationManager.ConnectionStrings["DbPath"].ConnectionString;


    }
}
