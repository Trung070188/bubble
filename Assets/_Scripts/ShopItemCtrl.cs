using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemCtrl : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private GameObject selected;

    [SerializeField]
    private TextMeshProUGUI priceTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Sprite iconSprite, int price, bool isUse)
    {
        icon.sprite = iconSprite;
        priceTxt.text = price.ToString();
        if (isUse) selected.SetActive(true);
        else selected.SetActive(false);
    }
}
