using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LoginManager : MonoBehaviour
{
    public TextMeshProUGUI WalletAddress;
    public GameObject LoginPannel;

    private void Awake()
    {

        if (DataManager.Instance.bIsWalletAddress == true)
        {
            LoginPannel.SetActive(false);
        }
        
    }

    private void Start()
    {
        
    }

    public void SetWalletAddress()
    {
        DataManager.Instance.walletAddress = WalletAddress.text;
        LoginPannel.SetActive(false);
        DataManager.Instance.bIsWalletAddress = true;
        Debug.Log(DataManager.Instance.walletAddress);

        
    }

    
}
