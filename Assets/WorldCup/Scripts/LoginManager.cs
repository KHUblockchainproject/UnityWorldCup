using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LoginManager : MonoBehaviour
{
    public TextMeshProUGUI WalletAddress;
    public GameObject LoginPannel;

    string worldcuplist;

    private void Awake()
    {

        if (DataManager.Instance.bIsWalletAddress == true)
        {
            LoginPannel.SetActive(false);
        }
        
    }

    public void SetWalletAddress()
    {
        DataManager.Instance.walletAddress = WalletAddress.text;
        LoginPannel.SetActive(false);
        DataManager.Instance.bIsWalletAddress = true;
        Debug.Log(DataManager.Instance.walletAddress);

        string GetWorldCupListURL = "";
        GetRequest(GetWorldCupListURL);
    }

    public IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {

            yield return webRequest.SendWebRequest();

            if ((webRequest.result == UnityWebRequest.Result.ConnectionError) || (webRequest.result == UnityWebRequest.Result.ProtocolError))
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                worldcuplist = webRequest.downloadHandler.text;
                TournametsJson tournametsJson = JsonUtility.FromJson<TournametsJson>(worldcuplist);
                int size = tournametsJson.tournaments.Count;

                for(int i = 0; i < size; i++)
                {
                    WorldCupTitle newtitle = new WorldCupTitle();

                    newtitle.tournaments = tournametsJson.tournaments[i];

                    string imageurl = "";

                    Texture2D myTexture = null;

                    UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageurl);
                    yield return www.SendWebRequest();

                    if (www.result != UnityWebRequest.Result.Success)
                    {
                        Debug.Log(www.error);
                    }
                    else
                    {
                        myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                    }

                    newtitle.TrumbnailImage = myTexture;
                    DataManager.Instance.worldcuplist.Add(newtitle);
                }
                

            }
        }
    }
}
