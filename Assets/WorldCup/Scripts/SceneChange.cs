using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject wait;
    private void Start()
    {
        if(wait != null)
        {
            wait.SetActive(false);
        }
        
    }
    public void ChangeScene(string scneeName)
    {
        if (scneeName == "Start")
        {
            if (wait != null)
            {
                wait.SetActive(true);
            }

            string GetWorldCupListURL = DataManager.Instance.urlprefix + "/tournaments";
            Debug.Log("Check2");

            StartCoroutine(DataManager.Instance.GetRequestTitle(GetWorldCupListURL));
        }
        else
        {
            SceneManager.LoadScene(scneeName);
        }
    }

    
}
