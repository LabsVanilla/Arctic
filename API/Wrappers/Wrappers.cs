using VRC;


namespace Arctic.Wrappers
{


    internal class playerW
    {
        public static Player LocalPlayer
        {
            get
            {
                return Player.prop_Player_0;
            }
        }
    }
    internal class WorldW
    {
        public static bool IsInWorld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0 != null;
        }
    }
}


