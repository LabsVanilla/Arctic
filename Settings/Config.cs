using System;
using System.IO;

namespace Arctic.Settings
{
    internal class Config
    {
        public static bool ShouldFly = false;

        public static string GlowLocation = "";
    }


    [Serializable]

    public class configa
    {

        public string QuestCrash { get; set; }
        public string PCCrash { get; set; }
        public bool ESP { get; set; }
        public string CurentWorld { get; set; }
        public bool Shouldrejoin { get; set; }
        
    }

    public class nconfig
    {
        public static void saveconfig(string path)
        {
            var sv = new configa()
            {
                QuestCrash = QuestCrash,
                PCCrash = PCCrash,
                ESP = ESP,
                CurentWorld = CurentWorld,
                Shouldrejoin = Shouldrejoin,
            };
            try
            {
                File.WriteAllText(path, $"{Newtonsoft.Json.JsonConvert.SerializeObject(sv)}");
            }
            catch
            {
                API.LogHandler.Error("Failed To Save Config IF you just started VRCHAT dont worry if not please alert Glow", "Config Saver");
            }


        }


        public static void applyconfig(string path, configa sta)
        {
            QuestCrash = (string)sta.QuestCrash;
            PCCrash = (string)sta.PCCrash;
            ESP = (bool)sta.ESP;
            CurentWorld = (string)sta.CurentWorld;
            Shouldrejoin = (bool)sta.Shouldrejoin;

            saveconfig(path);

        }

        public static string QuestCrash = "avtr_0c8a5fad-fab9-4940-8c50-dc638b52f41b";
        public static string PCCrash = "avtr_0c8a5fad-fab9-4940-8c50-dc638b52f41b";
        public static bool ESP = false;
        public static string CurentWorld = "";
        public static bool Shouldrejoin = false;
    }



}

