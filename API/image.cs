using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using MelonLoader;
namespace Arctic.API
{
    internal class image
    {

        public static IEnumerator loadtexture2d(Texture2D Instance, string url)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            Instance = DownloadHandlerTexture.GetContent(www);
        }


        public static IEnumerator loadspriterest(Image Instance, string url)
        {

            var www = UnityWebRequestTexture.GetTexture(url);
            _ = www.downloadHandler;
            var asyncOperation = www.SendWebRequest();
            Func<bool> func = () => asyncOperation.isDone;
            yield return new WaitUntil(func);
            if (www.isHttpError || www.isNetworkError)
            {
                MelonLogger.Log("Error4 : " + www.error);

                yield break;
            }

            var content = DownloadHandlerTexture.GetContent(www);
            var sprite2 = Instance.sprite = Sprite.CreateSprite(content,
                new Rect(0f, 0f, content.width, content.height), new Vector2(0f, 0f), 100000f, 1000u,
                SpriteMeshType.FullRect, Vector4.zero, false);

            if (sprite2 != null) Instance.sprite = sprite2;
        }
    }
}
