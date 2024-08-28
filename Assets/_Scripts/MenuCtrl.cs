using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

public class MenuCtrl : MonoBehaviour
{
    [Header("Screen")]
    [SerializeField]
    private GameObject startScreen;

    [SerializeField]
    private GameObject chooseModeScreen;

    [SerializeField]
    private GameObject levelScreen;

    [SerializeField]
    private GameObject topIcons;

    [Space(10)]
    [Header("Select Level")]
    [SerializeField]
    private GameObject lvPrefab;

    [SerializeField]
    private GameObject lvsContentParent;

    [SerializeField]
    private TMP_Dropdown chapterDropdown;

    [SerializeField]
    private GameObject notEnoughLifePopup;

    public Sprite PlayedSprite;

    public Sprite NotPlaySprite;

    private int _curChap = -1;

    private List<GameObject> _lvBtnLst = new List<GameObject>();

    [Space(10)]
    [Header("LeaderBoard")]
    [SerializeField]
    private GameObject leaderboard;

    [SerializeField]
    private GameObject starBtn;

    [SerializeField]
    private GameObject firstTryBtn;

    [SerializeField]
    private GameObject bestStreakBtn;

    [SerializeField]
    private GameObject playerBtn;

    [SerializeField]
    private GameObject nationBtn;
    //private int _lastSelectedChapter = 0;

    [Space(10)]
    [Header("Shop")]
    [SerializeField]
    private int maxPage;

    [SerializeField]
    private Vector3 pageStep;

    [SerializeField]
    private RectTransform shopPagesRect;

    [SerializeField]
    private float tweenTime;

    [SerializeField]
    private LeanTweenType tweenType;

    public List<ShopItemSO> ShopItemSOs = new List<ShopItemSO>();

    private int _currentPage;

    private Vector3 _targetPos;

    //Singleton
    public static MenuCtrl Instance { get; private set; }

    private void Awake()
    {
        //singleton
        Instance = this;

        //swipe shop
        _currentPage = 1;
        _targetPos = shopPagesRect.localPosition;

        //get user info
        GetData();
        //StartCoroutine(Test());
    }

    // Start is called before the first frame update
    void Start()
    {
        //_curChap = PlayerPrefs.GetInt(DataConfig.CURRENTCHAPTER, -1);

        //set playerpref default
        /*if (_curChap == -1)
        {
            PlayerPrefs.SetInt(DataConfig.CURRENTCHAPTER, 1);
            PlayerPrefs.SetInt(DataConfig.CURRENTLV + "1", 0);
            _curChap = 1;
        }*/

        //_lastSelectedChapter = PlayerPrefs.GetInt(DataConfig.LASTSELECTCHAPTER, 1);

        chapterDropdown.onValueChanged.AddListener(delegate
        {
            LoadLv(chapterDropdown.value + 1);
        });

        //check if open or return from main game
        if (!DataConfig.ReturnFromGame)
        {
            ChooseModeScreenBackBtn();
        }
        else
        {
            if (DataConfig.IsArcadeMode)
            {
                DataConfig.IsArcadeMode = false;
                OnClickReadyBtn();
            } else
            {
                AdventureMode();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Get Data
    public void GetData()
    {
        if (DataConfig.IsLoadUserDatas)
        {
            API.InitAndGetInfoUser(SystemInfo.deviceUniqueIdentifier, (res) =>
            {
                DataConfig.IsLoadUserDatas = false;
                _curChap = res.cur_chap;
                res.life = 30;
                Dictionary<string, string> temp = new Dictionary<string, string>();
                temp.Add(nameof(res.life), res.life.ToString());
                API.UpdateUserData(temp, res.user_data_id.ToString(), () =>
                {
                    API.InitAndGetInfoUser(SystemInfo.deviceUniqueIdentifier);
                });
            }, null);
        }

        //load level data
        if (DataConfig.IsLoadLvDatas)
        {
            //API.GetLevelData()
        }
    }

    public IEnumerator Test()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://api.pokeafk.onlineapi/users/info/" + SystemInfo.deviceUniqueIdentifier))
        {
            Debug.Log($"domain: {"https://api.pokeafk.online/api/users/info/" + SystemInfo.deviceUniqueIdentifier}");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Lỗi khi gọi API: " + www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log("Phản hồi từ server: " + responseText);
                try
                {
                    Debug.Log(responseText);
                    /*BankAllResponse bankResponse = JsonConvert.DeserializeObject<BankAllResponse>(responseText);

                    if (bankResponse != null && bankResponse.data != null)
                    {
                        DataStore.Instance.SetBankAll(bankResponse.data);

                        listBankAll.ClearOptions();


                        List<TMP_Dropdown.OptionData> newOptions = new List<TMP_Dropdown.OptionData>();

                        foreach (var bank in bankResponse.data)
                        {
                            newOptions.Add(new TMP_Dropdown.OptionData(bank.shortName));
                        }

                        listBankAll.AddOptions(newOptions);

                        listBank.value = 1;
                        listBank.RefreshShownValue();
                        OnBankSelectedAll(0);

                        Debug.Log($"Số lượng ngân hàng: {bankResponse.data.Count}");
                    }
                    else
                    {
                        Debug.LogError("Không thể parse dữ liệu ngân hàng.");
                    }*/
                }
                catch (JsonException e)
                {
                    Debug.LogError($"Lỗi khi parse JSON: {e.Message}");
                }
            }
        }
    }
    #endregion

    #region Main game flow
    public void OnClickReadyBtn()
    {
        startScreen.SetActive(false);
        chooseModeScreen.SetActive(true);
        levelScreen.SetActive(false);
    }

    public void AdventureMode()
    {
        DataConfig.IsArcadeMode = false;
        startScreen.SetActive(false);
        chooseModeScreen.SetActive(false);
        //LoadLv(_lastSelectedChapter);
        chapterDropdown.value = _curChap - 1;
        if (_curChap == 1)
        {
            LoadLv(1);
        }
    }

    public void ArcadeMode()
    {
        if (PlayerPrefs.GetInt(DataConfig.LIFE, DataConfig.DEFAULTLIFE) > 0)
        {
            PlayerPrefs.SetInt(DataConfig.LIFE, PlayerPrefs.GetInt(DataConfig.LIFE, DataConfig.DEFAULTLIFE) - 1);
            DataConfig.SelectedChap = Random.Range(1, 3);
            DataConfig.SelectedLv = Random.Range(49, 100);
            DataConfig.IsArcadeMode = true;
            DataConfig.Streak = 0;
            SceneManager.LoadScene(DataConfig.MAINSCENE);
        }
    }

    /*public void OnDropdownValueChange(TMP_Dropdown dropdown)
    {
        LoadLv(dropdown.value + 1);
    }*/

    public void LoadLv(int chapter)
    {
        //set chapter selected for spawn level in game
        DataConfig.SelectedChap = chapter;
        int curLv = PlayerPrefs.GetInt(DataConfig.CURRENTLV + chapter, 0);

        //remove all level button have in lvsContentParent to spawn new buttons
        foreach(GameObject child in _lvBtnLst)
        {
            Destroy(child);
        }
        _lvBtnLst.Clear();

        //spawn level buttons
        for (int i = 0; i < 100; i++)
        {
            GameObject lv = Instantiate(lvPrefab, lvsContentParent.transform);
            _lvBtnLst.Add(lv);
            bool isPlayed = (chapter <= _curChap && i <= curLv) ? true : false;
            //int star = PlayerPrefs.GetInt(DataConfig.LV + chapter + i, 0);
            //lv.GetComponent<ButtonLvCtrl>().Init(isPlayed, i + 1, star, )
            if (isPlayed)
            {
                PlayedLvDatas datas = new PlayedLvDatas();
                //string path = Application.dataPath + "/Resources/" + DataConfig.PLAYEDDATAPATH + chapter + ".json";
                TextAsset json = Resources.Load<TextAsset>(DataConfig.PLAYEDDATAPATH + chapter);
                if (json != null)
                {
                    string jsonString = json.text;
                    datas = JsonUtility.FromJson<PlayedLvDatas>(jsonString);
                    if (i < datas.Datas.Count - 1)
                    {
                        bool isfirstPlay = datas.Datas[i].Numbertries <= 1 && datas.Datas[i].IsPlayed;
                        lv.GetComponent<ButtonLvCtrl>().Init(isPlayed, i + 1, datas.Datas[i].Star, isfirstPlay);
                    } else
                    {
                        lv.GetComponent<ButtonLvCtrl>().Init(isPlayed, i + 1, 0, false);
                    }
                }
                else
                {
                    lv.GetComponent<ButtonLvCtrl>().Init(isPlayed, i + 1, 0, false);
                    Debug.LogError("Failed to load JSON file");
                }
            } else
            {
                lv.GetComponent<ButtonLvCtrl>().Init(isPlayed, i + 1, 0, false);
            }
        }
        levelScreen.SetActive(true);
    }

    public void ChooseModeScreenBackBtn()
    {
        startScreen.SetActive(true);
        chooseModeScreen.SetActive(false);
        levelScreen.SetActive(false);
    }

    public void ShowNotEnoughLifePopup()
    {
        notEnoughLifePopup.SetActive(true);
    }
    #endregion

    #region Bottom button
    public void OpenLeaderBoard()
    {
        startScreen.SetActive(false);
        chooseModeScreen.SetActive(false);
        levelScreen.SetActive(false);
        topIcons.SetActive(false);

        //load data
        LoadDataLeaderBoard(CATEGORY.STAR);

        //show leaderboard
        leaderboard.SetActive(true);
    }
    #endregion

    #region Leaderboard
    public void LoadDataLeaderBoard(CATEGORY category)
    {
        switch (category)
        {
            case CATEGORY.STAR:
                DataPlayerNation(CLASSIFY.PLAYER);
                break;
            case CATEGORY.FIRSTTRY:
                break;
            case CATEGORY.BESTSTREAK:
                break;
        }
    }

    public void DataPlayerNation(CLASSIFY classify)
    {
        switch (classify)
        {
            case CLASSIFY.PLAYER:
                break;
            case CLASSIFY.NATION:
                break;
        }
    }
    #endregion

    #region Shop
    //swipe shop
    public void Next()
    {
        if (_currentPage < maxPage)
        {
            _currentPage++;
            _targetPos += pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (_currentPage > 1)
        {
            _currentPage--;
            _targetPos -= pageStep;
            MovePage();
        }
    }

    public void MovePage()
    {
        shopPagesRect.LeanMoveLocal(_targetPos, tweenTime).setEase(tweenType);
    }

    //Load Shop Data

    #endregion
}

public enum CATEGORY
{
    STAR = 0,
    FIRSTTRY = 1,
    BESTSTREAK = 2
}

public enum CLASSIFY
{
    PLAYER = 0,
    NATION = 1
}

[System.Serializable]
public class PlayedLvData
{
    public int Star;
    public int Numbertries;
    public bool IsPlayed; //đã chơi qua lv

    public PlayedLvData()
    {
        
    }

    public PlayedLvData(int star, int numbertries, bool isPlayed)
    {
        Star = star;
        Numbertries = numbertries;
        this.IsPlayed = isPlayed;
    }
}

[System.Serializable]
public class PlayedLvDatas
{
    public List<PlayedLvData> Datas = new List<PlayedLvData>();

    public PlayedLvDatas()
    {
        
    }
}
