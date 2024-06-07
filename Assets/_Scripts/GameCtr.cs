using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtr : Singleton<GameCtr>
{
  public int numberClick = 0;
 
  void Update()
    {
        if(Input.GetMouseButtonDown(0) && numberClick > 0)
        {
            numberClick -= 1;
            UICtr.instance.NumberClick.text =  numberClick.ToString();

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseWorldPosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition2D, Vector2.zero);

        
            if (hit.collider != null)
            {
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
            }

        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(0);
        }
    }
}
