using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtr : Singleton<GameCtr>
{
  public int numberClick = 0;
    [Header("Core Game")]
    [SerializeField]
    private Transform bubbleParent;

    [SerializeField]
    private GameObject adventureMode;

    [SerializeField]
    private GameObject arcadeMode;

    public GameObject bubble4;
    public GameObject bubble1;
    public GameObject bubble2;
    public GameObject bubble3;
    public GameObject listBubble;
    public List<BubbleObject> bubbles;

    private PlayedLvDatas _datas = new PlayedLvDatas();
    string path;

    //private int _lv = 0;

    [Space(10)]
    [Header("Win & Lose")]
    [SerializeField]
    private GameObject winPopup;

    private float _delayShowPopup = 0.5f;

    [System.Serializable]
    public class Bubble
    {
        public int x;
        public int y;
        public int st;
    }

    [System.Serializable]
    public class Level
    {
        public int presses;
        public List<Bubble> bubbles;
    }

    [System.Serializable]
    public class LevelPack
    {
        public List<Level> levels;
    }

    void Awake()
    {
        path = Application.dataPath + "/Resources/" + DataConfig.PLAYEDDATAPATH + DataConfig.SelectedChap + ".json";

        string json = File.ReadAllText(path);

        if (!DataConfig.IsArcadeMode)
        {
            //init lv data
            if (json != null)
            {
                _datas = JsonUtility.FromJson<PlayedLvDatas>(json);

                //chưa có lv trong list
                if (DataConfig.SelectedLv >= PlayerPrefs.GetInt(DataConfig.CURRENTLV + DataConfig.SelectedChap, 0) && DataConfig.SelectedLv >= _datas.Datas.Count - 1)
                {
                    PlayedLvData data = new PlayedLvData(0, 1, false);
                    _datas.Datas.Add(data);
                }
                //Đã có lv trong list
                else
                {
                    if (!_datas.Datas[DataConfig.SelectedLv].IsPlayed)
                    {
                        _datas.Datas[DataConfig.SelectedLv].Numbertries++;
                    }
                }

                json = JsonUtility.ToJson(_datas);
                File.WriteAllText(path, json);
            }
            else
            {
                Debug.Log("main json");
            }
        }

        TextAsset jsonFile = Resources.Load<TextAsset>(DataConfig.SelectedChap.ToString());

        if (jsonFile != null)
        {
            string jsonString = jsonFile.text;
            LevelPack levelPack = JsonUtility.FromJson<LevelPack>(jsonString);
            GameCtr.instance.numberClick = levelPack.levels[DataConfig.SelectedLv].presses;
            for (int i = levelPack.levels[DataConfig.SelectedLv].bubbles.Count - 1; i >= 0; i--)
            {
                var lv = levelPack.levels[DataConfig.SelectedLv].bubbles[i];
                Vector3 position = ConvertPositionToUnity(lv.x, lv.y);
                CreateBubble(position, lv.st);
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && numberClick > 0)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseWorldPosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition2D, Vector2.zero);


            if (hit.collider != null)
            {
                //update number click
                numberClick -= 1;
                UICtr.instance.NumberClick.text = numberClick.ToString();

                //progess boom
                var collider = hit.collider.transform.GetComponent<BubbleObject>();
                if (collider.BubbleId == 4 && !collider.isClick)
                {
                    collider.isClick = true;
                    collider.InitParticle();
                    collider.gameObject.SetActive(false);
                }
                else
                {
                    collider.SetBubble();
                }

                if (bubbleParent.childCount == 0)
                {
                    if (!DataConfig.IsArcadeMode)
                    {
                        //update data
                        _datas.Datas[DataConfig.SelectedLv].IsPlayed = true;
                        _datas.Datas[DataConfig.SelectedLv].Star = numberClick + 1;

                        string json = JsonUtility.ToJson(_datas);
                        File.WriteAllText(path, json);

                        //save total star
                        PlayerPrefs.SetInt(DataConfig.TOTALSTAR, PlayerPrefs.GetInt(DataConfig.TOTALSTAR, 0) + numberClick + 1);

                        //Chưa đạt tới level cao nhất của chap hiện tại
                        if (DataConfig.SelectedLv + 1 < 99)
                        {
                            if (DataConfig.SelectedLv + 1 > PlayerPrefs.GetInt(DataConfig.CURRENTLV + DataConfig.SelectedChap, 0))
                            {
                                PlayerPrefs.SetInt(DataConfig.CURRENTLV + DataConfig.SelectedChap, DataConfig.SelectedLv + 1);
                            }
                        }
                        //Đạt tới lv cao nhất của chap hiện tại, chap hiện tại chưa phải chap cuối
                        else if (DataConfig.SelectedLv + 1 >= 99 && PlayerPrefs.GetInt(DataConfig.CURRENTCHAPTER, 1) + 1 <= DataConfig.MAXCHAP)
                        {
                            if (DataConfig.SelectedChap + 1 > PlayerPrefs.GetInt(DataConfig.CURRENTCHAPTER, 1))
                            {
                                PlayerPrefs.SetInt(DataConfig.CURRENTCHAPTER, DataConfig.SelectedChap);
                                PlayerPrefs.SetInt(DataConfig.CURRENTLV + DataConfig.SelectedChap, 0);
                            }
                        }

                        //show win popup
                        Invoke(nameof(ShowWinPopup), _delayShowPopup);
                    } else
                    {
                        Invoke(nameof(ShowWinArcadePopup), _delayShowPopup);
                    }
                }
                else if (bubbleParent.childCount > 0 && numberClick == 0)
                {
                    //show lose popup
                    Invoke(nameof(ShowLosePopup), _delayShowPopup);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(DataConfig.MAINSCENE);
        }
    }

    #region Create LV
    private void CreateBubble(Vector3 position, int state)
    {
        GameObject bubble;
        switch (state)
        {
            case 1:
                bubble = Instantiate(bubble1, position, Quaternion.identity, bubbleParent);
                break;
            case 2:
                bubble = Instantiate(bubble2, position, Quaternion.identity, bubbleParent);
                break;
            case 3:
                bubble = Instantiate(bubble3, position, Quaternion.identity, bubbleParent);
                break;
            case 4:
                bubble = Instantiate(bubble4, position, Quaternion.identity, bubbleParent);
                break;
            default:
                bubble = Instantiate(bubble4, position, Quaternion.identity, bubbleParent);
                break;
        }

    }
    private Vector3 ConvertPositionToUnity(int x, int y)
    {
        float scaledX = 32 + 64 * (x - 0.85f);
        float scaledY = 64 + 64 * (6 - y);

        float unityX = (scaledX / 352) * Screen.width;
        float unityY = (scaledY / 480) * Screen.height;

        return Camera.main.ScreenToWorldPoint(new Vector3(unityX, unityY, Camera.main.nearClipPlane));
    }
    #endregion

    #region Win & Lsoe
    public void ShowWinPopup()
    {
        //turn of interact of next btn if reach lv 100 of chapter 2
        
    }

    public void ShowLosePopup()
    {
        //turn of interact of skip btn if reach lv 100 of chapter 2
    }

    public void ShowWinArcadePopup()
    {

    }

    public void ShowLoseArcadePopup()
    {

    }
    #endregion

    #region Button Event
    public void OnClickLvBtn()
    {
        DataConfig.ReturnFromGame = true;
        SceneManager.LoadScene(DataConfig.MENUSCENE);
    }

    public void OnClickReplay()
    {
        if (PlayerPrefs.GetInt(DataConfig.LIFE, DataConfig.DEFAULTLIFE) > 0)
        {
            PlayerPrefs.SetInt(DataConfig.LIFE, PlayerPrefs.GetInt(DataConfig.LIFE, DataConfig.DEFAULTLIFE) - 1);
            SceneManager.LoadScene(DataConfig.MAINSCENE);
        }
    }

    public void OnClickNextBtn()
    {
        if (!DataConfig.IsArcadeMode)
        {
            if (DataConfig.SelectedLv >= 99)
            {
                DataConfig.SelectedChap++;
                DataConfig.SelectedLv = 0;
            }
            else
            {
                DataConfig.SelectedLv++;
            }
        } else
        {
            DataConfig.SelectedChap = Random.Range(1, 3);
            DataConfig.SelectedLv = Random.Range(49, 100);
            DataConfig.Streak++;
            if (DataConfig.Streak > PlayerPrefs.GetInt(DataConfig.BESTSTREAK, 0))
            {
                PlayerPrefs.SetInt(DataConfig.BESTSTREAK, DataConfig.Streak);
            }
        }
        SceneManager.LoadScene(DataConfig.MAINSCENE);
    }

    public void OnClickSkipBtn()
    {
        //reward ads
        
    }
    #endregion
}
