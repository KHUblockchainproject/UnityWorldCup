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

            }
        }
    }
}
