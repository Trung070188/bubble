using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtr : Singleton<UICtr>
{
    public Text NumberClick;
    private void Awake() {


    }
    void Start()
    {
        NumberClick.text = GameCtr.instance.numberClick.ToString();

    }

    void Update()
    {
        
    }
}
