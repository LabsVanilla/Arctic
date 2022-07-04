using Newtonsoft.Json;
using System;
using System.Timers;

namespace Galaxy.API
{
    internal class CheckServer
    {
        private static Timer CHECKSERVER;

        public static void SetTimer()
        {
            // Create a timer with a two second interval.
            CHECKSERVER = new System.Timers.Timer(30000);
            // Hook up the Elapsed event for the timer. 
            CHECKSERVER.Elapsed += IsUp;
            CHECKSERVER.AutoReset = true;
            CHECKSERVER.Enabled = true;
        }

        private static void IsUp(Object source, ElapsedEventArgs e)
        {
                var sendidtosv = new Settings.sendsinglemsg()
                {
                    Custommsg = "",

                    code = "1",
                };
                connect.sendmsg($"{JsonConvert.SerializeObject(sendidtosv)}");
        }
    }
}
