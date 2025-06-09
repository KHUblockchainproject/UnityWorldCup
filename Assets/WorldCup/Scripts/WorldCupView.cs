using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldCupView : MonoBehaviour
{

    List<int> selectedImage;

    int size;

    int currentImage;
    int select;

    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    
    public Button left;
    public Button right;

    GameObject SelectSizeUI;

    int leftId;
    int rightId;

    int finalId;

    int maxImagesSize;

    private void Start()
    {

        DataManager dataManager = DataManager.Instance;

        WorldCupData worldCupData = dataManager.currentWorldcup;
        worldCupData.Size = WorldCupSize.w16;

        maxImagesSize = worldCupData.ImageCount;
        selectedImage = new List<int>();

        for(int i = 0;  i < maxImagesSize; i++)
        {
            selectedImage.Add(i);
        }

        Debug.Log(selectedImage.Count);

        ShuffleList(ref selectedImage, selectedImage.Count);

        size = 16;

        currentImage = 0;
        select = 0;

        GetNextImage();

    }

    public void ClickButton(bool button)
    {

        // True == Left False == Right

        if (size == 1)
        {
            Debug.Log("Final");

            if (button == true)
            {
                finalId = leftId;
            }
            else
            {
                finalId = rightId;
            }
        }
        else
        {
            if (button == true)
            {
                selectedImage[select] = leftId;
                select++;
            }
            else
            {
                selectedImage[select] = rightId;
                select++;
            }

            GetNextImage();
        }

        
    }

    public void ShowSelectUI()
    {
        SelectSizeUI.SetActive(true);
    }



    public void GetNextImage()
    {
        if (true)
        {
            Image img = right.GetComponent<Image>();

            DataManager dataManager = DataManager.Instance;
            WorldCupData worldCupData = dataManager.currentWorldcup;

            Debug.Log(currentImage);

            leftId = selectedImage[currentImage];
            rightId = selectedImage[currentImage + 1];

            leftText.text = worldCupData.Describe[leftId];
            rightText.text = worldCupData.Describe[rightId];



            Texture2D tex = worldCupData.Images[leftId];

            if (tex != null)
            {
                float width = tex.width;
                float height = tex.height;

                Rect rect = new Rect(0, 0, width, height);

                Vector2 pivot = new Vector2(0.5f, 0.5f);
                Sprite sprite = Sprite.Create(tex, rect, pivot);

                left.image.sprite = sprite;

            }


            tex = worldCupData.Images[rightId];

            if (tex != null)
            {
                float width = tex.width;
                float height = tex.height;

                Rect rect = new Rect(0, 0, width, height);

                Vector2 pivot = new Vector2(0.5f, 0.5f);
                Sprite sprite = Sprite.Create(tex, rect, pivot);

                right.image.sprite = sprite;

            }


            currentImage += 2;


            if (size == currentImage)
            {
                currentImage = 0;
                select = 0;
                size = size / 2;
            }

            Debug.Log(size);
        }
        
    }

    public void SetWorldCupImages()
    {
        DataManager dataManager = DataManager.Instance;
        WorldCupSize currentSzie = dataManager.currentWorldcup.Size;

        if (currentSzie == WorldCupSize.w64)
        {
            selectedImage = new List<int>(64);
        }
        else if(currentSzie == WorldCupSize.w32)
        {
            selectedImage = new List<int>(32);
        }
        else if(currentSzie == WorldCupSize.w16)
        {
            selectedImage = new List<int>(16);
        }
        else
        {
            Debug.LogWarning("There is no WorldCupSize");
        }
    }

    public void ShuffleList(ref List<int> list, int size)
    {
        int random1, random2;
        int temp;

        for (int i = 0; i < size; i++)
        {
            random1 = UnityEngine.Random.Range(0, size);
            random2 = UnityEngine.Random.Range(0, size);

            temp = list[random1];
            list[random1] = list[random2];
            list[random2] = temp;
        }
    }

    public void WorldCupEnd()
    {

    }


}
