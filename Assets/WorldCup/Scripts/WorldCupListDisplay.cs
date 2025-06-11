using System.Collections.Generic;
using UnityEngine;

public class WorldCupListDisplay : MonoBehaviour
{
    [SerializeField]
    RectTransform contentRectTransform;

    [SerializeField]
    RectTransform layoutRectTransform;

    [SerializeField]
    GameObject WorldCupPrefeb;

    [SerializeField]
    public List<GameObject> worldList = new List<GameObject>();

    public GameObject wait;
    public GameObject cw;

    [SerializeField]
    int number;

    public int worldCupCount = 0;

    private void Start()
    {
        wait.SetActive(false);
        cw.SetActive(false);

        GetWorldTitles();

        contentRectTransform.ForceUpdateRectTransforms();
        layoutRectTransform.ForceUpdateRectTransforms();

        worldCupCount = 0;

        number = DataManager.Instance.worldcuplist.Count;

        for (int i = 0; i < number; i++)
        {
            AddContent(i);
        }
    }
    public void ContentCorrection()
    {

    }

    public void SelectButton(int id)
    {

    }

    public void AddContent(int i)
    {
        WorldCupTitle title = DataManager.Instance.worldcuplist[i];


        int addSize = 1700;
        int addSize2 = 850;

        GameObject instance = Instantiate<GameObject>(WorldCupPrefeb, layoutRectTransform);

        Texture2D tex = title.TrumbnailImage;

        if (tex != null)
        {

            float width = tex.width;
            float height = tex.height;

            Rect rect = new Rect(0, 0, width, height);

            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Sprite sprite = Sprite.Create(tex, rect, pivot);

            instance.GetComponent<WorldCupTitleView>().tumbnail.sprite = sprite;
        }
        instance.GetComponent<WorldCupTitleView>().text.text = title.tournaments.tournament_title;
        instance.GetComponent<GoToWorldCup>().id = title.tournaments.tournament_id;


        worldList.Add(instance);
        worldCupCount++;

        if (worldCupCount > 3)
        {
            Debug.Log("Count is bigger than 3");
            layoutRectTransform.anchoredPosition3D += new Vector3(-addSize2, 0, 0);
            contentRectTransform.sizeDelta += new Vector2(addSize, 0);
        }
    }

    public void GetWorldTitles()
    {

    }


}
