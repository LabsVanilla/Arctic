using MelonLoader;
using Newtonsoft.Json;
using System;
using WebSocketSharp;
// ik this is arctics old connect.cs but its only here for the avatar patch thats
// till i get aroud to rewriteing this whole thing to make secure 
namespace Arctic
{
    class connect
    {
        internal static WebSocket wss;
        internal static bool waitfortime = false;
        internal protected static bool ath = false;
        internal static string aviserchl = "";
        public static void Runsocket()
        {
#if DEBUG
           using (wss = new WebSocket("ws://localhost:8080"))
#else
            using (wss = new WebSocket("ws://api.glowking.net:8080"))
#endif
            // using (wss = new WebSocket("ws://api.glowking.net:8080"))
            //using (wss = new WebSocket("ws://localhost:8080"))
            {
                // wss.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                wss.Connect();
                wss.OnClose += (sender, e) =>
                {

                    tryrecconect();
                };
                wss.OnOpen += (sender, e) =>
                {
                   
                    var sendidtosv = new settings.sendsinglemsg()
                    {
                        Custommsg = "ARCTIC BETA LOGIN IGNORE",

                        code = "1",
                    };
                    sendmsg($"{JsonConvert.SerializeObject(sendidtosv)}");
                };
                wss.OnMessage += Ws_OnMessage;
                wss.Log.Output = (_, __) => { };

            }
        }

        public static void sendmsg(string text)
        {
            if (connect.wss.IsAlive)
                connect.wss.Send(text);
            //Style.Consoles.consolelogger(text);
        }

        internal static void tryrecconect()
        {
            try
            {
                if (!connect.wss.IsAlive)
                    wss.Connect();
            }
            catch (Exception error)
            {

                MelonLogger.Error("Cloud not connect : " + error);
                wss.Connect();
                // System.Diagnostics.Process.GetCurrentProcess().Kill();

            }

        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            var message = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(e.Data));
            // MelonLoader.Style.Consoles.consolelogger(message);
            //Style.Consoles.consolelogger(message);


            if (message.Contains("AvatarName") && message.Contains("Authorid") && message.Contains("Asseturl"))
            {
                //aviserchl = message;
                // return;
            }





            if (message.ToString() == "JUSTSAYHI")
            {
                ath = true;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome");
            }
            else if (message.ToString() == "UserNotAuth")
            {
                Console.WriteLine("UKNOWN HWID");
                Console.WriteLine("Here Is where i Would of Closed game but uh i havent implemnted it lol infact you dont even need a key since its a test build");

                //System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }


    }
}