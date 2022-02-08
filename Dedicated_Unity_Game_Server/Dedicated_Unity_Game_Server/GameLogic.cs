using System;
using System.Collections.Generic;
using System.Text;

namespace Dedicated_Unity_Game_Server
{
    class GameLogic
    {
        public static void Update()
        {
            ThreadManager.UpdateMain();
        }
    }
}
