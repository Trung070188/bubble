using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIDataType 
{
    [Serializable]
    public class MessageDetails
    {
        public bool success;
        public string message;
        public int code;
        public DataLogin data;
    }

    [Serializable]
    public class DataLogin
    {
        public string Id;
        public string Access_token;
        public string UserName;
    }

    public class UserInfo
    {
        public string DeviceId;
        public string UserName;
        public int AvtImgId;
        public int TotalStar;
        public int Coin;
        public int Life;
        public int BestStreak;

        public EquipmentInfo Equipment;

        public int CurChap;
        public int CurLv;

        public UserInfo()
        {
            
        }

        public UserInfo(string id, string userName, int avtImgId, int totalStar, int coin, int life, int bestStreak, EquipmentInfo equipment, int curChap, int curLv)
        {
            DeviceId = id;
            UserName = userName;
            AvtImgId = avtImgId;
            TotalStar = totalStar;
            Coin = coin;
            Life = life;
            BestStreak = bestStreak;
            Equipment = equipment;
            CurChap = curChap;
            CurLv = curLv;
        }
    }

    #region Level Data
    public class LevelData
    {
        public int Level;
        public int Chap;
        public int NumberTries;
        public int Star;
    }

    public class LevelDatas
    {
        public List<LevelData> Datas;
    }
    #endregion

    #region Shop
    #endregion
}
