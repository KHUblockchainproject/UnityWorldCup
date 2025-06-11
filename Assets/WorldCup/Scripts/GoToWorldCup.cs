using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GoToWorldCup : MonoBehaviour
{
    public int id;

    GameObject wait;
    GameObject cw;

    public void LetsGoPlayWorldCup()
    {
        // currentWorldcup 에 데이터 넣어주기



        Debug.Log("testcheck");

        string prefix = DataManager.Instance.urlprefix;
        string url = prefix + "/"+id;
        StartCoroutine(DataManager.Instance.GetRequestCurrentWorldCup(url, id));

        
    }

    public void Click()
    {
        Debug.Log("Check");

        wait = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        cw = GameObject.Find("Canvas").transform.GetChild(2).gameObject;

        StartCoroutine(CheckWorldUsed());
    }

    public IEnumerator CheckWorldUsed()
    {
        

        
        if (wait != null)
        {
            wait.SetActive(true);
        }

        VoteQury votequry = new VoteQury();
        votequry.wallet_address = DataManager.Instance.walletAddress;
        votequry.tournament_id = id;

        string json = JsonUtility.ToJson(votequry);
        string qurryurl = DataManager.Instance.voteprefix + "/vote_query";


        using (UnityWebRequest request = UnityWebRequest.Post(qurryurl, json, "application/json"))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                if (wait != null)
                {
                    wait.SetActive(false);
                }

                Debug.Log(request.error);
            }
            else
            {
                string check = request.downloadHandler.text;

                if(check == "true" || check == "1")
                {
                    if (wait != null)
                    {
                        wait.SetActive(false);
                    }

                    
                    cw.SetActive(true);
                }
                else
                {
                    LetsGoPlayWorldCup();
                }
            }
        }
    }


}
