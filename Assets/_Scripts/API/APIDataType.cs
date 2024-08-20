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
        public Data data;

    }

    [Serializable]
    public class Data
    {
        public string id;
        public string access_token;
        public string userName;
    }
}
