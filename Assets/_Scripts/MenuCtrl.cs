using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MenuCtrl : MonoBehaviour
{
    [Header("Screen")]
    [SerializeField]
    private GameObject startScreen;

    [SerializeField]
    private GameObject chooseModeScreen;

    [SerializeField]
    private GameObject levelScreen;

    [Space(10)]
    [Header("Select Level")]
    [SerializeField]
    private GameObject lvPrefab;

    [SerializeField]
    private GameObject lvsContentParent;

    [SerializeField]
    private TMP_Dropdown chapterDropdown;

    public Sprite PlayedSprite;

    public Sprite NotPlaySprite;

    private int _curLv = 0;
    private int _curChap = 0;
    private int _lastSelectedChapter = 0;

    //Singleton
    public static MenuCtrl Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _curLv = PlayerPrefs.GetInt(DataConfig.CURRENTLV, 0);
        _curChap = PlayerPrefs.GetInt(DataConfig.CURRENTCHAPTER, 1);
        _lastSelectedChapter = PlayerPrefs.GetInt(DataConfig.LASTSELECTCHAPTER, 1);
        if (!DataConfig.ReturnFromGame)
        {
            ChooseModeScreenBackBtn();
        }
        else
        {
            AdventureMode();
        }

        chapterDropdown.onValueChanged.AddListener(LoadLv);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickReadyBtn()
    {
        startScreen.SetActive(false);
        chooseModeScreen.SetActive(true);
        levelScreen.SetActive(false);
    }

    public void AdventureMode()
    {
        startScreen.SetActive(false);
        chooseModeScreen.SetActive(false);
        //LoadLv(_lastSelectedChapter);
        chapterDropdown.value = _lastSelectedChapter - 1;
        if (_lastSelectedChapter == 1)
        {
            LoadLv(0);
        }
    }

    public void LoadLv(int chapter)
    {
        foreach (Transform child in lvsContentParent.transform)
        {
            Destroy(child);
        }
        for (int i = 0; i < 100; i++)
        {
            GameObject lv = Instantiate(lvPrefab, lvsContentParent.transform);
            bool isPlayed = ((chapter + 1) <= _curChap && i <= _curLv) ? true : false;
            //int star = PlayerPrefs.GetInt(DataConfig.LV + chapter + i, 0);
            //lv.GetComponent<ButtonLvCtrl>().Init(isPlayed, i + 1, star, )
            if (isPlayed)
            {
                PlayedLvDatas datas = new PlayedLvDatas();
                //string path = Application.dataPath + "/Resources/" + DataConfig.PLAYEDDATAPATH + chapter + ".json";
                TextAsset json = Resources.Load<TextAsset>(DataConfig.PLAYEDDATAPATH + (chapter + 1));
                if (json != null)
                {
                    string jsonString = json.text;
                    datas = JsonUtility.FromJson<PlayedLvDatas>(jsonString);
                    lv.GetComponent<ButtonLvCtrl>().Init(isPlayed, i + 1, datas.Datas[i].Star, datas.Datas[i].IsFirstPlay);
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
}

public class PlayedLvData
{
    public int Star;
    public bool IsFirstPlay;

    public PlayedLvData()
    {
        
    }

    public PlayedLvData(int star, bool isFirstPlay)
    {
        Star = star;
        IsFirstPlay = isFirstPlay;
    }
}

public class PlayedLvDatas
{
    public List<PlayedLvData> Datas;
}
