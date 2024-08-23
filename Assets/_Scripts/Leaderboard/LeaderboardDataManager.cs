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

    [Serializable]
    public class LeaderboardNation
    {
        public List<LeaderboardNationData> NationDatas;
    }

    public class LeaderboardDataManager : MonoBehaviour
    {
        //get leaderboard data for player by category
        public void GetPlayerLeaderboardByCategory(string endpoint, Action<List<LeaderboardPlayerData>, LeaderboardPlayerData> onDone)
        {
            API.GetPlayerLeaderboardWithEndPoint(endpoint, (data) =>
            {
                var users = GetUsersDataInit(data);
                var current = GetCurrentUserData(data);
                onDone?.Invoke(users, current);
            }, null);
        }

        //for all other user
        private List<LeaderboardPlayerData> GetUsersDataInit(LeaderboardPlayer dataReceive)
        {
            return dataReceive.PlayerDatas;
        }

        //for current user
        private LeaderboardPlayerData GetCurrentUserData(LeaderboardPlayer dataReceive)
        {
            return dataReceive.CurrentPlayerData;
        }

        //get leaderboard data for nation by category
        public void GetNationLeaderboardByCategory(string endpoint, Action<List<LeaderboardNationData>> onDone)
        {
            API.GetNationLeaderboardWithEndPoint(endpoint, (data) =>
            {
                var datas = GetNationDataInit(data);
                onDone?.Invoke(datas);
            }, null);
        }

        //convert nation data
        private List<LeaderboardNationData> GetNationDataInit(LeaderboardNation dataReceive)
        {
            return dataReceive.NationDatas;
        }
    }
}
