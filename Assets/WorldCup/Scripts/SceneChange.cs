using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeScene(string scneeName)
    {
        SceneManager.LoadScene(scneeName);
    }
}
