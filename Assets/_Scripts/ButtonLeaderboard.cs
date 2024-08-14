using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLeaderboard : MonoBehaviour
{
    [SerializeField]
    private GameObject reward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        reward.SetActive(true);
    }
}
