using Galaxy.API;
using Galaxy.Settings;
using MelonLoader;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using UnityEngine;


namespace Galaxy.Main
{
    internal class Load
    {
        [Obfuscation(Exclude = true, ApplyToMembers = true, StripAfterObfuscation = true)]
        private static Thread tr = new Thread(connect.Runsocket);
        [Obsolete]
        public static void OnStar()
        {
            if (Environment.CommandLine.Contains("--BETAMODE"))
            {
                Settings.Config.ExtraBeta = "1";
            }
            
            MelonCoroutines.Start(HudNotify.StartHudNotify());
            LogoShower.DisplayLogo();
            API.Utils.Install.InstallBC();
            Discord.DiscordManager.Init();
            MelonCoroutines.Start(Buttons.Buttonlayout.WaitForSM());
            MelonCoroutines.Start(CheckAuth.CheckAuthMeth());
            tr.Start();
            Patch.Patch.Patchse();
            
        }

        public static void NONOMETHOD()
        {
            
#if DEBUG


            if (Input.GetKeyDown(KeyCode.P))
            {
                if (Input.GetKeyDown(KeyCode.P))
                {

                    try
                    {

                        Console.WriteLine(Settings.Config.betaEnabled);
                        Console.WriteLine(Settings.Config.IsStaff);
                        LogHandler.Log("Test", "Test Notify", true);

                        /*
                        string arguments = "";
                        foreach (string stringi in Environment.GetCommandLineArgs())
                        {
                            arguments += $"{stringi} ";
                        }
                        System.Diagnostics.Process vrc = new System.Diagnostics.Process();
                        vrc.StartInfo.FileName = $"{MelonUtils.GameDirectory}\\VRChat.exe";
                        vrc.StartInfo.Arguments = arguments;
                        vrc.Start();
                        Process.GetCurrentProcess().Kill();*/
                    }
                    catch
                    {

                    }

                }

            }
#endif

            if (Input.GetKeyDown(KeyCode.F1) & nconfig.EnableKeybinds)
            { Exploits.QuickChange.QuickChangeAvi(); }
            if (Input.GetKeyDown(KeyCode.F2) & nconfig.EnableKeybinds)
            { Exploits.QuickChange.QuickChangeAvi2(); }
            if (Input.GetKeyDown(KeyCode.F3) & nconfig.EnableKeybinds)
            { Exploits.QuickChange.QuickChangeAvi3(); }
            if (Input.GetKeyDown(KeyCode.F4) & nconfig.EnableKeybinds)
            { Exploits.QuickChange.QuickChangeAvi4(); }
            Exploits.Fly.FlyB();
        }
        public static void OVERSLEEP()
        {
            try
            {
                LogHandler.Log("Starter", "On Late Start Was Called Loading Now");
                
                load.PresenceUpdater();
                MelonCoroutines.Start(styles.LoadAudio.Starter());
                nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
            }
            catch (Exception ex)
            {
                MelonLogger.Msg(ex);
            }
        }

        public static void Quitter()
        {
            nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
        }


        public static void LoadConfig()
        {
            try
            {
                var mainl = Newtonsoft.Json.JsonConvert.DeserializeObject<configa>(File.ReadAllText($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"));
                nconfig.applyconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json", mainl);
            }
            catch
            { nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"); LogHandler.Log("ABD ", "Saved Config"); }
            //var mainl = Newtonsoft.Json.JsonConvert.DeserializeObject<configa>(File.ReadAllText($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"));
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
               { nconfig.applyconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json", mainl); }
               catch
               { nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"); LogHandler.Log("ABD ","Saved cinfig"); }
   */






#endif

        }
    }
}
