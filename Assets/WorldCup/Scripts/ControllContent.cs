using Unity.VisualScripting;
using UnityEngine;

public class ControllContent : MonoBehaviour
{
    [SerializeField]
    RectTransform contentRectTransform;

    [SerializeField]
    RectTransform layoutRectTransform;

    public GameObject showPrefeb;

    private void Start()
    {
        AddContents();
    }

    public void AddContents()
    {
        int addSize = 500;
        int addSize2 = 250;

        DataManager dataManager = DataManager.Instance;
        WorldCupData currentWorldCup = dataManager.currentWorldcup;

        for (int i = 0; i < currentWorldCup.ImageCount; i++)
        {
            GameObject instance = Instantiate<GameObject>(showPrefeb, layoutRectTransform);
            WorldCupALL worldcupdata = instance.GetComponent<WorldCupALL>();

            Texture2D tex = currentWorldCup.Images[i];

            if (tex != null)
            {

                float width = tex.width;
                float height = tex.height;

                Rect rect = new Rect(0, 0, width, height);

                Vector2 pivot = new Vector2(0.5f, 0.5f);
                Sprite sprite = Sprite.Create(tex, rect, pivot);

                worldcupdata.worldcupimage.sprite = sprite;
            }


            worldcupdata.text.text = currentWorldCup.Describe[i];
            worldcupdata.vote.text = dataManager.currentWorldcupVote[i].ToString();

            layoutRectTransform.anchoredPosition3D += new Vector3(0, addSize2, 0);
            contentRectTransform.sizeDelta += new Vector2(0, addSize);
        }
    }

    
}
