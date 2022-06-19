using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arctic.API;
using MelonLoader;
using Arctic.Main;


namespace Arctic.Main
{
    public class ArcticClientStarter : MelonMod
    {
        public override void OnApplicationStart() => Load.OnStar();

        public override void OnUpdate() => Load.NONOMETHOD();

        public override void OnApplicationLateStart() => Load.OVERSLEEP();

       
    }
}
