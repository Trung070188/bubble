using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadShop : MonoBehaviour
{
    [SerializeField]
    private ShopItemType type;

    [SerializeField]
    private GameObject shopItemPrefab;

    [SerializeField]
    private Transform itemParent;

    private void LoadItemShop()
    {
        //get data from server


        //set data for ui
        foreach (ShopItemData data in MenuCtrl.Instance.ShopItemSOs[(int)type].ItemDatas) 
        {
            GameObject item = Instantiate(shopItemPrefab, itemParent);
            item.GetComponent<ShopItemCtrl>().Init(data.ItemImg, data.ItemPrice, false);
        }
    }
}

public enum ShopItemType
{
    GLASS,
    GLOVES,
    SKIN,
    BOOTS
}
