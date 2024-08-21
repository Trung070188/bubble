using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nami.Leaderboard
{
    public enum LeaderboardCategoryType
    {
        STAR,
        FIRSTTRY,
        BESTSTREAK
    }

    public enum LeaderboardClassifyType
    {
        PLAYER,
        NATION
    }

    [Serializable]
    public class LeaderboardPlayer
    {
        public List<LeaderboardPlayerData> PlayerDatas;
        public LeaderboardPlayerData CurrentPlaterData;
    }

    [Serializable]
    public class LeaderboardPlayerData
    {
        public string Id;
        public string Username;
        public int NationId;
        public string ImgUrl;
    }

    [Serializable]
    public class LeaderboardNationData
    {
        public string IdNation;
    }

    public class LeaderboardDataManager : MonoBehaviour
    {
        //public void GetLeaderboardByCategory()
    }
}
