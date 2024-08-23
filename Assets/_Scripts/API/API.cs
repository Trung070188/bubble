using Nami.Leaderboard;
using Newtonsoft.Json;
using System;

public static class API 
{
    #region Base Account
    public static void InitAndGetDataUser(string deviceId, Action<APIDataType.UserInfo> onDone, Action onFail)
    {
        //push device id

        //if have this id, get user data from server

    }
    #endregion

    #region Leaderboard
    public static void GetPlayerLeaderboardWithEndPoint(string endpoint, Action<LeaderboardPlayer> onDone, Action onFail)
    {
        APIRequest.Call(endpoint, EndPoints.GET, (res) =>
        {
            var leaderboardData = JsonConvert.DeserializeObject<DataAPI<LeaderboardPlayer>>(res);
            onDone?.Invoke(leaderboardData.data);
        },
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
        },
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
