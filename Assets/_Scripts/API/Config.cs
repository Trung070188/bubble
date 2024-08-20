using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : Singleton<Config>
{
    // userData
    public APIDataType.MessageDetails UserData { get; set; }
    public string AccessToken
    {
        get
        {
            if (UserData == null)
            {
                return String.Empty;
            }
            return UserData.data == null ? String.Empty : UserData.data.access_token;
        }
    }
}
