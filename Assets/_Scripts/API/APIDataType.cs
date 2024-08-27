using System;
using System.Collections.Generic;

public class APIDataType 
{
    [Serializable]
    public class MessageDetails
    {
        public bool success;
        public string message;
        public int code;
        public User data;
    }

    [Serializable]
    public class UserData
    {
        public int UserId;
        public int AvtImgId;
        public int TotalStar;
        public int Coin;
        public int Life;
        public int BestStreak;

        public EquipmentInfo Equipment;

        public int CurChap;
        public int CurLv;

        public UserData()
        {
            
        }
    }

    [Serializable]
    public class User
    {
        public string DeviceId;
        public string UserName;
        public int UserId;
        public int AvtImgId;
        public int TotalStar;
        public int Coin;
        public int Life;
        public int BestStreak;

        public EquipmentInfo Equipment;

        public int CurChap;
        public int CurLv;
    }

    #region Level Data
    [Serializable]
    public class LevelData
    {
        public int UserId;
        public int Level;
        public int Chap;
        public int NumberTries;
        public int Star;
    }

    [Serializable]
    public class LevelDatas
    {
        public List<LevelData> Datas;
    }
    #endregion

    #region Shop
    #endregion
}
