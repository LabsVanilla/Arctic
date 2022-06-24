using MelonLoader;

namespace Arctic.Main
{
    public class ArcticClient : MelonMod
    {
        
        public override void OnApplicationStart() => Load.OnStar();

        public override void OnUpdate() => Load.NONOMETHOD();

        public override void OnApplicationLateStart() => Load.OVERSLEEP();

        public override void OnApplicationQuit() => Load.Quitter();
       

    }
}
