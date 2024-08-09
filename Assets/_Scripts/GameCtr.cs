using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtr : Singleton<GameCtr>
{
  public int numberClick = 0;
    [Header("Core Game")]
    [SerializeField]
    private Transform bubbleParent;

    [Space(10)]
    [Header("Win & Lose")]
    [SerializeField]
    private GameObject winPopup;

    private float _delayShowPopup = 0.5f;
 
  void Update()
    {
        if(Input.GetMouseButtonDown(0) && numberClick > 0)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseWorldPosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition2D, Vector2.zero);

        
            if (hit.collider != null)
            {
                //update number click
                numberClick -= 1;
                UICtr.instance.NumberClick.text = numberClick.ToString();

                //progess boom
                var collider = hit.collider.transform.GetComponent<BubbleObject>();
                if(collider.BubbleId == 4 && !collider.isClick)
                {
                    collider.isClick = true;
                    collider.InitParticle();
                    collider.gameObject.SetActive(false);
                    
                }
                else{
                    collider.SetBubble();
                }

                if (bubbleParent.childCount == 0)
                {
                    //update data & show win popup
                } else if (bubbleParent.childCount > 0 && numberClick == 0)
                {
                    //show lose popup
                    Invoke(nameof(ShowLosePopup), _delayShowPopup);
                }
            }

        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(DataConfig.MAINSCENE);
        }
    }

    #region Win & Lsoe
    public void ShowWinPopup()
    {

    }

    public void ShowLosePopup()
    {

    }
    #endregion

    #region Button Event
    public void OnClickLvBtn()
    {
        DataConfig.ReturnFromGame = true;
    }

    public void OnClickReplay()
    {
        SceneManager.LoadScene(DataConfig.MAINSCENE);
    }

    public void OnClickNextBtn()
    {

    }

    public void OnClickSkipBtn()
    {

    }
    #endregion
}
