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
    public int Id;
    //public BodyPositionEnum BodyPosition;
    public int head;
    public int arms;
    public int legs;
    public int body;
    public readonly int user_id;
}

public enum BodyPositionEnum
{
    GLASS = 0,
    GLOVES,
    BODY,
    BOOTS
}
