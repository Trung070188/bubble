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
        public readonly int UserId;
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
        public int id;
        public string username;
        public string device_uid;
        public int avt_image_id;
        public int coin;
        public int best_streak;
        public int cur_chap;
        public int cur_level;

        public int total_star;
        public int life;
        public int user_data_id;

        public EquipmentInfo equipment;
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
