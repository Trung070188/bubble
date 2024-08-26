using Nami.Leaderboard;
using Newtonsoft.Json;
using System;
using UnityEngine.Networking;

public static class API 
{
    #region Base Account
    public static void InitAndGetDataUser(string deviceId, Action onDone, Action onFail)
    {
        //push device id
        APIRequest.Call(EndPoints.GET_USER_INFO, deviceId, EndPoints.GET, (res) =>
        {
            //Get user data from server
            var responseInfo = JsonConvert.DeserializeObject<DataAPI<APIDataType.UserInfo>>(res);
            Config.instance.UserInfo = responseInfo.data;
            if (onDone != null)
            {
                onDone.Invoke();
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
