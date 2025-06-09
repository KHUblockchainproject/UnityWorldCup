using UnityEngine;

public struct WorldCupTitle
{
    public Texture2D TrumbnailImage;
    Tournaments tournaments;
}

public struct Tournaments
{
    int tournament_id;
    string tournament_title;
    string description;
    string thumbnail;
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