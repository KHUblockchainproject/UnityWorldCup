using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WorldCupTitle
{
    public Texture2D TrumbnailImage;
    public Tournaments tournaments;
}

[System.Serializable]
public class TournametsJson
{
    public List<Tournaments> tournaments = new List<Tournaments>();
}

[System.Serializable]
public class Tournaments
{
    public int tournament_id;
    public string tournament_title;
    public string description;
    public string thumbnail;
}

[System.Serializable]
public class Candidates
{
    public string name;
    public string image_url;
}

[System.Serializable]
public class Tournament
{
    public int tournament_id;
    public string tournament_title;
    public string description;
    public string wallet_address;
    public string thumbnail;
    public List<Candidates> candidates = new List<Candidates>();
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

[System.Serializable]
public struct WorldCupData
{
    public int WorldcupID;
    public int ImageCount;
    public WorldCupSize Size;

    public Texture2D[] Images;
    public string[] Describe;
}

[System.Serializable]
public enum WorldCupSize
{
    w64,
    w32,
    w16
}

public class WorldCommon : MonoBehaviour
{

}