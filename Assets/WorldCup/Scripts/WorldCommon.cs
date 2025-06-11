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
public class VoteQury
{
    public string wallet_address;
    public int tournament_id;
}

[System.Serializable]
public class TotalVote
{
    public List<int> totalVotes = new List<int>();
}

[System.Serializable]
public class Candidates
{
    public string Candidate_Name;
    public string Image_url;
}

[System.Serializable]
public class WorldCupCandidates
{
    public string candidate_id;
    public string candidate_name;
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
    public List<WorldCupCandidates> candidates = new List<WorldCupCandidates>();
}

[System.Serializable]
public class MakeWorldCup
{
    public string Tournament_title;
    public string Description;
    public string Wallet_address;
    public string Thumbnail;
    public List<Candidates> Candidates = new List<Candidates>();
}

[System.Serializable]
public class Vote
{
    public int tournament_id;
    public string wallet_address;
    public int selected_candidate_id;
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

    public List<Texture2D> Images;
    public List<string> Describe;
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