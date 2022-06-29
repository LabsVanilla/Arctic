using System;
using System.Collections;
using System.Text;
using UnityEngine;
using VRC.Core;


namespace Arctic
{
    internal class LogoShower
    {
        public static void DisplayLogo()
        {

            string fileVersion = "4";
            Console.Title = $"Arctic || v{fileVersion}";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("              ░█████╗░██████╗░░█████╗░████████╗██╗░█████╗░  ░█████╗░██╗░░░░░██╗███████╗███╗░░██╗████████╗              ");
            Console.WriteLine("              ██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██║██╔══██╗  ██╔══██╗██║░░░░░██║██╔════╝████╗░██║╚══██╔══╝              ");
            Console.WriteLine("              ███████║██████╔╝██║░░╚═╝░░░██║░░░██║██║░░╚═╝  ██║░░╚═╝██║░░░░░██║█████╗░░██╔██╗██║░░░██║░░░             ");
            Console.WriteLine("              ██╔══██║██╔══██╗██║░░██╗░░░██║░░░██║██║░░██╗  ██║░░██╗██║░░░░░██║██╔══╝░░██║╚████║░░░██║░░░             ");
            Console.WriteLine("              ██║░░██║██║░░██║╚█████╔╝░░░██║░░░██║╚█████╔╝  ╚█████╔╝███████╗██║███████╗██║░╚███║░░░██║░░░             ");
            Console.WriteLine("              ╚═╝░ ╚═╝╚═╝░░╚═╝░╚════╝░░░░╚═╝░░░╚═╝░╚════╝░  ░╚════╝░╚══════╝╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░             ");
            Console.WriteLine("                                                                                                                       ");
            Console.WriteLine("                                                                                                                       ");                                                                                                                       ");
            Console.WriteLine("========================================================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;

            Arctic.API.LogHandler.Loader("Success","Starting Arctic Client Now", true);
            
        }


        public static IEnumerator startanim()
        {
#if DEBUG
            yield return null;
#else

            while (APIUser.CurrentUser == null)
                yield return null;

            var wc = new System.Net.WebClient();

            var bytesa = wc.DownloadData("https://api.glowking.net/cl/assets/onstart2");

            var myLoadedAssetBundle = AssetBundle.LoadFromMemory(bytesa);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                yield break;
            }
            var gmj = myLoadedAssetBundle.LoadAsset<GameObject>("toload");
            myLoadedAssetBundle.Unload(false);
            var ssystem = GameObject.Instantiate(gmj, GameObject.Find("/UserInterface").transform.Find("MenuContent").transform);
            ssystem.transform.localScale = new Vector3(1, 1, 1);
            ssystem.transform.localPosition = new Vector3(0, 0, 0);
            ssystem.transform.localRotation = new Quaternion(0, 0, 0, 0);
            ssystem.transform.Find("Anim").transform.localScale = new Vector3(50, 50, 50);
            ssystem.transform.Find("Anim").transform.localPosition = new Vector3(8, -42.1199f, -1001);
            ssystem.transform.Find("Anim/Plane").gameObject.layer = 19;
            ssystem.name = "Animation";
            ssystem.transform.Find("Anim").gameObject.GetComponent<AudioSource>().volume = 0.2f;
            yield return null;
#endif
        }

    }
}
