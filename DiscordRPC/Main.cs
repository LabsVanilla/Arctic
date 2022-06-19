using MelonLoader;
using System;
using System.IO;
using System.Net;

namespace Arctic.Discord
{
    internal static class DiscordManager
    {
        internal static DiscordRpc.RichPresence presence;
        internal static DiscordRpc.EventHandlers eventHandlers;

        internal static void Downloader()
        {
            if (!File.Exists($"{MelonUtils.GameDirectory}\\UserLibs\\discord-rpc.dll"))
            {
                var wc = new WebClient();
                wc.DownloadFile("https://api.glowking.net/Femboycl/discord-rpc.dll", $"{MelonUtils.GameDirectory}\\UserLibs\\discord-rpc.dll");
                MelonLogger.Log("downloaded RPC");
            }

        }


        internal static void Init()
        {
            eventHandlers = default(DiscordRpc.EventHandlers);
            eventHandlers.errorCallback = delegate (int code, string message) { };
            presence.state = $".gg/arcticvrc";
            presence.details = "I hate the way you look at me";
            presence.largeImageKey = "null";
            presence.largeImageText = "By Glowking";
            presence.smallImageKey = "<3";
            presence.smallImageText = "discord.gg/arcticvrc";
            presence.partySize = 0;
            presence.partyMax = 0;
            presence.startTimestamp = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            presence.partyId = "";
            presence.spectateSecret = "IDK";
            try
            {
                DiscordRpc.Initialize("987909418366681118", ref eventHandlers, true, "");
                DiscordRpc.UpdatePresence(ref presence);

            }
            catch { }


        }


    }
}
