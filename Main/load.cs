using MelonLoader;
using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

namespace Arctic.Main
{
    public class Load
    {
        private static Thread tr = new Thread(connect.Runsocket);

        public static void OnStar()
        {
            LogoShower.DisplayLogo();
            Discord.DiscordManager.Downloader();
            MelonLogger.Msg("STARTING THE Discord RPC");
            Discord.DiscordManager.Init();
            MelonCoroutines.Start(Buttons.Buttonlayout.WaitForSM());
            MelonCoroutines.Start(LogoShower.startanim());
            tr.Start();


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
        }

        public static void OVERSLEEP()
        {

            try
            {
                MelonLogger.Msg("On LateNight Was Called");

                Arctic.Main.load.PresenceUpdater();
            }
            catch (Exception ex)
            {
                MelonLogger.Msg(ex);
            }
        }






    }
}
