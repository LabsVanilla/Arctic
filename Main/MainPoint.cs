using MelonLoader;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using UnityEngine;
using Arctic.API;
using Arctic.Settings;
using System.IO;


namespace Arctic.Main
{
    public class Load
    {
        [Obfuscation(Exclude = true, ApplyToMembers = true, StripAfterObfuscation = true)]
        private static Thread tr = new Thread(connect.Runsocket);
        [Obsolete]
        public static void OnStar()
        {
            LogoShower.DisplayLogo();
            API.Utils.Install.InstallBC();
            Discord.DiscordManager.Init();
            MelonCoroutines.Start(Buttons.Buttonlayout.WaitForSM());
            MelonCoroutines.Start(LogoShower.startanim());
            tr.Start();
            Patch.Patch.Patchse();
        }

        public static void NONOMETHOD()
        {
#if DEBUG


            if (Input.GetKeyDown(KeyCode.P) &&  Input.GetKeyDown(KeyCode.Backspace))
            {
                if (Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.Backspace))
                {

                    try
                    {

                        string arguments = "";
                        foreach (string stringi in Environment.GetCommandLineArgs())
                        {
                            arguments += $"{stringi} ";
                        }
                        System.Diagnostics.Process vrc = new System.Diagnostics.Process();
                        vrc.StartInfo.FileName = $"{MelonUtils.GameDirectory}\\VRChat.exe";
                        vrc.StartInfo.Arguments = arguments;
                        vrc.Start();
                        Process.GetCurrentProcess().Kill();
                    }
                    catch
                    {

                    }

                }

            }
#endif

            Arctic.Exploits.Fly.FlyB();


        }

        public static void OVERSLEEP()
        {

            try
            {
                API.LogHandler.Log("Starter", "On Late Start Was Called Loading Now");

                Arctic.Main.load.PresenceUpdater();
            }
            catch (Exception ex)
            {
                MelonLogger.Msg(ex);
            }
        }

        public static void Quitter()
        {

            nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Arctic\\Config\\GenConfig.json");

        }


        public static void LoadConfig()
        {
            try
            {
                var mainl = Newtonsoft.Json.JsonConvert.DeserializeObject<configa>(File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Config\\GenConfig.json"));
                nconfig.applyconfig($"{MelonUtils.GameDirectory}\\Arctic\\Config\\GenConfig.json", mainl); }
            catch
            { nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Arctic\\Config\\GenConfig.json"); LogHandler.Log("ABD ", "Saved Config"); }
            //var mainl = Newtonsoft.Json.JsonConvert.DeserializeObject<configa>(File.ReadAllText($"{MelonUtils.GameDirectory}\\Arctic\\Config\\GenConfig.json"));
#if DEBUG
            /*   foreach (var bbc in mainl.GetType().GetProperties())
               {
                   try
                   {

                       var bcc = bbc.GetValue(mainl);
                       bcc.ToString();

                       LogHandler.Log("Config Loader",$"{bbc.Name}:{bcc}");
                   }
                   catch
                   {
                       LogHandler.Error($"Load Failed{bbc.Name}", "Loader");
                       var getfields = typeof(nconfig).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                       foreach (var a in getfields)
                       {
                           try
                           {
                               if (bbc.Name == a.Name)
                               {
                                   bbc.SetValue(mainl, a.GetValue(getfields));

                               }
                           }
                           catch { LogHandler.Error($"BIG FAIL {bbc.Name}", "Load Error"); }
                       }

                   }
               }
   /*
               try
               { nconfig.applyconfig($"{MelonUtils.GameDirectory}\\Arctic\\Config\\GenConfig.json", mainl); }
               catch
               { nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Arctic\\Config\\GenConfig.json"); LogHandler.Log("ABD ","Saved cinfig"); }
   */
         
#endif
        }
    }
}
