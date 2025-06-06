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

    [SerializeField]
    int number;

    public int worldCupCount = 0;

    private void Start()
    {
        GetWorldTitles();

        contentRectTransform.ForceUpdateRectTransforms();
        layoutRectTransform.ForceUpdateRectTransforms();

        worldCupCount = 0;

        for(int i = 0; i < number; i++)
        {
            AddContent();
        }
    }
    public void ContentCorrection()
    {

    }

    public void SelectButton(int id)
    {

    }

    public void AddContent()
    {

        int addSize = 1700;
        int addSize2 = 850;

        GameObject instance = Instantiate<GameObject>(WorldCupPrefeb, layoutRectTransform);
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
