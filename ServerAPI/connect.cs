using Galaxy.API;
using Newtonsoft.Json;
using System;
using System.Reflection;
using VRC.Core;
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
                        Custommsg = "Galaxy Client Login",

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
            { connect.wss.Send(text); }
            else
            { tryrecconect(); }

            if (Settings.Config.betaEnabled == true)
            { LogHandler.Log("SERVER RESPONCE" , text); } 
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
           
            if (message.Contains("AvatarName") && message.Contains("Authorid") && message.Contains("Asseturl"))
            { }

            if (message.ToString() == "JUSTSAYHI")
            {
                ath = true;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome");
            }
            else if (message.ToString() == "UserNotAuth")
            { LogHandler.Error("UKNOWN HWID ... open a ticket To get a hwid reset", "Auth"); }

            if (message.ToString() == "Server Error 1")
            { LogHandler.Error("Unknown Issue With Server HyperV is working on it dont wory", "Server"); }

            if (message.ToString() == "Server Error 2")
            {
                LogHandler.Error("Server Mantinace", "Server");
                LogHandler.Error("please wait for server to come back online Server required Features will not work", "Server");
            }
            if (message.ToString() == "Close Connection")
            {
                LogHandler.Error("Server Mantinace", "Server");
                LogHandler.Error("please wait for server to come back online Server required Features will not work", "Server");
                // System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            if (message.ToString() == "IsStaff")
            { Settings.Config.IsStaff = true;}

            if (message.ToString() == "ExtraBeta")
            { Settings.Config.betaEnabled = true; }

            if (message.ToString() == "UserAuth")
            { Settings.Config.hasAuth = true; }

            if (message.Contains("Global"))
            {
                if (Settings.Config.GlobalMessage != message)
                {
                    Console.WriteLine(message);
                    Settings.Config.ServerNotify = true;
                    Settings.Config.GlobalMessage = message;
                }
            }
        }
    }
}
