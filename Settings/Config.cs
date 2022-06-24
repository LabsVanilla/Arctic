using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Arctic.Settings
{
    internal class Config
    {
        public static bool ShouldFly = false;
    }

    
        [Serializable]
        
        public class configa
        {

            public string QuestCrash { get; set; }
        public string PCCrash { get; set; }

    }

        public class nconfig
        {
            public static void saveconfig(string path)
            {
                var sv = new configa()
                {
                   QuestCrash = QuestCrash,
                   PCCrash = PCCrash,
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

            saveconfig(path);

            }

        public static string QuestCrash = "avtr_0c8a5fad-fab9-4940-8c50-dc638b52f41b";
        public static string PCCrash = "avtr_0c8a5fad-fab9-4940-8c50-dc638b52f41b";

    }



    }

