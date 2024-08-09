using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLvCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject levelTxtG;

    [SerializeField]
    private GameObject crown;

    [SerializeField]
    private GameObject star;

    private int _lv = 0;

    public void Init(bool isPlayed, int lv, int starNum, bool isFirstPlay) 
    {
        _lv = lv - 1;
        if (isPlayed)
        {
            gameObject.GetComponent<Image>().sprite = MenuCtrl.Instance.PlayedSprite;
            levelTxtG.GetComponent<TextMeshProUGUI>().text = lv.ToString();
            levelTxtG.SetActive(true);
            if (isFirstPlay)
            {
                crown.SetActive(true);
            }
            if (starNum > 0)
            {
                for (int i = 0; i < starNum; i++)
                {
                    star.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        } else
        {
            gameObject.GetComponent<Image>().sprite = MenuCtrl.Instance.NotPlaySprite;
        }
    }

    public void OnClickBtnLevel()
    {
        DataConfig.SelectedLv = _lv;
    }
}
