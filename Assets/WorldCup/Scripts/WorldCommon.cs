using UnityEngine;

public struct WorldCupTitle
{
    public Texture2D Trumbnail;
    public string Title;
    public int worldcupID;
}

public struct WorldCupData
{
    public int WorldcupID;
    public int ImageCount;
    public WorldCupSize Size;

    public Texture2D[] Images;
    public string[] Describe;
}

public enum WorldCupSize
{
    w64,
    w32,
    w16
}

public class WorldCommon : MonoBehaviour
{

}