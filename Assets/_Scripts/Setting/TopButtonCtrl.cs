using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopButtonCtrl : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField]
    private Image soundBtnImg;

    [SerializeField]
    private Image musicBtnImg;

    [SerializeField]
    private Image vibrationBtnImg;

    [SerializeField]
    private Sprite soundOn;

    [SerializeField]
    private Sprite soundOff;

    [SerializeField]
    private Sprite musicOn;

    [SerializeField]
    private Sprite musicOff;

    [SerializeField]
    private Sprite vibrationOn;

    [SerializeField]
    private Sprite vibrationOff;

    public static TopButtonCtrl Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitSettingBtns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Setting
    private void InitSettingBtns()
    {
        OnClickSoundBtn();
        OnClickMusicBtn();
        OnClickVibrationBtn();
    }

    public void OnClickSoundBtn()
    {
        if (PlayerPrefs.GetInt(DataConfig.SOUND, 1) == 1)
        {
            //turn off
            soundBtnImg.sprite = soundOff;
            PlayerPrefs.SetInt(DataConfig.SOUND, 0);
        } else if (PlayerPrefs.GetInt(DataConfig.SOUND, 1) == 0)
        {
            //turn on
            soundBtnImg.sprite = soundOn;
            PlayerPrefs.SetInt(DataConfig.SOUND, 1);
        }
    }

    public void OnClickMusicBtn()
    {
        if (PlayerPrefs.GetInt(DataConfig.MUSIC, 1) == 1)
        {
            //turn off
            musicBtnImg.sprite = musicOff;
            PlayerPrefs.SetInt(DataConfig.MUSIC, 0);
        }
        else if (PlayerPrefs.GetInt(DataConfig.MUSIC, 1) == 0)
        {
            //turn on
            musicBtnImg.sprite = musicOn;
            PlayerPrefs.SetInt(DataConfig.MUSIC, 1);
        }
    }

    public void OnClickVibrationBtn()
    {
        if (PlayerPrefs.GetInt(DataConfig.VIBRATION, 1) == 1)
        {
            //turn off
            vibrationBtnImg.sprite = vibrationOff;
            PlayerPrefs.SetInt(DataConfig.VIBRATION, 0);
        }
        else if (PlayerPrefs.GetInt(DataConfig.VIBRATION, 1) == 0)
        {
            //turn on
            vibrationBtnImg.sprite = vibrationOn;
            PlayerPrefs.SetInt(DataConfig.VIBRATION, 1);
        }
    }
    #endregion
}
