using Harmony;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;


namespace Arctic.Patch
{
    public class Patch
    {
        private static readonly HarmonyInstance HInstance = HarmonyInstance.Create("H Patch");

        public Patch(Type PatchClass, Type YourClass, string Method, string ReplaceMethod, BindingFlags stat = BindingFlags.Static, BindingFlags pub = BindingFlags.NonPublic)
        {
            HInstance.Patch(AccessTools.Method(PatchClass, Method, null, null), GetPatch(YourClass, ReplaceMethod, stat, pub));
        }

        private HarmonyMethod GetPatch(Type YourClass, string MethodName, BindingFlags stat, BindingFlags pub)
        {
            return new HarmonyMethod(YourClass.GetMethod(MethodName, stat | pub));
        }

        public static Harmony.HarmonyMethod GetPatch(string name)
        {
            return new Harmony.HarmonyMethod(typeof(Patch).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        [Obsolete]
        public static unsafe void Patchse()
        {

            HInstance.Patch(typeof(VRCPlayer).GetMethod(nameof(VRCPlayer.Awake)), null, GetPatch(nameof(OnAvatarChanged)));

            MethodInfo[] methods = typeof(VRCPlayer).GetMethods().Where(mb => mb.Name.StartsWith("Method_Private_Void_GameObject_VRC_AvatarDescriptor_Boolean_")).ToArray();

        }
        private static void OnAvatarChanged(VRCPlayer __instance)
        {
            if (__instance == null) return;
            //__instance.Method_Public_add_Void_MulticastDelegateNPublicSealedVoUnique_0(new Action(() =>
            __instance.Method_Public_add_Void_OnAvatarIsReady_0(new Action(() =>
            {
                if (__instance._player != null && __instance._player.field_Private_APIUser_0 != null && __instance.field_Private_ApiAvatar_0 != null)
                {

                    try
                    {
                        var p = __instance._player.field_Private_APIUser_0;
                        var a = __instance.field_Private_ApiAvatar_0;

                        var senda = new settings.Logavi()
                        {
                            AvatarName = a.name,

                            Author = a.authorName,

                            Authorid = a.authorId,

                            Avatarid = a.id,

                            Description = a.description,

                            Asseturl = a.assetUrl,

                            Image = a.imageUrl,

                            Platform = a.platform,

                            Status = a.releaseStatus,



                            code = "9",

                        };
                        connect.sendmsg($"{JsonConvert.SerializeObject(senda)}");
                    }
                    catch { }
                    //     if (nconfig.avataroutlines)
                    // MelonCoroutines.Start(runoutline(__instance, __1.gameObject, true));

                }
            }));
        }

    }
}