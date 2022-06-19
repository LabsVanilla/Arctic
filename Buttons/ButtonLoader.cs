using Arctic.API;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using MelonLoader;
using UnityEngine.Networking;
using UnityEngine;

namespace Arctic.Buttons
{
    internal class Buttonlayout
    {
        public static IEnumerator WaitForSM()
        {
            
            while (GameObject.Find($"UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup") == null) yield return null;

            Console.WriteLine("Found UI Now Loading Buttons");

            LoadButtons();

        }
        public static void LoadButtons()
        {

            // QMNestedMenu
            // Parameters: Location (Menu Name, QMNestedButton, or QMTabMenu), X Position, Y Position, Button Text, ToolTip Text, Menu Title Text
            // var menu = new QMNestedButton("Arctic", 1, 3, "ArcticClient", "Arctic Client Coldest Client Around", "Arctic Client");

            // QMSingleButton
            // Paramters: Location (QMNestedButton or QMTabMenu), X Position, Y Position, Button Action, ToolTip Text, [Make Half Button (Boolean)]
            // var singleButton = new QMSingleButton(, 1, 0, "Button 1", delegate
            // {
            //     Console.WriteLine("OwO Button Clicked!");
            // }, "Click me to write OwO in the Console!");

            // QMToggleButton
            // Parameters: Location (QMNestedButton or QMTabMenu), X Position, Y Position, Button Text, Toggle On Action, Toggle Off Action, ToolTip Text, [Default Toggle State (Boolean)]
            // var toggleButton = new QMToggleButton(menu, 2, 0, "UwU Toggle", delegate
            //  {
            //     Console.WriteLine("UwU Toggle: On!");
            //  }, delegate
            //  {
            //      Console.WriteLine("UwU Toggle: Off!");
            //  }, "Click to toggle the UwU button!");
            var Sprite = new GameObject();
            // Tab Menu
            // Parameters: ToolTip Text, Menu Title, [Sprite]
            var tabMenu = new QMTabMenu("Arctic OwO", "ArcticClient"  );
            var settingsmenu = new QMNestedButton(tabMenu, 4, 3, "Arctic Settings", "ArcticSettings", "Arctic Client");
            
            var ShowLogo = new QMSingleButton(tabMenu, 1, 0, "Ping Glow if u see this", delegate
            {
                LogoShower.DisplayLogo();
                MelonCoroutines.Start(LogoShower.startanim());
            }, "Click To Show Logo");

            var JoinTheDiscord = new QMSingleButton(tabMenu, 2, 0, "Join The Discord", delegate
            {
  
                Process.Start("https://glowking.net/discord");

            }, "Join The Discord");

            var Serenity = new QMSingleButton(tabMenu, 3, 0, "Bots", delegate
            {
                Console.WriteLine("You Made Good Choice");
                Process.Start("https://discord.gg/vrcbots");
            }, "SERENITY");

            var RestartGame = new QMSingleButton(settingsmenu, 4, 3, "Restart Game", delegate
            {
                try
                {

                    string arguments = "";
                    foreach (string stringi in Environment.GetCommandLineArgs())
                    {
                        arguments += $"{stringi} ";
                    }
                    System.Diagnostics.Process vrc = new System.Diagnostics.Process();
                    vrc.StartInfo.FileName = $"{MelonUtils.GameDirectory}\\VRChat.exe";
                    vrc.StartInfo.Arguments = arguments;
                    vrc.Start();
                    Process.GetCurrentProcess().Kill();
                }
                catch
                {

                }
            }, "Restart Game");

            var CloseGame = new QMSingleButton(settingsmenu, 3, 3, "Close Game", delegate
            {
                Process.GetCurrentProcess().Kill();
            }, "Click me to write OwO in the Console!");




            var Supporters = new QMNestedButton(tabMenu, 3, 3, "Arctic Supporters", "A doller a day can help change a mans life", "Arctic Supporters");

            // QMSingleButton
            // Paramters: Location (QMNestedButton or QMTabMenu), X Position, Y Position, Button Action, ToolTip Text, [Make Half Button (Boolean)]
            var singleButton = new QMSingleButton(Supporters, 3, 2, "This Can Be You", delegate
            {
                Console.WriteLine("Thank You");
            }, "Click me to write OwO in the Console!");

            //  QMToggleButton
            // Parameters: Location (QMNestedButton or QMTabMenu), X Position, Y Position, Button Text, Toggle On Action, Toggle Off Action, ToolTip Text, [Default Toggle State (Boolean)]
            var toggleButton = new QMToggleButton(Supporters, 2, 0, "UwU Toggle", delegate
            {
                Console.WriteLine("UwU Toggle: On!");
            }, delegate
            {
                Console.WriteLine("UwU Toggle: Off!");
            }, "Click to toggle the UwU button!");

           
            Console.WriteLine("Buttons Should Load");






        }

      




    }
}
