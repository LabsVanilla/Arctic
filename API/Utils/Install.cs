using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace Arctic.API.Utils
{
    internal class Install
    {
        public static void InstallBC()
        {
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Arctic"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Arctic");
            }

            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Config"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Arctic\\Config");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Arctic\\Config\\GenConfig.json"))
            {
                File.Create($"{MelonUtils.GameDirectory}\\Arctic\\Config\\GenConfig.json");
               Settings.nconfig.saveconfig($"{MelonUtils.GameDirectory}\\Arctic\\Config\\GenConfig.json");

            }
            Main.Load.LoadConfig();

        }



    }
}
