using TMPro;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    public TextMeshProUGUI WalletAddress;
    public GameObject LoginPannel;

    private void Awake()
    {
        /*
        if(DataManager.Instance.walletAddress != null)
        {
            LoginPannel.SetActive(false);
            Debug.Log(DataManager.Instance.walletAddress);
        }
        */
    }

    public void SetWalletAddress()
    {
        DataManager.Instance.walletAddress = WalletAddress.text;
        LoginPannel.SetActive(false);
        Debug.Log(DataManager.Instance.walletAddress);
    }
}
