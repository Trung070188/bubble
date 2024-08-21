using Nami.Leaderboard;
using Newtonsoft.Json;
using System;

public static class API 
{
    #region Base Account
    public static void Login(string json, Action onDone, Action onFail)
    {
        var isTimeOut = false;
        APIRequest.Call(EndPoints.LOGIN, EndPoints.POST, json, (res) =>
        {
            if (isTimeOut) return;
            var response = JsonConvert.DeserializeObject<APIDataType.MessageDetails>(res);
            if (!response.success)
            {
                //fail login
                onFail?.Invoke();
            } else
            {
                Config.instance.UserData = response;

            }
        });
    }

    public static void Register(string body, Action onDone = null, Action<string> onFail = null)
    {
        APIRequest.Call(EndPoints.REGISTER, EndPoints.POST, body, (res) =>
        {
            onDone?.Invoke();
        }, null, (res) =>
        {
            onFail?.Invoke(res);
        });
    }
    #endregion

    #region Leaderboard
    public static void GetLeaderboardWithEndPoint(string endpoint, Action<LeaderboardPlayer> onDone, Action onFail)
    {
        APIRequest.Call(endpoint, "", EndPoints.GET, "", (res) =>
        {
            var leaderboardData = JsonConvert.DeserializeObject<DataAPI<LeaderboardPlayer>>(res);
            onDone?.Invoke(leaderboardData.data);
        },
        (x) =>
        {
            onFail?.Invoke();
        });
    }
    #endregion
}
