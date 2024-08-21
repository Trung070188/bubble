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
        public string Id;
        public string UserName;
        public Sprite AvtImg;
        public int TotalStar;
        public int Coin;
        public int Life;
        public int BestStreak;
    }
}
