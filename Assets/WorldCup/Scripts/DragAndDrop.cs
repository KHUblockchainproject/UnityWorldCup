using UnityEngine;
using B83.Win32;
using UnityEngine.Events;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour
{
    public UnityEvent onDroppedFiles;
    public List<string> filesDropped = new List<string>();
    public List<GameObject> worldCupDes = new List<GameObject>();
    public GameObject AddWorldCup;


    // WorldCupAddDisplay
    [SerializeField]
    RectTransform contentRectTransform;

    [SerializeField]
    RectTransform layoutRectTransform;

    int worldCupCount = 0;

    


    private void Awake()
    {
        UnityDragAndDropHook.InstallHook(); //��� ��ġ
        UnityDragAndDropHook.OnDroppedFiles += OnDroppedFiles; //�ݹ� �Լ� ���
    }

    private void OnDestroy()
    {
        UnityDragAndDropHook.UninstallHook(); //��� ����
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SaveWorldCup();
        }
    }

    private void OnDroppedFiles(List<string> afiles, POINT aPos) //��ϵ� �ݹ� �Լ�
    {
        for(int i = 0; i < afiles.Count; i++)
        {
            filesDropped.Add(afiles[i]);

            string fileName = afiles[i];
            MakeWorldCupImage(fileName);
        }

        onDroppedFiles.Invoke(); //�̺�Ʈ ����
    }

    public void MakeWorldCupImage(string filename)
    {
        if (worldCupCount >= 15 && worldCupCount%5 == 0)
        {
            Debug.Log("Content Add");

            int addSize = 600;

            layoutRectTransform.sizeDelta += new Vector2(0, addSize);
            contentRectTransform.sizeDelta += new Vector2(0, addSize);
        }

        byte[] bytes = System.IO.File.ReadAllBytes(filename);

        Texture2D tex = new Texture2D(0, 0);
        tex.LoadImage(bytes);

        GameObject worldCupImage = Instantiate(AddWorldCup, layoutRectTransform);
        worldCupDes.Add(worldCupImage);

        if (tex != null)
        {

            float width = tex.width;
            float height = tex.height;

            Rect rect = new Rect(0, 0, width, height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Sprite sprite = Sprite.Create(tex, rect, pivot);

            if (sprite != null) 
            {
                worldCupImage.GetComponent<AddWorldCupImage>().worldCupimage.sprite = sprite;
            }
            else
            {
                Debug.Log("There is no Sprite");
            }
        }
        else
        {
            Debug.Log("There is no Texture2D");
        }

        worldCupCount++;

        
    }

    private Texture2D LoadTexture(string resourcePath)
    {
        byte[] bytes = System.IO.File.ReadAllBytes(resourcePath);

        Texture2D tex = new Texture2D(0, 0);
        tex.LoadImage(bytes);

        if (tex == null)
        {
            Debug.LogWarning($"[IGA] �̹��� �ε� ����: {resourcePath}");
        }

        return tex;
    }

    public void SaveWorldCup()
    {
        for(int i = 0; i < worldCupCount; i++)
        {
            TextMeshProUGUI text = worldCupDes[i].GetComponent<AddWorldCupImage>().textMesh;
            Debug.Log(text.text);
            Debug.Log(filesDropped[i]);

            SceneManager.LoadScene("Select");
        }
    }
}
