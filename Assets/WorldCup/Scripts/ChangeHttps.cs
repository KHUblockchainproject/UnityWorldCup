using TMPro;
using UnityEngine;

public class ChangeHttps : MonoBehaviour
{
    public TextMeshProUGUI urlText;

    public void ChangeURL()
    {
        DataManager.Instance.ChangeURL(urlText.text);

        Debug.Log(DataManager.Instance.urlprefix);
        Debug.Log(DataManager.Instance.voteprefix);
    }
}
