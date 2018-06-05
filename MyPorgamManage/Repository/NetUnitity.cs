using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Repository
{
    public class NetUnitity
    {
        public static string GetLannIP()
        {
            IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            if (addressList.Length < 2)
            {
                return "";
            }
            string IpV4Address = string.Empty;
            for (int i = 0; i < addressList.Length; i++)
            {
                if (addressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    IpV4Address = addressList[i].ToString();
                    break;
                }
            }

            return IpV4Address;
        }


    }
}
