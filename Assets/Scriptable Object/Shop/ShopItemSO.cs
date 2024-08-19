using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "Scriptable Object/Shop Item")]
public class ShopItemSO : ScriptableObject
{
    public List<ShopItemData> ItemDatas = new List<ShopItemData>();
}

[Serializable]
public class ShopItemData
{
    public int Id;
    public Sprite ItemImg;
    public int ItemPrice;
}
