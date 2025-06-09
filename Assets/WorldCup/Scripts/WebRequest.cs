using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    public Texture2D GetTexture(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            return null;
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            return myTexture;
        }
    }

    public IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            
            yield return webRequest.SendWebRequest();

            if((webRequest.result == UnityWebRequest.Result.ConnectionError) || (webRequest.result == UnityWebRequest.Result.ProtocolError))
            {
                Debug.LogError(webRequest.error);
            }
            else
            {

            }
        }
    }


}


