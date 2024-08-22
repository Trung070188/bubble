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
        public LeaderboardPlayerData CurrentPlayerData;
    }

    [Serializable]
    public class LeaderboardPlayerData
    {
        public string UserId;
        public int RankIndex;
        public string Username;
        public int NationId;
        public string ImgUrl;
        public int Point;
    }

    [Serializable]
    public class LeaderboardNationData
    {
        public string IdNation;
        public int Point;
    }

    public class LeaderboardDataManager : MonoBehaviour
    {
        public void GetPlayerLeaderboardByCategory(string endpoint, Action<List<LeaderboardPlayerData>, LeaderboardPlayerData> onDone)
        {
            API.GetPlayerLeaderboardWithEndPoint(endpoint, (data) =>
            {
                
            }, null);
        }

        private List<LeaderboardPlayerData> GetUsersDataInit(LeaderboardPlayer dataReceive)
        {
            var 
        }
    }
}
