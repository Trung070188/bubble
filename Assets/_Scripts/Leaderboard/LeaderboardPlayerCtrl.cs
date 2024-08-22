using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardPlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject playerItemPrefab;

    [SerializeField]
    private GameObject nationItemPrefab;

    [SerializeField]
    private Transform itemParent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        ClearItem();
    }

    public void ClearItem()
    {
        foreach (Transform child in itemParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void LoadDataPlayer()
    {
        
    }
}
