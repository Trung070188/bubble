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
        public Sprite AvtImg;
        public int TotalStar;
        public int Coin;
        public int Life;
        public int BestStreak;
        public EquipmentInfo Equipment;

        public UserInfo()
        {
            
        }

        public UserInfo(string id, string userName, Sprite avtImg, int totalStar, int coin, int life, int bestStreak, EquipmentInfo equipment)
        {
            DeviceId = id;
            UserName = userName;
            AvtImg = avtImg;
            TotalStar = totalStar;
            Coin = coin;
            Life = life;
            BestStreak = bestStreak;
            Equipment = equipment;
        }
    }
}
