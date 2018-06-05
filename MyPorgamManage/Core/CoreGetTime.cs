using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class CoreGetTime
    {
        ServerGetTime _ServerGetTime = new ServerGetTime();
        public DateTime GetNow()
        {
            return _ServerGetTime.GetNow();
        }

    }
}
