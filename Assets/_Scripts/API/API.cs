using Nami.Leaderboard;
using Newtonsoft.Json;
using System;
using UnityEngine;

public static class API 
{
    #region Base Account
    public static void InitAndGetInfoUser(string deviceId, Action<APIDataType.User> onDone = null, Action onFail = null)
    {
        //push device id
        APIRequest.Call(EndPoints.GET_USER_INFO, deviceId, EndPoints.GET, (res) =>
        {
            try
            {
                //Get user Information from server
                var responseInfo = JsonConvert.DeserializeObject<DataAPI<APIDataType.User>>(res);
                Config.instance.User = responseInfo.data;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }, null, (x) => 
        { 
            onFail?.Invoke();
        });
    }

    /*public static void GetUserData(int userId, Action onDone, Action onFail = null)
    {
        APIRequest.Call(EndPoints.UPDATE_USER_DATA, userId.ToString(), (res) =>
        {
            try
            {
                var response = JsonConvert.DeserializeObject<DataAPI<APIDataType.UserData>>(res);
                Config.instance.UserData = response.data;
                if (response.data != null)
                {
                    onDone?.Invoke();
                }
            } catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }, null, (x) =>
        {
            onFail?.Invoke();
        });
    }*/

    public static void GetLevelData(int userId, Action onDone = null, Action onFail = null)
    {
        APIRequest.Call(EndPoints.GET_LEVEL_DATA, userId.ToString(), (res) =>
        {
            try
            {
                var response = JsonConvert.DeserializeObject<DataAPI<APIDataType.LevelDatas>>(res);
                Config.instance.LevelData = response.data;
                onDone?.Invoke();
            } catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }, null, (x) => 
        {
            onFail?.Invoke();
        });
    }
    #endregion

    #region Leaderboard
    public static void GetPlayerLeaderboardWithEndPoint(string endpoint, Action<LeaderboardPlayer> onDone, Action onFail)
    {
        APIRequest.Call(endpoint, EndPoints.GET, (res) =>
        {
            var leaderboardData = JsonConvert.DeserializeObject<DataAPI<LeaderboardPlayer>>(res);
            onDone?.Invoke(leaderboardData.data);
        }, null,
        (x) =>
        {
            onFail?.Invoke();
        });
    }

    public static void GetNationLeaderboardWithEndPoint(string endpoint, Action<LeaderboardNation> onDone, Action onFail)
    {
        APIRequest.Call(endpoint, EndPoints.GET, (res) =>
        {
            var leaderboardData = JsonConvert.DeserializeObject<DataAPI<LeaderboardNation>>(res);
            onDone?.Invoke(leaderboardData.data);
        }, null,
        (x) =>
        {
            onFail?.Invoke();
        });
    }
    #endregion

    #region Shop
    public static void GetShopItemData()
    {

    }
    public static void BuyItemInShop()
    {

    }
    #endregion
}
