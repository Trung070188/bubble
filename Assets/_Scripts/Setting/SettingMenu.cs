using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [Header("Space between memu item")]
    [SerializeField]
    private Vector2 spacing;

    private Button _settingBtn;

    private SettingMenuItem[] _menuItems;

    private bool _isExpanded = false;

    private int _itemsCount;

    private Vector2 _settingBtnPos;

    [Space(10)]
    [Header("Setting button rotation")]
    [SerializeField]
    private float rotationDuration;

    [SerializeField]
    private Ease rotationEase;

    [Space(10)]
    [Header("Animation")]
    [SerializeField]
    private float expandDuration;
    
    [SerializeField]
    private float collapseDuration;

    [SerializeField]
    private Ease expandEase;

    [SerializeField]
    private Ease collapseEase;

    [Space(10)]
    [Header("Fading")]
    [SerializeField]
    private float expandFadeDuration;

    [SerializeField]
    private float collapseFadeDuration;

    // Start is called before the first frame update
    void Start()
    {
        _itemsCount = transform.childCount - 1; //-1 because dont count setting button
        _menuItems = new SettingMenuItem[_itemsCount];
        for (int i = 0; i < _itemsCount; i++)
        {
            _menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingMenuItem>(); //i + 1 to ignore the setting button which is child 0
        }

        _settingBtn = transform.GetChild(0).GetComponent<Button>();
        _settingBtn.onClick.AddListener(ToggleMenu);
        _settingBtn.transform.SetAsLastSibling(); //to make sure the setting button will be always at the top layer.

        _settingBtnPos = _settingBtn.transform.localPosition;

        //reset all menu items position to _settingBtnPos
        ResetPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetPos()
    {
        for (int i = 0; i < _itemsCount; i++)
        {
            _menuItems[i].trans.localPosition = _settingBtnPos;
        }
    }

    private void ToggleMenu()
    {
        _isExpanded = !_isExpanded;

        if (_isExpanded )
        {
            //menu opened
            for (int i = 0; i < _itemsCount; i++)
            {
                //_menuItems[i].trans.localPosition = _settingBtnPos + spacing * (i + 1); //use i + 1 to avoid multiplying by zero
                _menuItems[i].trans.DOLocalMove(_settingBtnPos + spacing * (i + 1), expandDuration).SetEase(expandEase);
                _menuItems[i].img.DOFade(1, expandFadeDuration).From(0);
            }
        } else
        {
            for (int i = 0; i < _itemsCount; i++)
            {
                //_menuItems[i].trans.localPosition = _settingBtnPos;
                _menuItems[i].trans.DOLocalMove(_settingBtnPos, collapseDuration).SetEase(collapseEase);
                _menuItems[i].img.DOFade(0, collapseFadeDuration);
            }
        }

        //rotate
        _settingBtn.transform.DORotate(Vector3.forward * 180f, rotationDuration).From(Vector3.zero).SetEase(rotationEase); //rotate around Z axis 180 degree
    }

    //remove event listeners to avoid memory leaks
    private void OnDestroy()
    {
        _settingBtn.onClick.RemoveListener(ToggleMenu);
    }
}
