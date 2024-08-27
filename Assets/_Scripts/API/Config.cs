using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : Singleton<Config>
{
    // userData
    /*public APIDataType.MessageDetails UserData { get; set; }
    public string AccessToken
    {
        get
        {
            if (UserData == null)
            {
                return String.Empty;
            }
            return UserData.data == null ? String.Empty : UserData.data.Access_token;
        }
    }*/

    #region User Data
    public APIDataType.User User { get; set; }

    public void SetUser(APIDataType.User user)
    {
        User = user;
    }

    public APIDataType.User GetUser()
    {
        return User;
    }

    public APIDataType.UserData UserData { get; set; }

    public void SetUserData(APIDataType.UserData user)
    {
        UserData = user;
    }

    public APIDataType.UserData GetUserData()
    {
        return UserData;
    }
    #endregion

    #region Level
    public APIDataType.LevelDatas LevelData { get; set; }

    public void SetLevelData(APIDataType.LevelDatas levelData)
    {
        LevelData = levelData;
    }

    public APIDataType.LevelDatas GetLevelData()
    {
        return LevelData;
    }
    #endregion
}
