using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToWorldCup : MonoBehaviour
{
    int id;

    public void LetsGoPlayWorldCup()
    {
        // currentWorldcup �� ������ �־��ֱ�

        SceneManager.LoadScene("WorldCup");
    }
}
