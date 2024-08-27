using System;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Unity.Mathematics;
using System.Collections.Generic;
using System.Net;

public class APIRequest
{
    private const int TIMEOUTDEFAULTPARAMETER = -1;
    private const int TIMEOUTDEFAULT = 60;

    protected string _url_base = Constants.URL_BASE;

    protected UnityWebRequest _request;

    /*public APIRequest(string endPoint, string extend = "", string method = "", string postData = "", int timeout = TIMEOUTDEFAULTPARAMETER)
    {
        _url_base = Constants.URL_BASE;

        _request = new UnityWebRequest(_url_base + endPoint + extend, method);
        if (timeout == TIMEOUTDEFAULTPARAMETER) _request.timeout = TIMEOUTDEFAULT;

        var log = string.Format("API <color=#016CA6> {0} </color>  --- send data {1} ", endPoint, string.IsNullOrEmpty(postData) ? extend : postData);
        Debug.Log(log);
        if (!string.IsNullOrEmpty(postData))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(postData);
            _request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        }
        _request.certificateHandler = new ForceAcceptAll();
        _request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        _request.SetRequestHeader("Api-Token", Constants.API_TOKEN);
        string bearerToken = Config.instance.AccessToken;
        if (!string.IsNullOrEmpty(bearerToken))
        {
            _request.SetRequestHeader("Authorization", "Bearer " + bearerToken);
        }
    }*/

    public APIRequest(Dictionary<string, string> postData, string endPoint, string extend = "", string method = "", int timeout = TIMEOUTDEFAULTPARAMETER)
    {
        _url_base = Constants.URL_BASE;

        _request = new UnityWebRequest(_url_base + endPoint + extend, method);
        Debug.Log($"domain: {_url_base + endPoint + extend}");
        if (timeout == TIMEOUTDEFAULTPARAMETER) _request.timeout = TIMEOUTDEFAULT;

        if (postData.Count > 0)
        {
            WWWForm form = new WWWForm();
            foreach (KeyValuePair<string, string> data in postData)
            {
                form.AddField(data.Key, data.Value);
            }

             
        }
        _request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    }

    public static void Call(string endPoint, string extend, string method, Dictionary<string, string> postData,
        Action<string> onSuccess = null, Action<byte[]> onResponseData = null, Action<string> onFail = null, int timeout = TIMEOUTDEFAULTPARAMETER, Action onTimeout = null)
    {
        _ = new APIRequest(postData, endPoint, extend, method, timeout: timeout)
            .Send((res) =>
            {
                var log = string.Format("API <color=#AD70EF> {0} </color> --- receive data: {1}", endPoint, JsonConvert.SerializeObject(res))
                    .Replace("\\", "");
                Debug.Log(log);
                if (res.ResponseCode == Constants.SUCCESS_CODE)
                {
                    onResponseData?.Invoke(res.ResponseData);
                    onSuccess?.Invoke(res.Response);
                }
                else
                {
                    if (res.ResponseCode == Constants.TIME_OUT_REQUEST || CheckTimeout(res))
                    {
                        onTimeout?.Invoke();
                        return;
                    }
                    var response = JsonConvert.DeserializeObject<APIDataType.MessageDetails>(res.Response);
                    if (onFail == null)
                    {
                        Debug.Log(response.message);
                    }
                    else
                        onFail.Invoke(response.message);
                }
            });
    }

    public static void Call(string endPoint, string method, Dictionary<string, string> postData, Action<string> onSuccess = null,
        Action<byte[]> onResponseData = null, Action<string> onFail = null, int timeout = TIMEOUTDEFAULTPARAMETER, Action onTimeout = null)
    {
        _ = new APIRequest(postData, endPoint, "", method, timeout: timeout)
            .Send((res) =>
            {
                var log = string.Format("API <color=#AD70EF> {0} </color> --- receive data: {1}", endPoint, JsonConvert.SerializeObject(res))
                    .Replace("\\", "");
                Debug.Log(log);
                if (res.ResponseCode == Constants.SUCCESS_CODE)
                {
                    onResponseData?.Invoke(res.ResponseData);
                    onSuccess?.Invoke(res.Response);
                }
                else
                {
                    if (res.ResponseCode == Constants.TIME_OUT_REQUEST || CheckTimeout(res))
                    {
                        onTimeout?.Invoke();
                        return;
                    }
                    var response = JsonConvert.DeserializeObject<APIDataType.MessageDetails>(res.Response);


                    if (onFail == null)
                    {
                        Debug.Log(response.message);
                    }
                    else
                        onFail.Invoke(response.message);
                }
            });
    }
    public static void Call(string endPoint, string extend, string method,
        Action<string> onSuccess = null, Action<byte[]> onResponseData = null, Action<string> onFail = null, int timeout = TIMEOUTDEFAULTPARAMETER, Action onTimeout = null)
    {
        Dictionary<string, string> temp = new Dictionary<string, string>();
        _ = new APIRequest(temp, endPoint, extend, method, timeout: timeout)
            .Send((res) =>
            {
                var log = string.Format("API <color=#AD70EF> {0} </color> --- receive data: {1}", endPoint, JsonConvert.SerializeObject(res))
                    .Replace("\\", "");
                Debug.Log(log);
                if (res.ResponseCode == Constants.SUCCESS_CODE)
                {
                    onResponseData?.Invoke(res.ResponseData);
                    onSuccess?.Invoke(res.Response);
                }
                else
                {
                    if (res.ResponseCode == Constants.TIME_OUT_REQUEST || CheckTimeout(res))
                    {
                        onTimeout?.Invoke();
                        return;
                    }
                    var response = JsonConvert.DeserializeObject<APIDataType.MessageDetails>(res.Response);
                    if (onFail == null)
                    {
                        Debug.Log(response.message);
                    }
                    else
                        onFail.Invoke(response.message);
                }
            });
    }

    public static void Call(string endPoint, string method, Action<string> onSuccess = null,
        Action<byte[]> onResponseData = null, Action<string> onFail = null, int timeout = TIMEOUTDEFAULTPARAMETER, Action onTimeout = null)
    {
        Dictionary<string, string> temp = new Dictionary<string, string>();
        _ = new APIRequest(temp, endPoint, "", method, timeout: timeout)
            .Send((res) =>
            {
                var log = string.Format("API <color=#AD70EF> {0} </color> --- receive data: {1}", endPoint, JsonConvert.SerializeObject(res))
                    .Replace("\\", "");
                Debug.Log(log);
                if (res.ResponseCode == Constants.SUCCESS_CODE)
                {
                    onResponseData?.Invoke(res.ResponseData);
                    onSuccess?.Invoke(res.Response);
                }
                else
                {
                    if (res.ResponseCode == Constants.TIME_OUT_REQUEST || CheckTimeout(res))
                    {
                        onTimeout?.Invoke();
                        return;
                    }
                    var response = JsonConvert.DeserializeObject<APIDataType.      MessageDetails>(res.Response);
                    if (onFail == null)
                    {
                        Debug.Log(response.message);
                    }
                    else
                        onFail.Invoke(response.message);
                }
            });
    }

    public static async Task<APIRequest> CallAsync(string method, string endPoint, Dictionary<string, string> postData)
    {
        return await (new APIRequest(postData, endPoint, "", method)).Send();
    }

    public async Task<APIRequest> Send(System.Action<APIRequest> onDone = null)
    {
        _request.SendWebRequest();

        while (!_request.isDone)
        {
            await Task.Delay(10);
        }

        if (onDone != null)
        {
            OnRequestComplete(onDone);
        }

        // Request and wait for the desired page.
        return this;
    }

    void OnRequestComplete(System.Action<APIRequest> action)
    {
        action(this);
    }

    public string Response => _request.downloadHandler.text;

    public long ResponseCode => _request.responseCode;

    public byte[] ResponseData => _request.downloadHandler.data;

    private static bool CheckTimeout(APIRequest apiRequest)
    {
        return apiRequest._request.error.Equals("Request timeout");
    }
}
