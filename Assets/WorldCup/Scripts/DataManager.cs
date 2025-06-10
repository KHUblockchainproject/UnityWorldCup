using NUnit.Framework;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public System.Collections.Generic.List<WorldCupTitle> worldcuplist;
    public WorldCupData currentWorldcup;

    public string walletAddress = null;
    public bool bIsWalletAddress = false;

    public static DataManager Instance
    {
        get 
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("DataManager");
                instance = obj.AddComponent<DataManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TrnasferWorldCupInfo(int id)
    {

    }

}
