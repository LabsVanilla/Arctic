using Galaxy.API;
using Newtonsoft.Json;
using System;
using System.Reflection;
using WebSocketSharp;
 
namespace Galaxy
{
    internal class connect
    {
        [Obfuscation(Exclude = true, ApplyToMembers = true, StripAfterObfuscation = true)]
        internal static WebSocket wss;
        internal static bool waitfortime = false;
        internal protected static bool ath = false;
        internal static string aviserchl = "";
        public static void Runsocket()
        {
            using (wss = new WebSocket("ws://api.galaxyvrc.xyz:8080"))
            {
                // wss.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;

                wss.Connect();
                wss.OnClose += (sender, e) =>
                {
                    tryrecconect();
                };
                wss.OnOpen += (sender, e) =>
                {

                    var sendidtosv = new Settings.sendsinglemsg()
                    {
                        Custommsg = "Galaxy BETA LOGIN IGNORE",

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
                LogHandler.Error("Server Down Possibly", "Server");
                LogHandler.Error($"Cloud not connect : {error}", "Server");

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
                API.LogHandler.Error("UKNOWN HWID", "Auth");
                API.LogHandler.Error("open a ticket To get a hwid reset", "Auth");

                //System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            if (message.ToString() == "Server Error 1")
            {
                LogHandler.Error("Unknown Issue With Server HyperV is working on it dont wory", "Server");
            }

            if (message.ToString() == "Server Error 2")
            {
                LogHandler.Error("Server Mantinace", "Server");
                LogHandler.Error("please wait for server to come back online Server required Features will not work", "Server");
            }
            if (message.ToString() == "Close Connection")
            {
                LogHandler.Error("Server Mantinace", "Server");
                LogHandler.Error("please wait for server to come back online Server required Features will not work", "Server");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            if (message.ToString() == "IsStaff")
            {
                LogHandler.Log("Auth", "Staff Mode Enabled");
                Settings.Config.IsStaff = true;

            }

            if (message.ToString() == "ExtraBeta")
            {
                LogHandler.Log("Auth", "Beta Mode Enabled");
                Settings.Config.betaEnabled = true;


            }

            if (message.ToString() == "UserAuth")
            {
                Settings.Config.hasAuth = true;
            }

        }

    }


}
