using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class EquipmentInfo
{
    public int ItemId;
    public BodyPositionEnum BodyPosition;
}

public enum BodyPositionEnum
{
    GLASS = 0,
    GLOVES,
    BODY,
    BOOTS
}
