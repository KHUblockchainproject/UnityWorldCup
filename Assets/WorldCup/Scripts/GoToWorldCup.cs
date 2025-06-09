using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToWorldCup : MonoBehaviour
{
    int id;

    public void LetsGoPlayWorldCup()
    {
        // currentWorldcup 에 데이터 넣어주기

        SceneManager.LoadScene("WorldCup");
    }
}
