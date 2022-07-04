using UnityEngine;
using System.Collections;

using UnityEngine.Networking;

namespace Galaxy.styles
{
    internal class LoadAudio
    {
        public static IEnumerator Starter()
        {
            if (Settings.nconfig.ShouldPlayLoadMusic == true)
            {
                var clip = UnityWebRequest.Get(Settings.nconfig.LoadMusic);
            
                clip.SendWebRequest();
                while (!clip.isDone) yield return null;
                if (clip.isHttpError) yield break;

                var audioclip = WebRequestWWW.InternalCreateAudioClipUsingDH(clip.downloadHandler, clip.url, false, false, AudioType.UNKNOWN);

                audioclip.hideFlags = HideFlags.DontUnloadUnusedAsset;

                //load screen when the game first starts
                while (GameObject.Find("UserInterface/LoadingBackground_TealGradient_Music") == null) yield return null;
                var source1 = GameObject.Find("UserInterface/LoadingBackground_TealGradient_Music").transform.Find("LoadingSound").GetComponent<AudioSource>();
                source1.clip = audioclip;
                source1.Play();
                //every load screen after
                while (GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup") == null) yield return null;
                var source2 = GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup").transform.Find("LoadingSound").GetComponent<AudioSource>();
                source2.clip = audioclip;
                source2.Play();
            }
        }
    }
}
