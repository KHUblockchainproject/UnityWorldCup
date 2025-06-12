using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using static System.Net.WebRequestMethods;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public System.Collections.Generic.List<WorldCupTitle> worldcuplist;
    public WorldCupData currentWorldcup;

    public List<int> currentWorldcupVote = new List<int>();

    public string walletAddress = null;
    public bool bIsWalletAddress = false;

    public string urlprefix = "http://127.0.0.1:9001/api/tournaments";
    public string voteprefix = "http://127.0.0.1:9001/api/votes";

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
        if (instance == null)
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

    public IEnumerator GetRequestTitle(string url)
    {
        Debug.Log("Check1");

        worldcuplist.Clear();

        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        if ((webRequest.result == UnityWebRequest.Result.ConnectionError) || (webRequest.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.LogError(webRequest.error);
        }
        else
        {
            string worldcuplistjson = webRequest.downloadHandler.text;
            TournametsJson tournametsJson = JsonUtility.FromJson<TournametsJson>(worldcuplistjson);
            int size = tournametsJson.tournaments.Count;

            for (int i = 0; i < size; i++)
            {
                WorldCupTitle newtitle = new WorldCupTitle();

                newtitle.tournaments = tournametsJson.tournaments[i];

                string imageurl = tournametsJson.tournaments[i].thumbnail;

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
                worldcuplist.Add(newtitle);
            }

            SceneManager.LoadScene("Start");
        }

    }


    public IEnumerator UploadWorldCup(string URL, string jsonfile)
    {

        using (UnityWebRequest request = UnityWebRequest.Post(URL, jsonfile, "application/json"))
        {
            yield return request.SendWebRequest();



            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

                SceneManager.LoadScene("Select");
            }


        }

    }

    public IEnumerator GetRequestCurrentWorldCup(string url, int id)
    {
        Debug.Log("Check1");

        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        if ((webRequest.result == UnityWebRequest.Result.ConnectionError) || (webRequest.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.LogError(webRequest.error);
        }
        else
        {
            currentWorldcup.Describe.Clear();
            currentWorldcup.Images.Clear();

            currentWorldcup.Size = WorldCupSize.w16;
            currentWorldcup.WorldcupID = id;



            string json = webRequest.downloadHandler.text;
            Tournament tournametsJson = JsonUtility.FromJson<Tournament>(json);

            int size = tournametsJson.candidates.Count;

            currentWorldcup.ImageCount = size;

            for (int i = 0; i < size; i++)
            {

                string imageurl = tournametsJson.candidates[i].image_url;
                currentWorldcup.Describe.Add(tournametsJson.candidates[i].candidate_name);


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

                currentWorldcup.Images.Add(myTexture);


            }


            SceneManager.LoadScene("WorldCup");
        }

    }

    public IEnumerator VoteWorldCup(string url, string jsonfile)
    {

        using (UnityWebRequest request = UnityWebRequest.Post(url, jsonfile, "application/json"))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

                SceneManager.LoadScene("Select");
            }


        }

    }

    public IEnumerator GoVoteWorldCup(string url, string jsonfile)
    {

        using (UnityWebRequest request = UnityWebRequest.Post(url, jsonfile, "application/json"))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

                string voteurl = voteprefix + "/vote_query";
                using (UnityWebRequest webRequest = UnityWebRequest.Get(voteurl))
                {
                    yield return webRequest.SendWebRequest();

                    if ((webRequest.result == UnityWebRequest.Result.ConnectionError) || (webRequest.result == UnityWebRequest.Result.ProtocolError))
                    {
                        Debug.LogError(webRequest.error);
                    }
                    else
                    {
                        string allvote = webRequest.downloadHandler.text;
                        TotalVote tournametsJson = JsonUtility.FromJson<TotalVote>(allvote);

                        currentWorldcupVote.Clear();

                        for (int i = 0; i < tournametsJson.totalVotes.Count; i++)
                        {
                            currentWorldcupVote.Add(tournametsJson.totalVotes[i]);
                        }

                        SceneManager.LoadScene("WorldCupH");
                    }
                }
            }


        }

    }



    public IEnumerator GoVoteWorldCupTest(string url, string jsonfile)
    {
        string voteurl = voteprefix + "/vote_query";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(voteurl))
        {
            yield return webRequest.SendWebRequest();

            if ((webRequest.result == UnityWebRequest.Result.ConnectionError) || (webRequest.result == UnityWebRequest.Result.ProtocolError))
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                string allvote = webRequest.downloadHandler.text;
                TotalVote tournametsJson = JsonUtility.FromJson<TotalVote>(allvote);

                currentWorldcupVote.Clear();

                for (int i = 0; i < tournametsJson.totalVotes.Count; i++)
                {
                    currentWorldcupVote.Add(tournametsJson.totalVotes[i]);
                }

                SceneManager.LoadScene("WorldCupH");
            }
        }
    }

    public void ChangeURL(string http)
    {
        urlprefix = http + "/api/tournaments";
        voteprefix = http + "/api/votes";
    }
}
