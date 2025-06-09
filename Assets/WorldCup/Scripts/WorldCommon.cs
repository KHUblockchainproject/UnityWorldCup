using NUnit.Framework;
using UnityEngine;

public struct WorldCupTitle
{
    public Texture2D TrumbnailImage;
    Tournaments tournaments;
}

[System.Serializable]
public class Tournaments
{
    int tournament_id;
    string tournament_title;
    string description;
    string thumbnail;
}

[System.Serializable]
public class Candidates
{
    string name;
    string image_url;
}

[System.Serializable]
public class Tournament
{
    int tournament_id;
    string tournament_title;
    string description;
    string wallet_address;
    string thumbnail;
    Candidates[] candidates;
}

[System.Serializable]
public class Vote
{
    int tournament_id;
    string wallet_address;
    int selected_candidate_id;
}

[System.Serializable]
public class Check_Vote
{
    string wallet_address;
    int tournament_id;
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