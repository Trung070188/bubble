using System.Collections;
using System.Collections.Generic;
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
        startScreen.SetActive(true);
        chooseModeScreen.SetActive(false);
        levelScreen.SetActive(false);
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
        LoadLv(_lastSelectedChapter);
    }

    public void LoadLv(int chapter)
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject lv = Instantiate(lvPrefab, lvsContentParent.transform);
            bool isPlayed = (chapter <= _curChap && i <= _curLv) ? true : false;
            int star = PlayerPrefs.GetInt(DataConfig.LV + chapter + i, 0);
            //lv.GetComponent<ButtonLvCtrl>().Init(isPlayed, i + 1, star, )
        }
    }
}
