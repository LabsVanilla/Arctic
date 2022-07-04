using MelonLoader;
using System.IO;
using System.Net;

namespace Galaxy.API.Utils
{
    internal class Install
    {
        public static void InstallBC()
        {
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Galaxy"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Galaxy");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Galaxy.key"))
            {
                File.Create($"{MelonUtils.GameDirectory}\\Galaxy\\Galaxy.key");
                //Settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
                LogHandler.Log("Config", "Created KeyFile", false);
            }
           

            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies");
            }

            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Config"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Galaxy\\Config");
            }

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json"))
            {
                File.Create($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
                //Settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
                LogHandler.Log("Config", "Created Config", false);
            }
            else
            {
                Main.Load.LoadConfig();
                LogHandler.Log("Config", "Loading Config");
            }

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies\\discord-rpc.dll"))
            {
                var wc = new WebClient();
                wc.DownloadFile("https://api.galaxyvrc.xyz/Galaxy/Dependencies/discord-rpc.dll", $"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies\\discord-rpc.dll");
                LogHandler.Log("Downloader", "Downloaded Discord RPC", false);
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies\\clientassetbundle"))
            {
                var wc = new WebClient();
                wc.DownloadFile("https://api.galaxyvrc.xyz/Galaxy/Dependencies/clientassetbundle", $"{MelonUtils.GameDirectory}\\Galaxy\\Dependencies\\clientassetbundle");
                LogHandler.Log("Downloader", "Downloaded Discord RPC", false);
            }
            Settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Galaxy\\Config\\GenConfig.json");
        }

    }

}
